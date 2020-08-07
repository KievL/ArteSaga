using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreCamBehavior : MonoBehaviour
{
    public GameObject pablo;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PrePabloBehavior.liberado == true && pablo.transform.position.x >= -0.297 && pablo.transform.position.x <= 1.636f)
        {
            camera.transform.position = new Vector3(pablo.transform.position.x, 0.033f, this.transform.position.z);
        }
    }
}
