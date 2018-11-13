namespace Beatbox.Services
{
    public interface IAudioPlayerProvider
    {
        IAudioPlayer Create();
    }
}