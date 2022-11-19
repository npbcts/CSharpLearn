using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MVVMSimple.Commands;
//这是命令传递的基础，即界面命令传递给后台执行
internal class DelegateCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        if (this.CanExcuteFunc == null)
        {
            return true;
        }
        return this.CanExcuteFunc(parameter);
    }
    public void Execute(object? parameter)
    {
        if (ExcuteAction == null) { return; }
        this.ExcuteAction(parameter);
    }

    //声明委托，实际上是将需要绑定的方法形成委托，传递给前端界面的命令按钮等，命令按钮触发时委托的方法即执行。
    public Action<object> ExcuteAction
    {
        get; set;
    }
    public Func<object, bool> CanExcuteFunc
    {
        get; set;
    }
}
