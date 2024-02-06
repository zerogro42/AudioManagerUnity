# Unity AudioManager Singleton

I've been using this singleton for a couple of XR projects based in Unity, figured I should keep updating it here. I referenced a few existing audio manager scripts out there, particularly this logic from [CodeMonkey](https://www.youtube.com/watch?v=QL29aTa7J5Q).

## How to Use

1. **Setup:**
   - Create an empty AudioManager GameObject and attach the script to it.
   - Define sound clips in the `SoundClips` enum list.
   - Create an Audio Mixer according to your sounds and the way you like to setup your mix.
   - In the inspector, populate the `audioClipArray` with `AudioClipToPlay` instances, associating each sound clip with its corresponding audio clip and audio mixer group.

2. **Play Sounds:**
   - Call `PlaySound3D` or `PlaySound2D` in a script attached to a GameObject to play 3D or 2D sounds, respectively.
   - Provide the appropriate parameters such as sound clip type, pitch, volume, spatial blend, spread, and loop flag.

3. **Stop Sounds:**
   - Call `StopSound` to stop a currently playing sound based on the specified sound clip.

4. **Fade In/Out:**
   - Use the `FadeInSound` and `FadeOutSound` methods for implementing sound fading.

## Example Usage

```csharp
// Play a 3D sound at the object's position with default settings
// Note - "ButtonClick" will be a sound from the Sound enum
AudioManager.PlaySound3D(AudioManager.SoundClips.ButtonClick, playerTransform, 1f, 1f, 1f, 1f, false, true, 1f);

// Play a 2D looping sound with custom pitch and volume
AudioManager.PlaySound2D(AudioManager.SoundClips.RoomAmbience, 0.8f, 0.5f, true, false, 0f);

// Stop the RoomAmbience sound
AudioManager.StopSound(AudioManager.SoundClips.RoomAmbience);

// Fade Out sound
StartCoroutine(FadeOutSound(AudioManager.SoundClips.RoomAmbience, 3f));

```
## Future
I know this can be optimized even further, probably by using object pooling instead of creating a new GameObject for each sound, if you have a lot of sounds playing frequently. I'll try adding this in the future either as a separate script or integrated into the Audio Manager.
