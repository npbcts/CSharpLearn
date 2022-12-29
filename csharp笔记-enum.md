## C# 自我初学笔记 第N章  

来源于: 根据[枚举类型 文档]( https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/enum )，
[ Enum 文档 ](https://learn.microsoft.com/zh-cn/dotnet/api/system.enum?view=net-6.0)整理。

### 简介

枚举类型 是由基础整型数值类型的一组命名常量定义的值类型。 若要定义枚举类型，请使用 `enum` 关键字并指定枚举成员 的名称：

```c#
enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
```


默认情况下，枚举成员的关联常数值为类型 `int`；它们从零开始，并按定义文本顺序递增 `1`。 
可以显式指定任何其他整数数值类型作为枚举类型的基础类型。 还可以显式指定关联的常数值，如下面的示例所示：

```c#
enum ErrorCode : ushort
{
    None = 0,
    Unknown = 1,
    ConnectionLost = 100,
    OutlierReading = 200
}
```

不能在枚举类型的定义内定义方法。 若要向枚举类型添加功能，请创建扩展方法。

枚举类型 E 的默认值是由表达式 (E)0 生成的值，即使零没有相应的枚举成员也是如此。

### 实例化枚举类型

可以通过多种方法实例化枚举值:

- 可以实例化枚举类型，就像实例化任何其他值类型一样：通过声明变量并向其分配枚举常量之一。 

```c#
Season sume = Season.Summer;


public class Example
{
   public static void Main()
   {
      ArrivalStatus status = ArrivalStatus.OnTime;
      Console.WriteLine("Arrival Status: {0} ({0:D})", status);
   }
}
// The example displays the following output:
//       Arrival Status: OnTime (0)
```

- 通过使用特定编程语言的功能将 整数值作为枚举值。 以下示例创建一个 `ArrivalStatus` 对象，其值采用 `ArrivalStatus.Early` 这种方式。

```c#
ArrivalStatus status2 = (ArrivalStatus) 1;
Console.WriteLine("Arrival Status: {0} ({0:D})", status2);
// The example displays the following output:
//       Arrival Status: Early (1)

```
- 通过调用其隐式无参数构造函数。 如以下示例所示，在这种情况下，枚举实例的基础值为 0。 但是，这不一定是枚举中有效常量的值。

```c#
ArrivalStatus status1 = new ArrivalStatus();
Console.WriteLine("Arrival Status: {0} ({0:D})", status1);
// The example displays the following output:
//       Arrival Status: OnTime (0)
```


### 转换

- 对于任何枚举类型，枚举类型与其基础整型类型之间存在显式转换。 如果将枚举值转换为其基础类型，则结果为枚举成员的关联整数值。

```c#
public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

public class EnumConversionExample
{
    public static void Main()
    {
        Season a = Season.Autumn;
        Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 2

        var b = (Season)1;
        Console.WriteLine(b);  // output: Summer

        var c = (Season)4;  //超出枚举值范围，直接返回数值
        Console.WriteLine(c);  // output: 4
    }
}
```

- 枚举值`ToString`后为 `string`类型

```c#
var xg = myenum.小刚.ToString();  
Console.WriteLine(xg);
Console.WriteLine(xg.GetType());
```

- 字符串转换为枚举值

`Parse`和 `TryParse` 方法允许将枚举值的字符串表示形式转换为该值。 字符串表示形式可以是枚举常量的名称或基础值。 请注意，如果字符串可以转换为枚举的基础类型的值，则分析方法将成功转换不是特定枚举成员的数字的字符串表示形式。 若要防止这种情况， `IsDefined` 可以调用 方法以确保分析方法的结果是有效的枚举值。 该示例演示了此方法，并演示了对 `Parse(Type, String) `和 `Enum.TryParse<TEnum>(String, TEnum)` 方法的调用。


```c#
string number = "-1";
string name = "Early";

try {
   ArrivalStatus status1 = (ArrivalStatus) Enum.Parse(typeof(ArrivalStatus), number);
   if (!(Enum.IsDefined(typeof(ArrivalStatus), status1)))
      status1 = ArrivalStatus.Unknown;
   Console.WriteLine("Converted '{0}' to {1}", number, status1);
}
catch (FormatException) {
   Console.WriteLine("Unable to convert '{0}' to an ArrivalStatus value.",
                     number);
}

ArrivalStatus status2;
if (Enum.TryParse<ArrivalStatus>(name, out status2)) {
   if (!(Enum.IsDefined(typeof(ArrivalStatus), status2)))
      status2 = ArrivalStatus.Unknown;
   Console.WriteLine("Converted '{0}' to {1}", name, status2);
}
else {
   Console.WriteLine("Unable to convert '{0}' to an ArrivalStatus value.",
                     number);
}
// The example displays the following output:
//       Converted '-1' to Late
//       Converted 'Early' to Early
```



- 整型(int),枚举类型相互转换

可以使用 `C#` 中的强制转换 运算符中使用转换 ，在枚举成员与其基础类型之间进行转换。 以下示例使用强制转换或转换运算符执行从整数到枚举值的转换，以及从枚举值到整数的转换

```c#
int value3 = 2;
ArrivalStatus status3 = (ArrivalStatus) value3;

int value4 = (int) status3;
```

### 迭代枚举成员

可以调用 `GetNames `方法检索包含枚举成员名称的字符串数组。 接下来，对于字符串数组的每个元素，可以调用 `Parse` 方法将字符串转换为其等效的枚举值。 下面的示例阐释了这种方法。

```c#
string[] names = Enum.GetNames(typeof(ArrivalStatus));
Console.WriteLine("Members of {0}:", typeof(ArrivalStatus).Name);
Array.Sort(names);
foreach (var name in names) {
   ArrivalStatus status = (ArrivalStatus) Enum.Parse(typeof(ArrivalStatus), name);
   Console.WriteLine("   {0} ({0:D})", status);
}
// The example displays the following output:
//       Members of ArrivalStatus:
//          Early (1)
//          Late (-1)
//          OnTime (0)
//          Unknown (-3)
```


可以调用 `GetValues` 方法以检索包含枚举中基础值的数组。 接下来，对于数组的每个元素，可以调用 `ToObject` 方法将整数转换为其等效枚举值。 下面的示例阐释了这种方法。

```c#
var values = Enum.GetValues(typeof(ArrivalStatus));
Console.WriteLine("Members of {0}:", typeof(ArrivalStatus).Name);
foreach (ArrivalStatus status in values) {
   Console.WriteLine("   {0} ({0:D})", status);
}
// The example displays the following output:
//       Members of ArrivalStatus:
//          OnTime (0)
//          Early (1)
//          Unknown (-3)
//          Late (-1)
```



(End)