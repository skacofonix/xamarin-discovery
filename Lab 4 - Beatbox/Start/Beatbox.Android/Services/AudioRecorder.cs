using System;
using System.IO;
using System.Threading.Tasks;
using Android.Media;
using Beatbox.Droid.Services;
using Beatbox.Services;
using Xamarin.Forms;

namespace Beatbox.Droid.Services
{
    public class AudioRecorder : IDisposable, IAudioRecorder
    {
        private const string OutputFilePatternName = "{0:yyyyMMddHHmmss}-{1:mmss}";
        private const string OutputFileExtension = "amr";
        private readonly MediaRecorder _recorder;

        public event EventHandler<MetadataAudio> FinishedRecording;

        public AudioRecorder()
        {
            _recorder = new MediaRecorder();
        }

        private DateTime _lastRecordStartTime;
        private string _lastRecordFullpath;

        public TimeSpan RecordDuration
        {
            get
            {
                if (!IsRecording)
                    return TimeSpan.Zero;
                return DateTime.Now - _lastRecordStartTime;
            }
        }

        public bool IsRecording { get; private set; }

        public void Start()
        {
            if (IsRecording) return;

            _lastRecordFullpath = GenerateTempFilepath();

            _recorder.Reset();
            _recorder.SetAudioSource(AudioSource.Mic);
            _recorder.SetOutputFormat(OutputFormat.ThreeGpp);
            _recorder.SetAudioEncoder(AudioEncoder.AmrWb);
            _recorder.SetOutputFile(_lastRecordFullpath);
            _recorder.Prepare();
            _recorder.Start();

            _lastRecordStartTime = DateTime.Now;

            IsRecording = true;
        }

        public void Stop()
        {
            if (!IsRecording) return;

            _recorder.Stop();
            IsRecording = false;

            var now = DateTime.Now;
            var duration = DateTime.Now - _lastRecordStartTime;
            var tempFullpath = _lastRecordFullpath.Substring(0);

            Task.Run(() => { FinalizeFile(tempFullpath, duration, now); });
        }

        private void FinalizeFile(string tempFilepath, TimeSpan recordDuration, DateTime recordTimestamp)
        {
            var ouputFilepath = GenerateOuputFilepath(recordDuration);
            File.Move(tempFilepath, ouputFilepath);
            var metaDataAudio = new MetadataAudio(ouputFilepath, recordDuration, recordTimestamp);

            FinishedRecording?.Invoke(this, metaDataAudio);
        }

        private static string GenerateTempFilepath()
        {
            var directory = Path.GetTempPath();
            const string filenameWithoutExtension = "output";
            var filename = Path.ChangeExtension(filenameWithoutExtension, OutputFileExtension);
            var fullepath = Path.Combine(directory, filename);
            return fullepath;
        }

        private static string GenerateOuputFilepath(TimeSpan duration)
        {
            var directory = Path.GetTempPath();
            var filenameWithoutExtension = string.Format(OutputFilePatternName, DateTime.UtcNow, duration);
            var filename = Path.ChangeExtension(filenameWithoutExtension, OutputFileExtension);
            var fullepath = Path.Combine(directory, filename);
            return fullepath;
        }

        public void Dispose()
        {
            _recorder.Release();
            _recorder.Dispose();
        }
    }
}