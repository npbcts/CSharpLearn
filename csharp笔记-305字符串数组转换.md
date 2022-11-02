## C# 自我初学笔记 第N章  数组的常用方法

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-arrays-operations/4-exercise-split-join#code-try-24),微软推出的初学者教程整理。


string 类型的变量具有许多内置方法，可将单个字符串转换为较小字符串的数组，或转换为单个字符的数组。

处理来自其他计算机系统的数据时，其格式或编码不一定符合你的需求。 在这些情况下，可以使用 string 数据类型的 Array 方法，将较大的字符串解析为数组。

### string和数组`char[]`相互转换

`ToCharArray()` 字符串拆分成单个字符组成的数组：
```c#
string value = "abc123";
char[] valueArray = value.ToCharArray();
```
这样处理会得到一个包含多个单字符的数组

这种将字符串拆分成单个`char`字符对于重新排序原始字符有很大的帮助。
```C#
string value = "abc123";
char[] valueArray = value.ToCharArray();
Array.Reverse(valueArray);
string result = new string(valueArray);
Console.WriteLine(result);
```

当然，也可以将单字符数组合并成字符串：
```c#
string result = new string(valueArray);
Console.WriteLine(result);
```
可以看到，这里使用了创建新字符串变量，并向`string`类提供参数`valueArray`的方式进行。并且这种方法只能传入 `char[]`， 即包含`char`类型的数组。

### 字符串和数组`string[]`拆分合并方法

`String` 类的 `Join()` 方法,字符串数组连接成字符串的另一种方法，这种方法更普遍：
```c#
string[] valueArray = {"abc", "123", "def"};
string result = String.Join("", valueArray);
Console.WriteLine(result);
```
输出结果`abc123def`
`Join()` 方法, 传入要用于分段的字符（可以不分段传入空字符或是传入逗号用于分段）和数组本身作为参数。当然数组应该是`string[]`类型， `char[]`类型的数组不能使用本方法合并。

按照特定的字符串拆分形成数组：
```c#
string result = "3,2,1,c,b,a";
string[] items = result.Split(',');
foreach (string item in items)
{
    Console.WriteLine(item);
}
```
注意`Split`方法需要传入分割字符串，并且不能为空字符串。此方法下，字符串不能转换为单个字符组成的数组，即`char[]`数据。


### `string[]`和`char[]`

观察如下代码:
```c#
string[] str = {"a", "b"};
Console.WriteLine(String.Join("", str));
char[] strChar = {'a', 'b'};
Console.WriteLine(String.Join("", strChar));
```
输出结果：
```
string[] to string :ab
char[] to string :ab
```
因此在将`string[]`和`char[]`合并成一个字符串的情况下，`String.Join`方法是通用的。

(End)
