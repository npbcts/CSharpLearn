## C# 自我初学笔记 第三（2）单元  字符串格式化输出

来源于: [Learn C# 初级自学教程](https:https://learn.microsoft.com/zh-cn/training/modules/csharp-format-strings/2-string-formatting-basics),微软推出的初学者教程整理。

### 设置货币格式

```c#
decimal price = 12.09m;
int discount = 50;
Console.Write($"Price: {price:C}(Save {discount:C})");
```
输出内容：

```c#
Price: ¤12.09(Save ¤50.00)
```
使用 ¤ 符号，而不是国家/地区的货币符号。 这是用于在任何货币类型下表示“货币”的通用符号。“Windows 显示语言”设置为“英语”的计算机执行此代码，会得到以下输出：
```c#
Price: $12.09(Save $50.00)
```
请注意，无论使用 int 还是 decimal，在大括号内的标记中添加 :C 都会将数字格式化为货币。

### 设置数值格式

千分位分割，`N` 数值格式说明符执行此操作
```c#
decimal measurement = 123456.78912m;
Console.WriteLine($"Measurement: {measurement:N} units");
```
输出:
```c#
Measurement: 123,456.79 units
```
`N` 数值格式说明符默认仅显示小数点后两位数字。`N4`可以显示四位小数。


### 设置百分比的格式
可以使用 `P` 格式说明符设置百分比的格式。 之后添加一个数字来控制小数点后显示位数。
```c#
decimal tax = .36785m;
Console.WriteLine($"Tax rate: {tax:P2}");
```
输出:
```c#
Tax rate: 36.79 %
```