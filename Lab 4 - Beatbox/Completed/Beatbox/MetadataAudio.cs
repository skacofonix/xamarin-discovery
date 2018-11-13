using System;

namespace Beatbox
{
    public class MetadataAudio
    {
        public string File { get; }
        public TimeSpan Duration { get; }
        public DateTime Timestamp { get; }

        public MetadataAudio(string file, TimeSpan duration, DateTime timestamp)
        {
            File = file;
            Duration = duration;
            Timestamp = timestamp;
        }
    }
}