using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR.Interaction.Toolkit;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    /// <summary>
    /// Holds all sound clip types.
    /// </summary>
    public enum SoundClips
    {
        ButtonClick,
        ButtonHover,
        MarkerHover,
        CardAnimIn,
        CardAnimOut,
        TableMoveUp,
        TableMoveDown,
        EarthAmbience,
        RoomAmbience,
        ExitButtonClick,
        GCBusClick,
        GCBusZoom,
    }

    /// <summary>
    /// SoundClipClass holds all the values of
    /// the sounds and their clips.
    /// </summary>
    [System.Serializable]
    public class AudioClipToPlay
    {
        public SoundClips soundClips;
        public AudioClip audioClip;
        public AudioMixerGroup audioMixerGroup;
    }
    public AudioClipToPlay[] audioClipArray;


    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        };
    }


    /// <summary>
    /// Store the currently playing audio sources for looped sounds.
    /// </summary>
    private static Dictionary<SoundClips, AudioSource> playingAudioSources = new Dictionary<SoundClips, AudioSource>();

    /// <summary>
    /// Takes in a sound audio clip, and assigns floats
    /// to the parameters of the instantiated audio source,
    /// to be played for 3D sounds.
    /// </summary>
    /// <param name="sound"></param>
    /// <param name="pitch"></param>
    /// <param name="volume"></param>
    /// <param name="spatialBlend"></param>
    /// <param name="spread"></param>
    /// <param name="loop"></param>
    public static void PlaySound3D(SoundClips sound, Transform positionTransform, float pitch, float volume, float spatialBlend, float spread, bool loop = false)
    {

        if (playingAudioSources.ContainsKey(sound) && playingAudioSources[sound].isPlaying)
        {
            return;
        }

        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        AudioMixerGroup audioMixerGroup = GetMixer(sound);
        soundGameObject.transform.position = positionTransform.position;

        audioSource.outputAudioMixerGroup = audioMixerGroup;
        audioSource.clip = GetAudioClip(sound);
        audioSource.pitch = pitch;
        audioSource.volume = volume;
        audioSource.spatialBlend = spatialBlend;
        audioSource.spread = spread;
        audioSource.loop = loop;

        audioSource.Play();

        if (loop == true)
        {
            playingAudioSources[sound] = audioSource;
        }
        else if (loop == false)
        {
            Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    /// <summary>
    /// Same as 3D, without the transform of the game object,
    /// and spatial settings.
    /// </summary>
    /// <param name="sound"></param>
    /// <param name="positionTransform"></param>
    /// <param name="pitch"></param>
    /// <param name="volume"></param>
    /// <param name="spatialBlend"></param>
    /// <param name="spread"></param>
    /// <param name="loop"></param>
    public static void PlaySound2D(SoundClips sound, float pitch, float volume, bool loop = false)
    {

        if (playingAudioSources.ContainsKey(sound) && playingAudioSources[sound].isPlaying)
        {
            return;
        }

        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        AudioMixerGroup audioMixerGroup = GetMixer(sound);

        audioSource.outputAudioMixerGroup = audioMixerGroup;
        audioSource.clip = GetAudioClip(sound);
        audioSource.pitch = pitch;
        audioSource.volume = volume;
        audioSource.loop = loop;

        audioSource.Play();

        if (loop == true)
        {
            playingAudioSources[sound] = audioSource;
        }
        else if (loop == false)
        {
            Destroy(soundGameObject, audioSource.clip.length);
        }
    }


    /// <summary>
    /// Get the correct sound clip from the sound clip array.
    /// </summary>
    /// <param name="sound"></param>
    /// <returns></returns>
    private static AudioClip GetAudioClip(SoundClips sound)
    {
        foreach (AudioClipToPlay audioClipToPlay in Instance.audioClipArray)
        {
            if(audioClipToPlay.soundClips == sound)
            {
                return audioClipToPlay.audioClip;
            }
        }
        Debug.LogError("Sound" + sound + "not found!");
        return null;
    }


    /// <summary>
    /// Get mixer channel for the associated AudioClipToPlay enum audio source.
    /// </summary>
    /// <param name="sound"></param>
    /// <returns></returns>
    private static AudioMixerGroup GetMixer(SoundClips sound)
    {
        foreach (AudioClipToPlay audioClipToPlay in Instance.audioClipArray)
        {
            if(audioClipToPlay.soundClips == sound)
            return audioClipToPlay.audioMixerGroup;
        }
        return null;
    }


    // Stop Sound
    public static void StopSound(SoundClips sound)
    {
        if (playingAudioSources.ContainsKey(sound))
        {
            AudioSource audioSource = playingAudioSources[sound];
            audioSource.loop = false;
            audioSource.Stop();
            playingAudioSources.Remove(sound);

            Destroy(audioSource.gameObject);
        }
    }

    // Fade In Sound
    public void FadeInSound(float time)
    {

    }

    // Fade Out Sound
    public void FadeOutSound(float time)
    {

    }
}
