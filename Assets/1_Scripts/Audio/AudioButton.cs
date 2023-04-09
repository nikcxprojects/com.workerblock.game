using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    private int volumeSounds;

    void Start()
    {
        volumeSounds = PlayerPrefs.GetInt("Volume", 1);
    }

    public void ChangeSoundsVolume()
    {
        volumeSounds = volumeSounds == 0 ? 1 : 0;
        PlayerPrefs.SetInt("Volume", volumeSounds);
    }
}
