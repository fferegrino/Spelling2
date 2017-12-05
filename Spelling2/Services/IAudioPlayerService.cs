using System;

namespace Spelling2.Services
{
    public interface IAudioPlayerService
    {
        Action OnFinishedPlaying { get; set; }
        void Play(string pathToAudioFile);
        void Play();
        void Pause();
    }
}