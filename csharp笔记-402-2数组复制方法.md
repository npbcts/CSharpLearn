## C# 自我初学笔记 第N章  数组方法属性

来源于: 根据[微软的.Net6文档](https://learn.microsoft.com/zh-cn/dotnet/api/system.array?view=net-6.0)整理。本文只对常用的知识整理，更详细需要查看链接指向的文档。

笔记中的代码成功运行在 [**此环境**](csharp笔记-000案例代码环境.md)，查看并使用方法属性时注意运行环境的版本区别。

C#中的数组类型是从抽象的基类型 `Array` 派生的引用类型。因此我们根据使用数组时根据`Array`的方法进行。同时，要更深入理解C#数组的特性也要从`Array`开始。


### `Array`的方法在c#中的实现

数组的方法主要分为复制项目，删除项目，修改项目，查询项目和其他方法。

#### >> 复制数组的方法

复制数组，转换类型至新数组。

- `Clone()`: 创建 Array 的浅表副本。
- `ConvertAll<TInput,TOutput>(TInput[], Converter<TInput,TOutput>)`: 
将一种类型的数组转换为另一种类型的数组。
- `ConstrainedCopy(Array, Int32, Array, Int32, Int32)`: 复制 Array 中的一系列元素（从指定的源索引开始），并将它们粘贴到另一 Array 中（从指定的目标索引开始）。 保证在复制未成功完成的情况下撤消所有更改。
- `Copy(Array, Array, Int32)`: 从第一个元素开始复制 `Array` 中的一系列元素，将它们粘贴到另一 `Array` 中（从第一个元素开始）。 长度指定为 32 位整数。
- `Copy(Array, Int32, Array, Int32, Int32)`: 复制 `Array` 中的一系列元素（从指定的源索引开始），并将它们粘贴到另一 `Array` 中（从指定的目标索引开始）。 长度和索引指定为 32 位整数。
- `CopyTo(Array, Int32)`: 从指定的目标数组索引处开始，将当前一维数组的所有元素复制到指定的一维数组中。 索引指定为 32 位整数。

上面方法中出现索引时，可以指定为 `64` 位整数类型。

`Clone()`方法复制时，改变源数组项目内容时，复制出的数组同样更改的例子:
```c#
public class ColneMethod
{
     public static void Main()
    {
        Student Luca = new Student("01", "Luca");
        Student Bob = new Student("02", "Bob");
        Student Dinesh = new Student("04", "Dinesh");
        Student[] students = new Student[] {Luca, Bob, Dinesh};
        // students浅复制给studentsNew
        Student[] studentsNew = (Student[])students.Clone();
        Console.WriteLine($"students第一个元素: {students[0].studentId}, {students[0].studentName}");
        Console.WriteLine($"studentsNew第一个元素: {studentsNew[0].studentId}, {studentsNew[0].studentName}");
        // 修改浅复制源students的引用类型元素值
        students[0].studentId = "XX";
        students[0].studentName = "XX";
        // 打印浅复制后的studentsNew
        Console.WriteLine($"students第一个元素: {students[0].studentId}, {students[0].studentName}");
        Console.WriteLine($"studentsNew第一个元素: {studentsNew[0].studentId}, {studentsNew[0].studentName}");

        /* 输出内容:
        students第一个元素: 01, Luca
        studentsNew第一个元素: 01, Luca
        students第一个元素: XX, XX
        studentsNew第一个元素: XX, XX
        */
    }

    class Student
    {
        public Student(string studentId, string studentName)
        {
            this.studentId = studentId;
            this.studentName = studentName;
        }
        public string studentId;
        public string studentName;
    }

}
```

使用`CopyTo`将数组(或一部分)复制给另一个数组的例子。
```c#
public class CopyToMethod
{
     public static void Main()
    {
        Student Luca = new Student("01", "Luca");
        Student Bob = new Student("02", "Bob");
        Student Dinesh = new Student("04", "Dinesh");
        Student[] students = new Student[] {Luca, Bob, Dinesh};
        
        Console.WriteLine($"students第一个元素: {students[0].studentId}, {students[0].studentName}");
        // 修改浅复制源students的引用类型元素值
        Student[] studentsNew = new Student[4];  //{Bob, Dinesh, Luca};
        students.CopyTo(studentsNew, 0);  // 从索引0开始，将students的所有元素复制给studentsNew
        // 打印浅复制后的studentsNew
        Console.WriteLine("==============");
        Console.WriteLine($"students第一个元素: {students[0].studentId}, {students[0].studentName}");
        Console.WriteLine($"studentsNew第一个元素: {studentsNew[0].studentId}, {studentsNew[0].studentName}");

        // 修改复制源
        students[0].studentId = "XX";
        students[0].studentName = "XX";
        // 修改复制源后打印studentsNew
        Console.WriteLine("==============");
        Console.WriteLine($"students第一个元素: {students[0].studentId}, {students[0].studentName}");
        Console.WriteLine($"studentsNew第一个元素: {studentsNew[0].studentId}, {studentsNew[0].studentName}");

        /* 输出内容:
        students第一个元素: 01, Luca
        ==============
        students第一个元素: 01, Luca
        studentsNew第一个元素: 01, Luca
        ==============
        students第一个元素: XX, XX
        studentsNew第一个元素: XX, XX
        */
    }

    class Student
    {
        public Student(string studentId, string studentName)
        {
            this.studentId = studentId;
            this.studentName = studentName;
        }
        public string studentId;
        public string studentName;
    }

}
```
此方法将当前数组实例的所有元素复制到 `array` 目标数组，从索引 `index`开始。 `array`目标数组必须已进行维度化，并且必须具有足够数量的元素来容纳复制的元素。**`CopyTo`它仅执行浅表副本**,同`Clone`的模式一致，即数组源的引用类型数据修改后，复制后的数组也将跟随修改。


`Copy` 方法的例子:
```c#
public class CopyMethod
{
     public static void Main()
    {
        Student Luca = new Student("01", "Luca");
        Student Bob = new Student("02", "Bob");
        Student Dinesh = new Student("04", "Dinesh");
        Student[] students = new Student[] {Luca, Bob, Dinesh};
        
        Console.WriteLine($"students第一个元素: {students[0].studentId}, {students[0].studentName}");
        // 修改浅复制源students的引用类型元素值
        Student[] studentsNew = new Student[students.Length];  //{Bob, Dinesh, Luca};
        
        Array.Copy(students, studentsNew, 1);  // 默认从索引0开始，将students的1个元素复制给studentsNew
        // 打印浅复制后的studentsNew
        Console.WriteLine("==============");
        Console.WriteLine($"students第一个元素: {students[0].studentId}, {students[0].studentName}");
        Console.WriteLine($"studentsNew第一个元素: {studentsNew[0].studentId}, {studentsNew[0].studentName}");

        // 修改复制源
        students[0].studentId = "XX";
        students[0].studentName = "XX";
        // 修改复制源后打印studentsNew
        Console.WriteLine("==============");
        Console.WriteLine($"students第一个元素: {students[0].studentId}, {students[0].studentName}");
        Console.WriteLine($"studentsNew第一个元素: {studentsNew[0].studentId}, {studentsNew[0].studentName}");

        /* 输出内容:
        students第一个元素: 01, Luca
        ==============
        students第一个元素: 01, Luca
        studentsNew第一个元素: 01, Luca
        ==============
        students第一个元素: XX, XX
        studentsNew第一个元素: XX, XX
        */
    }

    class Student
    {
        public Student(string studentId, string studentName)
        {
            this.studentId = studentId;
            this.studentName = studentName;
        }
        public string studentId;
        public string studentName;
    }

}
```
**`Copy`执行浅表副本**,同`Clone`和`CopyTo`的模式一致，即数组源的引用类型数据修改后，复制后的数组也将跟随修改。

数组内元素数据类型转换的例子:
```c#
public class ConertArrayType
{
     public static void Main()
    {
        string[] studentsId = {"01", "02", "03"};
        int[] studentsIdNew = Array.ConvertAll(studentsId, ConertType);
        Console.WriteLine($"students第一个元素: {studentsId[0]}, 类别：{studentsId[0] is string}");
        Console.WriteLine($"studentsNew第一个元素: {studentsIdNew[0]}, 类别 {studentsIdNew[0] is int}");

        /* 输出内容:
        students第一个元素: 01, 类别：True
        studentsNew第一个元素: 1, 类别 True
        */
    }

    public static int ConertType(string inputString)
    {
        return int.Parse(inputString);
    }

}
```
从例子中可以看出，`ConvertAll`中的第二个参数是针对每个数组元素转换的函数，即传入每个数组元素返回转换后的数组元素。

当然，为了简洁，可以使用`lambda`表达式作为转换函数参数。
```c#
public class ConertArrayType
{
     public static void Main()
    {
        string[] studentsId = {"01", "02", "03"};
        int[] studentsIdNew = Array.ConvertAll(studentsId, x => int.Parse(x));
        Console.WriteLine($"students第一个元素: {studentsId[0]}, 类别：{studentsId[0] is string}");
        Console.WriteLine($"studentsNew第一个元素: {studentsIdNew[0]}, 类别 {studentsIdNew[0] is int}");

        /* 输出内容:
        students第一个元素: 01, 类别：True
        studentsNew第一个元素: 1, 类别 True
        */
    }
}

```

(End)
