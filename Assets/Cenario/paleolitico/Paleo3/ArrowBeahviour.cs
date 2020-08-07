using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBeahviour : MonoBehaviour
{
    public bool subit = true;
    public Transform seta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Paleo3Manager.calcSteps == 0)
        {
            if (subit == true)
            {
                this.transform.Rotate(new Vector3(0, 0, 60 / 0.6f) * Time.deltaTime);
                if (seta.rotation.eulerAngles.z >= 75)
                {
                    subit = false;
                }

            }
            if (subit == false)
            {
                this.transform.Rotate(new Vector3(0, 0, -60 / 0.6f) * Time.deltaTime);
                if (this.transform.rotation.eulerAngles.z <= 15)
                {
                    subit = true;
                }
            }
        }
        
    }
    
}
