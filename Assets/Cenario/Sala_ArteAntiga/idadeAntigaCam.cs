using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idadeAntigaCam : MonoBehaviour
{
    public GameObject pablo;
    public GameObject cam;
    public float offsetX;
    public float offsetY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pabloGeral.liberado == true && pablo.transform.position.x >= -0.099 && pablo.transform.position.x <= 2.947998f)
        {
            cam.transform.position = new Vector3(pablo.transform.position.x + offsetX, offsetY, cam.transform.position.z);
        }
    }
}
