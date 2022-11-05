## C# 自我初学笔记 第N章  字典初始化

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer),微软推出的初学者教程整理。


Dictionary<TKey,TValue> 包含键/值对集合。  
若要初始化 Dictionary<TKey,TValue>,有如下方法 :

- Add 方法采用多个参数的任何集合，其 Add 方法采用两个参数，一个用于键，一个用于值。  
- 一种方法是将每组参数括在大括号中，如下面的示例中所示。 
- 另一种方法是使用索引初始值设定项，如下面的示例所示。


### Add方法初始化

将`students`变量声明`Dictionary<int, StudentName>()`类后，实际上为空字典。`Add`能为字典数据添加键值对。

示例代码:
```c#
public class HowToDictionaryInitializer
{
    class StudentName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
    }

    public static void Main()
    {
        var students = new Dictionary<int, StudentName>();
        students.Add(111, new StudentName { FirstName="Sachin", LastName="Karnik", ID=211 });
        students.Add(112, new StudentName { FirstName="Dina", LastName="Salimzianova", ID=317 });
        students.Add(113, new StudentName { FirstName="Andy", LastName="Ruth", ID=198 });

        foreach(var index in Enumerable.Range(111, 3))
        {
            Console.WriteLine($"Student {index} is {students[index].FirstName} {students[index].LastName}");
        }
        Console.WriteLine();
    }
}
```


### 直接赋值法

字典的整个集合初始值设定项被括在大括号中，并赋值给`students`变量。

示例代码：
```c#
public class HowToDictionaryInitializer
{
    class StudentName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
    }

    public static void Main()
    {
        var students = new Dictionary<int, StudentName>()
        {
            { 111, new StudentName { FirstName="Sachin", LastName="Karnik", ID=211 } },
            { 112, new StudentName { FirstName="Dina", LastName="Salimzianova", ID=317 } },
            { 113, new StudentName { FirstName="Andy", LastName="Ruth", ID=198 } }
        };

        foreach(var index in Enumerable.Range(111, 3))
        {
            Console.WriteLine($"Student {index} is {students[index].FirstName} {students[index].LastName}");
        }
        Console.WriteLine();
    }
}
```


### 使用索引初始值设定项

初始化使用 Dictionary 类的公共读取/写入索引器方法：

示例代码：
```c#
public class HowToDictionaryInitializer
{
    class StudentName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
    }

    public static void Main()
    {
        var students = new Dictionary<int, StudentName>()
        {
            [111] = new StudentName { FirstName="Sachin", LastName="Karnik", ID=211 },
            [112] = new StudentName { FirstName="Dina", LastName="Salimzianova", ID=317 } ,
            [113] = new StudentName { FirstName="Andy", LastName="Ruth", ID=198 }
        };

        foreach (var index in Enumerable.Range(111, 3))
        {
            Console.WriteLine($"Student {index} is {students[index].FirstName} {students[index].LastName}");
        }
    }
}
```

(End)