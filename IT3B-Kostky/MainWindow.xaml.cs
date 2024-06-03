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

        private Random _random;
        private Dice[] _diceArray;

        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();

            _diceArray = new Dice[6];
            _diceArray[0] = new Dice(diceGrid1);
            _diceArray[1] = new Dice(diceGrid2);
            _diceArray[2] = new Dice(diceGrid3);
            _diceArray[3] = new Dice(diceGrid4);
            _diceArray[4] = new Dice(diceGrid5);
            _diceArray[5] = new Dice(diceGrid6);
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var dice in _diceArray)
            {
                dice.Roll(_random);
            }
        }
    }
}