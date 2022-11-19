## WPF桌面程序 学习笔记 第N章  一个简单实现MVVM的例子

来源于: 根据[刘铁猛 《深入浅出WPF》系列高清视频教程](https://www.bilibili.com/video/BV1ht411e7Fe/?spm_id_from=333.1007.top_right_bar_window_custom_collection.content.click&vd_source=db5f224185fdd2c28b4cc762ebce92fe)整理。


### MVVM简介-[维基百科](https://zh.m.wikipedia.org/zh-hans/MVVM)

MVVM（Model–view–viewmodel）是一种软件架构模式。

MVVM有助于将图形**用户界面**的开发与**业务逻辑**或后端逻辑（数据模型）的开发**分离**开来，这是通过置标语言或GUI代码实现的。MVVM的视图模型是一个值转换器， 这意味着视图模型负责从模型中暴露（转换）数据对象，以便轻松管理和呈现对象。在这方面，视图模型比视图做得更多，并且处理大部分视图的显示逻辑。 视图模型可以实现中介者模式，组织对视图所支持的用例集的后端逻辑的访问。

- WPF笔记-105-1MVVM图示.png 是MVVM的流程图。
基本的逻辑示意如下：  
视图(View) <--绑定器(Binding)--> 视图模型(ViewModel) ---->  模型(Model)

MVVM和PM都来自MVC模式。MVVM由微软架构师Ken Cooper和Ted Peters开发，通过利用WPF（微软.NET图形系统）和Silverlight（WPF的互联网应用衍生品）的特性来简化用户界面的事件驱动程式设计。

MVVM也被称为model-view-binder，特别是在不涉及.NET平台的实现中。ZK（Java写的一个Web应用框架）和KnockoutJS（一个JavaScript库）使用model-view-binder。

#### MVVM模式的组成部分

- 模型(Model):
模型是指代表真实状态内容的领域模型（面向对象），或指代表内容的数据访问层（以数据为中心）。
- 视图(View):
就像在MVC和MVP模式中一样，视图是用户在屏幕上看到的结构、布局和外观（UI）。
- 视图模型(ViewModel):
视图模型是暴露公共属性和命令的视图的抽象。MVVM没有MVC模式的控制器，也没有MVP模式的presenter，有的是一个绑定器。在视图模型中，绑定器在视图和数据绑定器（英语：Data binding）之间进行通信。
- 绑定器(Binding):
声明性数据和命令绑定隐含在MVVM模式中。在Microsoft解决方案堆（英语：solution stack）中，绑定器是一种名为XAML的标记语言。绑定器使开发人员免于被迫编写样板式逻辑来同步视图模型和视图。在微软的堆之外实现时，声明性数据绑定技术的出现是实现该模式的一个关键因素。

#### 理论基础

**MVVM旨在利用WPF中的数据绑定函数，通过从视图层中几乎删除所有GUI代码（xaml对应的代码隐藏的cs文件），更好地促进视图层开发与模式其余部分的分离。**不需要用户体验（UX）开发人员编写GUI代码，他们可以使用框架标记语言（如XAML），并创建到应用程序开发人员编写和维护的视图模型的数据绑定。角色的分离使得交互设计师可以专注于用户体验需求，而不是对业务逻辑进行编程。这样，应用程序的层次可以在多个工作流中进行开发以提高生产力。即使一个开发人员在整个代码库上工作，视图与模型的适当分离也会更加高效，因为基于最终用户反馈，用户界面通常在开发周期中经常发生变化，而且处于开发周期后期。

MVVM模式试图获得MVC提供的功能性开发分离的两个优点，同时利用数据绑定的优势和通过绑定数据的框架尽可能接近纯应用程序模型。它使用绑定器、视图模型和任何业务层的数据检查功能来验证传入的数据。**结果是模型和框架驱动尽可能多的操作，消除或最小化直接操纵视图的应用程序逻辑（如代码隐藏）**。

MVVM模式不同于MVC，在MVVM模式中，将ViewModel层绑定到View层后，它基本不使用点击事件，而是使用命令(Command)来控制。数据的显示也是不同于MVC，而是使用Binding来绑定相关数据。

值得一提的是，MVVM通常会使用属性更改通知，即数据驱动而不是事件驱动。在WPF中当数据发生改变时，会通过接口INotifyPropertyChanged通知到对应的组件绑定的数据，实现同步数据刷新。

#### 批评

对这种模式的批评来自MVVM的创造者John Gossman本人，他指出，实现MVVM的开销对于简单的UI操作是“过度的”。他说，对于更大的应用来说，推广ViewModel变得更加困难。而且，他说明了非常大的应用程序中的数据绑定会导致相当大的内存消耗。

### 一个简单的例子

- 可以在Visual Studio中打开 WPF-905MVVMSimple 文件夹中的示例程序。

我们需要实现一个有以下功能的界面应用程序，输入两个数字，界面操作相加命令并把结果显示的程序界面上。

MVVMSimple项目文件夹:.  
│  App.xaml  
│  App.xaml.cs  
│  AssemblyInfo.cs  
│  MainWindow.xaml  
│  MainWindow.xaml.cs  
│  MVVMSimple.csproj  
│  MVVMSimple.csproj.user  
│  MVVMSimple.sln  
│  
├─Commands  
│      DelegateCommand.cs  
│  
├─Models  
│  
├─ViewModels  
│      MainWindowViewModel.cs  
│      NotificationObject.cs  
│  
└─Views  

从我们建立的文件夹可以看到，这些实现MVVM不同功能的文件夹主要有四个ViewModels、Models、Views、Commands四个文件夹。

- Views文件夹没有文件，由于视图简单使用MainWindow.xaml及其隐藏的MainWindow.xaml.cs代替。
- Models文件夹中没有文件，数据关系过于简单，使用MainWindowViewModel.cs中的属性代替。
- Commands.DelegateCommand.cs : 这是命令传递的基础类，即界面(Views)命令传递给后台(ViewModel)执行。
- ViewModels.NotificationObject.cs ：传递数据的基础类，保证界面(Views)、后台(ViewModel)之间的数据双向传递。
- ViewModels.MainWindowViewModel.cs ：
    - 声明数据属性和命令模型(此方面代替了Model的作用,更加庞大的数据可以拆分至单独的Model)
    - 创建数据处理逻辑和命令模型对应的方法
- MainWindow.xaml : 界面设计View。
- MainWindow.xaml.cs : 界面View的后台处理代码。此处只有基本的初始化代码，业务逻辑已经交给ViewModels执行。

套用MVVM模型表示的实现关系是:

视图(View)      <--绑定器(Binding)--> 视图模型(ViewModel) ---->  模型(Model)  
MainWindow.xaml(视图View) <--绑定器(Commands.DelegateCommand.cs+ViewModels.NotificationObject.cs+XAML元素的数据绑定机制)-->  ViewModels.MainWindowViewModel.cs(视图模型ViewModel)  ---->  ViewModels.MainWindowViewModel.cs中声明的属性和事件(模型Model) 

#### 前端代码 <--> 视图(View)：

MainWindow.xaml:
```xml
<Window x:Class="MVVMSimple.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:MVVMSimple"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="500">
    <Grid>
        <StackPanel>
            <TextBox x:Name="tb1" Background="LightBlue" Text="{Binding Input1}"
                     Margin="10" Width="200" FontSize="20"></TextBox>
            <TextBox x:Name="tb2" Background="LightBlue" Text="{Binding Input2}"
                     Margin="10" Width="200" FontSize="20"></TextBox>
            <TextBox x:Name="tb3" Background="LightBlue"  Text="{Binding Result}"
                     Margin="10" Width="200" FontSize="20"></TextBox>
            <Button x:Name="Add" Content="加" Width="200" Command="{Binding AddCommand}"
                    FontSize="20"></Button>
        </StackPanel>
    </Grid>
</Window>
```
说明:

界面实现了四个`TextBox`文本框和一个`Button`。同时类似于引入命名控件语句`xmlns:local="clr-namespace:MVVMSimple"`实现了对`MainWindow.xaml`隐藏的`MainWindow.xaml.cs`内容的引入。此引入语句实现了绑定数据源`DataContext`。`XAML`代码在执行时，需要数据时会搜索数据源，`DataContext`便是其中一种，也是从后台将数据暴露给前端的一种方式。具体代码见`MainWindow.xaml.cs`。


`Text="{Binding Input1}`语句中对`ViewModels.MainWindowViewModel.cs`中声明的属性`Input1`的绑定，即可实现此`TextBox`-`tb1`和`MainWindowViewModel.cs`文件中属性值之间的双向传输。另外两个`TextBox`使用相同的方式实现数据绑定。

`Button` 控件中的 `Command="{Binding AddCommand}` 实现了命令的绑定，即当 `Button` 在界面中被按下时，即执行对应的绑定函数。

空间绑定的完成，即实现了前端数据绑定器的一部分。无论前端如何变化，只要数据模型(Model)不变，都可以使用相同的方式绑定数据而不改变后端的任何代码。

`MainWindow.xaml.cs`文件代码:
```c#
using MVVMSimple.ViewModels;    //  MainWindowViewModel所在的命名空间

namespace MVVMSimple;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();  // XAML界面的初始化函数。这是默认的，无需特别更改。

        //将ViewModel中的字段赋值给window的DataContext，即将模型中的数据、属性或委托暴露给前端界面
        this.DataContext = new MainWindowViewModel();
    }
}
```


#### 绑定器(Binding)

`ViewModels.NotificationObject.cs`：
```c#
using System.ComponentModel;

namespace MVVMSimple.ViewModels;
//这是实现界面和后台双向通信的基类，ViewModel其他类继承自此基类即可实现双向通知的功能
//即后台数据变化后通知界面并变化，界面数据变化后反馈给后台数据。
//最终在控件中使用bingding绑定后台字段名称即可实现解耦。
//双向通知功能通过继承  INotifyPropertyChanged 接口实现。继承后事项接口约定的PropertyChanged事件即可。
internal class NotificationObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void RaiseProptyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
```

`Commands.DelegateCommand.cs`：
```c#
using System.Windows.Input;

namespace MVVMSimple.Commands;
//这是命令传递的基础，即界面命令传递给后台执行
internal class DelegateCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        if (this.CanExcuteFunc == null)
        { return true;}
        return this.CanExcuteFunc(parameter);
    }
    public void Execute(object? parameter)
    {
        if (ExcuteAction == null) { return; }
        this.ExcuteAction(parameter);
    }

    //声明委托，实际上是将需要绑定的方法形成委托，传递给前端界面的命令按钮等，命令按钮触发时委托的方法即执行。
    public Action<object> ExcuteAction{ get; set;}
    public Func<object, bool> CanExcuteFunc{get; set;}
}
```

`ViewModels.NotificationObject.cs`、`Commands.DelegateCommand.cs`实现了绑定器后端处理机制基础类部分。

#### 业务逻辑  <-->  视图模型(ViewModel)
```c#
using MVVMSimple.Commands;

namespace MVVMSimple.ViewModels;
class MainWindowViewModel: NotificationObject
{
    private double input1=2;

    //这是前端数据绑定的属性
    public double Input1
    {
        get{return input1; } 

        set
            {
                input1 = value;
                //此处"Input1"一定与属性的名称一致即Input1
                //赋值同时，通知绑定的控件值已经变化
                this.RaiseProptyChanged("Input1");
            }
    }

    private double input2=3;

    public double Input2
    {
        get{ return input2;}

        set
        {
            input2 = value;
            this.RaiseProptyChanged("Input2");
        }
    }


    private double result=5;

    public double Result
    {
        get { return result;}

        set
        {
            result = value;
            this.RaiseProptyChanged("Result");
        }
    }

    public DelegateCommand AddCommand{get; set;}

    private void Add(object parameter)
    {
        this.Result = this.Input1 + this.Input2;
    }


    public DelegateCommand SaveCommand{ get; set; }
    private void Save(object parameter)
    {
        SaveFileDialog dig = new SaveFileDialog();
        dig.ShowDialog();
    }

    public MainWindowViewModel()
    {
        //在这里委托绑定方法，前端界面上命令按钮命令绑定的是一种委托
        this.AddCommand = new DelegateCommand();
        this.AddCommand.ExcuteAction = new Action<object>(this.Add);

        this.SaveCommand= new DelegateCommand();    
        this.SaveCommand.ExcuteAction= new Action<object>(this.Save);
    }
}
```

#### 数据模型  <-->  Model 

这里隐含的数据模型是三个数据类型为 `double`的数据`Input1`，`Input2`，`Result`，并且三者之间的关系是  `Input1 + Input2 = Result`。由于过于简单，并没有单独成文件并放入`Model`文件夹中。


(End)