namespace Beatbox
{
    public interface IAudioProvider
    {
        IAudioPlayer CreatePlayer();
        IAudioPlayer GetPlayer();
        IAudioRecorder CreateRecorder();
        IAudioRecorder GetRecorder();
    }
}