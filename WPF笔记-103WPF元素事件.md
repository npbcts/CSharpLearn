## WPF桌面程序 学习笔记 第N章  

来源于: 根据[刘铁猛 《深入浅出WPF》系列高清视频教程](https://www.bilibili.com/video/BV1ht411e7Fe/?spm_id_from=333.1007.top_right_bar_window_custom_collection.content.click&vd_source=db5f224185fdd2c28b4cc762ebce92fe)整理。

事件本质上是.NET对象事件通信的机制。

### 构成事件处理元素

1. 事件的拥有者;
2. 事件拥有者的事件;
3. 事件的响应者：
4. 事件响应者的方法(事件处理器);
5. 事件订阅关系;

事件的五个要素全部完整时，构成了整个事件的处理系统。

### 典型的事件流程

#### 创建事件拥有者和响应者
下面的代码中创建了一个事件的拥有者`Button`名称为`myButton`：
```XML
 x:Class="WpfAppEventTest.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfAppEventTest"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="500">
    <Grid>
        <Button x:Name="myButton" Content="点击" Width="200" Height="100"></Button>
    </Grid>
</Window>
```
此时没有事件的其他元素，因此点击之后不响应。
实际上，这里同时创建了事件的响应者`Window`,即我们触发事件时窗体本身会做出相应。如果触发事件的方法（即事件处理器）没有让窗体任何动作相应，那么事件不成立。

#### `Button`的事件和创建订阅关系

调用事件并绑定事件处理器的代码：
```xml
<Window...
    <Grid>
        <Button x:Name="myButton" Content="点击" Width="200" Height="100"
                Click="myButton_Click"></Button>
    </Grid>
</Window>
```

`Click`事件是`Button`控件中已经存在的事件，我们只是声明出来并绑定至事件处理器中。我们绑定了`Click`事件的处理器，命名为`"myButton_Click"`。此时Visual studio会自动提示我们创建对应的方法，也就是事件处理器。点击提示后会自动在隐藏的C#代码文件中创建事件处理器方法。  
我们注意到，vs自动为我们生成的事件处理器名称为`"myButton_Click"`，即`控件名+_+事件名`的模式。  
事件的订阅关系体现在`Click="myButton_Click"`，即事件`Click` 和方法`myButton_Click`绑定到一起。这种方式是在`xaml`代码中执行的事件订阅。

#### 创建事件处理器

下面的代码中创建了一个方法，`private void myButton_Click(object sender, RoutedEventArgs e)`是vs自动添加，我们手动创建时也需要包含这些内容。方法体我们添加了需要的处理代码。
```C#
private void myButton_Click(object sender, RoutedEventArgs e)
{
    MessageBox.Show("我创建了一个按钮!");
}
```

#### 另一种创建事件订阅关系的方法


删掉xaml中的`Click="myButton_Click"`，即原有的事件订阅关系。
```xml
<Window...
    <Grid>
        <Button x:Name="myButton" Content="点击" Width="200" Height="100"
                ></Button>
    </Grid>
</Window>
```

在c#代码文件中的`MainWindow()`创建事件订阅关系:
```c#
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.myButton.Click += new RoutedEventHandler(myButton_Click);
    }

    private void myButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("我创建了一个按钮!");

    }
}
```
这种方法可以看到，事件处理器的响应方法创建在了`MainWindow()`中，即创建在了事件响应者中。也表明`this.myButton.Click`本质上是一种委托，例子中是将方法`myButton_Click`委托给了`this.myButton.Click`完成了事件订阅关系。


(End)