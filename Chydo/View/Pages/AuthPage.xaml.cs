using Chydo.Model;
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

namespace Chydo.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
        public AuthPage()
        {
            InitializeComponent();
            TBoxLogin.Focus();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User currentUser = db.context.User.Where(x => x.UserLogin == TBoxLogin.Text).FirstOrDefault();
                if (currentUser!=null)
                {
                    if (currentUser.UserLogin == TBoxLogin.Text && currentUser.UserPassword==TBoxPassword.Text)
                    {
                        App.CurrentUser = currentUser;
                        this.NavigationService.Navigate(new ProductPage());
                    }
                    else
                    {
                        MessageBox.Show("Не верный пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Не верый логин");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
