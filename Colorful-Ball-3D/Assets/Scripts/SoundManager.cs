using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonSource;
    public AudioSource blowUpSource;
    public AudioSource cashSource;
    public AudioSource completedSource;
    public AudioSource hitSource;
    public AudioSource cancelSource;

    public AudioClip buttonClip;
    public AudioClip blowUpClip;
    public AudioClip cashClip;
    public AudioClip completedClip;
    public AudioClip hitClip;
    public AudioClip cancelClip;

    public void ButtonSound()
    {
        buttonSource.PlayOneShot(buttonClip);
    }

    public void BlowUpSound()
    {
        blowUpSource.PlayOneShot(blowUpClip,0.3f);
    }

    public void CashSound()
    {
        cashSource.PlayOneShot(cashClip);
    }
    public void CompletedSound()
    {
        completedSource.PlayOneShot(completedClip);
    }
    public void HitSound()
    {
        hitSource.PlayOneShot(hitClip,0.4f);
    }
    public void CancelSound()
    {
        cancelSource.PlayOneShot(cancelClip);
    }
}
