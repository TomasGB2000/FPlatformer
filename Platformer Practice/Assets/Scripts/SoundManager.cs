using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{  //Assigning Audio to Events
    private AudioSource _soundSource;
    private AudioClip _coinSound;
    private AudioClip _jumpSound;
    private AudioClip _loseSound;
    private AudioClip _winSound;
    private AudioClip _backgroundSound;
    private AudioClip _gruntSound;

    void Start()
    {   //Assigning Sound Clips to assigned events
        _soundSource = GetComponent<AudioSource>();
        _coinSound = Resources.Load("CoinCollect") as AudioClip;
        _jumpSound = Resources.Load("Jump") as AudioClip;
        _loseSound = Resources.Load("Lose") as AudioClip;
        _winSound = Resources.Load("Win") as AudioClip;
        _backgroundSound = Resources.Load("Background") as AudioClip;
        _gruntSound = Resources.Load("Grunt") as AudioClip;
    }

    void Update()
    {

    }
    //Assigning Clips to be used in other scripts
    public void playCoinSound()
    {
        _soundSource.PlayOneShot(_coinSound);
    }

    public void playJumpSound()
    {
        _soundSource.PlayOneShot(_jumpSound);
    }

    public void playLoseSound()
    {
        _soundSource.PlayOneShot(_loseSound);
    }

    public void playWinSound()
    {
        _soundSource.PlayOneShot(_winSound);
    }

    public void playBackgroundSound()
    {
        _soundSource.PlayOneShot(_backgroundSound);
    }

    public void playGruntSound()
    {
        _soundSource.PlayOneShot(_gruntSound);
    }

}
