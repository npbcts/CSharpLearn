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
### 数组数据处理的常用方法

#### 增: 数组数据类型不能增加项目

C#数组继承了.NET中`Array`的特性:
`Array`具有固定容量。 若要增加容量，必须创建具有所需容量的新`Array`对象，将元素从旧 `Array` 对象复制到新对象，然后删除旧`Array`对象。

#### 删: 删除数组的项目

数组数据类型不能删除项目，但能将已有项目删除至默认值。可以使用`IList.Clear()`移除所有或部分数组项目。

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

数组更多的增删改查见下一篇笔记: 数组方法属性。

(End)