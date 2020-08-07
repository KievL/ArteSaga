using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadrosBeh : MonoBehaviour
{
    public GameObject pablo1;
    public GameObject a1, a2, a3, a4, a5, a6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pablo.places == 1 && pablo1.transform.position.x >= -2.923f && pablo1.transform.position.x <= -2.618f)
        {
            a1.SetActive(true);
        }
        else
        {
            a1.SetActive(false);
        }
        if (pablo.places == 1 && pablo1.transform.position.x >= -2.448f && pablo1.transform.position.x <= -2.333f)
        {
            a2.SetActive(true);
        }
        else
        {
            a2.SetActive(false);
        }
        if (pablo.places == 1 && pablo1.transform.position.x >= -2.147f && pablo1.transform.position.x <= -1.837f)
        {
            a3.SetActive(true);
        }
        else
        {
            a3.SetActive(false);
        }
        if (pablo.places == 1 && pablo1.transform.position.x >= -1.587f && pablo1.transform.position.x <= -1.039f)
        {
            a4.SetActive(true);
        }
        else
        {
            a4.SetActive(false);
        }
        if (pablo.places == 1 && pablo1.transform.position.x >= -0.825f && pablo1.transform.position.x <= -0.553f)
        {
            a5.SetActive(true);
        }
        else
        {
            a5.SetActive(false);
        }
        if (pablo.places == 1 && pablo1.transform.position.x >= -0.254f && pablo1.transform.position.x <= 0.005f)
        {
            a6.SetActive(true);
        }
        else
        {
            a6.SetActive(false);
        }
    }
}
