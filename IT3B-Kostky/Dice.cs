using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IT3B_Kostky
{
    public class Dice
    {
        private Grid _grid;
        public int CurrentValue { get; private set; }


        public Dice(Grid grid)
        {
            _grid = grid;
            InitializeDiceFaces();
        }

        private void InitializeDiceFaces()
        {
            for (int i = 1; i <= 6; i++)
            {
                Grid faceGrid = new Grid() { Name = $"face{i}", Visibility = Visibility.Collapsed };
                switch (i)
                {
                    case 1:
                        faceGrid.Children.Add(CreateDot(0.5, 0.5));
                        break;
                    case 2:
                        faceGrid.Children.Add(CreateDot(0.25, 0.25));
                        faceGrid.Children.Add(CreateDot(0.75, 0.75));
                        break;
                    case 3:
                        faceGrid.Children.Add(CreateDot(0.25, 0.25));
                        faceGrid.Children.Add(CreateDot(0.5, 0.5));
                        faceGrid.Children.Add(CreateDot(0.75, 0.75));
                        break;
                    case 4:
                        faceGrid.Children.Add(CreateDot(0.25, 0.25));
                        faceGrid.Children.Add(CreateDot(0.75, 0.25));
                        faceGrid.Children.Add(CreateDot(0.25, 0.75));
                        faceGrid.Children.Add(CreateDot(0.75, 0.75));
                        break;
                    case 5:
                        faceGrid.Children.Add(CreateDot(0.25, 0.25));
                        faceGrid.Children.Add(CreateDot(0.75, 0.25));
                        faceGrid.Children.Add(CreateDot(0.5, 0.5));
                        faceGrid.Children.Add(CreateDot(0.25, 0.75));
                        faceGrid.Children.Add(CreateDot(0.75, 0.75));
                        break;
                    case 6:
                        faceGrid.Children.Add(CreateDot(0.25, 0.25));
                        faceGrid.Children.Add(CreateDot(0.75, 0.25));
                        faceGrid.Children.Add(CreateDot(0.25, 0.5));
                        faceGrid.Children.Add(CreateDot(0.75, 0.5));
                        faceGrid.Children.Add(CreateDot(0.25, 0.75));
                        faceGrid.Children.Add(CreateDot(0.75, 0.75));
                        break;
                }
                _grid.Children.Add(faceGrid);
            }
        }

        private Ellipse CreateDot(double horizontalAlignment, double verticalAlignment)
        {
            return new Ellipse
            {
                Fill = Brushes.Black,
                Width = 10,
                Height = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(horizontalAlignment * _grid.Width - 5, verticalAlignment * _grid.Height - 5, 0, 0)
            };
        }

        public void Roll(Random random)
        {
            CurrentValue = random.Next(1, 7);
            ShowFace(CurrentValue);
        }

        private void ShowFace(int value)
        {
            foreach (UIElement child in _grid.Children)
            {
                if (child is Grid faceGrid)
                {
                    faceGrid.Visibility = faceGrid.Name == $"face{value}" ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

    }
}
