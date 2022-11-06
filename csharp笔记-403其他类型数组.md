## C# 自我初学笔记 第N章  

来源于: 根据[微软的.Net6文档]()整理。



### 多维数组


### 交错数组

### 隐士类型数组

可以创建隐式类型化的数组，其中数组实例的类型通过数组初始值设定项中指定的元素来推断。 针对隐式类型化变量的任何规则也适用于隐式类型化数组。 有关详细信息，请参阅[隐式类型局部变量](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables)。

隐式类型化数组通常用于查询表达式、匿名类型、对象和集合初始值设定项。

```c#
class ImplicitlyTypedArraySample
{
    static void Main()
    {
        var a = new[] { 1, 10, 100, 1000 }; // int[]
        var b = new[] { "hello", null, "world" }; // string[]

        // single-dimension jagged array
        var c = new[]
        {
            new[]{1,2,3,4},
            new[]{5,6,7,8}
        };

        // jagged array of strings
        var d = new[]
        {
            new[]{"Luca", "Mads", "Luke", "Dinesh"},
            new[]{"Karen", "Suma", "Frances"}
        };
    }
}
```

```c#

```

```c#

```

```c#

```

(End)