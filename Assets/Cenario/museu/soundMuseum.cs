using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundMuseum : MonoBehaviour
{
    public static AudioClip museumSound;
    static AudioSource audioSrc;
    public float crono = 0f;

    public static bool tocarLiberado = true;
    // Start is called before the first frame update
    void Start()
    {
        museumSound = Resources.Load<AudioClip>("museum");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.PlayOneShot(museumSound);
    }

    // Update is called once per frame
    void Update()
    {
        playSound();
        pararDeTocar();

    }
    void playSound()
    {
        crono += Time.deltaTime;
        if (crono >= 121f && tocarLiberado == true)
        {
            audioSrc.PlayOneShot(museumSound);
            crono = 0;
        }
    }

    void pararDeTocar()
    {
        if (tocarLiberado == false)
        {
            audioSrc.Stop();
        }
    }
}
