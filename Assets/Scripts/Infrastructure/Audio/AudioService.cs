using Platformer.Infrastructure.Audio.Info;
using UnityEngine;

namespace Platformer.Infrastructure.Audio
{
    public class AudioService : IAudioService
    {
        private readonly AudioContainer _audioContainer;

        private AudioSource _musicSource;

        public float GlobalVolume { get; private set; }
        public float SfxVolume { get; private set; }
        public float MusicVolume { get; private set; }

        public AudioService(AudioContainer audioContainer)
        {
            _audioContainer = audioContainer;
        }

        public void Bootstrap()
        {
            Load();
            CreateMusicSource();
        }

        public void SetGlobalVolume(float volume)
        {
            GlobalVolume = volume;
            // TODO: Change volume in _musicSource
            // TODO: Change volume in all cached sfxs
            
            Save();
        }

        public void SetSfxVolume(float volume)
        {
            // TODO: Change volume in all cached sfxs
        }

        public void SetMusicVolume(float volume)
        {
            // TODO: Change volume in _musicSource
        }

        public void PlaySfx(AudioClip audioClip)
        {
            InstantiateSfx(audioClip);
        }

        public void PlaySfx(SfxType sfxType)
        {
            SfxInfo sfxInfo = _audioContainer.Info(sfxType);
            if (sfxInfo == null)
                return;

            InstantiateSfx(sfxInfo);
        }

        private void InstantiateSfx(SfxInfo sfxInfo)
        {
            GameObject go = new GameObject();
            AudioSource source = go.AddComponent<AudioSource>();
            // source.clip = sfxInfo.Clip;
            source.volume = Volume(sfxInfo);

            // return source;
        }

        private void InstantiateSfx(AudioClip audioClip)
        {
            GameObject go = new GameObject();
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = audioClip;
            source.volume = Volume();
        }

        public void PlayMusic(MusicType musicType)
        {
            MusicInfo info = _audioContainer.Info(musicType);
            // _musicSource.clip = info.Clip;
            _musicSource.volume = Volume(info);
        }

        private void CreateMusicSource()
        {
            GameObject go = new GameObject("MusicAudioSource");
            _musicSource = go.AddComponent<AudioSource>();
        }

        private float Volume(SfxInfo sfxInfo) =>
            sfxInfo.Volume * Volume();

        private float Volume(MusicInfo info) =>
            info.Volume * Volume();

        private float Volume() =>
            GlobalVolume * SfxVolume;

        private void Save()
        {
            // TODO: Save volumes to prefs
        }

        private void Load()
        {
            // TODO: Load volume from prefs
        }
    }
}