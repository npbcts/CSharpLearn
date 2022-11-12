## C# 自我初学笔记 第N章  泛型List类

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.list-1?view=net-6.0)整理。本笔记只记录常用的概念、方法和接口。

`泛型List类`表示可通过索引访问的对象的强类型列表。 提供用于对列表进行搜索、排序和操作的方法。一个 `List<T>`在添加、删除和插入简单的业务对象方面比数组`Array`有优势，同时保存统一的数据类型相较于`ArrayList`在数据存储时较少的耗费计算性能。


`List<T>` 类是类 `ArrayList` 的泛型等效项。 它通过使用一个数组实现 `IList<T>` 泛型接口，该数组的大小根据需要动态增加。

可以使用`Add`或`AddRange`方法将项添加到 `List<T>`。

该 `List<T>` 类使用相等比较器和排序比较器。

- 方法（例如 `Contains`， `IndexOf`） `LastIndexOf`对 `Remove` 列表元素使用相等比较器。 类型 `T` 的默认相等比较器按如下所示确定。 如果类型 `T` 实现 `IEquatable<T>` 泛型接口，则相等比较器是 `Equals(T) `该接口的方法;否则，默认相等比较器为 `Object.Equals(Object)`。

- 用于列表元素的排序比较器等`BinarySearchSort`方法。 类型 `T` 的默认比较器按如下所示确定。 如果类型 `T` 实现 `IComparable<T> `泛型接口，则默认比较器是 `CompareTo(T)` 该接口的方法;否则，如果类型 `T` 实现非泛型 `IComparable` 接口，则默认比较器是 `CompareTo(Object)` 该接口的方法。 如果类型 `T` 实现两个接口，则没有默认比较器，并且必须显式提供比较器或比较委托。

`List<T>`不能保证排序。 必须先对 (执行操作进行排序 `List<T> `，例如 `BinarySearch` 需要 `List<T>` 排序的) 。

可以使用整数索引访问此集合中的元素。 此集合中的索引从零开始。

### 构造函数

- `List<T>()`：初始化 List<T> 类的新实例，该实例为空并且具有默认初始容量。
- `List<T>(IEnumerable<T>)`	：初始化 List<T> 类的新实例，该实例包含从指定集合复制的元素并且具有足够的容量来容纳所复制的元素。
- `List<T>(Int32)`：初始化 List<T> 类的新实例，该实例为空并且具有指定的初始容量。

默认的构造函数示例:
```c#
List<int> myList = new List<int>();
```

`AddRange`方法将项添加到 `List<T>`:
```c#
List<int> myList = new List<int>();
myList.AddRange(Enumerable.Range(0, 4));
Console.WriteLine(string.Join(" ", myList));

// 输出结果:
// 0 1 2 3
```

```c#

```

(End)