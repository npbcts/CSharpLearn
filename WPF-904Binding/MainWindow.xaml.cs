using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppBinding;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
 
    Student stu = new Student();
    public MainWindow()
    {
        InitializeComponent();

        /*第一个例子***************************使用通用的BindingOperations方法绑定属性，讲解绑定的过程
    `   // 数据源
        stu.Name = "小明";

        //绑定数据
        Binding binding= new Binding();
        binding.Source = stu;
        binding.Path = new PropertyPath("Name");

        //使用Binding连接数据源和目标
        BindingOperations.SetBinding(this.myTextbox, TextBox.TextProperty, binding);

        *****************************/

        //第一个例子实际绑定数据的 简化写法
        //使用Textbox控件本身实现的BindingOperations方法
        myTextbox.SetBinding(
            TextBox.TextProperty,
            new Binding("Name") {Source = stu = new Student()});

        //第二个例子slider和mySlideTextbox数据连接
        mySlideTextbox.SetBinding(TextBox.TextProperty, new Binding("Value") { Source=mySlider });


        ////第三个例子
        /// 创建listbox数据集
        var students = new List<Student3>() {
            new Student3("小明", "01", 28),
            new Student3("小刚", "02", 20),
            new Student3("小梅", "03", 20),
            new Student3("小东", "04", 21),
            new Student3("小华", "05", 20),
            new Student3("小西", "06", 25),
        };
        ///第三个例子为listbox绑定数据源
        this.StudentListBox.ItemsSource=students;
        this.StudentListBox.DisplayMemberPath = "Name";

        Binding StudentIdTextboxbinding = new Binding("SelectedItem.Id"){
            Source= this.StudentListBox
        };
        this.StudentIdTextbox.SetBinding(TextBox.TextProperty, StudentIdTextboxbinding);

    }

    private void myButton_Click(object sender, RoutedEventArgs e)
    {   //第一个例子
        //点击按钮，给绑定的目标this.myTextbox一个新值
        stu.Name = "小刚";

    }



}

// 第一个例子
// 建立 Student类作为XAML元素的数据源
//要实现Student类和XAML元素的双向通信，需要实现INotifyPropertyChanged接口
public class Student: INotifyPropertyChanged
{
    private string name;

    public string Name
    {
        get => name;
        set
        {
            name = value;
            if (this.PropertyChanged != null)
            {   // 激发数据接收者PropertyChanged事件，使Name属性感知数据界面接收者的变化，从而实现双向通信
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
    }

    //实现INotifyPropertyChanged接口声明的事件，这个事件是格式化的
    public event PropertyChangedEventHandler? PropertyChanged;
}

//第三个例子
public class Student3
{
    public Student3(string name, string id, int age)
    {
        Name = name;
        Id = id;
        Age = age;
    }

    public string Id
    {
    get; set; }

    public string Name
    {
    get; set; }
    public int Age
    {
    get; set; }
}
