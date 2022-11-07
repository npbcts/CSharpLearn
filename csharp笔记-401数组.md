## C# 自我初学笔记 第N章  数组概述

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/arrays/)整理。

### 什么是数组?

数组是一种数据容器,可以将同一类型的多个变量存储在一个数组数据结构中。 通过指定数组的元素类型来声明数组。 如果希望数组存储任意类型的元素，可将其类型指定为 `object`。在 C# 的统一类型系统中，所有类型（预定义类型、用户定义类型、引用类型和值类型）都是直接或间接从 Object 继承的。
C#中的数组是派生自.NET库中抽象的基类型`Array`派生的**引用类型**。

数组具有以下属性：

- 数组可以是一维、多维或交错的。
- 创建数组实例时，**初始化的长度在生存期内无法更改**。
- 数值数组元素的默认值设置为零，而引用元素设置为 null。
- 数组从零开始编制索引：包含 n 元素的数组从 0 索引到 n-1。
- 数组元素可以是任何类型，其中包括数组类型。
- 数组类型可以使用 foreach 语句循环访问数组。

### 作为对象的数组

在 C# 中，数组实际上是对象，可以使用 Array 具有的属性和其他类成员。 例如，使用 Length 属性来获取数组的长度。

一个初始化数组并获取长度的例子:
```c#
string[] students = new string[]{ "小明", "小花","小刚"};
int countOfStudents = students.Length;
Console.WriteLine($"学生数: {countOfStudents}");
```
输出结果:
```
学生数: 3
```
Array 类可提供多种其他有用的方法和属性，用于对数组进行排序、搜索和复制。

### 一维数组初始化

上个例子中，初始化并直接给一维数组赋值。下面的例子是初始化不赋值的情况：

```c#
int[] array = new int[5]; 
foreach (int arr in array)
{
    Console.WriteLine(arr);
}
```
输出结果:
```
0
0
0
0
0
```
初始化`int`类型数组，默认值是0。

下面的例子是初始化字符串类型的数组:
```c#
string[] students = new string[3]; 
foreach (string student in students)
{
    Console.WriteLine(student==null);
}
```
输出结果:
```
True
True
True
```
结果说明,在没有给`string`类型数组赋值时，默认值是`null`。

初始化但并不赋值给数组，默认值不同的原因是数组包含的数据类型差别，值类型默认值为`0`和引用类型数组默认值为`null`。

#### 其他数组初始化的情况

注意下面数组初始化即赋值的情况，和初始化不赋值清醒的区别:
```c#
string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
```
初始化即赋值时，并不需要定义数组的长度，因为可以根据初始化数组的数量推算得出。

更简洁的数组初始化方式：
```c#
int[] array2 = { 1, 3, 5, 7, 9 };
string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
```
这称为隐式类型化数组。

数组的声明和赋值分开的情况:
```c#
int[] array3;
array3 = new int[] { 1, 3, 5, 7, 9 };   // OK
//array3 = {1, 3, 5, 7, 9};   // Error
```

> `.NET` 支持不从零开始的数组, 可以使用该方法创建 `CreateInstance(Type, Int32[], Int32[])` 此类数组，

### 数组数据处理的常用方法

#### 数组的复制

- `Clone()`: [创建 Array 的浅表副本。](csharp笔记-402-2数组复制方法.md#clone方法)
- `CopyTo(Array, Int32)`: 从指定的目标数组索引处开始，将当前一维数组的所有元素复制到指定的一维数组中。 索引指定为 32 位整数。
- `Copy(Array, Array, Int32)`: 从第一个元素开始复制 `Array` 中的一系列元素，将它们粘贴到另一 `Array` 中（从第一个元素开始）。 长度指定为 32 位整数。
- `Copy(Array, Int32, Array, Int32, Int32)`: 复制 `Array` 中的一系列元素（从指定的源索引开始），并将它们粘贴到另一 `Array` 中（从指定的目标索引开始）。 长度和索引指定为 32 位整数。
- `ConvertAll<TInput,TOutput>(TInput[], Converter<TInput,TOutput>)`: 将一种类型的数组转换为另一种类型的数组。

#### 增: 数组数据类型不能增加项目

C#数组继承了.NET中`Array`的特性:
`Array`具有固定容量。 若要增加容量，必须创建具有所需容量的新`Array`对象，将元素从旧 `Array` 对象复制到新对象，然后删除旧`Array`对象。

#### 删: 删除数组的项目

数组数据类型不能删除项目，但能将已有项目删除至默认值。可以使用`IList.Clear()`移除所有或部分数组项目。

- `Clear()`: [从 `IList` 中移除所有项。](csharp笔记-402-4数组移除及其他方法.md#数组的删除方法)
- `Clear(Array, Int32, Int32)`: 将数组中的某个范围的元素设置为每个元素类型的默认值。

#### 改: 修改数组项目

直接索引数组的位置并赋予新值:
```c#
string[] students = new string[] {"Luca", "Tom", "Luke", "Dinesh"};
students[0] = "Lily";
foreach (string student in students)
{
    Console.Write($"{student} ");
}
```
更复杂的数组修改方法:

- `Reverse(Array)`: [反转整个一维 Array 中元素的顺序。](csharp笔记-402-3数组修改方法.md#数组的反转)
- `Reverse(Array, Int32, Int32)`: 反转一维 Array 中元素子集的顺序。
- `Reverse<T>(T[])`: 反转一维泛型数组中元素的顺序。
- `Reverse<T>(T[], Int32, Int32)`: 反转一维泛型数组中元素子集的顺序。
- `SetValue(Object, Int32)`: [将值设置为一维 Array 中指定位置的元素。 索引指定为 32 位整数。](csharp笔记-402-3数组修改方法.md#为数组设置值)
- `SetValue(Object, Int32, Int32)`: 将某值设置给二维 Array 中指定位置的元素。 索引指定为 32 位整数。
- `Sort(Array)`: [使用 Array 中每个元素的 IComparable 实现，对整个一维 Array 中的元素进行排序。](csharp笔记-402-3数组修改方法.md#数组排序)
- `Sort(Array, Array)`: 基于第一个 Array 中的关键字，使用每个关键字的 IComparable 实现，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）进行排序。
- `Sort(Array, Array, IComparer)`: 基于第一个 Array 中的关键字，使用指定的 IComparer，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）进行排序。
- `Sort(Array, Array, Int32, Int32)	`: 基于第一个 Array 中的关键字，使用每个关键字的 IComparable 实现，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序。
- `Sort(Array, Array, Int32, Int32, IComparer)`: 基于第一个 Array 中的关键字，使用指定的 IComparer，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序。
- `Sort(Array, IComparer)`: 使用指定的 IComparer，对一维 Array 中的元素进行排序。
- `Sort(Array, Int32, Int32)`: 使用 Array 中每个元素的 IComparable 实现，对一维 Array 中的部分元素进行排序。
- `Sort(Array, Int32, Int32, IComparer)	`: 使用指定的 IComparer，对一维 Array 中的部分元素进行排序。
`Resize<T>(T[], Int32)`： [将一维数组的元素数更改为指定的新大小。](csharp笔记-402-3数组修改方法.md#改变数组的大小)

#### 查: 从数组中检索数据

- 可以使用索引来检索数组中的数据。 例如：

```c#
string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

Console.WriteLine(weekDays2[0]);
Console.WriteLine(weekDays2[2]);
Console.WriteLine(weekDays2[6]);

/*Output:
Sun
Tue
Fri
*/
```
- 查询数组数据的另一种方法: [使用`foreach`循环读取数组](csharp笔记-202数组和foreach.md)

更多的数组查询方法:

- `IndexOf(Object)`: [确定 `IList` 中特定项的索引](csharp笔记-402-4数组查询方法.md#indexof系列方法)。
- `IndexOf(Array, Object, Int32)`: 在一个一维数组的一系列元素中搜索指定对象，然后返回其首个匹配项的索引。 范围从指定索引到该数组结尾。  
- `IndexOf(Array, Object, Int32, Int32)`: 在一个一维数组的一系列元素中搜索指定-对象，然后返回其首个匹配项的索引。 该元素系列的范围从指定数量的元素的指定索引开始。
- `LastIndexOf(Array, Object)`: 在整个一维 Array 中搜索指定的对象，并返回最后一个匹配项的索引。
- `LastIndexOf(Array, Object, Int32)`: 搜索指定的对象，并返回一维 Array 中从第一个元素到指定索引的元素范围内最后一个匹配项的索引。
- `LastIndexOf(Array, Object, Int32, Int32)`: 搜索指定的对象并返回一维 Array 中包含指定数目元素且在指定索引处结尾的元素范围内的最后一个匹配项的索引。
- `Find<T>(T[], Predicate<T>)`: [搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中的第一个匹配元素。](csharp笔记-402-4数组查询方法.md#find系列方法)。
- `Exists<T>(T[], Predicate<T>)`: 确定指定数组包含的元素是否与指定谓词定义的条件匹配。
- `FindAll<T>(T[], Predicate<T>)`: 检索与指定谓词定义的条件匹配的所有元素。
- `FindIndex<T>(T[], Int32, Int32, Predicate<T>)`: 	搜索与指定谓词所定义的条件相匹配的一个元素，并返回 Array 中从指定的索引开始、包含指定元素个数的元素范围内第一个匹配项的从零开始的索引。
- `FindIndex<T>(T[], Int32, Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回 Array 中从指定索引到最后一个元素的元素范围内第一个匹配项的从零开始的索引。
- `FindIndex<T>(T[], Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中第一个匹配元素的从零开始的索引。
- `FindLast<T>(T[], Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中的最后一个匹配元素。
- `FindLastIndex<T>(T[], Int32, Int32, Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回 Array 中包含指定元素个数、到指定索引结束的元素范围内最后一个匹配项的从零开始的索引。
- `FindLastIndex<T>(T[], Int32, Predicate<T>)`: 搜索与由指定谓词定义的条件相匹配的元素，并返回 Array 中从第一个元素到指定索引的元素范围内最后一个匹配项的从零开始的索引。
- `FindLastIndex<T>(T[], Predicate<T>)`: 搜索与指定谓词所定义的条件相匹配的元素，并返回整个 Array 中最后一个匹配元素的从零开始的索引。
- `GetValue(Int32)`: [获取一维 Array 中指定位置的值。 索引指定为 32 位整数。](csharp笔记-402-4数组查询方法.md#getvalue系列方法)。
- `GetValue(Int32, Int32)`: 获取二维 Array 中指定位置的值。 索引指定为 32 位整数。
- `GetValue(Int64)`: 获取一维 Array 中指定位置的值。 索引指定为 64 位整数。
- `GetValue(Int64, Int64)`: 获取二维 Array 中指定位置的值。 索引指定为 64 位整数。

### 其他方法

- `TrueForAll<T>(T[], Predicate<T>)`: [确定数组中的每个元素是否都与指定谓词定义的条件匹配。](csharp笔记-402-4数组移除及其他方法.md#数组的其他方法)
[官方文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.array.trueforall?view=net-6.0#system-array-trueforall-1(-0()-system-predicate((-0))))
- `GetType()`: 获取当前实例的 `Type`。(继承自 `Object`)
- `GetHashCode()`: 作为默认哈希函数。(继承自 `Object`)
- `GetLowerBound(Int32)`: 获取数组中指定维度第一个元素的索引。
- `GetUpperBound(Int32)`: 获取数组中指定维度最后一个元素的索引。


(End)