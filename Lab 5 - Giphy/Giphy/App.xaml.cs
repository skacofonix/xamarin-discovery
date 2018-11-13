using System;
using Giphy.Api;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Giphy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new SearchPage(new GiphyClient(new SimpleHttpClientProvider(), "9tFp7UP3V6rMWOfXDKb9Uc5FFKFPQDIg"));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
