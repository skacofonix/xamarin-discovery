using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Beatbox.Services;
using DLToolkit.Forms.Controls;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Beatbox
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            FlowListView.Init();

            var model = new BeatboxModel(20, new AudioProvider());
            var beatBoxPage = new BeatboxPage(model);
            MainPage = new NavigationPage(beatBoxPage);
        }
    }
}