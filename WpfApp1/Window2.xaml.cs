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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private double _currentValue = 0;
        private double _storedValue = 0;
        private char _operation = '\0';
        public Window2()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();
            if (txtDisplay.Text == "0" && number != ".")
            {
                txtDisplay.Text = number;
            }
            else
            {
                txtDisplay.Text += number;
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _operation = button.Content.ToString()[0];
            _storedValue = double.Parse(txtDisplay.Text);
            txtDisplay.Text = "0";
        }

        private void EqualsButton_Click(Object sender, RoutedEventArgs e)
        {
            _currentValue = double.Parse(txtDisplay.Text);
            switch(_operation )
            {
                case '+':
                    _currentValue += _storedValue;
                    break;
                case '-':
                    _currentValue = _storedValue - _currentValue;
                    break;
                case '*':
                    _currentValue *= _storedValue;
                    break;
                case '/':
                    if(_currentValue != 0)
                    {
                        _currentValue = _storedValue / _currentValue;
                    }
                    else
                    {
                        MessageBox.Show("На 0 делить нальзя.");
                        return;
                    }
                    break;
            }
            txtDisplay.Text = _currentValue.ToString();
            _operation = '\0';
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            _storedValue = 0;
            _currentValue = 0;
            _operation = '\0';
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            MessageBox.Show(textBox.Text);
        }
    }
}
