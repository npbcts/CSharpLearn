## WPF桌面程序 学习笔记 第N章  向 UI 添加元素

来源于: 根据[向 UI 添加元素](https://learn.microsoft.com/zh-cn/training/modules/create-ui-for-windows-10-apps/2-adding-elements-to-your-ui?pivots=wpf)整理。


在完成应用布局的设置后， 接下来的任务是使用元素来填充布局。 我们将探索所有元素共有的一些属性。 此外，还将了解如何组合这些元素，并配置它们的属性，以创建所需的 UI。

### 对齐方式和边距

在上一单元中，我们使用 `Rectangle` 演示了一些有关 `Grid` 如何布局行和列的功能。 这一次，我们将直接使用 `Rectangle` 演示大多数 `UI` 元素共有的一些基本属性：

- `Width` 和 `Height`
- `Margin` 和 `Padding`
- `VerticalAlignment` 和 `HorizontalAlignment`

这些**属性对所有控件的工作方式都相同**。 所以，了解简单的 `Rectangle` 意味着，可以将此类知识应用于其他控件。

`HorizontalAlignment`属性使本控件在上级控件位置发生变化，此处属性值`Left`让`Rectangle`在水平方向处于`Grid`中的左侧。
`VerticalAlignment="Top"`使控件在垂直方向上处于顶部。因此最终`Rectangle`控件在`Grid`的左上角。
```xml
<Window ...
    <Grid>
        <Rectangle Fill="Blue"
                   Width="200"
                   Height="200"
                   VerticalAlignment="Top"
                   HorizontalAlignment="Left" />

        <Rectangle Fill="LightBlue"
                   Width="100"
                   Height="100" />
    </Grid>
</Window>

```

下面的例子中，我们为`Rectangle`控件使用了所有 `UI` 元素都有的 `Margin` 属性，即设置本元素同其他元素之间的距离。
```xml
<Window ....
    <Grid>
        <Rectangle Fill="Blue"
                   Width="200"
                   Height="200"
                   HorizontalAlignment="Left"
                   VerticalAlignment="Top"
                   Margin="20,20,0,0" />

        <Rectangle Fill="LightBlue"
                   Width="100"
                   Height="100" />
    </Grid>
</Window>
```
在 `Rectangle` 和 `Grid` 之间增加一些边缘空间。 我们将使用所有 `UI` 元素都有的 `Margin` 属性添加空间。设置 `Margin` 时，可以对值使用“左边距, 上边距, 右边距, 下边距”模式。若要让四周的边距值都相同，请使用一个数字，如 `Margin="20"`。

>一些控件有 Padding 属性。 Grid 就是其中之一。 此属性等同于 Margin。 不同之处在于，它是向内边缘（而不是外边缘）增加空间。 通过设置 <Grid Padding="20"> 来看看此属性的实际效果。


### `TextBlock`和属于自己的属性

实际上，前面介绍的控件属性一般认为可以通用到所有元素。实际上各个元素的不同在于有自己专有的属性。由于元素的种类繁多，使用专有属性时。

```xml
<Window ...
    <Grid>
        <Rectangle Fill="LightBlue"
                Width="100"
                Height="100" />
        <TextBlock Text="I'm a TextBlock." />
    </Grid>
</Window>
```
此文本显示在 `Grid` 的左上角。 与矩形一样，整个 `TextBlock` 容器的默认对齐方式是`Stretch`。 但文本对齐方式是左上角对齐，这是默认行为。

若要在浅蓝色 `Rectangle` 之上居中显示此文本，请将 `TextBlock` 的`“VerticalAlignment”`和`“HorizontalAlignment”`更改为`“Center”`。即两个元素位置重叠，`Rectangle`在之前建立，位于 `TextBlock`空间的底部。同时， `TextBlock`除文字外的部分是透明，可以形成背景效果。

最后，尝试设置一些 `TextBlock` 字体属性，如 `FontFamily`、`FontSize` 和 `FontWeight`。这也是文字元素通用的属性。


```xml
<Window ...
    <Grid>
        <Rectangle Fill="LightBlue"
                   Width="100"
                   Height="100" />

        <TextBlock Text="I'm a TextBlock."
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"
                   FontSize="46"
                   FontWeight="Bold"
                   FontFamily="Consolas" />
    </Grid>
</Window>
```

### `Button`控件

大多数控件不像 `TextBlock` 一样使用 `Text` 属性。 相反，它们使用 `Content` 属性。 可以将其他任何元素设置为 `Content`。 但如果只使用文本，它也会为你显示文本。

```xml
<Window ...
    <Grid>
        <Button Content="确认" />
    </Grid>
</Window>
```
上面的代码表示，在按钮上显示的文本为`确认`。

>在 WPF 中，默认情况下，`Button` 的`“HorizontalAlignment”`设置为`“Stretch”`，`“VerticalAlignment”`设置为`“Stretch”`。 若要更改这些值，请设置 `Width` 和 `Height` 的确切值，或更改默认对齐方式值。 尝试使用新控件时，请注意，**并非所有控件的默认属性值都相同**。

`Button`也接受以下属性设置：

- 将 `HorizontalAlignment` 设置为 `Center`
- 将 `VerticalAlignment` 设置为 `Bottom`
- 将 `Margin` 设置为 `20`
- 将`“FontSize”`设置为`“36”`
- 将`“FontWeight”`设置为`“SemiBold”`
- 将`“FontFamily”`设置为`“Arial”`


### 属性的另一种赋值方式: [资源](https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/advanced/resources-wpf?view=netframeworkdesktop-4.8)




(End)

