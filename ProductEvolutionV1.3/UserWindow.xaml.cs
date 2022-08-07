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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                var user = db.UserSet.FirstOrDefault(x => x.Login == LoginTextBox.Text && x.Password == PasswordTextBox.Password);

                    if ((LoginTextBox.Text == "root" && PasswordTextBox.Password == "root"))
                    {
                        MessageBox.Show("OK!");
                        AdminWindow adminWindow = new AdminWindow(1);

                        this.Close();
                        adminWindow.ShowDialog();

                }
                else if (user != null)
                    {
                        switch (user.UserStatus)
                        {
                            case "ADMIN":
                                AdminWindow adminWindow = new AdminWindow(user.UserProfil.UserProfilId);
                                this.Close();
                                adminWindow.ShowDialog();
                                break;
                            case "USER":
                                MainWindow mainWindow = new MainWindow(user.UserProfil.UserProfilId);
                                this.Close();
                                mainWindow.ShowDialog();
                                break;
                        }
                    }
                    else
                        MessageBox.Show("Неверные данные!");
            }
        }


    }
}
