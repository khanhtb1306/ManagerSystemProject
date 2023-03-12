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
    public class MainViewModel : BaseViewModel
    {
        public ICommand LoadedWindownCommand { get; set; }
        public ICommand LoadProductWindowCommand { get; set; }

        public bool IsLoad = false;
        public MainViewModel()
        {
            LoadedWindownCommand = new ReplayCommand<Window>((p) => { return true; }, (p) => {
                IsLoad = true;
                if (p == null) return;
                p.Hide();
                LoginWindown loginWindown = new LoginWindown();
                loginWindown.ShowDialog();
                if (loginWindown == null) return;
                var loginVM = loginWindown.DataContext as LoginViewModel;
                
                if (loginVM.IsLogin) p.Show();
                else p.Close();
            });
            LoadProductWindowCommand = new ReplayCommand<Window>((p) => { return true; }, (p) => {
               ProductWindow productWindow = new ProductWindow();
                productWindow.ShowDialog();
            });


        }
    }
}
