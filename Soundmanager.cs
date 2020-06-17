using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public static AudioClip Attack, Death, Jump;
    static AudioSource AudioSrc;

    void Start()
    {
        Attack = Resources.Load<AudioClip>("Attack");
        Death = Resources.Load<AudioClip>("Death");
        Jump = Resources.Load<AudioClip>("Jump");

        AudioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip) {
            case "Attack":
                AudioSrc.PlayOneShot(Attack);
                break;
            case "Death":
                AudioSrc.PlayOneShot(Death);
                break;
            case "Jump":
                AudioSrc.PlayOneShot(Jump);
                break;
        }
    }
}
