# Lab 2 - TipCalculator
Découverte Xamarin.forms

1. Lancer la solution
	=> Le calcul du Tips est à réaliser

2. Ouvrir MainPage.xaml

3. A la fin de la déclaration de la Grid, ajouter un label pour afficher le résultat

	<Label Grid.Column="1"
		   Grid.Row="2"
		   x:Name="TipsLabel" />

4. Ouvrir MainPage.xaml.cs, ajouter une méthode pour calculer le Tips

	private void ComputeTips()
	{
		if (double.TryParse(AmountEntry.Text, out var amount))
		{
			var tips = amount * TipsPercentSlider.Value;
			TipsLabel.Text = tips.ToString(CultureInfo.InvariantCulture);
		}
		else
		{
			TipsLabel.Text = "N/A";
		}
	}

5. Déclencher le calcul au changement de valeur du Montant (dans le constructeur)

	AmountEntry.TextChanged += (sender, args) => ComputeTips();
	
6. Déclencher le calcul au changement du pourcentage (dans le constructeur)

	TipsPercentSlider.ValueChanged += (sender, args) =>
	{
		var percent = Math.Round(args.NewValue * 100, 0);
		TipsPercentLabel.Text = $"Tips {percent:#0}%";

		ComputeTips();
	};
	
7. Et enfin déclencher le calcul du tips au chargement initial (dans le constructeur)

	ComputeTips();
	
8. Launch()!
	