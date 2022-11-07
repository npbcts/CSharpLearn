## C# 自我初学笔记 第N章  数组方法属性

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.array?view=net-6.0)整理。本文只对常用的知识整理，更详细需要查看链接指向的文档。

笔记中的代码成功运行在 [**此环境**](csharp笔记-000案例代码环境.md)，查看并使用方法属性时注意运行环境的版本区别。

C#中的数组类型是从抽象的基类型 `Array` 派生的引用类型。因此我们根据使用数组时根据`Array`的方法进行。同时，要更深入理解C#数组的特性也要从`Array`开始。


### `Array`的方法在c#中的实现

数组的方法主要分为复制项目，删除项目，修改项目，查询项目和其他方法。


###  数组的删除方法

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

### 数组的其他方法

TrueForAll<T>(T[], Predicate<T>)	
确定数组中的每个元素是否都与指定谓词定义的条件匹配。

(End)
