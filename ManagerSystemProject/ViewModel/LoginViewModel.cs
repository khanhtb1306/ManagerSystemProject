using ManagerSystemLibrary.Repository;
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

     public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }
        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        IUserRepository managerRepository;
     
        public LoginViewModel()
        {
            managerRepository = new UserRepository();
            IsLogin = false;
            LoginCommand = new ReplayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            CloseCommand = new ReplayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });

            PasswordChangedCommand = new ReplayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

        }
        public void Login(Window p)
        {
            
            if (p == null) return;

            var user = managerRepository.GetUserByName(UserName);
            if (user != null)
            {
                if (user.Password.Equals(Password))
                {
                    IsLogin = true;
                    p.Close();

                }
                else
                {
                    IsLogin = false;
                    MessageBox.Show("Password is wrong!");

                }
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Username is wrong!");


            }
        }
    }
}
