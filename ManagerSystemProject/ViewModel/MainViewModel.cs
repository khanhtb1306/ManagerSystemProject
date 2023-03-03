using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagerSystemProject.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoad = false;
        public MainViewModel()
        {
            if (!IsLoad)
            {
                LoginWindown loginWindown = new LoginWindown();
                loginWindown.Show();
            }
            IsLoad = true;

        }
    }
}
