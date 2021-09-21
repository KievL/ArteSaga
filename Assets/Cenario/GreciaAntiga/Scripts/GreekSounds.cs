using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreekSounds : MonoBehaviour
{

    public static bool soundSlash = false;
    public bool sounded = false;

    public static AudioClip slash;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        slash = Resources.Load<AudioClip>("slash");        
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (soundSlash)
        {
            if (sounded == false)
            {
                audioSrc.PlayOneShot(slash);
                sounded = true;
            }
        }
    }
}
