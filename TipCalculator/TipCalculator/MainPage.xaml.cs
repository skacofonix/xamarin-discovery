using System;
using System.Globalization;

namespace TipCalculator
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            AmountEntry.TextChanged += (sender, args) => ComputeTips();
            TipsPercentSlider.ValueChanged += (sender, args) =>
            {
                var percent = Math.Round(args.NewValue * 100, 0);
                TipsPercentLabel.Text = $"Tips {percent:#0}%";

                ComputeTips();
            };

            ComputeTips();
        }

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
    }
}