## WPF桌面程序 学习笔记 第N章  布局基础知识

来源于: 根据[微软官方教程: 入门 (WPF)](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/getting-started/?view=netframeworkdesktop-4.8)
[微软培训内容: 创建 Windows 10 应用的用户界面 (UI)](https://learn.microsoft.com/zh-cn/training/modules/create-ui-for-windows-10-apps/) 整理。


Windows Presentation Foundation (WPF) 是一个可创建桌面客户端应用程序的 UI 框架。 WPF 开发平台支持广泛的应用开发功能，包括应用模型、资源、控件、图形、布局、数据绑定、文档和安全性。 它是 .NET Framework 的子集，因此，如果你曾经使用 ASP.NET 或 Windows 窗体通过 .NET Framework 构建应用程序，应该会熟悉此编程体验。 **WPF 使用 `Extensible Application Markup Language (XAML)`**，为应用编程提供声明性模型。

### 为什么学习WPF?

- 由于WPF使用 `XAML`作为界面编程，是一种比较通用的界面编程的方式，包括 `Android`和微软新推出的`WinUI`都使用这种方式进行界面编程。
- 虽然 `WPF`目前不作为主流的 `windows`界面编程方式，并且微软没有推出新的特性，但可以使用图形化编程和快速搭建方式仍然在很多领域使用。
- `.NET6`作为长期支持版本，仍然包含对`WPF`的支持。

### 基础概念

- **XAML**: `XAML`是`eXtensible Application Markup Language`的英文缩写，相应的中文名称为**可扩展应用程序标记语言**，它是微软公司为构建应用程序用户界面而创建的一种新的描述性语言。`XAML`提供了一种便于扩展和定位的语法来定义和程序逻辑分离的用户界面。

- **元素**:这些构建基块称为“控件”，有时亦称为“元素”。 控件可以仅用于定位其他控件，如 `Grid` 控件。 也可以有特定用途，如 `TextBox `控件用于显示文本。 无论特定用途是什么，所有控件都共同承担责任。 它们是生成用户界面的元素。

- **布局控件**是任意用户界面的基础。 它们排列应用的 `UI` 元素。 文本、按钮和图像等元素都需要规定自己位置和行为方式的规则。


### 布局知识

打开 `Visual Studio`，并创建 `WPF C#` 项目。 在本课中，为项目命名有意义的名称。 例如，`“UsingLayoutsApp.Wpf”`。

在 Visual Studio 生成项目后，便会看到 MainWindow.xaml 默认打开。
```xml
<Window x:Class="UsingLayoutsApp.Wpf.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:UsingLayoutsApp.Wpf"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>

    </Grid>
</Window>
```

这段最基本的代码中包含了两个控件 `Window`,`Grid`。两个控件之间的关系是:`Grid` 元素是嵌套在两个 `<Window></Window>` 标记中的, `Grid` 是 Window 的子元素。

`Window` 元素只支持包含一个子元素。 `Grid` 元素支持包含所需的任意多个子元素。 因此，`Grid` 是用途最广泛的布局元素之一。 它通常用作应用页面的主布局控件。

同时，我们也注意到，`<Window>`标签中包含`x:Class`是控件声明的类，`xmlns`是引入控件的命名控件。
`Title`、`Height`、 `Width`是元素`Window` 的属性，并赋予了能够接受的值。在**元素标签内部直接赋值**是元素赋值的方式之一，另一种方式会在下一小结中介绍。

### 向`Grid`布局元素内添加元素

向 `Grid` 添加三个 `Rectangle` 元素。 这些元素通常是居中放置。 但可使用 `HorizontalAlignment` 将它们彼此分开：
```xml
<Window ...
    <Grid Margin="100" Background="Gray">
        <Rectangle Width="100" Height="100" Fill="LightBlue" HorizontalAlignment="Left" />
        <Rectangle Width="100" Height="100" Fill="LightPink" HorizontalAlignment="Center" />
        <Rectangle Width="100" Height="100" Fill="LightGreen" HorizontalAlignment="Right" />
    </Grid>
</Window>
```
实际上这种布局产生了要素之间的父子关系。 `Rectangle` 元素是 `Grid` 的子元素，`Grid` 又是 `Window` 的子元素。矩形是不超出 `Grid` 范围进入 Window 的白色区域的。 

#### `Grid`行列的创建元素的另一种赋值方式: 属性标签

`Grid` 是一种网格型的布局控件，任何子元素都可以布局或坐落在制定好的格子之上。另外，网格的特殊属性，可自动调整 `Grid` 的子元素的大小和位置。  可以说`Grid`非常灵活且功能强大的布局控件。网格的建立是通过使用 `Grid.RowDefinitions` 和 `Grid.ColumnDefinitons` 这两个`Grid`属性声明完成的。

在一个空的`Grid` 元素中创建行:
```xml
<Window ...
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition />
        </Grid.RowDefinitions>
    </Grid>
</Window>
```
可以看到，在`<Grid.RowDefinitions>`的属性标签内有两行`<RowDefinition />`，这是为元素属性赋值的另一种方式，**将属性值写在属性标签内**。同时这种方法也适合一个属性设置多个值。  
属性标签的书写格式是`对象类型.属性名`。  
设置`<Grid.RowDefinitions>`属性后，将`Grid`分为两行。使用`<Grid.ColumnDefinitions>`可以创建列。

#### `Grid`添加其他元素

下面的例子向`Grid`添加了两个矩形`Rectangle`元素
```xml
<Window ...
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition />
        </Grid.RowDefinitions>

        <Rectangle Width="200" Height="200" Fill="LightBlue" />
        <Rectangle Width="200" Height="200" Fill="Red" Grid.Row="1" />
        <Rectangle Width="100" Height="100" Fill="Green" Grid.Column="1" />
        <Rectangle Width="100" Height="100" Fill="Blue" Grid.Row="1" Grid.Column="1" />
    </Grid>
</Window>
```
我们注意到第一个 `Rectangle`元素在设计器绘制出的界面中的左上角，即`Grid`的`0`行`0`列。实际上，这是控件在`Grid`中的`Grid.Row`,` Grid.Column`默认值。或者可以说，`Grid.Row`,` Grid.Column`这两个属性，控制着`Grid`中控件的相对位置。

#### 元素属性的默认值

元素的大多数属性都有默认值，合理恰当的使用默认值能够简化代码。注意，使用元素属性默认值时不用输入属性名称，即使用`Height`默认值不用输入`Height=`。下面是已学元素的默认值：

- `Grid.Row="0"` 和 `Grid.Column="0"` 是 `Grid` 的任意子元素的默认值。
- `Height`、 `Width`的默认值是`*`,指最大限度地占用空间。
- `HorizontalAlignment`, `VerticalAlignment`: `Stretch`延申填充空间。

`Width`和`Height`是绝对值。 它们优先于默认的垂直对齐方式和水平对齐方式值`Stretch`。即当属性设置值时，会使属性放弃使用默认值。

请注意，**并非所有控件的默认属性值都相同**。

### 另一种布局控件 `StackPanel`

`StackPanel` 是将项彼此堆叠在一起的简单布局控件。 它无需定义行或列。 常用组合是 `Grid` 和 `StackPanel`。

如果两个`Grid`子控件都位于同一行列中，他们的位置可以使用`HorizontalAlignment`, `VerticalAlignment`属性控制。但我们可以使用`StackPanel`将控件分组并平铺在空间中。

```xml
<Window ...
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition />
        </Grid.RowDefinitions>

        <StackPanel VerticalAlignment="Center" HorizontalAlignment="Center">
            <Rectangle Width="100" Height="100" Fill="LightBlue" />
            <Rectangle Width="100" Height="100" Fill="Blue" />
        </StackPanel>

        <Rectangle Width="100" Height="100" Fill="Red" Grid.Row="1" />
        <Rectangle Width="100" Height="100" Fill="Green" Grid.Column="1" />
        <Rectangle Width="100" Height="100" Fill="Blue" Grid.Row="1" Grid.Column="1" />
    </Grid>
</Window>

```
在这个例子中 `StackPanel` 元素作为左上角的显示元素。即在`Grid`中包含四个平行的子元素，那么`Grid`可以理解为元素容器。`StackPanel` 的**默认堆叠策略是垂直**。你还可以水平堆叠各项。 将 `StackPanel` 的`Orientation`属性设置为`Horizontal`，`Orientation`属性控制着容器内元素的布局方向。


(End)
