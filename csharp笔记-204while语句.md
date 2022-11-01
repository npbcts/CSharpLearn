## C# 自我初学笔记 第202章  多样的流程控制语句

来源于: Learn C# 初级自学教程:[while语句教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-do-while/)，微软推出的初学者教程整理。

`do-while` 和 `while` 语句是可用于循环访问代码块，从而更改代码执行流的更多迭代语句。`do-while/while`迭代语句的运行原理，是在不知道循环次数时根据提供的布尔值判断结束循环过程。

### do while循环

当指定布尔表达式的计算结果为 true 时，do 语句执行语句或语句块。 由于在每次执行循环之后都会计算此表达式，所以 do-while 循环会执行一次或多次。

```c#
Random random = new Random();
int current = 0;

do
{
    current = random.Next(1, 11);
    Console.WriteLine(current);
} while (current != 7);
```
当`current`等于7时，`while`后的布尔判断为真，循环结束。
>请注意，代码块中的代码会影响是否继续循环访问代码块。 这是区分 do-while 和 while 语句的关键特征。 foreach 和 for 都依赖于代码块的外部因素来确定执行流是否应该继续执行代码块。

### while循环

语句首先计算布尔表达式，只要布尔表达式的计算结果为 true，就会继续循环访问代码块。如果第一次计算的结果为`false`，那么`while`代码块部分永远不会执行。

```c#
Random random = new Random();
int current = random.Next(1, 11);

while (current >= 3)
{
    Console.WriteLine(current);
    current = random.Next(1, 11);
}
Console.WriteLine($"Last number: {current}");
```
在本例中，我们将 while 关键字和布尔表达式放在代码块前面。 这种做法会改变代码的含义，并且充当“门户”，仅在布尔表达式的计算结果为 true 时才允许执行流进入。

### `continue`和`break`关键字

`continue`可以跳过循环代码块后面的部分，从循环代码块开始判断部分继续执行。

```c#
Random rnd = new Random();
int current = rnd.Next(1, 11);

while (current>=3)
{
    current = rnd.Next(1, 11);

    if (current>=8) continue;

    Console.WriteLine(current);
}
Console.WriteLine($"Last number: {current}");

```
上面的例子中，会不打印8及以上的数字。


```c#
Random rnd = new Random();
int current = rnd.Next(1, 11);

while (current>=3)
{
    current = rnd.Next(1, 11);

    if (current>=8) 
    {
        Console.WriteLine("find number bigger than 8, and stop loop");
        break;
    }
    Console.WriteLine(current);
}
Console.WriteLine($"Last number: {current}");

```

上面的例子中，发现8及以上的数字时循环终止。
