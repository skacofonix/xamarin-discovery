using System.Windows.Input;
using Xamarin.Forms;

namespace Beatbox
{
    public class SettingsViewModel
    {
        private readonly BeatboxModel _model;

        public ObservableRangeCollection<SoundModel> Sounds { get; } = new ObservableRangeCollection<SoundModel>();

        public SettingsViewModel(BeatboxModel model)
        {
            _model = model;
            Sounds.AddRange(model.Sounds);
        }

        private Command<SoundModel> _startRecordCommand;

        public ICommand StartRecordCommand => _startRecordCommand ?? (_startRecordCommand = new Command<SoundModel>(sound =>
        {
            sound?.StartRecord();
        }));

        private Command<SoundModel> _stopRecordCommand;

        public ICommand StopRecordCommand =>_stopRecordCommand ?? (_stopRecordCommand = new Command<SoundModel>(sound =>
        {
            sound?.StopRecord();
        }));
    }
}