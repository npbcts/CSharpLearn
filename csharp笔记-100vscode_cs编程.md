## 使用 Visual Studio Code 创建 .NET 控制台应用程序
来源微软官方教程整理: [教程源地址](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-6-0)

### 先决条件
- 已安装 [C# 扩展](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) 的 Visual Studio Code。 
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)。

### ubuntu22.04安装 `.NET6`

安装 `SDK`
`.NET SDK` 使你可以通过 `.NET` 开发应用。 如果安装 `.NET SDK`，则无需安装相应的运行时。 若要安装 `.NET SDK`，请运行以下命令：

bash命令:
```Bash
sudo apt-get update && \
  sudo apt-get install -y dotnet6
```
安装运行时
通过 `ASP.NET Core` 运行时，可以运行使用 `.NET` 开发且未提供运行时的应用。 以下命令将安装 `ASP.NET Core` 运行时，这是与 `.NET` 最兼容的运行时。 在终端中，运行以下命令：

bash命令:
```Bash
sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-6.0
```
作为 `ASP.NET Core` 运行时的一种替代方法，你可以安装不包含 `ASP.NET Core` 支持的 `.NET` 运行时：将上一命令中的 `aspnetcore-runtime-6.0` 替换为 `dotnet-runtime-6.0`：

bash命令:
```Bash
sudo apt-get install -y dotnet-runtime-6.0
```

### 创建一个名为“HelloWorld”的 .NET 控制台应用项目。

1. 启动 Visual Studio Code。

2. 创建“HelloWorld”文件夹并将其选中。 然后单击“选择文件夹”（在 macOS 上为“打”） 。

默认情况下，文件夹名称将是项目名称和命名空间名称。 稍后将在本教程中添加代码，假定项目命名空间为 HelloWorld。
3. 在主菜单中选择“视图”“终端”，从 Visual Studio Code 中打开“终端”。“终端”在“HelloWorld”文件夹中连同命令提示符一起打开。

在“终端”中输入以下命令：
```bash
dotnet new console --framework net6.0
```
该项目模板通过在 Program.cs 中调用 Console.WriteLine(String) 方法，创建了一个在控制台窗口中显示“Hello World”的简单应用程序。
```c#
Console.WriteLine("Hello, World!");
```

### 运行应用

```bash
dotnet run
```
程序显示“Hello World!”并终止。


(End)