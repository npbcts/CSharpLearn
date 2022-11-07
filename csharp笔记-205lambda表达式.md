## C# 自我初学笔记 第N章  

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/lambda-expressions#code-try-4)整理。需要查看详细内容，可以点击进入官方文档。



### => 运算符

`=>` 令牌支持两种形式：作为 `lambda` 运算符、作为成员名称的分隔符和表达式主体定义中的成员实现。

### Lambda 表达式

使用 `Lambda` 表达式来创建匿名函数。 使用 `lambda` 声明运算符 `=>` 从其主体中**分离 `lambda` 参数列表**。 任何 `Lambda` 表达式都可以转换为委托类型, 在此不做深入讨论。
`Lambda` 表达式可采用以下任意一种形式：

#### 表达式 `lambda`

表达式位于 `=>` 运算符右侧的 `lambda` 表达式称为“表达式 `lambda`”。 表达式 `lambda` 会返回表达式的结果，表达式为其主体：
```c#
(input-parameters) => expression
```
表达式 lambda 的主体可以包含方法调用。 不过，若要创建在 .NET 公共语言运行时 (CLR) 的上下文之外（如在 SQL Server 中）计算的表达式树，则不得在 Lambda 表达式中使用方法调用。 在 .NET 公共语言运行时 (CLR) 上下文之外，方法将没有任何意义。



#### 语句 lambda
语句 `lambda` 与表达式 `lambda` 类似，只是语句括在大括号中语句块作为其主体：
```c#
(input-parameters) => { <sequence-of-statements> }
```
语句 `lambda` 的主体可以包含任意数量的语句；但是，实际上通常不会多于两个或三个。

语句 `lambda` 的例子:
```c#
Action<string> greet = name =>
{
    string greeting = $"Hello {name}!";
    Console.WriteLine(greeting);
};
greet("World");
// Output:
// Hello World!
```

### lambda 表达式的输入参数

将 lambda 表达式的输入参数括在括号中。 使用空括号指定零个输入参数：
```c#
Action line = () => Console.WriteLine();
```

如果 lambda 表达式只有一个输入参数，则括号是可选的：
```c#
Func<double, double> cube = x => x * x * x;
```

两个或更多输入参数使用逗号加以分隔：
```c#
Func<int, int, bool> testForEquality = (x, y) => x == y;
```

有时，编译器无法推断输入参数的类型。 可以显式指定类型，如下面的示例所示：
```c#
Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;
```
输入参数类型必须全部为显式或全部为隐式；否则，便会生成 CS0748 编译器错误。


```c#

```
```c#

```

(End)