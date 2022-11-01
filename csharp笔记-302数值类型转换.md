## C# 自我初学笔记 第N章  数据类型转换

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-convert-cast/2-exercise-data-type-conversion#code-try-14),微软推出的初学者教程整理。

处理数据时，你经常需要将值从一种数据类型更改为另一种数据类型。
一个简单的示例是对字符串数据执行任何数学运算。 你首先需要将值更改为数字数据类型，如 int，然后才能操作运算。 或者，你也可以使用字符串内插来格式化和输出数值。 
> 需要注意的是，C#有隐式更改值的数据类型的操作，但并不提倡这么做，原因在于“明确胜于隐晦”。

### 决定是否转换类型

有多种方法可以执行数据类型转换或强制转换。 选择哪种方法取决于你对两个重要问题的回答：

问题 1：对于不同的值，尝试更改值的数据类型是否可能在运行时引发异常？
问题 2：对于不同的值，尝试更改值的数据类型是否可能导致信息丢失？

#### 问题 1：转换引发异常


**一种不鼓励的隐式转换**示例代码:
```c#
int first = 2;
string second = "4";
string result = first + second;
Console.WriteLine(result);
```
输出的结果是`24`。  
出现类型冲突时，从 C# 编译器的角度来看，更安全的操作是将 int 转换为 string 并改为执行字符串串联。相反的情况，C# 编译器不会隐式执行从 string 到 int 的转换。

如果需要将值从原始数据类型更改为新的数据类型，并且更改可能在运行时引发异常，则必须执行**显示**数据转换。若要执行数据转换，你可以使用下列方法之一：

- 对数据类型使用帮助程序方法
- 对变量使用帮助程序方法
- 使用 Convert 类的方法


#### 问题2： 转换导致的信息丢失


术语**扩大转换**表示你正在尝试将值从一种可以保留较少信息的数据类型转换为一种可保留较多信息的数据类型。 在这种情况下，你**不会丢失任何信息**。 因此，一个示例是转换存储在 `int` 类型的变量中的值，并将该值转换为 `decimal` 类型的变量。

一个扩大转换的例子:
```c#
int myInt = 3;
Console.WriteLine($"int: {myInt}");

decimal myDecimal = myInt;
Console.WriteLine($"decimal: {myDecimal}");
```
输出:
```
int: 3
decimal: 3
```
由于任何 int 值都可以轻松地纳入 decimal，因此编译器会执行转换。


术语“收缩转换”表示你试图将值从一种可以保留较多信息的数据类型转换为一种可保留较少信息的数据类型。 在这种情况下，你可能会丢失信息，如精度（即小数点后的位数）。 一个示例是转换存储在 decimal 类型的变量中的值，并将该值转换为 int 类型的变量。 如果打印出这两个值，你可能会注意到出现了信息丢失的情况。

如果你了解需要执行收缩转换，则需要执行强制转换。 强制转换是一种针对 C# 编译器的指令，**即你知道可能发生精度丢失，但这种情况可以接受**。

一个强制转换的例子：
```c#
decimal myDecimal = 3.14m;
Console.WriteLine($"decimal: {myDecimal}");

int myInt = (int)myDecimal;
Console.WriteLine($"int: {myInt}");
```
若要执行强制转换，请使用强制转换运算符 `()` 将数据类型括起来，然后将其放在要转换的变量旁边。

输出：
```c#
decimal: 3.14
int: 3
```
#### 如何确定转换是“扩大转换”还是“收缩转换”？

权威资源是 Microsoft Docs 中的以下文章：[.NET 中的类型转换表](https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/conversion-tables),[内置类型表](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/built-in-types)

.NET 中的类型转换表 介绍类型的 `.NET` 类库名称，而非数据类型的 `C#` 关键字，结合"内置类型表"即可了解 `C#` 关键字和 `.NET` 类库类型之间进行映射。


### 使用 `Convert` 类进行数据转换

在[问题2-转换导致的信息丢失](#问题2-转换导致的信息丢失)我们讲述了一种强制转换的方法,在需要强制转换的变量/数值前加`(数据)`类型。收缩转换时，会发生数据信息丢失，如`demical=3.14`转换后`int=3`，即去除了全部的小数部分，只保留整数部分。

另一种不同的转换方式是使用`Convert` 类进行数据转换,转换的原则是四舍五入。

两种转换方法的比较：
```c#
int value = (int)1.5m; // casting truncates
Console.WriteLine(value);

int value2 = Convert.ToInt32(1.5m); // converting rounds up
Console.WriteLine(value2);
```
输出结果
```
1
2
```

`()`强制转换时，系统会截断 `float` 的值，这意味着完全忽略 `decimal` 后的值。 我们可以将文本 `float` 更改为 `1.999m`，强制转换的结果也是相同的。

使用 `Convert.ToInt32()` 进行转换时，文本 `float` 值将正确地向上舍入到 `2`。 如果将文本值更改为 `1.499m`，则会向下舍入到 `1`。 


> 为什么该方法的名称为 ToInt32()？ 为什么不是 ToInt()？ System.Int32 是 .NET 类库中的基础数据类型名称，C# 编程语言将其映射到 int 关键字。 由于 Convert 类也属于 .NET 类库，因此调用该类时是按其全名（而非按其 C# 名称）进行调用。 通过将数据类型定义为 .NET 类库的一部分，Visual Basic、F#、IronPython 等多种 .NET 语言可以在 .NET 类库中共享相同的数据类型和相同的类。 

(End)