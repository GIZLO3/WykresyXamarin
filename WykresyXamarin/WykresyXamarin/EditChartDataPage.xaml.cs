using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WykresyXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditChartDataPage : ContentPage
    {
        public EditChartDataPage()
        {
            InitializeComponent();

            for (int i = 0; i < MainPage.ChartData.Count; i++)
            {
                (grid.Children[i] as Entry).Text = MainPage.ChartData[i].Name;
                (grid.Children[i + 7] as Entry).Text = MainPage.ChartData[i].Value.ToString();
            }
            titleEntry.Text = MainPage.ChartTitle;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {

        }
    }
}