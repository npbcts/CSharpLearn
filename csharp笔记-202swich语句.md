## C# 自我初学笔记 第202章  多样的流程控制语句

来源于: Learn C# 初级自学教程:[swich-case结构教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-switch-case/),
微软推出的初学者教程整理。

### C#语言多样化特点

在使用 C# 编程语言时，可选择不同方式来表达同一概念，这一点与人类的书面语或口头语很相似。 某些字词和短语相较其他更具描述性、准确性或简洁性。可以通过多种方式在应用程序中添加循环逻辑，每种方式都有自己独有的特点、优势和劣势。

但是，这与python倡导的"一件事只能通过一种做法完成"的简单哲学相悖，我更倾向于使语言应用简单的pythonic做法。由于两种流程控制结构已经存在现有解决方案并且能够应用在所有的场景中，为减轻初学者压力和程序的风格一致那么就不宜使用过多的方案。  
已有的两种方案是:

- 选择控制流程: `if-else if-else` 语句  
- 循环流程控制: `foreach` 语句  

同时，`if`语句可以使用没有代码块标识`{}`的写法，这样的流程简洁度并不输于`swich-case`语句，另一种选择流程控制语句。

另外的流程控制语句有：

- 选择控制流程: `swich-case`语句
- 循环流程控制: `for`循环语句，`while`语句,`do while`语句

我的初步结论是**尝试使用`if`语句和`foreach`完成所有的编程任务场景**,其他流程控制方法只作为备用方法了解即可。

### `swich-case`语句

将一个变量或表达式与多个可能值相匹配的分支逻辑。  
`switch` 是选择语句，它根据匹配表达式的模式匹配从候选项列表中选择一个 `switch` 部分来执行。 `Switch` 语句包含一个或多个 `switch` 部分。 每个 `switch` 部分都包含一个或多个 `case` 标签（`case` 或 `default` 标签），后跟一个或多个语句。`Switch` 语句最多只能包含一个位于任意 `switch` 部分中的 `default` 标签。

代码示例如下:
```c#
int employeeLevel = 200;
string employeeName = "John Smith";

string title = "";

switch (employeeLevel)
{
    case 100:
        title = "Junior Associate";
        break;
    case 200:
        title = "Senior Associate";
        break;
    case 300:
        title = "Manager";
        break;
    case 400:
        title = "Senior Manager";
        break;
    default:
        title = "Associate";
        break;
}

Console.WriteLine($"{employeeName}, {title}");
```
例子中的`break` 关键字是结束 `switch` 部分并如其字义跳出 `switch` 语句的其中一种方式。 如果未使用 `break` 关键字（或 `return` 关键字），编译器将生成错误。


上面的代码使用`if`语句的等效写法:

```c#
int employeeLevel = 200;
string employeeName = "John Smith";

string title = "";

if (employeeLevel == 100)
    title = "Junior Associate";
else if (employeeLevel == 200)
    title = "Senior Associate";
else if (employeeLevel == 300)
    title = "Manager";
else if (employeeLevel == 400)
    title = "Senior Manager";
else
    title = "Associate";

Console.WriteLine($"{employeeName}, {title}");
```
上面的例子中,`swich`语句本身使用18行代码,`if`语句本身使用10行代码，并且可读性可理解性并不差。当选择分支更多时，使用`swich`和`if`语句都不是明智的选择，应该使用字典这样的数据结构去解决问题。


