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
        string Count;
        int num;
        bool resultCalculator = false;
        string firstNumber = "";
        string secondNumber = "";
        string thirdNumber = "";
        string showNumber = "";

        public Calculator()
        {
            InitializeComponent();
           
        }

        private void Number()
        {
           int numFirst = Int32.Parse(firstNumber);
            int numSecond = Int32.Parse(secondNumber);
            int numThird = Int32.Parse(thirdNumber);
            switch (showNumber)
            {
                case "+":
                    thirdNumber = (numFirst + numSecond).ToString();
                    break;
                case "-":
                    thirdNumber = (numFirst - numSecond).ToString();
                    break;
                case "*":
                    thirdNumber = (numFirst * numSecond).ToString();
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
                    thirdNumber += Count;
                }
            }

            else
            {
                if (Count == "=")
                {
                    Number();
                    textBoxCount.Text += thirdNumber;
                    showNumber = "";
                }
                else
                {
                    if (secondNumber != "")
                    {
                        Number();
                        firstNumber = thirdNumber;
                        thirdNumber = "";
                    }
                    showNumber = Count;
                }
            }
        }
    }
}
