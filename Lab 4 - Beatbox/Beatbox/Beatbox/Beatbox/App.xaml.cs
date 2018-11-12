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

        protected override void OnStart()
        {
            Task.Run(async () =>
            {
                var permissionsNeeded = new List<Permission>
                {
                    Permission.Storage,
                    Permission.Microphone,
                    Permission.Location
                };

                foreach (var permission in permissionsNeeded)
                {
                    var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
                    if (status != PermissionStatus.Granted)
                    {
                        if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(permission))
                        {
                            await UserDialogs.Instance.AlertAsync(
                                $"L'application croquette a besoin de la permission {permission}",
                                $"Permission {permission}", "OK");
                        }

                        var results = await CrossPermissions.Current.RequestPermissionsAsync(permission);
                        if (results.ContainsKey(permission))
                            status = results[permission];
                    }

                    if (status != PermissionStatus.Granted)
                    {
                        await UserDialogs.Instance.AlertAsync(
                            "L'application Croquette ne peut pas fonctionner sans cette permission.",
                            "Permission refusée",
                            "OK");
                    }
                }
            });
        }
    }
}