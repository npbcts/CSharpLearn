## C# 自我初学笔记 第N章  

来源于: 根据[ 取消任务列表 (C#) ](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/async/cancel-an-async-task-or-a-list-of-tasks)整理。


如果不想等待异步控制台应用程序完成，可以取消该应用程序。 通过遵循本主题中的示例，可将取消添加到下载网站内容的应用程序。 可通过将 `CancellationTokenSource` 实例与每个任务进行关联来取消多个任务。 如果选择 `Enter` 键(可以根据取消任务的线程函数设置判断条件)，则将取消所有尚未完成的任务。

建立可取消的异步任务需要 **.NET 5 或更高版本的 SDK**

下面是编写支持取消的异步应用程序和演示发出取消信号的例子。

### 一个包含取消命令的网络下载命令行程序

添加声明
```c#
using System.Diagnostics;
using System.Net.Http;
using System.Threading;  //  CancellationTokenSource
using System.Threading.Tasks;  //  Task

```

创建网络服务实例`HttpClient`和 取消下载类`CancellationTokenSource`实例。在类中定义，可以直接被方法使用。
```c#
static readonly CancellationTokenSource s_cts = new CancellationTokenSource();

static readonly HttpClient s_client = new HttpClient
{
    MaxResponseContentBufferSize = 1_000_000
};

static readonly IEnumerable<string> s_urlList = new string[]
{
    "https://learn.microsoft.com",
    "https://learn.microsoft.com/aspnet/core",
    "https://learn.microsoft.com/azure",
    "https://learn.microsoft.com/azure/devops",
    "https://learn.microsoft.com/dotnet",
    "https://learn.microsoft.com/dynamics365",
    "https://learn.microsoft.com/education",
    "https://learn.microsoft.com/enterprise-mobility-security",
    "https://learn.microsoft.com/gaming",
    "https://learn.microsoft.com/graph",
    "https://learn.microsoft.com/microsoft-365",
    "https://learn.microsoft.com/office",
    "https://learn.microsoft.com/powershell",
    "https://learn.microsoft.com/sql",
    "https://learn.microsoft.com/surface",
    "https://learn.microsoft.com/system-center",
    "https://learn.microsoft.com/visualstudio",
    "https://learn.microsoft.com/windows",
    "https://learn.microsoft.com/xamarin"
};

```
`CancellationTokenSource` 用于向 `CancellationToken` 发出请求取消的信号。 `HttpClient` 公开发送 `HTTP` 请求和接收 `HTTP` 响应的能力。 `s_urlList` 包括应用程序计划处理的所有 `URL`。


更新应用程序入口点

```c#
static async Task Main()
{
    Console.WriteLine("Application started.");
    Console.WriteLine("Press the ENTER key to cancel...\n");

    Task cancelTask = Task.Run(() =>
    {
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            Console.WriteLine("Press the ENTER key to cancel...");
        }

        Console.WriteLine("\nENTER key pressed: cancelling downloads.\n");
        s_cts.Cancel();
    });

    Task sumPageSizesTask = SumPageSizesAsync();

    await Task.WhenAny(new[] { cancelTask, sumPageSizesTask });

    Console.WriteLine("Application ending.");
}

```
目前将已更新的 `Main` 方法视为异步 `main` 方法，这允许将异步入口点引入可执行文件中。 

- 将几条说明性消息写入控制台，
- 然后声明名为 `cancelTask` 的 `Task` 实例，这将读取控制台密钥笔画。 如果按 `Enter`，则会调用 `CancellationTokenSource.Cancel()`。 这将发出取消信号。 
- 下一步，从 `SumPageSizesAsync` 方法分配 `sumPageSizesTask` 变量。 
- 然后，将这两个任务传递到 Task.WhenAny(Task[])，这会在完成两个任务中的任意一个时继续。即此时 `await Task.WhenAny(new[] { cancelTask, sumPageSizesTask });` 中的 `await` 等待观测两个异步线程任务，`cancelTask`和`sumPageSizesTask`。

> 任何其中一个完成后，即可完成等待，继续进行同步任务。即如果`cancelTask`提前完成(在发出取消信号时)，`sumPageSizesTask`任务进行一部分也不再继续观察结果，结束异步线程，继续程序中的下一步任务。(由于存在ConfigAwait,结束异步线程可能返回原线程，也可能返回新线程执行下一步任务)。注意到此只是不再`sumPageSizesTask`接受异步返回的内容，如果实质停止`sumPageSizesTask`任务，还需要向异步进程中传 `CancellationToken` 参数发出请求取消的信号。


创建获取页面大小的方法 `SumPageSizesAsync`
```c#
static async Task SumPageSizesAsync()
{
    var stopwatch = Stopwatch.StartNew();

    int total = 0;
    foreach (string url in s_urlList)
    {
        int contentLength = await ProcessUrlAsync(url, s_client, s_cts.Token);
        total += contentLength;
    }

    stopwatch.Stop();

    Console.WriteLine($"\nTotal bytes returned:  {total:#,#}");
    Console.WriteLine($"Elapsed time:          {stopwatch.Elapsed}\n");
}
```

 `SumPageSizesAsync` 依赖的底层下载方法
```c#
static async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
{
    HttpResponseMessage response = await client.GetAsync(url, token);
    byte[] content = await response.Content.ReadAsByteArrayAsync(token);
    Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

    return content.Length;
}
```
对于任何给定的 `URL`，该方法都将使用提供的 `client` 实例以 `byte[]` 形式来获取响应。 `CancellationToken` 实例会传递到 `HttpClient.GetAsync(String, CancellationToken)` 和 `HttpContent.ReadAsByteArrayAsync()` 方法中。 `token` 用于注册请求取消。 将 `URL` 和长度写入控制台后会返回该长度。
因此在此处，取消任务的信息最终接收方是作为 `.Net` `API`的 `HttpClient.GetAsync(String, CancellationToken)` 和 `HttpContent.ReadAsByteArrayAsync()` 方法。



### 示例应用程序输出

```bash
Application started.
Press the ENTER key to cancel...

https://learn.microsoft.com                                       37,357
https://learn.microsoft.com/aspnet/core                           85,589
https://learn.microsoft.com/azure                                398,939
https://learn.microsoft.com/azure/devops                          73,663
https://learn.microsoft.com/dotnet                                67,452
https://learn.microsoft.com/dynamics365                           48,582
https://learn.microsoft.com/education                             22,924

ENTER key pressed: cancelling downloads.

Application ending.
```



(End)