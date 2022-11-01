## C# 自我初学笔记 第八章 if语句

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-if-elseif-else/2-exercise-if),微软推出的初学者教程整理。

### 初步了解if语句

运用最广泛的分支语句是 if 语句。 if 语句依赖布尔表达式，后者用一组括号括起来。 如果表达式为 true，则执行 if 语句后面的代码。 如果表达式为 false，则跳过 if 语句后面的代码。
一个简单的if语句如下:
```c#
if 布尔表达式
    代码块
```
一个简单的摇骰仔游戏:
```c#
Random dice = new Random();
int roll = dice.Next(1, 7);

if (roll > 3)
{
    Console.WriteLine("You win!");
}
```
简单的理解是， 
- 布尔表达式是由`()`中返回`true`,`false`的代码构成。
- 代码块，是{}包括起来的一行或多行代码。
- if语句，根据布尔表达式的真假，选择执行代码块。

### 什么是布尔表达式？

布尔表达式是返回布尔值（true 或 false）的任意代码。 
#### 最简单的布尔表达式是值 `true` 和 `false`。   

#### 此外，布尔表达式可以是返回值 `true` 或 `false` **结果的方法**。  

例如，下面是一个简单的代码示例，它使用 string.Contains() 方法计算某个字符串是否包含另一个字符串：
```c#
string message = "The quick brown fox jumps over the lazy dog.";
bool result = message.Contains("dog");
Console.WriteLine(result);
if (message.Contains("fox"))
{
    Console.WriteLine("What does the fox say?");
}
```
#### 其他简单的布尔表达式可通过使用运算符比较两个值进行创建。 
运算符包括:
- `==`，用于测试是否相等的“等于”运算符。
- `>`，用于测试左边的值是否大于右边的值的“大于”运算符。
- `<`，用于测试左边的值是否小于右边的值的“小于”运算符。
- `>=`，“大于或等于”运算符。
- `<=`，“小于或等于”运算符。

[更详细的布尔表达式教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-evaluate-boolean-expressions/)

### 代码块
代码块是包含一行或多行代码的集合，其中代码行由左大括号和右大括号 { } 定义。 它表示在软件系统中用途单一的完整代码单位。   
在此情况下，如果布尔表达式为 true，则会在运行时执行代码块中的所有代码行。 反之，如果布尔表达式为 false，则会忽略代码块中的所有代码行。  
C# 中存在许多级别的代码块。 实际上，.NET 编辑器隐藏了这样一个事实，即我们的代码是在定义某一方法的代码块中执行的。  

[更详细的关于代码块的知识教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-code-blocks/)

### 逻辑运算符
逻辑运算符合并了多个布尔表达式，以在单行代码中创建一个复合布尔表达式。

双竖线分隔符 `||` 是“逻辑或”运算符，主要表示“要使整个布尔表达式为 `true`，要么左侧表达式必须为 `true`，要么右侧表达式必须为 `true`”。 如果两个布尔表达式均为 `false`，则整个布尔表达式为 `false`。 我们使用两个“逻辑或”运算符，以便可将计算扩展到第三个布尔表达式。

双与字符 `&&` 是“逻辑与”运算符，主要表示“只有当两个表达式均为 `true` 时，整个表达式才为 `true`”。 


### 稍微复杂的随机数游戏

我们来创造一种游戏，用于帮助我们编写 if 语句。 我们将为该游戏创建几条规则，然后在代码中实现它们。

我们将使用 Random.Next() 方法来模拟抛掷三个六面骰子。 我们将评估值以计算得分。 如果得分大于任意总和，则向用户显示一条获胜消息。 否则，向用户显示一条失败消息。

如果抛掷任何两个骰子得到相同的值，则因两个骰子投出同样的点数获得两点奖励得分。
如果抛掷全部三个骰子都得到相同的值，则因三个骰子投出同样的点数获得六点奖励得分。
如果三个骰子投出的点数之和加上所有奖励点数大于等于 15，则你赢得比赛。 否则，就是你输了。

初步的代码实现:
```c#
Random dice = new Random();
int roll1 = dice.Next(1, 7);
int roll2 = dice.Next(1, 7);
int roll3 = dice.Next(1, 7);
int total = roll1 + roll2 + roll3;
Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

if (roll1==roll2 || roll3==roll2 || roll1==roll3)
{
    Console.WriteLine("You rolled doubles! +2 bonus to total!");
    total += 2;
}

if ((roll1==roll2) && (roll2==roll3))
{
    Console.WriteLine("You rolled doubles! +6 bonus to total!");
    total += 6;
}

if (total >= 15)
{
    Console.WriteLine("You win!");
}

if (total < 15)
{
    Console.WriteLine("Sorry, You loss!");
}
```

### 使用else和内嵌if语句完善随机数游戏

通过嵌套，我们可以将代码块放在代码块中。 在此情况下，我们将 if 和 else 语句（检查是否有三倍奖励）嵌套在另一个 if 语句（检查是否有两倍奖励）中，以防止两种情况同时发生。

```c#
Random dice = new Random();
int roll1 = dice.Next(1, 7);
int roll2 = dice.Next(1, 7);
int roll3 = dice.Next(1, 7);
int total = roll1 + roll2 + roll3;
Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

if (roll1==roll2 || roll3==roll2 || roll1==roll3)
{
    if ((roll1==roll2) && (roll2==roll3))
    {
        Console.WriteLine("You rolled doubles! +6 bonus to total!");
        total += 6;
    }
    else
    {
    Console.WriteLine("You rolled doubles! +2 bonus to total!");
    total += 2;
    }
}

if (total >= 15)
{
    Console.WriteLine("You win!");
}
else
{
    Console.WriteLine("Sorry, You loss!");
}
```
### else if拓展更多条件分支

可以使用 if、else 和 else if 语句创建多个排他性条件作为布尔表达式。 换言之，如果你只希望产生一种结果，但却有多个可能的条件和结果，则根据需要使用任意数量的 else if 语句。 如果 if 和 else if 语句均不适用，则将执行最后的 else 代码块。 **else 是可选的，但必须最后执行**。

为了使游戏更有趣，我们将游戏从输赢结果改为对每个分数奖励虚拟奖品。 我们将提供 4 个奖品。 玩家应该只赢取一个奖品：

- 如果玩家的分数大于等于 16，则赢得一辆新车。
- 如果玩家的分数大于等于 10，则赢得一台新的笔记本电脑。
- 如果玩家的分数正好为 7，则赢得一次旅行机会。
- 否则，玩家赢得一只小猫。

最后部分的代码更改如下:
```c#
if (total >= 16)
{
    Console.WriteLine("You win a new car!");
}
else if (total >= 10)
{
    Console.WriteLine("You win a laptop!");
}
else if (total >= 7)
{
    Console.WriteLine("You win a trip!");
}
else
{
    Console.WriteLine("You win a kittem!");
}
```

(End)