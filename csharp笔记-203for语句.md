## C# 自我初学笔记 第202章  多样的流程控制语句

来源于: Learn C# 初级自学教程:[for语句教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-for/1-introduction),
微软推出的初学者教程整理。


`for`语句虽然在某些场景下针对`foreach`的使用有优势，有时也很简洁，但并非不可替代。实际上通过特定的处理方法，可以全面使用`foreach`处理循环控制。放弃学习不影响使用的部分，可以有时间快速掌握语言的其他更重要部分的知识。

### `for`循环语句

一个最基本的`for`循环语句，它循环遍历其代码块十次，并执行代码块中的任务：
```c#
for (int i = 0; i < 10; i++)
{
    Console.WriteLine("something");
}
```

同样是代码块执行10次循环，使用foreach的替代写法:
```c#
int[] array = new int[10];
foreach (int i in array)
{
    Console.WriteLine("something");
}
```

`for`语句的语法:

`for` 语句有三个部分。

- `for` 关键字。
- 用于定义 `for` 迭代条件的一组括号。 它包含三个不同的部分，在语句运算符的末尾处由分号分隔。
    - 第一部分定义并初始化迭代器变量。 在本示例中：`int i = 0`。 文档将此部分称为初始化表达式。
    - 第二部分定义完成条件。 在本示例中：`i < 10`。 换言之，只要 `i` 小于 `10`，运行时就会持续遍历 `for` 语句下代码块中的代码。 当 `i` 等于 `10` 时，运行时停止执行 `for` 语句的代码块。 文档将此部分称为条件。
    - 第三部分定义每次迭代后要执行的操作。 在这种情况下，每次迭代后，`i++` 会将 `i` 的值增加 `1`。 文档将此部分称为迭代器。
- 最后来说说代码块。 这是每次迭代要执行的代码。 请注意，`i` 的值是在代码块内引用的。 文档将此部分称为主体。

#### 通过改变 for 语句的三个部分，可以改变其行为。

- 我们将迭代变量初始化为 10。  
- 我们将完成条件更改为：当 i 小于 0 时，退出 for 语句。  
- 我们将迭代器模式更改为：在每次完成迭代时从 i 中减去 1。  

关于计数器变量`i`的步长,是可以根据情况变化的,如需要从大至小循环:

```c#
for (int i = 10; i >= 0; i--)
{
    Console.WriteLine(i);
}
```
迭代步长为3的循环:
```c#
for (int i = 0; i < 10; i += 3)
{
    Console.WriteLine(i);
}
```
#### 使用 break 关键字中断迭代语句

```c#
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
    if (i == 7) break;
}
```
同时，`break`关键字可以中断其他分支流程，包括`foreach`语句。

#### *逆序*循环访问数组中的每个元素

虽然 foreach 会依次迭代数组中的每个元素，但还可以调整 for 语句以提供更多自定义。

```c#
string[] names = { "Alex", "Eddie", "David", "Michael" };
for (int i = names.Length - 1; i >= 0; i--)
{
    Console.WriteLine(names[i]);
}
```
我们注意到，上面的例子是从数组的末尾开始访问，正常的`foreach`语句无法实现。那么我们可以先将使用数组的`Reverse`方法逆序排列即可。
*但要注意，这么做对于小型数据的迭代并不会产生性能负担，但对于大规模数据，先逆序排列会有一定的性能损失。???性能是否损失有待考证，由于`Reverse`方法返回的是类似于"生成器"，在不实际使用时并不对其查询。*

`foreach`语句的等效实现:
```c#
string[] names = { "Alex", "Eddie", "David", "Michael" };
foreach (string name in names.Reverse())
{
    Console.WriteLine(name);
}
```

#### `for`迭代期间更新数组中的值

一般认为这是`foreach`语句的局限。不过也可以借助外部计数器实现。

先看下`for`循环实现方式(删除了花括号，因为代码块只包含单独一行代码。):
```c#
string[] names = { "Alex", "Eddie", "David", "Michael" };
for (int i = 0; i < names.Length; i++)
    if (names[i] == "David") names[i] = "Sammy";

foreach (var name in names) Console.WriteLine(name);
```
输出结果可以看出,数组中的值被改变了，实现了我们想要的效果:
```
Alex
Eddie
Sammy
Michael
```

`foreach`等效实现:

```c#
string[] names = { "Alex", "Eddie", "David", "Michael" };
int count = 0;
foreach (string name in names) 
{
    if (name == "David") names[count] = "Sammy"; count ++; 
}
foreach (var name in names) Console.WriteLine(name); 
```
