## C# 自我初学笔记 第N章  数据类型转换

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-convert-cast/3-exercise-tryparse),微软推出的初学者教程整理。


#### 使用 `ToString()` 将数字转换为字符串

每个数据类型变量都具有 ToString() 方法。 ToString() 方法的作用取决于它在给定类型上的实现方式。 但在大多数基元中，该方法执行扩大转换,即**不会损失信息,也不会引发异常**。 

一个使用`ToString()` 方法的例子：
```c#
int first = 5;
int second = 7;
string message = first.ToString() + second.ToString();
Console.WriteLine(message);
```
输出`57`

### 将字符串显式转换为数字: 不鼓励使用的 `Parse()` 方法
大部分数字数据类型都具有 Parse() 方法，可将字符串转换为给定的数据类型。 在这种情况下，我们使用 Parse() 方法将两个字符串转换为 int 值，然后将二者相加。

```c#
string first = "5";
string second = "7";
int sum = int.Parse(first) + int.Parse(second);
Console.WriteLine(sum);
```
输出`12`
示例代码输出了我们想要的结果，但存在转换过程中的隐患。当`first="a"`时，即将 `first` （或 `second`） 变量设置为无法转换为 int 的值，会发生什么情况呢？ 会在运行时引发异常。 

### 值得鼓励的转换方式：使用TryParse()

一个使用`int.Parse`引发异常的例子
```c#
string name = "Bob";
Console.WriteLine(int.Parse(name));
```
若要避免格式异常，请对目标数据类型使用 TryParse () 方法。

TryParse() 方法可同时执行多项操作：

- 它会尝试将字符串分析成给定的数字数据类型。
- 如果成功，它会将转换后的值存储在 out 参数中。
- 它将返回一个布尔值，指示操作是成功还是失败。

```c#
string value = "102";
int result = 0;
if (int.TryParse(value, out result))
    Console.WriteLine($"Measurement: {result}");
else
    Console.WriteLine("Unable to report the measurement.");
```
运行代码时，应会看到以下输出：
```
Measurement: 102
```
示例中，我们使用 int 数据类型，但对于所有数字数据类型，均可使用类似的 TryParse() 方法。

#### TryParse() 的运行机制

如果 int.TryParse() 方法成功地将 string 变量 value 转换为 int，则返回 true；否则，将返回 false。 因此，将该语句置于 if 语句中，然后相应地执行决策逻辑。

请注意，转换后的值将存储在 int 变量 result 中。 在此代码行之前声明并初始化了 int 变量 result，因此，对于属于 if 和 else 语句的代码块，在其内部及外部均可访问该变量。

out 关键字指示编译器，TryParse() 方法不仅会以传统方式返回值（作为返回值），还会通过此双向参数传递输出。

如果转换成功，TryParse() 会返回 true；如果失败，则会返回 false。

一个不能转换的例子：
```c#
string value = "bad";
int result = 0;
if (int.TryParse(value, out result))
{
    Console.WriteLine($"Measurement: {result}");
}
else
{
    Console.WriteLine("Unable to report the measurement.");
}

// Since it is defined outside of the if statement, 
// it can be accessed later in your code.
if (result > 0)
    Console.WriteLine($"Measurement (w/ offset): {50 + result}");
```
输出结果
```
Unable to report the measurement.
```


> 什么是 out 参数？
方法可返回值或返回“void”，后者意味着不返回值。 方法还可以通过 out 参数返回值，这些值的定义与输入参数一样，但包含关键字 out。

> 使用 out 参数调用方法时，还必须在变量前使用关键字 out，以便保存值。 因此，在调用将用于存储 out 参数值的方法之前，必须先定义一个变量。 然后，可在代码的其余部分使用包含 out 参数中包含的值。


(End)