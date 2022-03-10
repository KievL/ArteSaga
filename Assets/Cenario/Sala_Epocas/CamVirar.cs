using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamVirar : MonoBehaviour
{
    public GameObject pablo;
    public GameObject cameraScene;
    public float smoothing;
    public float offsetX;
    public float offsetY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pabloGeral.liberado == true && pablo.transform.position.x >= -1.48f && pablo.transform.position.x <= 1.199602f)
        {
            cameraScene.transform.position = new Vector3(pablo.transform.position.x + offsetX, -0.466f + offsetY, this.transform.position.z);
        }
    }
}
