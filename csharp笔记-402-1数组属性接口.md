## C# 自我初学笔记 第N章  数组方法属性

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.array?view=net-6.0)整理。本文只对常用的知识整理，更详细需要查看链接指向的文档。

笔记中的代码成功运行在 [**此环境**](csharp笔记-000案例代码环境.md)，查看并使用方法属性时注意运行环境的版本区别。

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
