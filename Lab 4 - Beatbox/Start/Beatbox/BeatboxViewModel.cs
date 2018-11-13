using System.Windows.Input;
using Beatbox.Common;
using Xamarin.Forms;

namespace Beatbox
{
    public class BeatboxViewModel
    {
        private readonly BeatboxModel _model;

        public ObservableRangeCollection<SoundModel> Sounds { get; } = new ObservableRangeCollection<SoundModel>();

        public BeatboxViewModel(BeatboxModel model)
        {
            _model = model;
            Sounds.AddRange(model.Sounds);
        }

        private Command<SoundModel> _startPlayCommand;

        public ICommand StartPlayCommand => _startPlayCommand ?? (_startPlayCommand = new Command<SoundModel>(sound =>
        {
            sound.StartPlay();
        }));

        private Command<SoundModel> _stopPlayCommand;

        public ICommand StopPlayCommand => _stopPlayCommand ?? (_stopPlayCommand = new Command<SoundModel>(sound =>
        {
            sound?.StopRecord();
        }));
    }
}