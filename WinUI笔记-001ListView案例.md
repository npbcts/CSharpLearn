## WinUI3桌面程序 学习笔记 第N章  ListView实用案例

来源于: 根据[微软的.WinUI3文档](https://learn.microsoft.com/zh-cn/windows/apps/design/controls/listview-and-gridview)整理。


`ListView` 和 `GridView` 的类型都是 `ItemsControl`，因此它们可以包含任何类型的项的集合。 `ListView` 或 `GridView` 控件必须在其 `Items` 集合中具有项，然后才能在屏幕上显示任何内容。 若要填充视图，可以直接 将项添加到集合 或将 `ItemsSource` 属性设置为数据源。
 

> 注意:可以使用 `Items` 或 `ItemsSource` 属性填充列表，但不能同时使用这两个属性。 如果你设置 `ItemsSource` 属性并使用 XAML 添加项目，将忽略添加的项目。 如果 `ItemsSource` 属性已设置且使用代码向项集合中添加项，则会引发异常。

列表中的项更常见，这些项来自动态源，例如联机数据库中的书籍列表。 出于此目的，你使用 `ItemsSource` 属性。

### `ItemsSource`绑定数据

使用`ItemsSource`绑定数据的好处是，能够最大化的前端界面和后端数据的分离。


程序入口类中添加列表数据，并声明 `Contacts`，作为对 `XAML` 界面的数据源。
```c#
// C#
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.Title = "Hello world!";

        Contacts.Add(new Contact("John", "Doe", "Contoso, LTD."));
        Contacts.Add(new Contact("Jane", "Doe", "Fabrikam, Inc."));
        Contacts.Add(new Contact("Santa", "Claus", "Alpine Ski House"));

    }
    ObservableCollection<Contact> Contacts = new ObservableCollection<Contact>();
}
```

创建在`ListView`中显示的数据类:
```c#
// C#
public class Contact
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Company { get; private set; }
        public string Name => FirstName + " " + LastName;

        public Contact(string firstName, string lastName, string company)
        {
            FirstName = firstName;
            LastName = lastName;
            Company = company;
        }

        /// <summary>
        /// 需要重新类的ToString方法，否则显示类名，而不是我们需要的名称
        /// </summary>
        /// <returns>Name</returns>
        public override string ToString()
        {
            return Name;  // 列表中显示的项目字符串
        }
    }
```

在这里，`ItemsSource` 绑定到名为 `Contacts` 的公共属性，该属性公开页面的专用数据收集，该集合名为 `_contacts`。
```XML
<!--XAML-->
<StackPanel Orientation="Vertical" HorizontalAlignment="Center" VerticalAlignment="Center">

    <Button x:Name="myButton" Click="myButton_Click">替换内容</Button>

    <ListView
        x:Name="BaseExample"
            ItemsSource="{x:Bind Contacts}"
        
        BorderThickness="1"
        BorderBrush="{ThemeResource SystemControlForegroundBaseMediumLowBrush}"
        Width="350"
        Height="400"
        HorizontalAlignment="Left">

    </ListView>

</StackPanel>
```

### 修改 `ListView` 内容

修改数据按照 `Contacts`的方法完成，下面是增加数据的例子：
```c#
// C#
private void myButton_Click(object sender, RoutedEventArgs e)
{
    Contacts.Add(new Contact("Dff33", "666", "Contoso, LTD."));
    Contacts.Add(new Contact("2deff", "965", "Fabrikam, Inc."));
    Contacts.Add(new Contact("h5433", "fs335", "Alpine Ski House"));

    BaseExample.ItemsSource = Contacts;
}

```

清空现有`ListView`的方法 ->  即`Contacts`的方法
```c#
// C#
Contacts.Clear();
```


(End)