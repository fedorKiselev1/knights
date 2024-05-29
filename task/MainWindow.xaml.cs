using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using classes;

namespace task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<classes.Knight> knightsArr = new List<classes.Knight> { };
        List<classes.Tavern> tavernsArr = new List<classes.Tavern> { };
        public MainWindow()
        {
            InitializeComponent();
            //tavernsArr.Add(new classes.Tavern("example", 100, 20, 10, 4, 0, 1600, "г. Ag g, ул. Gb n n, дом 20", "+7 355 999 23 43", 30, "12:00-16:00", "lame"));
            //taverns.ItemsSource = tavernsArr;
        }
        private void createKnight_Click(object sender, RoutedEventArgs e)
        {
            knightCreation win2 = new knightCreation();
            win2.ShowDialog();

            StreamReader r = new StreamReader("knight.txt");
            int linesNumber = 0;
            while (r.ReadLine() != null) { linesNumber++; }
            r.Close();
            StreamReader sr = new StreamReader("knight.txt");
            if (linesNumber != 0)
            {
                for (int i = 0; i < linesNumber; i += 2)
                {
                    Knight knightVar = new classes.Knight(sr.ReadLine(), float.Parse(sr.ReadLine()));
                    if (!checkDuplicates(knightVar))
                    {
                        errorcreate.Content = string.Empty;
                        knightsArr = knightsArr.Append(knightVar).ToList();
                    } else
                    {
                        errorcreate.Content = "knight already exists";
                    } 
                }
                knights.ItemsSource = knightsArr;
            }
            sr.Close();
            StreamWriter sw = new StreamWriter("knight.txt");
            sw.Close();
        }

        private void createTavern_Click(object sender, RoutedEventArgs e)
        {
            tavernCreation win3 = new tavernCreation();
            win3.ShowDialog();
            StreamReader r = new StreamReader("tavern.txt");
            int linesNumber = 0;
            while (r.ReadLine() != null) { linesNumber++; }
            r.Close();
            if (linesNumber != 0)
            {
                StreamReader sr = new StreamReader("tavern.txt");
                tavernsArr = tavernsArr.Append(new classes.Tavern(sr.ReadLine(), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), Convert.ToInt32(sr.ReadLine()), sr.ReadLine(), sr.ReadLine(), float.Parse(sr.ReadLine()), sr.ReadLine(), sr.ReadLine())).ToList();
                taverns.ItemsSource = tavernsArr;
                sr.Close();
                StreamWriter sw = new StreamWriter("tavern.txt");
                sw.Close();
            }

        }

        private void sendKnight_Click(object sender, RoutedEventArgs e)
        {
            if (taverns.SelectedItem != null && knights.SelectedItem != null)
            {
                bool flag = false;
                for (int i = 0; i < (taverns.SelectedItem as Tavern).knights.Count; i++)
                {
                    if ((knights.SelectedItem as Knight).name == (taverns.SelectedItem as Tavern).knights[i].name)
                    {
                        flag = true; break;
                    }
                }
                if (flag == false)
                {
                    errorsend.Content = string.Empty;
                    tavernsArr[taverns.SelectedIndex].knights = (taverns.SelectedItem as Tavern).knights.Append(knights.SelectedItem as Knight).ToList();
                    (knights.ItemsSource as List<Knight>).RemoveAt(knights.SelectedIndex);
                    var k = knights.ItemsSource;
                    knights.ItemsSource = null;
                    knights.ItemsSource = k;
                } else
                {
                    errorsend.Content = "knight with that name already exists"; 
                }
            }
            else
            {
                errorsend.Content = "select a tavern and a knight";
            }
        }

        private void selectTavern_Click(object sender, RoutedEventArgs e)
        {
            if (taverns.SelectedItem != null)
            {
                errorview.Content = string.Empty;
                knights.ItemsSource = tavernsArr[taverns.SelectedIndex].knights;
                currentKnightList.Content = tavernsArr[taverns.SelectedIndex].name;
            }
            else
            {
                errorview.Content = "select a tavern";
            }
        }

        private void deselect()
        {
            knights.ItemsSource = knightsArr;
            currentKnightList.Content = "homeless";
        }
        private void deselect_Click(object sender, RoutedEventArgs e)
        {
            deselect();
        }
        public string towerOfBabel(int length)
        {
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZабвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            Random random = new Random();
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str += letters[random.Next(letters.Length)].ToString();
            }
            return str;
        }

        private bool checkDuplicates(Knight knight)
        {
            bool flag = false;
            for (int j = 0; j < tavernsArr.Count; j++)
            {
                for (int k = 0; k < tavernsArr[j].knights.Count; k++)
                {
                    if (knight.name == tavernsArr[j].knights[k].name)
                    {
                        flag = true;
                    }
                }
            }
            for (int k = 0; k < knightsArr.Count; k++)
            {
                if (knight.name == knightsArr[k].name)
                {
                    flag = true;
                }
            }
            return flag;
        }
        private void randomTavern_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>() { "cool tavern", "epic tavern" };
            List<string> listadress = new List<string>() { "here", "or here" };
            List<string> listtime = new List<string>() { "10:00-19:00", "8:00-21:00" };
            List<string> listtype = new List<string>() { "slick", "lame", "mysterious" };
            Random random = new Random();
            int a = random.Next(100000000, 999999999);
            string b = a.ToString();
            tavernsArr = tavernsArr.Append(new Tavern(list[random.Next(0, 2)], random.Next(1, 999), random.Next(1, 999), random.Next(1, 999), random.Next(1, 5), random.Next(1, 999), random.Next(1, 2000), listadress[random.Next(0, 2)], b, random.Next(0, 999), listtime[random.Next(0, 2)], listtype[random.Next(0, 3)])).ToList();
            taverns.ItemsSource = tavernsArr;
        }
        private void randomKnight_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            List<string> list = new List<string>() { "bob", "guy", "sol", "man"};
            Knight knightVar = new Knight(list[random.Next(0, 3)], random.Next(0, 999));
            int i = 0;
            while (checkDuplicates(knightVar))
            {
                i++;
                knightVar.name += i.ToString();
            }
            knightsArr = knightsArr.Append(knightVar).ToList();
            deselect();
        }

        private void kickKnight_Click(object sender, RoutedEventArgs e)
        {
            if (knights.SelectedItem != null)
            {
                if (knights.ItemsSource != knightsArr)
                {
                    errorkick.Content = string.Empty;
                    knightsArr = knightsArr.Append(knights.SelectedItem as Knight).ToList();
                    (knights.ItemsSource as List<Knight>).RemoveAt(knights.SelectedIndex);
                    var k = knights.ItemsSource;
                    knights.ItemsSource = null;
                    knights.ItemsSource = k;
                }
                else
                {
                    errorkick.Content = "cant kick the homeless";
                }
            }
            else
            {
                errorkick.Content = "select a knight";
            }
        }
    }
}
