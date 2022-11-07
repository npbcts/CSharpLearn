## C# 自我初学笔记 第N章  

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/arrays/jagged-arrays)整理。


### 多维数组

#### 初始化
数组可具有多个维度。 例如，以下声明创建一个具有四行两列的二维数组:
```c#
int[,] array = new int[4, 2];
```
以下声明创建一个具有三个维度（4、2 和 3）的数组:
```c#
int[,,] array1 = new int[4, 2, 3];
```
还可在不指定级别的情况下初始化数组:
```c#
int[,] array4 = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
```
如果选择在不初始化的情况下声明数组变量，则必须使用 new 运算符将数组赋予变量。 new 的用法如以下示例所示。
```c#
int[,] array5;
array5 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };   // OK
```
#### 获取值
```c#
array5[2, 1] = 25;
```
#### 设置值
```c#
int elementValue = array5[2, 1];
```

### 交错数组

交错数组是一个数组，其元素是数组，大小可能不同。 交错阵列有时称为“数组的数组”。

一个初始化和赋值交错数组的例子:
```c#
public class jaggedArray
{

    public static void Main()
    {
        int[][] jaggedArray = new int[3][];
        jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
        jaggedArray[1] = new int[] { 0, 2, 4, 6 };
        jaggedArray[2] = new int[] { 11, 22 };
        PrintJaggedArray(jaggedArray);
    }

    public static void PrintJaggedArray(int[][] jaggedArray)
    {
        foreach(int indexOuter in Enumerable.Range(0, jaggedArray.GetUpperBound(0)+1))
        {
            int[] arrayInner = jaggedArray[indexOuter];
            foreach(int indexIndex in Enumerable.Range(0, arrayInner.GetUpperBound(0)+1))
            {
                Console.WriteLine($"数组索引[ {indexOuter}, {indexIndex}], 数组值 : {arrayInner[indexIndex]}");
            }
        }
    }
}

/*输出
数组索引[ 0, 0], 数组值 : 1
数组索引[ 0, 1], 数组值 : 3
数组索引[ 0, 2], 数组值 : 5
数组索引[ 0, 3], 数组值 : 7
数组索引[ 0, 4], 数组值 : 9
数组索引[ 1, 0], 数组值 : 0
数组索引[ 1, 1], 数组值 : 2
数组索引[ 1, 2], 数组值 : 4
数组索引[ 1, 3], 数组值 : 6
数组索引[ 2, 0], 数组值 : 11
数组索引[ 2, 1], 数组值 : 22
*/
```

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


(End)