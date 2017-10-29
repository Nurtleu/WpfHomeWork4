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

namespace WpfHomeWorkFour
{
    /// <summary>
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        private string Count;
        private int num;
        private bool resultCalculator = false;
        private string firstNumber = "";
        private string secondNumber = "";
        private string showNumber = "";

        public Calculator()
        {
            InitializeComponent();
            List<string> styles = new List<string> { "dark", "white" };
            colorComboBox.SelectionChanged += ThemeChange;
            colorComboBox.ItemsSource = styles;
            colorComboBox.SelectedItem = "Black";
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string styleComboBox = colorComboBox.SelectedItem as string;
            var color = new Uri(styleComboBox + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(color) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Number()
        {
            int numFirst = Int32.Parse(firstNumber);
            int numSecond = Int32.Parse(secondNumber);
            switch (showNumber)
            {
                case "+":
                    secondNumber = (numFirst + numSecond).ToString();
                    break;
                case "-":
                    secondNumber = (numFirst - numSecond).ToString();
                    break;
                case "*":
                    secondNumber = (numFirst * numSecond).ToString();
                    break;
                case "/":
                    secondNumber = (numFirst / numSecond).ToString();
                    break;
            }
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            this.textBoxCount.Clear();
        }

        private void ButtonCalculator_Click(object sender, RoutedEventArgs e)
        {
            Count = (string)((Button)e.OriginalSource).Content;
            textBoxCount.Text += Count;
            resultCalculator = Int32.TryParse(Count, out num);

            if (resultCalculator == true)
            {
                if (showNumber == "")
                {
                    firstNumber += Count;
                }
                else
                {
                    secondNumber += Count;
                }
            }

            else
            {
                if (Count == "=")
                {
                    Number();
                    textBoxCount.Text += secondNumber;
                    showNumber = "";
                }
                else
                {
                    if (secondNumber != "")
                    {
                        Number();
                        firstNumber = secondNumber;
                        secondNumber = "";
                    }
                    showNumber = Count;
                }
            }
        }
    }
}
