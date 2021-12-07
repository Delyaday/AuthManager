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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AuthManager
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(5);
            signInButton.BeginAnimation(Button.WidthProperty, btnAnimation);
        }

        private void log_click(object sender, RoutedEventArgs e)
        {

            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Login can't be less than 5 symbols!";
                textBoxLogin.BorderBrush = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Password can't be less than 5 symbols!";
                passBox.BorderBrush = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = null;
                textBoxLogin.BorderBrush = Brushes.Transparent;

                passBox.ToolTip = null;
                passBox.BorderBrush = Brushes.Transparent;

                User logUser = null;
                using (AppContext db = new AppContext())
                {
                    logUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if(logUser != null)
                {
                    MessageBox.Show("All is good, thank you for choosing us!");
                    UserPage userPage = new UserPage();
                    userPage.Show();
                    this.Close();
                } 
                else
                {
                    MessageBox.Show("Login or Pass is wrong!");
                }

            }

        }

        private void reg_window_click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWondow = new MainWindow();
            mainWondow.Show();
            this.Hide();
        }
    }
}
