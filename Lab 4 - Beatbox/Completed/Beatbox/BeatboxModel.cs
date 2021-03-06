﻿using System.Collections.Generic;
using Beatbox.Services;

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
                var player = audioProvider.CreatePlayer();
                Sounds.Add(new SoundModel(player, recorder));
            }
        }
    }
}