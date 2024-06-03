using Microsoft.Win32;
using System.IO;
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
        private List<string> _history;
        private string _filePath = "dice_roll_history.txt";



        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
            _history = new List<string>();

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
            int[] results = new int[6];
            for (int i = 0; i < _diceArray.Length; i++)
            {
                _diceArray[i].Roll(_random);
                results[i] = _diceArray[i].CurrentValue;
            }
            AddToHistory(results);
            SaveHistoryToFile();
        }

        private void AddToHistory(int[] results)
        {
            string resultString = string.Join(", ", results);
            _history.Add(resultString);
            historyListBox.Items.Add(resultString);
        }

        private void SaveHistoryToFile()
        {
            File.WriteAllLines(_filePath, _history);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = "dice_roll_history.txt",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                File.Copy(_filePath, saveFileDialog.FileName, true);
            }
        }
    }
}