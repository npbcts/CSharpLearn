## C# 自我初学笔记 第N章  逻辑运算

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-evaluate-boolean-expressions/2-exercise-boolean-expressions),微软推出的初学者教程整理。

在[csharp笔记-108if语句](csharp笔记-108if语句.md)我们简单讲解过`if`语句中的布尔表达式。布尔表达式依赖逻辑运算和返回布尔值的，这节我们继续学习C#中更多的逻辑运算知识。

“决策逻辑”(包括“分支逻辑”)是程序员根据某些表达式的计算结果用来描述执行路径更改的术语。 例如，我们可能会编写计算用户输入的代码。 如果用户输入的值与字符串值“a”相等，则执行一个代码块。 如果用户输入的值与字符串值“b”相等，则执行另一个代码块。

### 什么是表达式？

表达式是返回一个值的值（文本或变量）、运算符和方法的任意组合。 语句是 C# 中的完整指令，由一个或多个表达式组成。

虽然表达式有许多不同的类别，但在使用决策语句时，我们会选用布尔表达式。 在布尔表达式中，运行时会计算值、运算符和方法，返回一个 `true` 值或 `false` 值。

布尔表达式非常重要，因为我们接下来要学习的决策语句使用布尔表达式来决定要执行的代码块。

我们可以使用许多不同的运算符，具体取决于要在代码中表达的意图。

### 计算相等性

很多时候，你想要检查两个值是否相等。 你可以两个值之间使用相等运算符 == 来计算相等性。 如果相等运算符两侧的两个值相等，则表达式将返回 `true`。 否则，将返回 `false`。

```c#
Console.WriteLine("a" == "a ");
```
运行后的返回值:
```
false
```

**使用字符串的内置帮助程序方法来改进字符串相等性的检查:**

如果需要接受不精确的匹配项，则可以先“篡改”数据。 “篡改”数据意味着，在执行相等性比较之前需要执行一些清理操作。

要在检查相等性之前“篡改”两个字符串，应执行以下操作：

对任何字符串值使用 ToUpper() 或 ToLower() 帮助程序方法，确保这两个字符串全部大写或全部小写。
对任何字符串值使用 Trim() 帮助程序方法，删除前导空格或尾随空格。

```c#
string value1 = " a";
string value2 = "A ";
Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());
```
> 注意，例子中代码使用了方法的链式调用。即将两个值的两种方法链接,原理也很容易理解，`value1`是字符串对象调用`Trim`方法，返回字符串，字符串也有也有`ToLower`，这些方法都可以使用`string.method`的方法调用。


### 计算不等性和逻辑非

有时，你也可能想要检查两个值是否不相等。 你可以在两个值之间使用不相等运算符 `!=` 来计算相等性。

术语“逻辑非”指的是 `!` 运算符。 有些人简单地称之为“非运算符”。 在条件表达式（如方法调用）之前添加 `!` 运算符，以确保表达式为 `false`。

一个简单的示例:
```c#
Console.WriteLine("a" != "a");
```
运行后返回`False`。


### 使用比较运算符

处理数值数据类型时，需要确定一个值是大于、小于还是等于另一个值。 使用以下运算符执行这些类型的比较。

- 大于 >
- 小于 <
- 大于或等于 >=
- 小于或等于 <=

示例:
```c#
Console.WriteLine(1 > 2);
Console.WriteLine(1 < 2);
Console.WriteLine(1 >= 1);
Console.WriteLine(1 <= 1);
```
运行结果
```
False
True
True
True
```

### 返回布尔值的方法

某些方法返回一个布尔值。 你可以将这类方法视为查询。

方法返回布尔值的例子:
```c#
string pangram = "The quick brown fox jumps over the lazy dog.";
Console.WriteLine(pangram.Contains("fox"));
Console.WriteLine(pangram.Contains("cow"));
```
输出结果：
```
True
False
```

> 某些数据类型具有执行有用实用工具任务的方法。 字符串数据类型很多。 其中有几种类型都返回布尔值，包括 Contains()、StartsWith() 和 EndsWith()。

可以使用逻辑非`!`运算符将方法返回的布尔值运算成相反的结果:
```c#
string pangram = "The quick brown fox jumps over the lazy dog.";
Console.WriteLine(!pangram.Contains("fox"));
Console.WriteLine(!pangram.Contains("cow"));
```
运行结果:
```
False
True
```

### 条件运算符：“决策逻辑”的简化写法。

条件运算符 `?:`（通常称为三元条件运算符）用于计算布尔表达式，并返回两个表达式中其中一个的计算结果，返回的结果取决于布尔表达式的计算结果为 `true` 还是 `false`。

其基本形式如下：

```C#
<evaluate this condition> ? <if condition is true, return this value> : <if condition is false, return this value>
```
假设你需要快速确定客户在购买时是否有资格享受促销折扣。 如果销售额大于 1000 美元，则购买折扣为 100 美元。 如果销售额为 1000 美元或以下，则购买折扣仅为 50 美元。
使用条件运算符完成的代码:
```c#
int saleAmount = 1001;

int discount = saleAmount > 1000 ? 100 : 50;

Console.WriteLine($"Discount: {discount}");
```

使用`if`语句完成的代码:
```c#
int price = 10009;
int discount = 0;

if (price > 1000)
    discount = 100;
else
    discount = 50;
Console.WriteLine(discount);
```
可以看到，条件运算符使用精简格式，这样可以节省几行代码，但出于更为清晰逻辑的表达，使用`if`语句更为合适。


条件运算符的另一种使用场景:
```C#
int saleAmount = 1001;
// int discount = saleAmount > 1000 ? 100 : 50;

Console.WriteLine($"Discount: {(saleAmount > 1000 ? 100 : 50)}");
```
虽然这一特定示例很简洁，还展示了可能出现的情况，但如果对代码行的整体可读性有不利影响，那么合并代码行并不总是一个好主意。 

(End)