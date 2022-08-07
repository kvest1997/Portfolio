using ProductEvolutionV1._3.Core;
using ProductEvolutionV1._3.Core.Site;
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

namespace ProductEvolutionV1._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParserWorker<string[]> parserWorker;
        ProfilWindow profilWindow;
        Model1Container dbContext;
        public MainWindow(int currentId)
        {
            InitializeComponent();

            parserWorker = new ParserWorker<string[]>(new SiteParser());
            parserWorker.OnCompleted += ParserWorker_OnCompleted;
            parserWorker.OnNewData += ParserWorker_OnNewData;
            profilWindow = new ProfilWindow(currentId);
            

            using (dbContext = new Model1Container())
            {
                for (int i = 1; i <= 8; i++)
                {
                    var nameCategory = dbContext.CategorySet.FirstOrDefault(x => x.CategoryId == i);
                    if(nameCategory != null)
                        TypeItemComboBox.Items.Add(nameCategory.Name);
                }
            }
        }

        private void ParserWorker_OnNewData(object arg1, string[] arg2)
        {
            for (int i = 0; i < arg2.Length; i++)
            {
                ListBoxResult.Items.Add(arg2[i]);
            }
        }

        private void ParserWorker_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            parserWorker.ParserSettings = new SiteSettings(EnterTextBox.Text);
            parserWorker.Start();
            PriceTextBlock.Text = Calc().ToString("#.##");

            
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ProfilMenuItem_Click(object sender, RoutedEventArgs e)
        {
            profilWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private double Calc()
        {
            double categoryRate = 0.1;
            using(dbContext = new Model1Container())
            {
                var itemRate = dbContext.RateItemsSet.FirstOrDefault(x => x.RateItemsId == RateCombo.SelectedIndex);
                categoryRate = Convert.ToDouble(itemRate.Rate);
            }

            double resultSum = 0.1;
            int Rate = 0;
            float sredSum = 0;

            for (int i = 0; i < ListBoxResult.Items.Count; i++)
            {
                string tempItem = ListBoxResult.Items[i].ToString();

                string price = tempItem.Substring(tempItem.LastIndexOf('-')+2);
                string onlyPrice = new string(price.Where(t => char.IsDigit(t)).ToArray());
                
                if(onlyPrice != "")
                    sredSum += Convert.ToInt32(onlyPrice);
                
            }

            sredSum /= ListBoxResult.Items.Count;

            switch (RateCombo.Text)
            {
                case "А - отличное": Rate = 0; break;
                case "B - хорошее": Rate = 10; break;
                case "С - среднее": Rate = 20; break;
                case "D - удовлетворительное": Rate = 30; break;
                case "C - плохое": Rate = 40; break;
            }

            resultSum = (sredSum * (categoryRate / 100)) - (sredSum * (categoryRate / 100) * (Rate / 100));

            return resultSum;
        }
    }
}
