## C# 自我初学笔记 第N章  数组方法属性

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.array?view=net-6.0)整理。本文只对常用的知识整理，更详细需要查看链接指向的文档。

笔记中的代码成功运行在 [**此环境**](csharp笔记-000案例代码环境.md)，查看并使用方法属性时注意运行环境的版本区别。

C#中的数组类型是从抽象的基类型 `Array` 派生的引用类型。因此我们根据使用数组时根据`Array`的方法进行。同时，要更深入理解C#数组的特性也要从`Array`开始。


###  数组的删除方法

- `Clear()`: 从 `IList` 中移除所有项。
- `Clear(Array, Int32, Int32)`: 将数组中的某个范围的元素设置为每个元素类型的默认值。

使用`Clear()`移除所有数组项目:
```c#
string[] students = new string[] {"Luca", "Tom", "Luke", "Dinesh"};
Array.Clear(students);
foreach (string student in students)
{
    Console.Write($"{student is null} ");
}

/* 输出内容:
True True True True
*/
```
数组项目被移除后项目变为初始默认值。

也可以使用`Clear()`的重载方法移除部分数组项目:
```c#
string[] students = new string[] {"Luca", "Tom", "Luke", "Dinesh"};
Array.Clear(students, 1, 2);  // 此处添加了删除开始索引和删除项目参数
foreach (string student in students)
{
    Console.Write($"{student is null} ");
    if (student is not null)
        Console.WriteLine($"{student} ");
    else
        Console.WriteLine();
}

/* 输出内容:
False Luca 
True 
True 
False Dinesh 
*/
```

### 数组的其他方法

- `TrueForAll<T>(T[], Predicate<T>)`: 确定数组中的每个元素是否都与指定谓词定义的条件匹配。
[官方文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.array.trueforall?view=net-6.0#system-array-trueforall-1(-0()-system-predicate((-0))))

例子:
```c#
string[] students = new string[] {"Luca", "Tom", "Luke", "Dinesh"};
bool trueForAll = Array.TrueForAll(students, student => student.StartsWith('L'));
Console.WriteLine($"数组中的字符串开头为L :{trueForAll}");
Console.WriteLine("=================");
string[] studentsL = new string[] {"Luca", "LTom", "Luke", "LDinesh"};
bool trueForAllL = Array.TrueForAll(studentsL, student => student.StartsWith('L'));
Console.WriteLine($"数组中的字符串开头为L :{trueForAllL}");

/*输出内容
数组中的字符串开头为L :False
=================
数组中的字符串开头为L :True
*/
```
`Predicate<T>`函数使用了`lambda`表达式，也可以使用能够返回布尔值的复杂函数。

文档中使用复杂函数判断的例子：
```c#
public class Example
{
   public static void Main()
   {
      String[] values1 = { "Y2K", "A2000", "DC2A6", "MMXIV", "0C3" };
      String[] values2 = { "Y2", "A2000", "DC2A6", "MMXIV_0", "0C3" };

      if (Array.TrueForAll(values1, EndsWithANumber))
         Console.WriteLine("All elements end with an integer.");
      else
         Console.WriteLine("Not all elements end with an integer.");

      if (Array.TrueForAll(values2, EndsWithANumber))
         Console.WriteLine("All elements end with an integer.");
      else
         Console.WriteLine("Not all elements end with an integer.");
   }

   private static bool EndsWithANumber(string value)
   {
      int s;  // 实际上是无用的返回参数，但TryParse方法要求输入创建
      return int.TryParse(value.Substring(value.Length - 1), out s);
   }
}
// 例子输出t:
//       Not all elements end with an integer.
//       All elements end with an integer.
```

- `GetType()`: 获取当前实例的 `Type`。(继承自 `Object`)
- `GetHashCode()`: 作为默认哈希函数。(继承自 `Object`)

继承自 `Object`的方法在c#中较为通用，可以使用到其他变量。
```c#
string[] students = new string[] {"Luca", "Tom", "Luke", "Dinesh"};
Console.WriteLine($"变量类型: {students.GetType()}");
Console.WriteLine($"变量hashcode: {students.GetHashCode()}");

// 变量类型: System.String[]
// 变量hashcode: 801554879
```
关于确定变量类型，可以使用`is`关键字判断类型是否属于某个类型变量并返回布尔值。

- `GetEnumerator()`: 返回 `IEnumerator` 的 `Array`。
```c#
string[] students = new string[] {"Luca", "Tom", "Luke", "Dinesh"};
System.Collections.IEnumerator myEnumerator = students.GetEnumerator();
Console.WriteLine($"是否存在下一个元素: {myEnumerator.MoveNext()}");
Console.WriteLine($"第迭代下一个元素: {myEnumerator.Current}");

// 是否存在下一个元素: True
// 第迭代下一个元素: Luca
```

- `GetLowerBound(Int32)`: 获取数组中指定维度第一个元素的索引。
- `GetUpperBound(Int32)`: 获取数组中指定维度最后一个元素的索引。
该方法 `GetLowerBound` 始终返回一个值，该值指示数组下限的索引，即使数组为空也是如此。

请注意，尽管 `.NET` 中的大多数数组都是从零开始的 (， `GetLowerBound` 但该方法为数组的每个维度返回零) ，但 `.NET` 支持不从零开始的数组。 可以使用该方法创建 `CreateInstance(Type, Int32[], Int32[])` 此类数组，也可以从非托管代码返回。

因此， 对于不从零开始的数组，`GetLowerBound(Int32)`不会为 `0`, `GetUpperBound(Int32)`不会为 `Array.Length`值。总之，使用这两种方法获取数组的开始和结束索引比使用`0`和`Array.Length`更安全。

另外， 使用 `GetLowerBound` 和 `GetUpperBound` 方法可以显示一维数组和二维数组的边界。

例子:
```c#
string[] students = new string[] {"Luca", "Tom", "Luke", "Dinesh"};
Console.WriteLine($"数组第一个元素的索引： {students.GetLowerBound(0)}");  //参数：数组的维度
Console.WriteLine($"数组最后元素的索引： {students.GetUpperBound(0)}");

// 输出:
// 数组第一个元素的索引： 0
// 数组最后元素的索引： 3

```


(End)
