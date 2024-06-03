using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IT3B_Kostky
{
 /// <summary>
 /// Interaction logic for MainWindow.xaml
 /// </summary>
 public partial class MainWindow : Window
 {

    private Random random;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            int diceRoll = random.Next(1, 7); // Generate a number between 1 and 6
            resultText.Text = $"You rolled a {diceRoll}";
            ShowDiceFace(diceRoll);
        }

        private void ShowDiceFace(int face)
        {
            dice1.Visibility = Visibility.Collapsed;
            dice2.Visibility = Visibility.Collapsed;
            dice3.Visibility = Visibility.Collapsed;
            dice4.Visibility = Visibility.Collapsed;
            dice5.Visibility = Visibility.Collapsed;
            dice6.Visibility = Visibility.Collapsed;

            switch (face)
            {
                case 1:
                    dice1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    dice2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    dice3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    dice4.Visibility = Visibility.Visible;
                    break;
                case 5:
                    dice5.Visibility = Visibility.Visible;
                    break;
                case 6:
                    dice6.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}