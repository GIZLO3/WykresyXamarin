using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace WykresyXamarin
{
    public partial class MainPage : TabbedPage
    {
        public static List<ChartData> ChartData { get; set; }
        public static string ChartTitle { get; set; }
        private Color[] Colors = { Color.Red, Color.Blue, Color.Orange, Color.Green, Color.Purple, Color.Gray, Color.Crimson };
        
        public MainPage()
        {
            InitializeComponent();

            ChartTitle = "Sample";
            ChartData = new List<ChartData>
            {
                new ChartData() { Name = "Seria 1", Value = 15},
                new ChartData() { Name = "Seria 2", Value = 50},
                new ChartData() { Name = "Seria 3", Value = 27},
                new ChartData() { Name = "Seria 4", Value = 75},
            };
        }

        private void BarChartAppearing(object sender, EventArgs e)
        {
            barChart.Children.Clear();
            barChart.ColumnDefinitions.Clear();
            barChart.RowDefinitions.Clear();
            for (int i = 0; i < ChartData.Count; i++)
                barChart.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            barChart.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            barChart.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Absolute) });
            barChart.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            Line horizontalLine = new Line
            {
                HeightRequest = 1,
                BackgroundColor = Color.Black
            };
            barChart.Children.Add(horizontalLine, 0, 1);

            barChartLabel.Text = Title;

            if (ChartData.Count > 0)
            {
                Grid.SetColumnSpan(horizontalLine, ChartData.Count);
                double max = ChartData.Max(x => x.Value);
                for (int i = 0; i < ChartData.Count; i++)
                {
                    StackLayout stackLayout = new StackLayout
                    {
                        BackgroundColor = Colors[i],
                        Margin = new Thickness(10),
                        HeightRequest = ChartData[i].Value / max * 700,
                        VerticalOptions = LayoutOptions.End,
                        ScaleY = 0,
                        AnchorY = 1
                    };
                    Label label = new Label
                    {
                        TextColor = Color.White,
                        HorizontalOptions = LayoutOptions.Center,
                        Text = ChartData[i].Value.ToString()
                    };
                    stackLayout.Children.Add(label);
                    Label title = new Label
                    {
                        FontSize = 17,
                        HorizontalOptions = LayoutOptions.Center,
                        Text = ChartData[i].Name
                    };
                    barChart.Children.Add(stackLayout, i, 0);
                    barChart.Children.Add(title, i, 2);
                    stackLayout.ScaleYTo(1, 2000, Easing.SinInOut);
                }
            }
        }

        private void EditDataToolbarItemClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditChartDataPage());
        }
    }
}
