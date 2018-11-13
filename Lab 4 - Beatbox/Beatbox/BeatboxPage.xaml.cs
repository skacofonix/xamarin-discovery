using System;

namespace Beatbox
{
    public partial class BeatboxPage
    {
        private readonly BeatboxModel _model;

        public BeatboxPage(BeatboxModel model)
        {
            _model = model;

            InitializeComponent();
            BindingContext = new BeatboxViewModel(model);
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var settingsPage = new SettingsPage(_model);
            Navigation.PushAsync(settingsPage);
        }
    }
}