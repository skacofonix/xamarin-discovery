using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Beatbox
{
    public class SoundModel : INotifyPropertyChanged
    {
        private readonly IAudioPlayer _player;
        private readonly IAudioRecorder _recorder;
        private readonly object _locker = new object();
        private string _fullpath;

        private SoundStatus _status = SoundStatus.Empty;

        public SoundStatus Status
        {
            get => _status;
            set
            {
                if (value == _status) return;
                _status = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan _duration = TimeSpan.Zero;

        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                if (value == _duration) return;
                _duration = value;
                OnPropertyChanged();
            }
        }

        public SoundModel(IAudioPlayer player, IAudioRecorder recorder)
        {
            _player = player;
            _recorder = recorder;

            _player.FinishedPlaying += (sender, args) =>
            {
                if (Status != SoundStatus.Playing) return;

                lock (_locker)
                {
                    Status = SoundStatus.Idle;
                }
            };
            _recorder.FinishedRecording += (sender, audio) =>
            {
                if (Status != SoundStatus.Recording) return;
                lock (_locker)
                {
                    Status = SoundStatus.Idle;
                }

                _fullpath = audio.File;
            };
        }

        public void StartRecord()
        {
            lock(_locker)
            {
                if (Status.HasFlag(SoundStatus.Busy)) return;
                Status = SoundStatus.Recording;
            }

            _fullpath = null;
            Duration = TimeSpan.Zero;
            _recorder.Start();
        }

        public void StopRecord()
        {
            lock (_locker)
            {
                if (Status != SoundStatus.Recording) return;
            }

            _recorder.Stop();
        }

        public void StartPlay()
        {
            lock (_locker)
            {
                if (Status.HasFlag(SoundStatus.Busy)) return;
            }

            if (_fullpath == null) return;
            _player.Play(_fullpath);
        }

        public void StopPlay()
        {
            lock (_locker)
            {
                if (Status == SoundStatus.Playing) return;
            }

            _player.Stop();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}