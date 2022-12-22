using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    //linux平台会出现 Unhandled exception
    static async Task Main()
    {
        Console.WriteLine("程序开始......");
        string cancelText = "按 \"Enter\" 键 取消任务......";
        Console.WriteLine(cancelText);
        Task cancelTask = Task.Run( ()=>
        {
            while(Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine(cancelText);
            }
            Console.WriteLine("已按下回车键，取消任务");
            s_cts.Cancel();
        }
        );

    Task sumPageSizeTask = SumPageSizeAsync();

    await Task.WhenAll(new[] {cancelTask, sumPageSizeTask});

    Console.WriteLine("程序结束......");


    }

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

    static async Task SumPageSizeAsync()
    {
        var stopwatch = Stopwatch.StartNew();

        int total = 0;
        foreach(string url in s_urlList)
        {
            int contentLength = await ProcessUrlAsync(url, s_client, s_cts.Token);
            total += contentLength;
        }

        stopwatch.Stop();
        Console.WriteLine($"\n总共返回页面大小(bytes): {total: #.#}");
        Console.WriteLine($"程序耗费时间:            {stopwatch.Elapsed}\n");
    }


    static async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
    {
        HttpResponseMessage response = await client.GetAsync(url, token);
        byte[] content = await response.Content.ReadAsByteArrayAsync(token);
        Console.WriteLine($"{url, -60} {content.Length,10:#,#}");
        return content.Length;
    }

}

// Unhandled exception. System.Threading.Tasks.TaskCanceledException: The operation was canceled.
//  ---> System.IO.IOException: Unable to read data from the transport connection: Operation canceled.
//  ---> System.Net.Sockets.SocketException (125): Operation canceled
//    --- End of inner exception stack trace ---
//    at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.System.Threading.Tasks.Sources.IValueTaskSource<System.Int32>.GetResult(Int16 token)
//    at System.Net.Security.SslStream.EnsureFullTlsFrameAsync[TIOAdapter](TIOAdapter adapter)
//    at System.Net.Security.SslStream.ReadAsyncInternal[TIOAdapter](TIOAdapter adapter, Memory`1 buffer)
//    at System.Net.Http.HttpConnection.SendAsyncCore(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
//    --- End of inner exception stack trace ---
//    at System.Net.Http.HttpClient.HandleFailure(Exception e, Boolean telemetryStarted, HttpResponseMessage response, CancellationTokenSource cts, CancellationToken cancellationToken, CancellationTokenSource pendingRequestsCts)
//    at System.Net.Http.HttpClient.<SendAsync>g__Core|83_0(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationTokenSource cts, Boolean disposeCts, CancellationTokenSource pendingRequestsCts, CancellationToken originalCancellationToken)
//    at Program.ProcessUrlAsync(String url, HttpClient client, CancellationToken token) in /home/clark/git/CSharpLearn/csharp-cancelTask/Program.cs:line 86
//    at Program.SumPageSizeAsync() in /home/clark/git/CSharpLearn/csharp-cancelTask/Program.cs:line 74
//    at Program.Main() in /home/clark/git/CSharpLearn/csharp-cancelTask/Program.cs:line 30
//    at Program.<Main>()
