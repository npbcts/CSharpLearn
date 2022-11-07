## C# 自我初学笔记 第N章  

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.ienumerable-1?view=net-6.0)整理。

`IEnumerable<T>` 接口有很多方法，此笔记只记录常用方法。想要了解更多，可以查看文档原文。

### [Enumerable.Select 方法](https://learn.microsoft.com/zh-cn/dotnet/api/system.linq.enumerable.select?view=net-6.0#system-linq-enumerable-select-2(system-collections-generic-ienumerable((-0))-system-func((-0-1))))

定义: 将序列中的每个元素投影到新表单。
基础的`Select`接口有两个重载:

- `Select<TSource,TResult>(IEnumerable<TSource>, Func<TSource,TResult>)`:	
将序列中的每个元素投影到新表单。
- `Select<TSource,TResult>(IEnumerable<TSource>, Func<TSource,Int32,TResult>)`:	
通过合并元素的索引，将序列的每个元素投影到新窗体中。

使用第一个重载方法的例子:
```c#
public class Example
{
    public static void Main()
    {
        int[] numbers = {1, 2, 3, 4};
        var squaredNumbers = numbers.Select(x => x * x);
        Console.WriteLine(string.Join(" ", squaredNumbers));
    }
}

//输出内容:
//1 4 9 16
```

- `SelectMany<TSource,TResult>(IEnumerable<TSource>, Func<TSource,IEnumerable<TResult>>)`:	
将序列的每个元素投影到 IEnumerable<T> 并将结果序列合并为一个序列。
- `SelectMany<TSource,TResult>(IEnumerable<TSource>, Func<TSource,Int32,IEnumerable<TResult>>)`:	
将序列的每个元素投影到 IEnumerable<T> 并将结果序列合并为一个序列。 每个源元素的索引用于该元素的投影表。
- `SelectMany<TSource,TCollection,TResult>(IEnumerable<TSource>, Func<TSource,IEnumerable<TCollection>>, Func<TSource,TCollection,TResult>)`:	
将序列的每个元素投影到 IEnumerable<T>，并将结果序列合并为一个序列，并对其中每个元素调用结果选择器函数。
- `SelectMany<TSource,TCollection,TResult>(IEnumerable<TSource>, Func<TSource,Int32,IEnumerable<TCollection>>, Func<TSource,TCollection,TResult>)`:	
将序列的每个元素投影到 IEnumerable<T>，并将结果序列合并为一个序列，并对其中每个元素调用结果选择器函数。 每个源元素的索引用于该元素的中间投影表。


### `Min` 和 `Max`

- `Min<TSource>(IEnumerable<TSource>)`:返回泛型序列中的最小值。
- `Min<TSource>(IEnumerable<TSource>, IComparer<TSource>)`:	返回泛型序列中的最小值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Decimal>)`:对序列中的每个元素调用转换函数，并返回最小的 Decimal 值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Double>)`:对序列中的每个元素调用转换函数，并返回最小的 Double 值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Int32>)`:对序列中的每个元素调用转换函数，并返回最小的 Int32 值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Int64>)`:对序列中的每个元素调用转换函数，并返回最小的 Int64 值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Decimal>>)`:对序列中的每个元素调用转换函数，并返回可以为 null 的最小的 Decimal 值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Double>>)`:	对序列中的每个元素调用转换函数，并返回可以为 null 的最小的 Double 值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int32>>)`:对序列中的每个元素调用转换函数，并返回可以为 null 的最小的 Int32 值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Int64>>)`:	对序列中的每个元素调用转换函数，并返回可以为 null 的最小的 Int64 值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Nullable<Single>>)`:	对序列中的每个元素调用转换函数，并返回可以为 null 的最小的 Single 值。
- `Min<TSource>(IEnumerable<TSource>, Func<TSource,Single>)`:对序列中的每个元素调用转换函数，并返回最小的 Single 值。
- `Min<TSource,TResult>(IEnumerable<TSource>, Func<TSource,TResult>)`:对序列中的每个元素调用转换函数，并返回最小结果值。
- `MinBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>)`:根据指定的键选择器函数返回泛型序列中的最小值。
- `MinBy<TSource,TKey>(IEnumerable<TSource>, Func<TSource,TKey>, IComparer<TKey>)`:	根据指定的键选择器函数和键比较器返回泛型序列中的最小值。

使用`Min<TSource>(IEnumerable<TSource>)`的例子:
```c#
int[] numbers = {1, 2, 3, 4};
Console.WriteLine(numbers.Min());

// 输出
// 1
```


(End)