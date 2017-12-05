using System;
using AVFoundation;
using Foundation;
using Spelling2.iOS.Services;
using Spelling2.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlayerService))]

namespace Spelling2.iOS.Services
{
    public class AudioPlayerService : IAudioPlayerService
    {
        private AVAudioPlayer _audioPlayer;
        public Action OnFinishedPlaying { get; set; }

        public void Play(string pathToAudioFile)
        {
            // Check if _audioPlayer is currently playing
            if (_audioPlayer != null)
            {
                _audioPlayer.FinishedPlaying -= Player_FinishedPlaying;
                _audioPlayer.Stop();
            }

            var localUrl = pathToAudioFile;
            _audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename(localUrl));
            _audioPlayer.FinishedPlaying += Player_FinishedPlaying;
            _audioPlayer.Play();
        }

        public void Pause()
        {
            _audioPlayer?.Pause();
        }

        public void Play()
        {
            _audioPlayer?.Play();
        }

        private void Player_FinishedPlaying(object sender, AVStatusEventArgs e)
        {
            OnFinishedPlaying?.Invoke();
        }
    }
}