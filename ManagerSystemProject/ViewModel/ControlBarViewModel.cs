using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManagerSystemProject.ViewModel
{
    public class ControlBarViewModel:BaseViewModel
    {
        public ICommand CloseWindownCommand { get; set; }
        public ICommand MaximiWindownCommand { get; set; }
        public ICommand MinimiWindownCommand { get; set; }


        public ControlBarViewModel() {
            CloseWindownCommand = new ReplayCommand<UserControl>((p) => { return p == null?false:true; },(p)=> { FrameworkElement windown = GetWindownParent(p);
                var w = windown as Window;
                if(w != null)
                {
                    w.Close();
                }
            });
            MaximiWindownCommand = new ReplayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement windown = GetWindownParent(p);
                var w = windown as Window;
                if (w != null)
                {
                    if(w.WindowState != WindowState.Maximized)
                    {
                        w.WindowState  = WindowState.Maximized;
                    }
                    else w.WindowState = WindowState.Normal;
                }
            });
            MinimiWindownCommand = new ReplayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement windown = GetWindownParent(p);
                var w = windown as Window;
                if (w != null)
                {
                    if (w.WindowState != WindowState.Minimized)
                    {
                        w.WindowState = WindowState.Minimized;
                    }
                    else w.WindowState = WindowState.Maximized;
                }
            });
        }
        FrameworkElement GetWindownParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
    }
}
