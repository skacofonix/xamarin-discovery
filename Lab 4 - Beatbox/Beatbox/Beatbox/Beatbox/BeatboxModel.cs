using System.Collections.Generic;

namespace Beatbox
{
    public class BeatboxModel
    {
        public List<SoundModel> Sounds { get; } = new List<SoundModel>();

        public BeatboxModel(int nbPad, IAudioProvider audioProvider)
        {
            var recorder = audioProvider.GetRecorder();

            for (var i = 0; i < nbPad; i++)
            {
                var player = audioProvider.GetPlayer();
                var hash = player.GetHashCode();
                Sounds.Add(new SoundModel(player, recorder));
            }
        }
    }
}