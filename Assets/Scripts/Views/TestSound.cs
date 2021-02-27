using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    public static TestSound I;
    public AudioSource SoundSource;
    public List<AudioClip> Clips;

    private void Awake()
    {
        I = this;
    }

    public void PlayRandomCardSound()
    {
        int randomIndex = Random.Range(0, Clips.Count);
        var clip = Clips[randomIndex];

        SoundSource.PlayOneShot(clip);
    }
}
