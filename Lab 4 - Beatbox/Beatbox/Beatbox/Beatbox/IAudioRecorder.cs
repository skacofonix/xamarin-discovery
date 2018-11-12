using System;

namespace Beatbox
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