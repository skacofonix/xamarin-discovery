using System;

namespace Beatbox.Services
{
    public interface IAudioRecorder
    {
        event EventHandler<MetadataAudio> FinishedRecording;
        TimeSpan RecordDuration { get; }
        bool IsRecording { get; }
        void Start();
        void Stop();
    }
}