using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Najdah.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["name"] = nameEntry.Text ?? "Asem Alabdali";
            App.Current.Properties["age"] = ageEntry.Text ?? "25";
            App.Current.Properties["bloodType"] = bloodTypeEntry.Text ?? "O+";
        }
    }
}