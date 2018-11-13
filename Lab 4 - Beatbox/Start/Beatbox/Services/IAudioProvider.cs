namespace Beatbox.Services
{
    public interface IAudioProvider
    {
        IAudioPlayer CreatePlayer();
        IAudioPlayer GetPlayer();
        IAudioRecorder CreateRecorder();
        IAudioRecorder GetRecorder();
    }
}