## C# 自我初学笔记 第N章  案例代码编辑的环境



由于不同版本的.NET环境存在差异，同一方法可能在不同版本下是否可用或者使用方法并不相同。

由于.NET已实现了跨系统运行，不同操作系统下对绝大多数C#代码运行不会产生影响。

笔记中示例中代码运行环境如下:

使用`dotnet --info`打印的信息:
```shell
.NET SDK (反映任何 global.json):
 Version:   6.0.110
 Commit:    ce0a42998a

运行时环境:
 OS Name:     ubuntu
 OS Version:  22.04
 OS Platform: Linux
 RID:         ubuntu.22.04-x64
 Base Path:   /usr/lib/dotnet/dotnet6-6.0.110/sdk/6.0.110/

global.json file:
  Not found

Host:
  Version:      6.0.10
  Architecture: x64
  Commit:       5a400c212a

.NET SDKs installed:
  6.0.110 [/usr/lib/dotnet/dotnet6-6.0.110/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 6.0.10 [/usr/lib/dotnet/dotnet6-6.0.110/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 6.0.10 [/usr/lib/dotnet/dotnet6-6.0.110/shared/Microsoft.NETCore.App]

Download .NET:
  https://aka.ms/dotnet-download

Learn about .NET Runtimes and SDKs:
  https://aka.ms/dotnet/runtimes-sdk-info

```

(End)