using Beatbox.Droid.Services;
using Beatbox.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlayerProvider))]
namespace Beatbox.Droid.Services
{
    public class AudioPlayerProvider : IAudioPlayerProvider
    {
        public IAudioPlayer Create()
        {
            return new AudioPlayer();
        }
    }
}