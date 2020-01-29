using Najdah.Models;
using Najdah.Services;
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
    public partial class MainView : ContentPage
    {
        ReportingService _reportingService;
        private Person person = new Person();
        private Report report = new Report();
        public MainView()
        {
            InitializeComponent();
            _reportingService = new ReportingService();

        }

        protected async override void OnAppearing()
        {

            person.Name = App.Current.Properties.ContainsKey("name") ? 
                                    App.Current.Properties["name"].ToString() : "Asem Alabdali";
            person.Age = App.Current.Properties.ContainsKey("age") ? 
                                    int.Parse(App.Current.Properties["age"].ToString()) : 22;
            person.BloodType = App.Current.Properties.ContainsKey("bloodType") ?
                                    App.Current.Properties["bloodType"].ToString() : "O+";

            await _reportingService.ConnectAsync();
        }

        private async void PoliceButtonClicked(object sender, EventArgs e)
        {
            string location = await DisplayPromptAsync("Location", "Type Emergency Location", "Send");
            report.ReportType = ReportType.Policeman;
            report.Location = location ?? "PV6 - Taman melati - Malaysia";
            Dispatcher.BeginInvokeOnMainThread(async () =>
            {
                await _reportingService.Send(person, report);
            });
        }

        private async void HospitalButtonClicked(object sender, EventArgs e)
        {
            string location = await DisplayPromptAsync("Location", "Type Emergency Location" ,"Send");
            report.ReportType = ReportType.Hospital;
            report.Location = location ?? "PV6 - Taman melati - Malaysia";
            Dispatcher.BeginInvokeOnMainThread(async () =>
            {
                await _reportingService.Send(person, report);
            });
        }
        private async void FirefighterButtonClicked(object sender, EventArgs e)
        {
            string location = await DisplayPromptAsync("Location", "Type Emergency Location", "Send");
            report.ReportType = ReportType.Firefighter;
            report.Location = location ?? "PV6 - Taman melati - Malaysia";
            Dispatcher.BeginInvokeOnMainThread(async () =>
            {
                await _reportingService.Send(person, report);
            });
        }
        private async void WorkerButtonClicked(object sender, EventArgs e)
        {
            string location = await DisplayPromptAsync("Location", "Type Emergency Location", "Send");
            report.ReportType = ReportType.Municipality;
            report.Location = location ?? "PV6 - Taman melati - Malaysia";
            Dispatcher.BeginInvokeOnMainThread(async () =>
            {
                await _reportingService.Send(person, report);
            });
        }

    }
}