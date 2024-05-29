using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Windows.Media.Media3D;

namespace task
{
    /// <summary>
    /// Логика взаимодействия для knightCreation.xaml
    /// </summary>
    public partial class knightCreation : Window
    {
        public knightCreation()
        {
            InitializeComponent();
        }
        private void submitKnightCreation(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"(\w+\s\d+,\s?)*(\w+\s\d+)");
            MatchCollection matches = regex.Matches(knights.Text);
            if (matches.Count > 0)
            {
                StreamWriter sw = new StreamWriter("knight.txt");
                string[] knightStringArr = knights.Text.Split(",");
                string knightsFinal = "";
                for (int f = 0; f < knightStringArr.Length; f++)
                {
                    string i = knightStringArr[f].Trim();
                    string[] iArr = i.Split(" ");
                    for (int j = 0; j < iArr.Length; j++)
                    {
                        knightsFinal += iArr[j];
                        if (f != knightStringArr.Length - 1 || j != iArr.Length - 1)
                        {
                            knightsFinal += "\n";
                        }
                    }
                }
                sw.WriteLine($"{knightsFinal}");
                sw.Close();
                DialogResult = true;
            } else
            {
                kcreateerror.Content = "wrong format";
            }

            //    ((MainWindow)Application.Current.MainWindow)
        }
    }
}
