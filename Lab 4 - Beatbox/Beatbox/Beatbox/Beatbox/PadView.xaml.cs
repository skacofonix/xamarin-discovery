using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Beatbox
{
    public partial class PadView
    {
        public static readonly BindableProperty StartCommandProperty = BindableProperty.Create(
            nameof(StartCommand),
            typeof(ICommand),
            typeof(PadView));

        public static readonly BindableProperty StopCommandProperty = BindableProperty.Create(
            nameof(StopCommand),
            typeof(ICommand),
            typeof(PadView));

        public static readonly BindableProperty StatusProperty = BindableProperty.Create(
            nameof(Status),
            typeof(SoundStatus),
            typeof(PadView));

        public PadView()
        {
            InitializeComponent();
        }

        private void OnPressed(object sender, EventArgs e)
        {
            if (StartCommand == null) return;
            if (StartCommand.CanExecute(BindingContext))
            {
                StartCommand.Execute(BindingContext);
            }
        }

        private void OnReleased(object sender, EventArgs e)
        {
            if(StopCommand == null) return;
            if (StopCommand.CanExecute(BindingContext))
            {
                StopCommand.Execute(BindingContext);
            }
        }

        public ICommand StartCommand
        {
            get => (ICommand)GetValue(StartCommandProperty);
            set => SetValue(StartCommandProperty, value);
        }

        public ICommand StopCommand
        {
            get => (ICommand)GetValue(StopCommandProperty);
            set => SetValue(StopCommandProperty, value);
        }

        public SoundStatus Status
        {
            get => (SoundStatus)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }
    }
}