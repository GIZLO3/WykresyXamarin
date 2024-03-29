﻿using System;
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
            MainPage.ChartData = new List<ChartData>();

            for (int i = 0; i < 7; i++)
            {
                if (!string.IsNullOrWhiteSpace((grid.Children[i] as Entry).Text) && !string.IsNullOrWhiteSpace((grid.Children[i + 7] as Entry).Text))
                    MainPage.ChartData.Add(new ChartData(){Name = (grid.Children[i] as Entry).Text, Value = double.Parse((grid.Children[i + 7] as Entry).Text)});
            }
            if (string.IsNullOrWhiteSpace(titleEntry.Text))
                DisplayAlert("Błąd", "Podaj poprawny tytuł", "OK");
            else
            {
                MainPage.ChartTitle = titleEntry.Text;
                Navigation.PopAsync();
            }
        }
    }
}