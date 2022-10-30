## C# 自我初学笔记 第一单元  编写第一个csharp代码

- 来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-write-first/),微软推出的初学者教程整理。

- 练习环境: 在线网页版 .NET 编辑器


### 学习目标
通过学习本章，你将能够：

- 编写第一批 C# 代码
- 使用两种不同的技术将消息打印到文本控制台
- 识别运算符、类和方法等不同 C# 语法元素

### 练习 -“Hello World!”

```c#
Console.WriteLine("Hello World!");
```
输出  
```
Hello World!
```  
注意, 在线网页版.NET编辑器,没有初始化类，引入空间名等步骤。

### 注释
为代码行添加两根正斜杠 `// `的前缀，即可创建代码注释。 这会指示编译器忽略该行的所有指令。 用途:  
- 当你尚未准备好删除代码，但希望暂时忽略它时，代码注释很有用。   
- 还可使用代码注释为自己添加消息，提醒自己代码的功能。  


### 消息打印到输出控制台

`Console.WriteLine()`: 在行的末尾，它添加了一个换行符。
`Console.Write()`: 在结尾处不添加换行符，即所有打印内容都在一行。

### 代码是如何工作的？

- `Console` 部分称为“类”。 类“拥有”方法，或者更好的说法是方法存在于类中。
- `WriteLine()` 部分称为“方法”。 WriteLine() 方法的作用是向输出窗口编写一行数据。 打印的数据作为输入参数在左括号和右括号之间发送。 部分方法需要输入参数，而其他方法则不需要。 但是，如果要调用方法，则必须始终在方法名称后使用括号。 **该括号称为方法调用运算符**。
- 还有一个点 `.`（或句点）将类名 Console 和方法名称 WriteLine() 分隔。 该句点是成员访问运算符。
- 最后，分号`;`是语句运算符的结尾。   
“语句”是 C# 中的完整指令。 分号指示编译器我们已经完成了命令的输入。


### [顶级语句 - 不使用 Main 方法的程序](https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/program-structure/top-level-statements)
以下两种写法等同:

```c#
Console.WriteLine("Hello, World!");
```

```c#
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

```
为什么第一种写法简单到一条语句;而第二种写法包含了c#的很多要素？原因在于从 **C# 9** 开始，无需在控制台应用程序项目中显式包含 Main 方法。 相反，可以使用顶级语句功能最大程度地减少必须编写的代码。 在这种情况下，编译器将为应用程序生成类和 Main 方法入口点。

顶级语句的特点如下:
- 仅能有一个顶级文件: 一个应用程序只能有一个入口点。 一个项目只能有一个包含顶级语句的文件。 
- 没有其他入口点:在具有顶级语句的项目中，不能使用 -main 编译器选项来选择入口点，即使该项目具有一个或多个 Main 方法。
- using 指令: 如果包含 using 指令，则它们必须首先出现在文件中.
    ```c#
    using System.Text;

    StringBuilder builder = new();
    builder.AppendLine("Hello");
    builder.AppendLine("World!");

    Console.WriteLine(builder.ToString());
    ```
- 顶级语句隐式位于全局命名空间中。


### 顶级语句的命名空间和类型定义

具有顶级语句的文件还可以包含命名空间和类型定义，但它们必须位于顶级语句之后。 例如：

```c#
MyClass.TestMethod();
MyNamespace.MyClass.MyMethod();

public class MyClass
{
    public static void TestMethod()
    {
        Console.WriteLine("Hello World!");
    }

}

namespace MyNamespace
{
    class MyClass
    {
        public static void MyMethod()
        {
            Console.WriteLine("Hello World from MyNamespace.MyClass.MyMethod!");
        }
    }
}

```

[顶级语句更详细的文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/proposals/csharp-9.0/top-level-statements)