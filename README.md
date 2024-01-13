# Unity AudioManager Singleton

I've been using this singleton for a couple of XR projects based in Unity, figured I should keep updating it here. I referenced a few existing audio manager scripts out there, particularly this logic from [CodeMonkey]([url](https://www.youtube.com/watch?v=QL29aTa7J5Q)).
## Features

- **SoundClips Enumeration:** Enumerates all sound clip types for easy reference.
- **AudioClipToPlay Class:** Holds the values of sound clips and their associated audio clips.
- **PlaySound3D Method:** Plays 3D sounds with spatial settings, allowing for positioning in 3D space.
- **PlaySound2D Method:** Plays 2D sounds without spatial settings.
- **StopSound Method:** Stops a currently playing sound based on the specified sound clip.
- **FadeInSound and FadeOutSound Methods:** Placeholder methods for future implementation of sound fading.

## How to Use

1. **Setup:**
   - Create an empty AudioManager GameObject and attach the script to it.
   - Define sound clips in the `SoundClips` enum list.
   - Create an Audio Mixer according to your sounds and the way you like to setup your mix.
   - Populate the `audioClipArray` with `AudioClipToPlay` instances, associating each sound clip with its corresponding audio clip and audio mixer group.

2. **Play Sounds:**
   - Call `PlaySound3D` or `PlaySound2D` in a script attached to a GameObject to play 3D or 2D sounds, respectively.
   - Provide the appropriate parameters such as sound clip type, pitch, volume, spatial blend, spread, and loop flag.

3. **Stop Sounds:**
   - Call `StopSound` to stop a currently playing sound based on the specified sound clip.

4. **Fade In/Out (Future):**
   - Use the `FadeInSound` and `FadeOutSound` methods for implementing sound fading (currently placeholders).

## Example Usage

```csharp
// Play a 3D sound at the object's position with default settings
AudioManager.PlaySound3D(AudioManager.SoundClips.ButtonClick, playerTransform, 1f, 1f, 1f, 1f, false);

// Play a 2D looping sound with custom pitch and volume
AudioManager.PlaySound2D(AudioManager.SoundClips.RoomAmbience, 0.8f, 0.5f, true);

// Stop the RoomAmbience sound
AudioManager.StopSound(AudioManager.SoundClips.RoomAmbience);

```

