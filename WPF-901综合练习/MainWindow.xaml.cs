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

namespace WpfApptest;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private decimal? FirstNumber
    {
        get; set;
    }
    private decimal? SecondNumber
    {
        get; set;
    }
    private Func<decimal, decimal, decimal> SelectedMathFunction
    {
        get; set;
    }

    private void FirstNumberBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(FirstNumberBox?.Text))
        {

            FirstNumber= null;
            MessageBox.Show("请输入第一个数字...");
            return;
        }

        if (decimal.TryParse(FirstNumberBox.Text, out decimal parsedNumber))
        {
            FirstNumber = parsedNumber;
        }
        else 
        {
            FirstNumberBox.Text = FirstNumberBox.Text.TrimEnd(FirstNumberBox.Text.LastOrDefault());
        }
    }

    private decimal Add(decimal a, decimal b)
    {
        var result = a + b;
        return result;
    }    
    
    private decimal Subtract(decimal a, decimal b)
    {
        var result = a - b;
        return result;
    }
    
    private decimal Multiply(decimal a, decimal b)
    {
        var result = a * b;
        return result;
    }    
    private decimal Divide(decimal a, decimal b)
    {
        var result = a / b;
        return result;
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        var radioButton = sender as RadioButton;
        string ratioButtonContent = radioButton?.Content?.ToString();
        if (ratioButtonContent == "加")
        {
            SelectedMathFunction = Add;
        }
        else if (ratioButtonContent == "减")
        {
            SelectedMathFunction = Subtract;
        }
        else if (ratioButtonContent == "乘")
        {
            SelectedMathFunction = Multiply;
        }
        else if (ratioButtonContent == "除")
        {
            SelectedMathFunction = Divide;
        }
        else {
            SelectedMathFunction = null;
        }

    }

    private void SecondNumberBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(SecondNumberBox?.Text))
        {
            SecondNumber = null;
            MessageBox.Show("请使用滑块选择第二个数字....");
            return;
        }

        if (decimal.TryParse(SecondNumberBox?.Text.ToString(), out decimal parserNumber))
        {
            SecondNumber = parserNumber;
        }
        else 
        { 
            SecondNumberBox.Text = SecondNumberBox.Text.TrimEnd(SecondNumberBox.Text.LastOrDefault());
        }
    }

    private void SecondNumberSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        SecondNumberBox.Text = e.NewValue.ToString("N");

    }

    private void Calculate_Click(object sender, RoutedEventArgs e)
    {
        if (FirstNumber is null || SecondNumber is null)
        {
            MessageBox.Show("输入错误"); return;
        }
        if (SecondNumber ==0 && SelectedMathFunction == Divide)
        {
            MessageBox.Show("除数不能为0...");
            return;
        }
        decimal result;
        result = SelectedMathFunction((decimal)FirstNumber, (decimal)SecondNumber);
        ResultTextBlock.Text = $"计算结果是: {result:N2}";

        
    }
}
