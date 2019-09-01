using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used changes to the next song, when out of songs turns off, when used while off, plays first song.
/// 
/// TODO; It should auto play, randomise order potentially and go to next track when used.
///     In other words, act kind of like the radio in a GTA style game.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BoomBoxItem : InteractiveItem
{
    //TODO: you will need more data than this, like clips to play and a way to know which clip is playing
    protected AudioSource audioSource;
    public AudioClip[] songs;
    public bool isPlaying = true;
    public int NowPlaying = 0;

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        PlayClip();        
    }

    public void PlayClip()
    {
        audioSource.clip = songs[NowPlaying];
        audioSource.Play();
    }

    public override void OnUse()
    {
        base.OnUse();

        if (!isPlaying)
        {
            isPlaying = true;
            NowPlaying = 0;
            PlayClip();
            return;
        }

        NowPlaying++;

        if (NowPlaying >= songs.Length)
        {
            isPlaying = false;
            audioSource.Stop();
        }

        else
            PlayClip();
    }
}
