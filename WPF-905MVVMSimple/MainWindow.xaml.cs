using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using MVVMSimple.ViewModels;

namespace MVVMSimple;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //使用模式进行

        //将ViewModel中的字段赋值给window的DataContext，即将模型中的数据、属性或委托暴露给前端界面
        this.DataContext = new MainWindowViewModel();
    }

    //private void Add_Click(object sender, RoutedEventArgs e)
    //{
        //不使用模式，直接完成的程序
        //tb3.Text = (double.Parse(tb1.Text) + double.Parse(tb2.Text)).ToString();
       
    //}

    //private void FileSave_Click(object sender, RoutedEventArgs e)
    //{
    //    SaveFileDialog fileDialog = new SaveFileDialog();
    //    fileDialog.ShowDialog();
    //}
}
