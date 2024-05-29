using classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace task
{
    /// <summary>
    /// Логика взаимодействия для tavernCreation.xaml
    /// </summary>
    public partial class tavernCreation : Window
    {
        public tavernCreation()
        {
            InitializeComponent();
            type.SelectedIndex = 1;
        }
        private void submitTavernCreation(object sender, RoutedEventArgs e)
        {
            Regex rnumber = new Regex(@"\w+");
            Regex radress = new Regex(@"(г\.|гор\.|д\.|дер\.|с\.|пос\.)\s([A-Z]|[А-Я])\w*(\s\w+)*\,\s(ул\.|пер\.|просп\.|проспект|бульв\.|бульвар|туп\.|тупик\.|проезд|ш\.|шоссе|пл\.)\s([A-Z]|[А-Я])\w*(\s\w+)*\,\s(д\.|дом)\№?\s\d+");
            Regex rphone = new Regex(@"(\+7|8)\s(\([0-9]{3}\)|[0-9]{3})(\s|-)?[0-9]{3}(\s|-)?[0-9]{2}(\s|-)?[0-9]{2}");
            Regex rmoney = new Regex(@"(\d+|\d+\,[0-9]{2})");
            Regex rwork = new Regex(@"([01][0-9]|2[0-3]):[0-5][0-9]-([01][0-9]|2[0-3]):[0-5][0-9]");
            
            MatchCollection mseats = rnumber.Matches(seats.Text);
            MatchCollection mguests = rnumber.Matches(guests.Text);
            MatchCollection mbeds = rnumber.Matches(beds.Text);
            MatchCollection mstars = rnumber.Matches(stars.Text);
            MatchCollection mbandits = rnumber.Matches(bandits.Text);
            MatchCollection myear = rnumber.Matches(year.Text);
            MatchCollection madress = radress.Matches(adress.Text);
            MatchCollection mphone = rphone.Matches(phone.Text);
            MatchCollection mmoney = rmoney.Matches(money.Text);
            MatchCollection mwork = rwork.Matches(work.Text);
            if (mseats.Count > 0 && mguests.Count > 0 && mbeds.Count > 0 && mstars.Count > 0 && mbandits.Count > 0 && myear.Count > 0 && madress.Count > 0 && mphone.Count > 0 && mmoney.Count > 0 && mwork.Count > 0)
            {
                StreamWriter sw = new StreamWriter("tavern.txt");
                sw.WriteLine($"{name.Text}");
                sw.WriteLine($"{seats.Text}");
                sw.WriteLine($"{guests.Text}");
                sw.WriteLine($"{beds.Text}");
                sw.WriteLine($"{stars.Text}");
                sw.WriteLine($"{bandits.Text}");
                sw.WriteLine($"{year.Text}");
                sw.WriteLine($"{adress.Text}");
                sw.WriteLine($"{phone.Text}");
                sw.WriteLine($"{money.Text}");
                sw.WriteLine($"{work.Text}");
                sw.WriteLine($"{type.Text}");
                sw.Close();
                DialogResult = true;
            
            } else
            {
                ctavernerror.Content = "there is a mistake somewhere";
            }
            
        }
    }
}
