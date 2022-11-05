## C# 自我初学笔记 第N章  

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-readable-code/2-choose-variable-names),微软推出的初学者教程整理。


由于我们只编写一次代码但会多次阅读，因此提高可读性将有助于长期维护和支持代码。


### 变量的命名规则
*此部分在[05变量基础知识](CSharp笔记-05变量基础知识.md)中也有讲述*

一位软件开发人员曾经说过一句名言：“软件开发最难的部分就是命名。”变量的名称不仅必须遵循某些语法规则，还应使代码更易于用户阅读和理解。 编写单个代码行的要求非常多！

下面是有关变量名的一些重要注意事项：

- 变量名可包含**字母数字字符和下划线字符**。 不允许使用特殊字符，如哈希符号 #（也称为数字符号或井符号）或美元符号 $。
- 变量名必须以**字母**或下划线开头，不能以数字开头。 开发者将下划线用于特殊目的，因此现在请勿使用。
- 变量名不能是 C# 关键字。 例如，不能使用以下变量声明：decimal decimal; 或 string string;。
- 变量名区分大小写，这意味着 string Value; 和 string value; 是两个不同的变量。
变量名**应使用骆驼式命名法**，这是一种编写样式，即第一个单词以小写字母开始，后续每个单词的- 首字母采用大写形式。 例如 string thisIsCamelCase;。
- 变量名在应用程序中应具有描述性且有意义。 为变量选择一个名称，用于表示其将保存的数据类型。
- 变量名应是附加在一起的一个或多个完整字词。 请勿使用缩写，因为阅读你的代码的人可能不清楚该变量的名称（以及其用途）。
- 变量名称**不应包含变量的数据类型**。 你可能会看到使用类似 string strValue; 样式的一些建议。 该建议已不适用于最新情况。

变量符合约定的命名示例:

```c#
char userOption;

int gameScore;

float particlesPerMillion;

bool processedCustomer;
```

约定是软件开发社区一致同意的建议。 虽然你可以自由决定不遵循这些约定，但是它们非常受欢迎，如果不遵循可能会使其他开发人员难以理解你的代码。 你应该练习采用这些约定，并将其作为自己的一部分技能。

### 其他命名约定

我们所讨论的规则和约定适用于局部变量。 局部变量是作用域在方法主体内的变量。
其他涉及变量命名的部分有：
- 类中还使用了其他类型的变量。 类支持字段，字段是类的成员，作用类似于变量，因为它们存储值，或者更确切地说是存储状态。
- 私有字段和公共字段有其自己的命名约定。
- 类和方法也有其自己的命名约定。

普通变量命名约定适合更大型的命名框架。 最终目标是仅仅通过查看任何标识符（局部变量、私有字段、类、方法等）的名称，就应该能够立即了解代码的功能。

### 代码注释

代码注释是一条指令，用于指示编译器忽略当前行中代码注释符号后面的一切内容。

单行注释:
```c#
// 这是一条代码注释!
```

多行注释:
```c#
/*
这是多行注释
这是多行注释
*/
```

一开始，这似乎没有用。 但它在三种情况下很有用：

- 记录意图。当你想记下一段代码的意图时。 当你准备编写一组极具挑战性的代码指令时，这有助于描述用途或思考过程。 将来的你会感谢自己。

- 暂时删除。当你想暂时删除应用程序中的代码，以尝试其他方法，但不确信新想法是否有用时。 可以注释掉代码，编写新代码，一旦你确定新代码会按预期方式运行时，就可安全地删除旧代码（注释代码）。

- 添加TODO。添加类似于 TODO 的消息，以提醒自己稍后查看特定的代码段。 你应该明智地使用此消息，这是一个有效原因。 当阅读到引起你关注的代码行时，你可能正在使用另一项功能。 你可以对其进行标记以便稍后调查，而不是忽略关注的新代码行。 Visual Studio IDE(Code) 甚至提供名为“任务列表”的窗口，以帮助你识别你在代码中记下的 TODO 消息。

> 注意: 代码注释不可信任。 通常，开发人员会更新其代码，但忘记更新代码注释。 **最好使用注释来描述更高级别的想法**，请勿添加关于单个代码行如何工作的注释。


### 不可取的注释和好的注释

#### 一个关于注释的错误示范：
```c#
Random random = new Random();
string[] orderIDs = new string[5];
// Loop through each blank orderID
for (int i = 0; i < orderIDs.Length; i++)
{
    // Get a random value that equates to ASCII letters A through E
    int prefixValue = random.Next(65, 70);
    // Convert the random value into a char, then a string
    string prefix = Convert.ToChar(prefixValue).ToString();
    // Create a random number, padd with zeroes
    string suffix = random.Next(1, 1000).ToString("000");
    // Combine the prefix and suffix together, then assign to current OrderID
    orderIDs[i] = prefix + suffix;
}
// Print out each orderID
foreach (var orderID in orderIDs)
{
    Console.WriteLine(orderID);
}

```
此代码存在两个问题：

- 代码注释不必要地解释了单独代码行的明显功能。 这些被视为低质量的注释，因为它们只解释了 C# 或 .NET 类库的方法如何工作。 如果读者不熟悉这些内容，他们可以使用 Microsoft Docs 或 Intellisense 来查阅。
- 代码注释未提供代码所解决问题的任何上下文。 这些被视为低质量的注释，因为**读者无法了解此代码的用途**，尤其是在涉及到更大的系统时。

#### 优秀注释案例

```c#
/*
  The following code creates five random OrderIDs
  to test the fraud detection process.  OrderIDs 
  consist of a letter from A to E, and a three
  digit number. Ex. A123.
*/
Random random = new Random();
string[] orderIDs = new string[5];

for (int i = 0; i < orderIDs.Length; i++)
{
    int prefixValue = random.Next(65, 70);
    string prefix = Convert.ToChar(prefixValue).ToString();
    string suffix = random.Next(1, 1000).ToString("000");

    orderIDs[i] = prefix + suffix;
}

foreach (var orderID in orderIDs)
{
    Console.WriteLine(orderID);
}
```
注释是否无用是一种主观意识。 只要与代码可读性相关的事，都应该相信自己最合理的判断。 做你认为最能清楚描述代码的事。

### 使用空格增加代码的可读性 [教程地址](https://learn.microsoft.com/zh-cn/training/modules/csharp-readable-code/4-exercise-use-whitespace#code-try-13)

印刷和 Web 设计师明白，在一个小型空间中放置太多信息会使阅读者眼花缭乱，因此他们会战略性地使用空格或负空间来分解信息，以最大程度地提高阅读者理解所传达的主要信息的能力。

当开发者在编辑器中编写代码时，他们可以使用类似的策略。 通过使用空格传达含义，开发者可以更清楚地传达代码意图。

#### 空格和代码可读性

**术语“空格”指的是由 space bar 生成的单个空格、由 tab 键生成的制表符以及由 enter 键生成的新行。C# 编译器会忽略空格。**

下面这段代码是错误的示范：
```c#
// Example 1:
Console
.
WriteLine
(
"Hello World!"
)
;

// Example 2:
string firstWord="Hello";string lastWord="World";Console.WriteLine(firstWord+" "+lastWord+"!");
```

上面的这两段代码可以运行并得出正确的结果。这两个代码示例说明了两个重要概念：

- 空格对编译器而言不重要。 但是…
- 正确使用空格可以提高你阅读和理解代码的能力。

你可能只需编写一次代码，但需要多次阅读代码。 因此，应注重所编写代码的可读性。 你会逐渐意识到使用空格（如空格字符、制表符和新行）的好处。

#### 正确使用空格的规范

正确的示范:
```c#
Random dice = new Random();

int roll1 = dice.Next(1, 7);
int roll2 = dice.Next(1, 7);
int roll3 = dice.Next(1, 7);

int total = roll1 + roll2 + roll3;
Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3)) 
{
    if ((roll1 == roll2) && (roll2 == roll3)) 
    {
        Console.WriteLine("You rolled triples!  +6 bonus to total!");
        total += 6; 
    } 
    else 
    {
        Console.WriteLine("You rolled doubles!  +2 bonus to total!");
        total += 2;
    }
}

```

好的代码书写格式一般原则：

- 每个完整的命令（语句）都属于单独的一行。
- 如果单个代码行过长，可以将其拆分。 但是，不应随意将单个语句拆分为多行，除非你有充分的理由这样做。
- 在赋值运算符的左侧和右侧使用空格。
- 执行相似或相关操作的两个、三个或四个代码行之间引入空行。尝试了将相似或协同工作的代码行放在一起，以完成一些小任务。
- `{` 和 `}` 符号可创建代码块。 许多 `C#` 构造都需要代码块。 应将这些符号放在单独的行中，以便其边界清晰可见且可阅读。
- 请务必使用 `tab` 键使代码块符号在其所属的关键字下方对齐。 可以理解为，if语句的执行模块应该和语句的关键词保持在同一缩进列，这样更能清晰表达相互之间的关系。其他语句也应该遵循此规范。

(End)
