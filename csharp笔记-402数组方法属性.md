## C# 自我初学笔记 第N章  

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.array?view=net-6.0)整理。本文只对常用的知识整理，更详细需要查看链接指向的文档。

C#中的数组类型是从抽象的基类型 `Array` 派生的引用类型。因此我们根据使用数组时根据`Array`的方法进行。同时，要更深入理解C#数组的特性也要从`Array`开始。

### .NET6中`Array`概述

`Array`提供一些方法，用于创建、处理、搜索数组并对数组进行排序，从而充当公共语言运行时中所有数组的基类。该 `Array` 类是支持数组的语言实现的基类。 但是，只有系统和编译器才能从类显式 `Array` 派生。 用户应采用语言提供的数组构造，因此
- 程序开发人员不能直接使用.NEt的`Array`类。  
- 同时，多个语言框架都能够通过语言编译器使用`Array`类构建自己的数组数据容器或结构。

`Array`具有固定容量。 若要增加容量，必须创建具有所需容量的新`Array`对象，将元素从旧 `Array` 对象复制到新对象，然后删除旧`Array`对象。

### `Array`的属性在c#中的实现

- `Length`: 获取 Array 的所有维度中的元素总数。
- `Rank`: 获取 Array 的秩（维数）。 例如，一维数组返回 1，二维数组返回 2，依次类推。
- `IsFixedSize`: 获取一个值，该值指示 `Array` 是否具有固定大小。对于所有数组，此属性始终为 true。
- `IsReadOnly`: 获取一个值，该值指示 `Array` 是否为只读。对于所有数组，此属性始终为 false

查看数组长度和维度的示例:
```c#
string[] students = new string[] {"Luca", "Mads", "Luke", "Dinesh"};
Console.WriteLine($"数组长度: {students.Length}");
Console.WriteLine($"数组维度: {students.Rank}");

/* 输出
数组长度: 4
数组维度: 1
*/
```
> 注意，在`Array`文档中，个别的属性或方法都不能在c#数组类型中实现，在使用不常用的方式时需要验证是否可用。

查看数组的只读和固定长度属性:
```c#
string[] students = new string[] {"Luca", "Mads", "Luke", "Dinesh"};
Console.WriteLine($"数组是否固定长度: {students.IsFixedSize}");
Console.WriteLine($"数组是否只读: {students.IsReadOnly}");

/* 输出
数组是否固定长度: True
数组是否只读: False
*/
```


### `Array`的方法在c#中的实现

#### 复制数组的方法

复制数组，转换类型至新数组。

Clone()	
创建 Array 的浅表副本。

ConstrainedCopy(Array, Int32, Array, Int32, Int32)	
复制 Array 中的一系列元素（从指定的源索引开始），并将它们粘贴到另一 Array 中（从指定的目标索引开始）。 保证在复制未成功完成的情况下撤消所有更改。

ConvertAll<TInput,TOutput>(TInput[], Converter<TInput,TOutput>)	
将一种类型的数组转换为另一种类型的数组。

Copy(Array, Array, Int32)	
从第一个元素开始复制 Array 中的一系列元素，将它们粘贴到另一 Array 中（从第一个元素开始）。 长度指定为 32 位整数。

Copy(Array, Array, Int64)	
从第一个元素开始复制 Array 中的一系列元素，将它们粘贴到另一 Array 中（从第一个元素开始）。 长度指定为 64 位整数。

Copy(Array, Int32, Array, Int32, Int32)	
复制 Array 中的一系列元素（从指定的源索引开始），并将它们粘贴到另一 Array 中（从指定的目标索引开始）。 长度和索引指定为 32 位整数。

Copy(Array, Int64, Array, Int64, Int64)	
复制 Array 中的一系列元素（从指定的源索引开始），并将它们粘贴到另一 Array 中（从指定的目标索引开始）。 长度和索引指定为 64 位整数。

CopyTo(Array, Int32)	
从指定的目标数组索引处开始，将当前一维数组的所有元素复制到指定的一维数组中。 索引指定为 32 位整数。

CopyTo(Array, Int64)	
从指定的目标数组索引处开始，将当前一维数组的所有元素复制到指定的一维数组中。 索引指定为 64 位整数。

#### 修改数组的方法

排序，反转，设置值

Reverse(Array)	
反转整个一维 Array 中元素的顺序。

Reverse(Array, Int32, Int32)	
反转一维 Array 中元素子集的顺序。

Reverse<T>(T[])	
反转一维泛型数组中元素的顺序。

Reverse<T>(T[], Int32, Int32)	
反转一维泛型数组中元素子集的顺序。

SetValue(Object, Int32)	
将值设置为一维 Array 中指定位置的元素。 索引指定为 32 位整数。

SetValue(Object, Int32, Int32)	
将某值设置给二维 Array 中指定位置的元素。 索引指定为 32 位整数。

SetValue(Object, Int32, Int32, Int32)	
将值设置为三维 Array 中指定位置的元素。 索引指定为 32 位整数。

SetValue(Object, Int32[])	
将值设置为多维 Array 中指定位置的元素。 索引指定为一个 32 位整数数组。

SetValue(Object, Int64)	
将值设置为一维 Array 中指定位置的元素。 索引指定为 64 位整数。

SetValue(Object, Int64, Int64)	
将某值设置给二维 Array 中指定位置的元素。 索引指定为 64 位整数。

SetValue(Object, Int64, Int64, Int64)	
将值设置为三维 Array 中指定位置的元素。 索引指定为 64 位整数。

SetValue(Object, Int64[])	
将值设置为多维 Array 中指定位置的元素。 索引指定为一个 64 位整数数组。

Sort(Array)	
使用 Array 中每个元素的 IComparable 实现，对整个一维 Array 中的元素进行排序。

Sort(Array, Array)	
基于第一个 Array 中的关键字，使用每个关键字的 IComparable 实现，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）进行排序。

Sort(Array, Array, IComparer)	
基于第一个 Array 中的关键字，使用指定的 IComparer，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）进行排序。

Sort(Array, Array, Int32, Int32)	
基于第一个 Array 中的关键字，使用每个关键字的 IComparable 实现，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序。

Sort(Array, Array, Int32, Int32, IComparer)	
基于第一个 Array 中的关键字，使用指定的 IComparer，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序。

Sort(Array, IComparer)	
使用指定的 IComparer，对一维 Array 中的元素进行排序。

Sort(Array, Int32, Int32)	
使用 Array 中每个元素的 IComparable 实现，对一维 Array 中的部分元素进行排序。

Sort(Array, Int32, Int32, IComparer)	
使用指定的 IComparer，对一维 Array 中的部分元素进行排序。

Sort<T>(T[])	
使用 Array 中每个元素的 IComparable<T> 泛型接口实现，对整个 Array 中的元素进行排序。

Sort<T>(T[], Comparison<T>)	
使用指定的 Comparison<T>，对 Array 中的元素进行排序。

Sort<T>(T[], IComparer<T>)	
使用指定的 IComparer<T> 泛型接口，对 Array 中的元素进行排序。

Sort<T>(T[], Int32, Int32)	
使用 Array 中每个元素的 IComparable<T> 泛型接口实现，对 Array 中元素范围内的元素进行排序。

Sort<T>(T[], Int32, Int32, IComparer<T>)	
使用指定的 IComparer<T> 泛型接口，对 Array 中的部分元素进行排序。

Sort<TKey,TValue>(TKey[], TValue[])	
基于第一个 Array 中的键，使用每个键的 IComparable<T> 泛型接口实现，对一对 Array 对象（一个包含键，另一个包含对应的项）进行排序。

Sort<TKey,TValue>(TKey[], TValue[], IComparer<TKey>)	
基于第一个 Array 中的关键字，使用指定的 IComparer<T> 泛型接口，对两个 Array 对象（一个包含关键字，另一个包含对应的项）进行排序。

Sort<TKey,TValue>(TKey[], TValue[], Int32, Int32)	
基于第一个 Array 中的键，使用每个键的 IComparable<T> 泛型接口实现，对两个 Array 对象（一个包含键，另一个包含对应的项）的部分元素进行排序。

Sort<TKey,TValue>(TKey[], TValue[], Int32, Int32, IComparer<TKey>)	
基于第一个 Array 中的关键字，使用指定的 IComparer<T> 泛型接口，对两个 Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序。



```c#

```

#### 数组的查询方法

数组的查询方法较多，主要分为三类, `IndexOf`系列，`Find`系列和`GetValue`系列。
- `IndexOf`: 系列通过数组的项目值获取对应的在数组中的索引。
- `Find`: 系列根据数组的项目值的特征获取项目值、项目在数组中的索引。
- `GetValue`系列: 根据索引获取数组项目值。


具体方法如下:

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


- `Find<T>(T[], Predicate<T>)`: 	
搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中的第一个匹配元素。
- `FindAll<T>(T[], Predicate<T>)`: 	
检索与指定谓词定义的条件匹配的所有元素。
- `FindIndex<T>(T[], Int32, Int32, Predicate<T>)`: 	
搜索与指定谓词所定义的条件相匹配的一个元素，并返回 Array 中从指定的索引开始、包含指定元素个数的元素范围内第一个匹配项的从零开始的索引。
- `FindIndex<T>(T[], Int32, Predicate<T>)`: 	
搜索与指定谓词所定义的条件相匹配的元素，并返回 Array 中从指定索引到最后一个元素的元素范围内第一个匹配项的从零开始的索引。
- `FindIndex<T>(T[], Predicate<T>)`: 	
搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中第一个匹配元素的从零开始的索引。
- `FindLast<T>(T[], Predicate<T>)`: 	
搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中的最后一个匹配元素。
- `FindLastIndex<T>(T[], Int32, Int32, Predicate<T>)`: 	
搜索与指定谓词所定义的条件相匹配的元素，并返回 Array 中包含指定元素个数、到指定索引结束的元素范围内最后一个匹配项的从零开始的索引。
- `FindLastIndex<T>(T[], Int32, Predicate<T>)`: 	
搜索与由指定谓词定义的条件相匹配的元素，并返回 Array 中从第一个元素到指定索引的元素范围内最后一个匹配项的从零开始的索引。
- `FindLastIndex<T>(T[], Predicate<T>)`: 	
搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中最后一个匹配元素的从零开始的索引。


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


- `GetValue(Int32)`: 获取一维 Array 中指定位置的值。 索引指定为 32 位整数。
- `GetValue(Int32, Int32)`: 获取二维 Array 中指定位置的值。 索引指定为 32 位整数。
- `GetValue(Int64)`: 获取一维 Array 中指定位置的值。 索引指定为 64 位整数。
- `GetValue(Int64, Int64)`: 获取二维 Array 中指定位置的值。 索引指定为 64 位整数。
获取三维及多维数组项目值的方法在此不再列示，需要使用时可以查询文档。


##### 数组的删除方法

- `Clear()`: 从 IList 中移除所有项。
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


```c#

```




### `Array`的接口在c#中的实现

- `IList.Contains(Object)`: 确定某元素是否在 IList 中。


`IList.Contains(Object)`示例:
```c#
string[] students = new string[] {"Luca", "Mads", "Luke", "Dinesh"};
Console.WriteLine($"数组是否包含: {students.Contains("Luca")}");
Console.WriteLine($"数组是否包含: {students.Contains("abc")}");

/* 输出
数组是否包含: True
数组是否包含: False
*/
```


> 在`Array`文档中的接口在特定版本的.NET环境中并不全部可实现，需要在使用前验证。

(End)
