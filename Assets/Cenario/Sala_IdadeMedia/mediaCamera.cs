using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mediaCamera : MonoBehaviour
{
    public GameObject sceneCamera, pablo;

    public float limEsq, limDir, cameraY;

    // Update is called once per frame
    void Update()
    {
        if(pabloGeral.liberado == true && pablo.transform.position.x >= limEsq && pablo.transform.position.x <= limDir)
        {
            sceneCamera.transform.position = new Vector3(pablo.transform.position.x, cameraY, this.transform.position.z);
        }
    }
}
