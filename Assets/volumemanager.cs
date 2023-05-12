using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumemanager : MonoBehaviour
{
   public AudioMixer _audio;

   public void SetVolume(float vol){
    _audio.SetFloat("vol", vol);
   }
}
