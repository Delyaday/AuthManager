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

namespace AuthManager.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ListOfResidents.xaml
    /// </summary>
    public partial class ListOfResidents : UserControl
    {
        public ListOfResidents()
        {
            InitializeComponent();

            AppContext db = new AppContext();
            List<User> users = db.Users.ToList();

            listOfusers.ItemsSource = users;
        }
    }
}
