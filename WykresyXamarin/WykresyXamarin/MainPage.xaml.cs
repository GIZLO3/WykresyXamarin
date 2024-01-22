using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WykresyXamarin
{
    public partial class MainPage : TabbedPage
    {
        private Color[] Colors = { Color.Red, Color.Blue, Color.Orange, Color.Green, Color.Purple, Color.Gray };

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
