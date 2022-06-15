using UnityEngine;

namespace Platformer.Infrastructure.Audio
{
    public interface IAudioService
    {
        float GlobalVolume { get; }
        float SfxVolume { get; }
        float MusicVolume { get; }

        void Bootstrap();
        void SetGlobalVolume(float volume);
        void SetSfxVolume(float volume);
        void SetMusicVolume(float volume);
        
        void PlaySfx(AudioClip audioClip);
        void PlaySfx(SfxType sfxType);

        void PlayMusic(MusicType musicType);
    }
}