## C# 自我初学笔记 第N章  代码块和变量范围

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-code-blocks/2-exercise-variable-scope),微软推出的初学者教程整理。


### 代码块和变量范围

代码块是定义执行路径的一个或多个 C# 语句。 通常，代码块外部的语句会影响在运行时执行该代码块的时间、确定性和频率。

此外，**代码块`{}`还会影响变量范围**。

变量范围是指变量对应用程序中其他代码的可见性。 **局部变量只能在定义它的代码块内进行访问**。 如果尝试在代码块外部访问变量，则将出现编译器错误。

一个没有注意变量范围而报错的例子:
```c#
bool flag = true;
if (flag)
{
    int value = 10;
    Console.WriteLine("Inside of code block: " + value);
}
Console.WriteLine($"Outside of code block: {value}");
```
最后一条语句`Console.WriteLine($"Outside of code block: {value}");`错误地使用了`if`代码块中的变量`value`。
报错信息如下:
```
error CS0103: The name 'value' does not exist in the current context
```
### 在不同作用范围下正确使用变量

要从代码块（例如 if 语句的代码块）外部和内部访问变量，需要将**变量声明移动到 if 语句的代码块外部**，以便该变量对所有代码都可见。

可行的例子：

```c#
bool flag = true;
int value = 0;

if (flag)
{
    value = 10;
    Console.WriteLine("Inside of code block: " + value);
}
Console.WriteLine("Outside of code block: " + value);
```
在将变量的位置级别提升后，变量即对`if`下的及其他下一级代码块可见。  
> 这里需要注意的细节是，在**外部声明变量时需要初始赋值**。原因在于，如果不对`value`变量初始赋值而是在`if`语句内，编译器不确定分支是否执行(虽然上段代码`flag = true`但普遍情况下并非都是如此)，因此可能永远不会为该变量`value`分配值，编译器不允许这样做。

### 代码块定义方法、类和命名空间

我们仅使用了代码块来定义 if-elseif-else 和 foreach 语句。 在学习更多的决策和迭代语句时，我们将继续使用它们，但**代码块对于为代码定义更高级别的结构也至关重要**。

一个c#简单但是完整代码的示例：
```c#
using System;

namespace MyNewApp
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
在笔记第一部分各单元中，我们使用微软网页版 .NET 编辑器或Visual Studio Code来撰写C#代码单条或多条类似于`Console.WriteLine("Hello World!");`的语句，这是通过一种[顶级语句](csharp笔记-101第一个cs代码.md#顶级语句---不使用-main-方法的程序)技术实现的，但这样不允许构建真实的应用程序。

如果要在 Visual Studio Code（通过 dotnet 命令行接口或 CLI）或完整版 Visual Studio IDE 中创建新的 C# 控制台应用程序项目，则会生成一个名为 Program.cs 的名称文件，其中包含来自模板的代码(即示例中展示的代码)。

示例中的代码，从上至下(更准确的说从外至内)存在四行代码和三个`{}`代码块，涉及C#语言的最常用的基础概念。

- 代码  
    - `namespace`: 命名空间,包含类的更高级别容器。在命名空间中，我们可以根据程序需要添加不同的类,但命名空间中不能直接包含字段、方法或语句之类的成员。
    - `class`: 类, 方法、属性、事件、字段等成员的容器。一个命名空间中可以根据需要创建多个类。  
    - `static`: 方法,是一个作为执行单元的代码块。注意此处的`static`只是针对本例说明。实际声明方法的关键字有多种。  
    - `Console`语句: 最终程序执行的语句。

- `{}`代码块  
    代码块`{}`: 我们知道，代码块`{}`定义了`if`语句`foreach`语句的执行范围，在这个简单的例子中同样也定义了C#其他结构的执行范围。[代码块和变量范围](#代码块和变量范围)中说明的数据变量作用范围，也能够适用于命名空间`namespace`、类`class`和方法`static`定义的变量的作用范围，有关变量范围和访问权限的规则在`namespace`级别上也是正确的。

    因此在C#中，**代码块定义每个构造的边界, 代码块表示所有权（或包含）关系**。

不同的构造关系命名原则是，构造内部定义的内容不能重名, 但隶属于不同构造的内容就不受限制。可以看到，较大的`.net`类库中不同的命名空间存在同名的方法，但由于命名空间不同，也能够在同一程序中使用。原因在于代码块构造出的不同边界起作用。

### 方法和类的调用

调用规则: 同一代码块的类(或方法)可以使用名称直接调用;超出代码块边界的类(或方法)的调用，需要添加共同的上级名称调用。名称的添加方法使用`.`表示从属关系,即`namespace.class.method`。

一个复杂的调用关系代码示例：

```c#
using System;

namespace MyNewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "Microsoft Learn";

            // 下面是不同的namespace调用方法
            string reversedValue = MyNewApp.Utilities.Utility.Reverse(value);
            Console.WriteLine($"Secret message: {reversedValue}");

            // 下面是同类class中调用方法
            string addValue = AddStr(value);
            Console.WriteLine($"AddStr :{addValue}");

            // 下面是不同类调用
            string judgeResult = JudgeWord.JudgeWordInSentence(value, "Learn");
            Console.WriteLine($"JudgeWorld Class: {judgeResult}");
        }

        static string AddStr(string message)
        {
            message = message + ": change with method AddStr";
            return message;
        }
    }

    class JudgeWord
    {
        public static string JudgeWordInSentence(string message, string theword)
        {
            string containResult = "";
            if (message.Contains(theword))
            {
                containResult = "is";
            }
            else
            {
                containResult = "is not";
            }
            return $"sentence {containResult} contains word {theword}";
        }
    }
}

namespace MyNewApp.Utilities
{
    class Utility
    {
        public static string Reverse(string message)
        {
            char[] letters = message.ToCharArray();
            Array.Reverse(letters);
            return new string(letters);
        }
    }
}
```
> 注意，代码块定义更高级别的结构（例如命名空间、类和方法）的边界，就像它们定义决策和迭代语句的边界一样。 在某些情况下，必须将其他关键字（例如 public 和 using）用于传递到其他代码块的边界。 在创建类时，能够被其他类调用的方法需要使用`public`关键词。

### 使用using语句添加命名空间

示例代码中，调用不同的命名空间方法时的代码需要逐级写出名称`MyNewApp.Utilities.Utility.Reverse`，这使得代码较为繁琐。

一种繁琐的跨命名空间调用方法的示例:
```c#
// 下面是不同的namespace调用方法
string reversedValue = MyNewApp.Utilities.Utility.Reverse(value);
```

一种更好的选择是添加 `using` 语句。 将 `using` 语句添加到代码文件的顶部，该语句解析在文件中使用的类名，指示编译器查看命名空间列表以查找所有类名。

使用`using`跨命名空间调用的示例：

```c#
using MyNewApp.Utilities;
string reversedValue = Utility.Reverse(value);
```

### 简化`if`语句的代码块标记
可以删除`if`语句的代码块标记`{}`，语句的代码即使在一行仍然可以运行。但同时注意使用类似python一样的缩进可以增加代码的可阅读性。
```c#
class JudgeWord
{
    public static string JudgeWordInSentence(string message, string theword)
    {
        string containResult = "";
        if (message.Contains(theword))
            containResult = "is";
        else
            containResult = "is not";
        return $"sentence {containResult} contains word {theword}";
    }
}
```
