# Lab 4 - BeatBox
Converters, Permission, Injection de dépendances, Custom Renderer

1. Implémenter les services IAudioPlayer et IAudioRecorder (Sous Android)

2. Enregistrer les implémentations spécifique auprès du service d'injection de dépendance de Xamarin
   Placer l'attribut Dependency juste au dessus de la déclaration du Namespace, dans chaque implémentation.

	[assembly: Dependency(typeof(AudioPlayer))]
	
3. Permission
3.1 Editer le manifest Android (Properties/AndroidManifest.xml)
	Ajouter les lignes pour expliciter les persmissions requises
	
	<uses-permission android:name="android.permission.MODIFY_AUDIO_SETTINGS" />
	<uses-permission android:name="android.permission.RECORD_AUDIO" />
	
3.2 Dans le projet Forms ouvrir la class App.xaml.cs
	Ajouter le code nécessaire pour demander la permission à l'utilisateur les permission
	
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
