using Xamarin.Forms;

namespace Beatbox.Services
{
    public class AudioProvider : IAudioProvider
    {
        public IAudioPlayer CreatePlayer() => DependencyService.Get<IAudioPlayer>();

        private IAudioPlayer _player;

        public IAudioPlayer GetPlayer() => _player ?? (_player = DependencyService.Get<IAudioPlayer>());

        public IAudioRecorder CreateRecorder() => DependencyService.Get<IAudioRecorder>();

        private IAudioRecorder _recorder;

        public IAudioRecorder GetRecorder() => _recorder ?? (_recorder = DependencyService.Get<IAudioRecorder>());
    }
}