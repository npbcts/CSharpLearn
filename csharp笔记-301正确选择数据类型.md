## C# 自我初学笔记 第N章  数据类型的选择

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-choose-data-type/1-introduction),微软推出的初学者教程整理。


### 数据类型概述

C# 编程语言广泛地依赖于数据类型。 数据类型用于限制可存储在给定变量中的值类型，可以在尝试创建无错误的代码时提供帮助。 作为开发者，你可以自信地操作变量，因为你预先知道该变量仅存储有效值。

考虑到在你职业生涯中将要构建的应用程序类型，你就会发现你只选定了所有可用数据类型中的一小部分。 
下面**基本数据类型几乎能够满足你所有的编程要求**(除精度极高的科学计算和硬件性能追求极致的程序):

**- int，适用于大部分整数,是一种应用最广泛的*整型类型***  
**- decimal，适用于表示资金的数字和小数数字,是一种应用最广泛的*浮点型类型***  
**- bool，适用于 true 或 false 值**  
**- string，适用于字母数字值**  

但仍必须知道还存在其他数据类型以及为什么存在,以及在特殊情况下如何选择。

C#的数据类型可以分为两大类，值类型和引用类型。

简单的值类型是由 `C#` 提供作为关键字的一组预定义类型。 这些关键字只是 .NET 类库中定义的预定义类型的别名。 例如， `C#` 关键字 `int` 是在 `.NET` 类库中定义为 `System.Int32` 的值类型的别名。

简单的值类型包括`char`, `bool`, `int`, `byte`, `decimal`, `double`, `flout`，等等接近二十种类型。

除了简单的值类型外，其他值类型还包括枚举和结构。

### 如何选择简单数据类型

由于可供选择的数据类型太多，针对特定情况应采用哪种标准选择适当的数据类型呢？这也奠定我们之后如何学习繁杂的C#甚至.NET库数据类型的方向。

在评估下面这些选项时，必须考虑一些重要的注意事项。 正确答案通常不止一个，但有些答案比其他答案更正确。

- 根据变量保存的数据范围选择数据类型。  
例如在您创建的游戏程序中，主角的血量满值为100,那么你可以将`血量`的数据类型设置为`byte`(一种整数类型，范围在0-255之间)。如果你的某个储存距离的变量位于 1 - 10,000 公里之间的值（否则将超出预期边界），则可能要避免使用 `byte`、`sbyte` 数据类型，因为它们的范围太小。 

- 在编程之初，不用考虑选择不同数据类型对计算机性能的影响。  
对于一般的应用程序和目前计算机性能过剩的趋势不需要过度关注数据选择对性能的影响，除追求极致处理速度的实时金融交易系统和硬件条件苛刻的嵌入式系统。你可能想要选择使用最少二进制位存储数据的数据类型，认为这样可以提高应用程序的性能。 但与应用程序性能（即应用程序运行速度）相关的最佳建议是不要“过早优化”。需要有目的的优化时，可以凭经验使用特殊软件来衡量应用程序的性能，以真正地了解应用程序的哪部分可能会对性能产生负面影响。

- 根据与库函数的交互以及输入和输出的数据类型来选择数据类型。 
假设你想要处理在两个日期之间间隔的年份范围。 如果这是业务应用程序，你可能会确定只需 1960 到 2200 的范围。 因此，你可能会使用 `byte`，因为它可以表示 0 - 255 之间的数字。 但当你研究 `System.TimeSpan` 和 `System.DateTime` 类的内置方法时，就会意识到这些方法通常会接受 `double` 和 `int` 类型的值。 如果选择 `sbyte`，则会在 `sbyte` 与 `double` 或 `int` 之间不停地来回转换。 在这种情况下，如果不需要亚秒级精度，则选择 `int` 会更有意义，如果需要亚秒级精度，则选择 `double`。

- 根据对其他系统的影响（例如，在数据库中长期存储）选择数据类型。   
有时必须考虑其他应用程序或其他系统（如数据库）使用信息的方式。 例如，`SQL Server` 的类型系统不同于 `C#` 的类型系统。 因此，必须在这两个系统之间进行某些映射之后才能将数据保存到该数据库。 如果应用程序的用途是与数据库进行交互，则可能需要考虑数据的存储方式、存储的数据量，以及选择更大的数据类型可能会对存储应用程序将生成的所有数据所需的物理存储量（和成本）产生哪些影响。

- 如有疑问，请继续使用基本类型。   
虽然我们已经介绍了一些注意事项，你通常会根据这些注意事项考虑多种不同的数据类型，但在开始使用时，为简单起见，应首选部分基本数据类型，包括：

    - int，适用于大部分整数
    - decimal，适用于表示资金的数字
    - bool，适用于 true 或 false 值
    - string，适用于字母数字值


### 整型类型

整型类型是一种简单的值类型，表示整数（非小数）。 在此类别中**最常见的是 `int` 数据类型**。

对每个整型类型使用 MinValue 和 MaxValue 属性,查看数据类型的范围值：
```c#
Console.WriteLine("Signed integral types:");

Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

Console.WriteLine("");
Console.WriteLine("Unsigned integral types:");

Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");
```
整型范围结果是：
```c#
Signed integral types:
sbyte  : -128 to 127
short  : -32768 to 32767
int    : -2147483648 to 2147483647
long   : -9223372036854775808 to 9223372036854775807

Unsigned integral types:
byte   : 0 to 255
ushort : 0 to 65535
uint   : 0 to 4294967295
ulong  : 0 to 18446744073709551615
```
根据程序语句运行结果可知各个整型数据最大的区别是:
- 大小范围
- 是否有正负值(可将整型分为有符号整型和无符号整型)

### 浮点型类型

浮点型类型是一种简单的值数据类型，可以存储小数。

对每个有签名的浮点类型使用 MinValue 和 MaxValue 属性，查看数据范围
```c#
Console.WriteLine("");
Console.WriteLine("Floating point types:");
Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
```
各浮点型的范围结果：
```c#
Floating point types:
float  : -3.402823E+38 to 3.402823E+38 (with ~6-9 digits of precision)
double : -1.79769313486232E+308 to 1.79769313486232E+308 (with ~15-17 digits of precision)
decimal: -79228162514264337593543950335 to 79228162514264337593543950335 (with 28-29 digits of precision)
```
浮点型数据数值范围较大而使用科学记数法表示，`取值范围最大和使用最广泛的是`decimal`类型。`

进一步探讨浮点型:
- 为应用程序选择适当的浮点类型类型不仅仅需要考虑它可以存储的最大值和最小值。 还必须考虑在小数点后可以保留多少个值、如何存储数字以及内部存储如何影响数学运算的结果。
- 当数字变得特别大时，有时可以使用“E 表示法”来表示浮点值。
- 编译器和运行时处理 decimal 的方式与处理 float 或 double 的方式存在基本差异，尤其是在确定数学运算需要多少准确度时。

#### 评估浮点型类型
- 首先，必须考虑每个类型允许的精度位数。 精度是小数点后可以存储的值的数目。

- 其次，必须考虑值的存储方式以及该方式对值的准确度造成的影响。 换句话说，float 和 double 值在内部以二进制 (base 2) 格式存储，而 decimal 值以十进制 (base 10) 格式存储。 为什么了解这一点很重要？

如果你已习惯了十进制 (base 10) 数学运算，在对二进制浮点值执行数学运算时，可能会产生意外结果。 通常，二进制浮点值的数学运算结果是实际值的近似值。 因此，float 和 double 有用，因为它们可以使用较小的内存占用量来存储较大的数字，但仅当近似值有用时才应使用这两个数据类型。 例如，在计算视频游戏中武器的爆炸区域时，偏离千分之几就已非常接近实际值。

如果需要更精确的答案，应使用 decimal。 decimal 类型的每个值都具有比较大的内存占用量，但执行数学运算可提供更精确的结果。 因此，在处理财务数据时或在任何需要通过计算得出精确结果的场景下，应使用 decimal。

### 引用类型

引用类型包括数组、类和字符串。 在应用程序执行时存储值的方式方面，引用类型的处理方式不同于值类型。

#### 数组类型
声明并初始化一个包含三个简单`int`数值类型的数组:
```c#
int[] data = new int[3];
```
#### 字符串类型`string`
string 数据类型也是引用类型。 你可能会奇怪为什么我们在声明字符串时不使用 new 操作符。 这仅仅是因为 C# 设计者想要提供一种便利。 由于 string 数据类型使用非常频繁，因此我们可以使用以下格式：
```c#
string shortenedString = "Hello World!";
Console.WriteLine(shortenedString);
```
但在后台，系统会创建 System.String 的新实例，并将其初始化为“Hello World!”。这是语言设计者提供的"语法糖"。


(End)
