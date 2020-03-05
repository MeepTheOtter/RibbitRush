using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingSFX : MonoBehaviour
{
    public AudioSource SelectColor;
    public AudioSource PlayButton;
    public AudioSource GeneralClick;
    public AudioSource ColorClick;
    public AudioSource BackButton;
    public AudioSource MainMusic;
    public AudioSource Lick;
    public AudioSource SecretMusic;

    public void PlayMusic()
    {
        MainMusic.Play();
    }
    public void PlaySplash()
    {
        ColorClick.Play();
    }
    public void PlayButtonPressed()
    {
        PlayButton.Play();
    }
    public void PlayBack()
    {
        BackButton.Play();
    }
    public void PlayGeneralClick()
    {
        GeneralClick.Play();
    }
    public void PlayLick()
    {
        Lick.Play();
    }
    public void PlaySecretMusic()
    {
        SecretMusic.Play();
    }
    public void StopMusic()
    {
        MainMusic.Stop();
        SecretMusic.Stop();
    }
}
