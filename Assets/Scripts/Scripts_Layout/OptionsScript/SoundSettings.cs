using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

  public void SetVolumeMusic(float music)
  {
        audioMixer.SetFloat("music", music);
  }
}
