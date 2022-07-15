using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    private static MuteMusic mm;

    public Button muteButton;
    public GameObject GameSound;
    
    public void Mute()
    {
        GameSound.SetActive(!GameSound.activeSelf);
    }

    void Awake()
    {
        if (mm == null)
        {
            mm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
