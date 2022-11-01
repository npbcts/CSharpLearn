## C# 自我初学笔记 第三章  数值操作

来源于: [Learn C# 初级自学教程](https://learn.microsoft.com/zh-cn/training/modules/csharp-basic-operations/),微软推出的初学者教程整理。


### 两中基本数值类型 int, decimal


- int, 整型, 取值区间: -2147483648 ~ 2147483647
- decimal,小数型,  取值区间 : -79228162514264337593543950335 ～ 79228162514264337593543950335  
    decimal数据使用如下方法表示:

    ```c# 
    10m
    ```


### 执行基本的数学运算
使用如 +、-、* 和 / 的运算符来执行基本数学运算。
```c#
int sum = 7 + 5;
int difference = 7 - 5;
int product = 7 * 5;
int quotient = 7 / 5;

Console.WriteLine("Sum: " + sum);
Console.WriteLine("Difference: " + difference);
Console.WriteLine("Product: " + product);
Console.WriteLine("Quotient: " + quotient);
```

注意，整型相除的商并不准确。需要进行格式转换。
两个 int 值相除，得到小数点后的任意值被截断的结果。 要保留小数点后面的值，需要先将除数或被除数（或两者）由 int 强制转换为浮点数，如 decimal，然后为了避免截断，商必须是相同的浮点类型。

### 使用文本小数数据添加代码以执行除法
稳健的做法是， 统一将结果变量，参与相除的数都约定为decimal数据类型，能得出正确结果。
```c#
decimal quotient = 7m / 5m;
Console.WriteLine("Quotient: " + quotient);
```
输出结果准确:`1.4`,是准确结果。


### 涉及不同数据类型,正确(准确)的除法运算
int类型变量参与相除时的类型转换,变量前加  `(decimal)` 转换类型

```c#
int first = 7;
int second = 5;
decimal quotient = (decimal)first / (decimal)second;
Console.WriteLine(quotient);
```

### 取模运算:

整数相除后的余数,使用 ` % `,  % 运算符捕获相除后的余数。

```c#
Console.WriteLine("Modulus of 200 / 5 : " + (200 % 5));
Console.WriteLine("Modulus of 7 / 5 : " + (7 % 5));
```

### 运算顺序
与普遍意义上的数学运算一致。C#中的数值运算顺序如下:

- 圆括号 (P)（括号内的内容首先执行）
- 指数 (E)
- 乘法 (M) 和除法 (D)（从左至右）
- 加法 (A) 和减法 (S)（从左至右）

### 双括号()的使用总结

- 方法调用：方法输入参数
- 运算顺序
- 强制类型转换


### 复合运算符

下面代码的第三行使用了 `+=` 运算符，将右边的值加到变量后获得新值，再返回给变量。在其余运算符中均有类似的复合方法。  
由于存在**更容易理解的普通运算符写法**，不再深入学习复合运算符的使用。
```c#
int value = 0;
value = value + 5;
value += 5;
```

### 练习
若要将温度从华氏度94转换为摄氏度。需首先将其减去 32，然后乘以九分之五 (5/9)。
```c#
int fahrenheit = 94;
decimal celsius = (fahrenheit - 32m) * (5m / 9m);
Console.WriteLine("The temperature is " + celsius + " Celsius.");
```
注意进行除法及其他运算时, 所有数值(包括变量)转换为decimal.这种写代码显性转换是比较保守的准确做法，不再探究不同数据类型的数值进行运算的结果是否准确。

(End)
