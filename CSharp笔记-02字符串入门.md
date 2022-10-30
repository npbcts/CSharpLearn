## C# 自学笔记 第二章-字符串基础

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-basic-formatting/),微软推出的初学者教程整理。



### 字符串类型


- 字符串**只能使用**双引号建立  "" -> (python中有三种建立字符串的方式)

```c#
srtring firstName = "Li Xiaoming";
```
### 字符转义

```c#
Console.WriteLine("Hello\nWorld!");
Console.WriteLine("Hello\tWorld!");
```

打印结果:
```bash
Hello
World!
Hello	World!
```


- 字符转义序列使用反斜杠 \ ,在字符串内表示**双引号、反斜杠本身**前使用反斜杠,n 序列将添加一个新行，而 \t 序列将添加一个制表符(与python相同)
- 逐字字符串文本将保留所有空格和字符，而无需转义反斜杠，在字符串前使用@。两个连续的双引号字符 ("") 在输出字符串中被打印成一个双引号字符 (") -> (python中的原始字符串)
- 下面是关于设置文本字符串格式要记住的最重要的事项：

    - 当需要在文本字符串中插入特殊字符时，请使用字符转义序列，例如制表符 \t、换行符 \n 或双引号 \"。
    - 在所有其他情况下，需要使用反斜杠时，请对反斜杠 \\ 使用转义字符。
    - 使用 @ 指令创建逐字字符串文本，以将所有空白格式和反斜杠字符保留在字符串中。

### 使用unicode字符

可以直接打印输出对应语言文字的字符串。

```c#
string projectName = "ACME";
string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";
Console.Write($"{projectName}\n{projectName}\n");
Console.Write(russianMessage);
```


### 字符串串联(弃用此方法，*使用字符串内插*)

字符串串联指的是将两个或更多值简单合并成一个新值。 -> 此特性与python相同.

```c#
string firstName = "Bob";
string message = "Hello " + firstName;
Console.WriteLine(message);
```

### 字符串内插

字符串内插通过使用“模板”和一个/多个内插表达式将**多个值:包含非文本值**合并为单个文本字符串。 内插表达式是一个变量，由一个左大括号和一个右大括号符号 { } 括起来。 当文本字符串以 $ 字符为前缀时，该字符串将变为模板。 -> python f-string和.format()函数相似。

```c#
string firstName = "Li Xiaoming";
int yearOld = 3;
Console.WriteLine($"Hello {firstName}, year old is {yearOld}！");
```

### 合并逐字文本和字符串内插

那么? 如何合并字符串内带有斜杠的文本? 类似与windows文件夹地址?  
可以同时使用逐字文本前缀符号 @ 和字符串内插 $ 符号。

```c#
string projectName = "First-Project";
Console.WriteLine($@"C:\Output\{projectName}\Data");
```

## 总结

我们的目标是编写代码来**设置包含特殊字符**（例如双引号、换行符、制表符和其他空格）的字符串的格式，**使用 Unicode 字符**，并使用两种不同的技术将**字符串合并**在一起。

- 借助字符转义序列，我们通过使用特殊转义序列或逐字字符串在文本字符串中添加特殊字符。 
- 我们在文本字符串中添加了来自日语汉字和俄语西里尔字母等其他语言集的 Unicode 字符。   
- 我们结合使用了简单的字符串串联和 + 符号，并升级到字符串内插，以便将值合并到字符串模板中。
