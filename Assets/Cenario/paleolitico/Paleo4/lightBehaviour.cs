using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBehaviour : MonoBehaviour
{
    public float crono = 0;
    public float lightSteps = 0;
    public float lMax = 1.2f;
    public float lMin = 0.8f;
    public float lNormal = 1f;
    public Light luz;
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LightChaos();

    }
    void LightChaos()
    {
        if(lightSteps == 0)
        {
            luz.intensity += Time.deltaTime*vel;
            if(luz.intensity >= 1.08)
            {
                lightSteps = 1;
            }
        }if(lightSteps ==1)
        {
            luz.intensity -= Time.deltaTime*vel;
            if(luz.intensity <= 1.02f)
            {
                lightSteps = 2;
            }
        }
        if (lightSteps == 2)
        {
            luz.intensity += Time.deltaTime*vel;
            if (luz.intensity <= 1.07f)
            {
                lightSteps = 3;
            }
        }
        if (lightSteps == 3)
        {
            luz.intensity -= Time.deltaTime*vel;
            if (luz.intensity <= 1f)
            {
                lightSteps = 4;
            }
        }
        if (lightSteps == 4)
        {
            luz.intensity += Time.deltaTime*vel;
            if (luz.intensity <= 1.08f)
            {
                lightSteps = 5;
            }
        }
        if (lightSteps == 5)
        {
            luz.intensity -= Time.deltaTime*vel;
            if (luz.intensity <= 1f)
            {
                lightSteps = 0;
            }
        }

    }
}
