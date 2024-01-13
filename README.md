# Unity AudioManager Singleton

## Overview

This Unity AudioManager Singleton provides a centralized system for managing audio in your Unity project. It includes features such as playing 2D and 3D sounds, stopping sounds, and handling various sound clips.

## Features

- **Singleton Design:** Ensures there is only one instance of the AudioManager in the scene.
- **SoundClips Enumeration:** Enumerates all sound clip types for easy reference.
- **AudioClipToPlay Class:** Holds the values of sound clips and their associated audio clips.
- **PlaySound3D Method:** Plays 3D sounds with spatial settings, allowing for positioning in 3D space.
- **PlaySound2D Method:** Plays 2D sounds without spatial settings.
- **StopSound Method:** Stops a currently playing sound based on the specified sound clip.
- **FadeInSound and FadeOutSound Methods:** Placeholder methods for future implementation of sound fading.

## How to Use

1. **Setup:**
   - Attach the AudioManager script to a GameObject in your scene.
   - Define sound clips in the `SoundClips` enumeration.
   - Populate the `audioClipArray` with `AudioClipToPlay` instances, associating each sound clip with its corresponding audio clip and mixer group.

2. **Play Sounds:**
   - Call `PlaySound3D` or `PlaySound2D` to play 3D or 2D sounds, respectively.
   - Provide the appropriate parameters such as sound clip type, pitch, volume, spatial blend, spread, and loop flag.

3. **Stop Sounds:**
   - Call `StopSound` to stop a currently playing sound based on the specified sound clip.

4. **Fade In/Out (Future):**
   - Use the `FadeInSound` and `FadeOutSound` methods for implementing sound fading (currently placeholders).

## Example Usage

```csharp
// Play a 3D sound at the player's position with default settings
AudioManager.PlaySound3D(AudioManager.SoundClips.ButtonClick, playerTransform, 1f, 1f, 1f, 1f, false);

// Play a 2D looping sound with custom pitch and volume
AudioManager.PlaySound2D(AudioManager.SoundClips.RoomAmbience, 0.8f, 0.5f, true);

// Stop the RoomAmbience sound
AudioManager.StopSound(AudioManager.SoundClips.RoomAmbience);
