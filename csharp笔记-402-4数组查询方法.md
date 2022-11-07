## C# 自我初学笔记 第N章  数组查询方法

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.array?view=net-6.0)整理。本文只对常用的知识整理，更详细需要查看链接指向的文档。

笔记中的代码成功运行在 [**此环境**](csharp笔记-000案例代码环境.md)，查看并使用方法属性时注意运行环境的版本区别。

C#中的数组类型是从抽象的基类型 `Array` 派生的引用类型。因此我们根据使用数组时根据`Array`的方法进行。同时，要更深入理解C#数组的特性也要从`Array`开始。

###  数组的查询主要方法

数组的查询方法较多，主要分为三类, `IndexOf`系列，`Find`系列和`GetValue`系列。
- `IndexOf`: 系列通过数组的项目值获取对应的在数组中的索引。
- `Find`: 系列根据数组的项目值的特征获取项目值、项目在数组中的索引。
- `GetValue`系列: 根据索引获取数组项目值。


### `IndexOf`系列方法

- `IndexOf(Object)`: 确定 IList 中特定项的索引。
- `IndexOf(Array, Object, Int32)`: 在一个一维数组的一系列元素中搜索指定对象，然后返回其首个匹配项的索引。 范围从指定索引到该数组结尾。  
- `IndexOf(Array, Object, Int32, Int32)`: 在一个一维数组的一系列元素中搜索指定-对象，然后返回其首个匹配项的索引。 该元素系列的范围从指定数量的元素的指定索引开始。
- `LastIndexOf(Array, Object)`: 在整个一维 Array 中搜索指定的对象，并返回最后一个匹配项的索引。
- `LastIndexOf(Array, Object, Int32)`: 搜索指定的对象，并返回一维 Array 中从第一个元素到指定索引的元素范围内最后一个匹配项的索引。
- `LastIndexOf(Array, Object, Int32, Int32)`: 搜索指定的对象并返回一维 Array 中包含指定数目元素且在指定索引处结尾的元素范围内的最后一个匹配项的索引。


使用`IndexOf(Object)`获取元素的索引位置:
```c#
string[] students = new string[] {"Luca", null, "Luke", "Dinesh"};
Console.WriteLine($"数组项目的索引: {Array.IndexOf(students, "Luca")}");
Console.WriteLine($"数组项目的索引: {Array.IndexOf(students, null)}");

/* 输出
数组项目的索引: 0
数组项目的索引: 1
*/
```
另一个检索数组获取索引的例子:
```c#
string[] students = new string[] {"Luca", null, "Luca", "Luke", "Dinesh"};
Console.WriteLine($"从第1项开始搜索数组项目的索引: {Array.IndexOf(students, "Luca", 1)}");
Console.WriteLine($"搜索到数组项目最后符合的索引: {Array.LastIndexOf(students, "Luca")}");

/* 输出内容:
从第1项开始搜索数组项目的索引: 2
搜索到数组项目最后符合的索引: 2
*/
```
### `Find`系列方法

- `Find<T>(T[], Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中的第一个匹配元素。
- `Exists<T>(T[], Predicate<T>)`: 确定指定数组包含的元素是否与指定谓词定义的条件匹配。
- `FindAll<T>(T[], Predicate<T>)`: 检索与指定谓词定义的条件匹配的所有元素。
- `FindIndex<T>(T[], Int32, Int32, Predicate<T>)`: 	搜索与指定谓词所定义的条件相匹配的一个元素，并返回 Array 中从指定的索引开始、包含指定元素个数的元素范围内第一个匹配项的从零开始的索引。
- `FindIndex<T>(T[], Int32, Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回 Array 中从指定索引到最后一个元素的元素范围内第一个匹配项的从零开始的索引。
- `FindIndex<T>(T[], Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中第一个匹配元素的从零开始的索引。
- `FindLast<T>(T[], Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中的最后一个匹配元素。
- `FindLastIndex<T>(T[], Int32, Int32, Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回 Array 中包含指定元素个数、到指定索引结束的元素范围内最后一个匹配项的从零开始的索引。
- `FindLastIndex<T>(T[], Int32, Predicate<T>)`: 搜索与由指定谓词定义的条件相匹配的元素，并返回 Array 中从第一个元素到指定索引的元素范围内最后一个匹配项的从零开始的索引。
- `FindLastIndex<T>(T[], Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中最后一个匹配元素的从零开始的索引。


使用 `Find<T>(T[], Predicate<T>)`和`FindAll<T>(T[], Predicate<T>)`的例子:

```c#
string[] students = new string[] {"Luca", "Bob", "Luca", "Luke", "Blue", "Dinesh"};
// 返回搜索到的一个项目,可能为null
string? findWordStartB = Array.Find(students, stu => stu.StartsWith("B"));  
Console.WriteLine($"WordStartB {findWordStartB}");  
Console.WriteLine("//~~~~~~~~~~~~");
// 返回搜索到的所有项目形成新数组
string[]? studentStartB = Array.FindAll(students, stu => stu.StartsWith("B"));  
foreach (string stu in studentStartB)
{
    Console.WriteLine($"studentsStartB {stu}");
}

/* 输出内容:
WordStartB Bob
//~~~~~~~~~~~~
studentsStartB Bob
studentsStartB Blue
*/
```
例子中搜索 `Predicate<T>` 条件使用了 `lambda` 表达式 `stu => stu.StartsWith("B")` 返回以 `B`开头的字符串。
`Find<T>(T[], Predicate<T>)` 方法的多个重载方法让我们可以结合搜索范围、返回值的位置(开始还是结束位置)进行搜索，或者可以返回索引位置。  
`Exists<T>(T[], Predicate<T>)`的用法与`Find<T>(T[], Predicate<T>)` 类似。

### `GetValue`系列方法

- `GetValue(Int32)`: 获取一维 Array 中指定位置的值。 索引指定为 32 位整数。
- `GetValue(Int32, Int32)`: 获取二维 Array 中指定位置的值。 索引指定为 32 位整数。
- `GetValue(Int64)`: 获取一维 Array 中指定位置的值。 索引指定为 64 位整数。
- `GetValue(Int64, Int64)`: 获取二维 Array 中指定位置的值。 索引指定为 64 位整数。
获取三维及多维数组项目值的方法在此不再列示，需要使用时可以查询文档。

```c#
string[] students = new string[] {"Luca", "Bob", "Luca", "Luke", "Blue", "Dinesh"};
Console.WriteLine(students.GetValue(2));
/*输出
Luca
*/
```
注意，当索引范围超出数组长度时，会抛出异常。


(End)
