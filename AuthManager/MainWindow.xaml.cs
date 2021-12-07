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
using System.Windows.Media.Animation;

namespace AuthManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(5);
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation);
        }

        private void reg_button(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Login can't be less than 5 symbols!";
                textBoxLogin.BorderBrush = Brushes.DarkRed;
            } else if (pass.Length < 5)
            {
                Clear();
                passBox.ToolTip = "Password can't be less than 5 symbols!";
                passBox.BorderBrush = Brushes.DarkRed;
            } else if (pass != pass_2)
            {
                Clear();
                passBox_2.ToolTip = "Password doesn't match!";
                passBox_2.BorderBrush = Brushes.DarkRed;
            }
             else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                Clear();
                textBoxEmail.ToolTip = "Email is not correct!";
                textBoxEmail.BorderBrush = Brushes.DarkRed;
            } 
            else
            {
                MessageBox.Show("All is good, thank you for choosing us!");
                User user = new User(login, pass, email);

                db.Users.Add(user);
                db.SaveChanges();

                SignIn signIn = new SignIn();
                signIn.Show();
                this.Close();
            }

        }

        private void Clear()
        {
            textBoxLogin.ToolTip = null;
            textBoxLogin.BorderBrush = Brushes.Transparent;

            passBox.ToolTip = null;
            passBox.BorderBrush = Brushes.Transparent;

            passBox_2.ToolTip = null;
            passBox_2.BorderBrush = Brushes.Transparent;

            textBoxEmail.ToolTip = null;
            textBoxEmail.BorderBrush = Brushes.Transparent;
        }

        private void signIn_click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            this.Close();
        }
    }
}
