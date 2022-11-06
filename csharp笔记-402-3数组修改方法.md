## C# 自我初学笔记 第N章  数组方法属性

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.array?view=net-6.0)整理。本文只对常用的知识整理，更详细需要查看链接指向的文档。

笔记中的代码成功运行在 [**此环境**](csharp笔记-000案例代码环境.md)，查看并使用方法属性时注意运行环境的版本区别。

C#中的数组类型是从抽象的基类型 `Array` 派生的引用类型。因此我们根据使用数组时根据`Array`的方法进行。同时，要更深入理解C#数组的特性也要从`Array`开始。


### `Array`的方法在c#中的实现

数组的方法主要分为复制项目，删除项目，修改项目，查询项目和其他方法。


###  >> 修改数组的方法

修改数组的方法设计: 数组的排序，反转，设置值。下面的修改数组的方法都会对原数组进行修改。


- `Reverse(Array)`: 反转整个一维 Array 中元素的顺序。
- `Reverse(Array, Int32, Int32)`: 反转一维 Array 中元素子集的顺序。
- `Reverse<T>(T[])`: 反转一维泛型数组中元素的顺序。
- `Reverse<T>(T[], Int32, Int32)`: 反转一维泛型数组中元素子集的顺序。
- `SetValue(Object, Int32)`: 将值设置为一维 Array 中指定位置的元素。 索引指定为 32 位整数。
- `SetValue(Object, Int32, Int32)`: 将某值设置给二维 Array 中指定位置的元素。 索引指定为 32 位整数。
- `Sort(Array)`: 使用 Array 中每个元素的 IComparable 实现，对整个一维 Array 中的元素进行排序。
- `Sort(Array, Array)`: 基于第一个 Array 中的关键字，使用每个关键字的 IComparable 实现，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）进行排序。
- `Sort(Array, Array, IComparer)`: 基于第一个 Array 中的关键字，使用指定的 IComparer，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）进行排序。
- `Sort(Array, Array, Int32, Int32)	`: 基于第一个 Array 中的关键字，使用每个关键字的 IComparable 实现，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序。
- `Sort(Array, Array, Int32, Int32, IComparer)`: 基于第一个 Array 中的关键字，使用指定的 IComparer，对两个一维 Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序。
- `Sort(Array, IComparer)`: 使用指定的 IComparer，对一维 Array 中的元素进行排序。
- `Sort(Array, Int32, Int32)`: 使用 Array 中每个元素的 IComparable 实现，对一维 Array 中的部分元素进行排序。
- `Sort(Array, Int32, Int32, IComparer)	`: 使用指定的 IComparer，对一维 Array 中的部分元素进行排序。

`SetValue`中设计`Int32`类型，可以使用`Int64`数据。

一个使用`Reverse(Array)`反转数组的例子:
```c#
public class TestReverse
{
     public static void Main()
    {
        int[] studentsId = {1, 2, 3};
        PrintArray(studentsId);
        Array.Reverse(studentsId);
        PrintArray(studentsId);

        /* 输出内容:
        1 2 3 
        3 2 1 
        */
    }
    public static void PrintArray(int[] arr)
    {
        foreach (int a in arr)
        {
            Console.Write($"{a} ");
        }
        Console.WriteLine();
    }
}
```

一个使用`Reverse(Array)`重载方法反转**部分数组**的例子:
```c#
public class TestReverse
{
     public static void Main()
    {
        int[] studentsId = {1, 2, 3, 4, 5};
        PrintArray(studentsId);
        Array.Reverse(studentsId, 1, 3); // 从第一个元素开始，一共反转三个元素
        PrintArray(studentsId);

        /* 输出内容:
        1 2 3 4 5 
        1 4 3 2 5 
        */
    }
    public static void PrintArray(int[] arr)
    {
        foreach (int a in arr)
        {
            Console.Write($"{a} ");
        }
        Console.WriteLine();
    }
}
```

使用`SetValue(Object, Int32)`设置数组值的例子:
```c#
public class TestSetValue
{
     public static void Main()
    {
        int[] studentsId = {1, 2, 3, 4, 5};
        PrintArray(studentsId);
        studentsId.SetValue(100, 3); // 设置第三个元素为100
        PrintArray(studentsId);

        /* 输出内容:
        1 2 3 4 5 
        1 2 3 100 5 
        */
    }
    public static void PrintArray(int[] arr)
    {
        foreach (int a in arr)
        {
            Console.Write($"{a} ");
        }
        Console.WriteLine();
    }
}
```

使用`Sort()`方法对数组排序:
```c#
public class SortArray
{
     public static void Main()
    {
        int[] studentsId = {1, 4, 5, 2, 3, 10};
        PrintArray(studentsId);  // 打印数组
        Array.Sort(studentsId);
        PrintArray(studentsId);  // 打印排序后的数组

        /* 输出内容:
        1 4 5 2 3 10 
        1 2 3 4 5 10 
        */
    }
    public static void PrintArray(int[] arr)
    {
        foreach (int a in arr)
        {
            Console.Write($"{a} ");
        }
        Console.WriteLine();
    }
}
```

使用`Sort()`重载方法对数组一部分排序:
```c#
public class TestSort
{
     public static void Main()
    {
        int[] studentsId = {1, 4, 5, 2, 3, 10};
        PrintArray(studentsId);
        Array.Sort(studentsId, 1, 3);
        // studentsId.SetValue(100, 3); // 从第一个元素开始，一共反转三个元素
        PrintArray(studentsId);

        /* 输出内容:
        1 4 5 2 3 10 
        1 2 4 5 3 10  
        */
    }
    public static void PrintArray(int[] arr)
    {
        foreach (int a in arr)
        {
            Console.Write($"{a} ");
        }
        Console.WriteLine();
    }
}
```

(End)
