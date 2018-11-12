using System;

namespace Beatbox
{
    public interface IAudioPlayer
    {
        event EventHandler FinishedPlaying;
        bool IsPlaying { get; }
        bool Play(string pathToAudioFile);
        void Stop();
    }
}