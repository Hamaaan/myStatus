using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{

    public float defaultVolume = 1;
    bool isMute = false;

    public void AudioMute()
    {
        if (isMute)
        {
            isMute = false;
            AudioListener.volume = defaultVolume;
        }
        else
        {
            isMute = true;
            AudioListener.volume = 0;
        }
    }
}
