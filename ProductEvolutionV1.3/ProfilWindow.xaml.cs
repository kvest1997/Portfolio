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
    /// Логика взаимодействия для ProfilWindow.xaml
    /// </summary>
    public partial class ProfilWindow : Window
    {
        public ProfilWindow(int currentId)
        {            
            InitializeComponent();

            using(Model1Container db = new Model1Container())
            {
                var currentUser = db.UserProfilSet.FirstOrDefault(x => x.UserProfilId == currentId);


                this.Title += " - "+currentUser.User.UserStatus;

                string login = currentUser.User.Login;
                string fullName = currentUser.FullName;
                string email = currentUser.Email;
                string statusWork = currentUser.StatusWork;
                string number = currentUser.Number;
                string age = currentUser.Age;


                LoginText.Text = login;
                FullNameText.Text = fullName;
                EmailText.Text = email;
                StatusText.Text = statusWork;
                NumberText.Text = number;
                AgeText.Text = age;
                
            }

        }
    }
}
