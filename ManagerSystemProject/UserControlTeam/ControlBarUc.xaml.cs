using ManagerSystemProject.ViewModel;
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
using System.Windows.Shapes;

namespace ManagerSystemProject.UserControlTeam
{
    /// <summary>
    /// Interaction logic for ControlBarUc.xaml
    /// </summary>
    public partial class ControlBarUc : UserControl
    {
        public ControlBarViewModel ViewModel { get; set; }

        public ControlBarUc()
        {
            InitializeComponent();
            this.DataContext = ViewModel = new ControlBarViewModel();

        }
    }
}
