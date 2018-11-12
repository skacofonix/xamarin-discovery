using System;
using System.IO;
using Android.Media;
using Beatbox.Droid;
using Java.Lang;
using Xamarin.Forms;
using Exception = System.Exception;

[assembly: Dependency(typeof(AudioPlayer))]
namespace Beatbox.Droid
{
    public class AudioPlayer : IDisposable, IAudioPlayer
    {
        private readonly MediaPlayer _player;

        public event EventHandler FinishedPlaying;

        public AudioPlayer()
        {
            _player = new MediaPlayer();
            _player.Completion += MediaPlayer_Completion;
        }

        public bool Play(string filepath)
        {
            var isPlaying = false;

            _player.Reset();

            try
            {
                _player.SetDataSource(filepath);
                _player.Prepare();
                _player.Start();
                isPlaying = true;
            }
            catch (IllegalArgumentException illegalArgumentException)
            {
                Console.WriteLine(illegalArgumentException);
            }
            catch (IOException ioException)
            {
                Console.WriteLine(ioException);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return isPlaying;
        }

        public bool IsPlaying => _player?.IsPlaying ?? false;

        private void MediaPlayer_Completion(object sender, EventArgs e)
        {
            FinishedPlaying?.Invoke(this, EventArgs.Empty);
        }

        public void Stop()
        {
            _player.Stop();
        }

        public void Dispose()
        {
            _player.Release();
            _player.Dispose();
        }
    }
}