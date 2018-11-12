using System;

namespace Beatbox
{
    public partial class SettingsPage
    {
        private readonly BeatboxModel _model;

        public SettingsPage(BeatboxModel model)
        {
            _model = model;

            InitializeComponent();
            BindingContext = new SettingsViewModel(model);
        }
    }
}