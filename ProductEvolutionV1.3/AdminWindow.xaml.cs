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

namespace ProductEvolutionV1._3
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        ProfilWindow profilWindow;
        public AdminWindow(int currentId)
        {
            using(Model1Container db = new Model1Container())
            {
                var currentUser = db.UserProfilSet.FirstOrDefault(x => x.UserProfilId == currentId);
                profilWindow = new ProfilWindow(currentId);
            }
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            profilWindow.Show();
        }
    }
}
