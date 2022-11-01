## C# 自我初学笔记 第三单元  字符串内置方法

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-format-strings/4-exercise-string-methods-padding),微软推出的初学者教程整理。

### 字符串方法概述
字符串可以理解为类，有自己的方法完成特性任务。
对于 string 数据类型，及字符串类型的任何文本字符串或变量，都具有很多类似的方法。

- 添加空白进行格式设置的方法：PadLeft()、PadRight()  
- 比较两个字符串或辅助比较的方法：Trim()、TrimStart()、TrimEnd()、GetHashcode()、Length 属性  
- 帮助确定字符串内部内容，甚至只检索部分字符串的方法：Contains()、StartsWith()、EndsWith()、Substring()  
- 通过替换、插入或删除部件来更改字符串内容的方法：Replace()、Insert()、Remove()
- 将字符串转换为字符串或字符数组的方法：（Split()、ToCharArray()）

### 为字符串添加空白格式
#### 为字符串添加空白
```c#
string input = "Pad this";
Console.Write(input.PadLeft(12));
```
输出:
`    Pad this`  
字符串左侧有四个字符作为前缀，使其长度为 12 个字符。即字符串变量的.PadLeft(2)方法参数12，使字符串总长度变为12,左边填充空格。  

#### 方法重载
在 C# 中，重载方法是具有不同或其他参数的方法的另一个版本，这些参数会略微修改方法的功能，就像在 PadLeft() 方法的重载版本中一样。

使用方法重载可以向字符串填充其他类型的字符，而不是空白。注意，重载方法时，`*`变量使用的是单引号`'`。

```c#
string input = "Pad this";
Console.Write(input.PadLeft(12, '*'));
```
输出结果:
`****Pad this`

(End)