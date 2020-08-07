using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pabloBehavior : MonoBehaviour
{
    public GameObject pablo;
    public static int lado = 0;
    public Camera cam;
    public float velCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition();
        pabloPlace();
    }
    void cameraPosition()
    {
        if(lado == 1 && cam.transform.position.x <= 2.01f)
        {
            cam.transform.Translate(new Vector2(velCamera, 0) * Time.deltaTime);
        }
        if(lado == 0 && cam.transform.position.x >= 0f)
        {
            cam.transform.Translate(new Vector2(-velCamera, 0) * Time.deltaTime);
        }
    }
    void pabloPlace()
    {
        if(pablo.transform.position.x >= 6.9f)
        {
            lado = 1;
        }
        else
        {
            lado = 0;
        }
    }
}
