using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medBeahvior : MonoBehaviour
{
    public bool subir = true;
    public Transform med;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(subir == true)
        {
            this.transform.Translate(new Vector3(0, 4.6f / 1.5f, 0) * Time.deltaTime);
            if(this.transform.position.y >= 2.18f)
            {
                subir = false;
            }
        }
        if(subir == false)
        {
            this.transform.Translate(new Vector3(0, -4.6f / 1.5f, 0) * Time.deltaTime);
            if (this.transform.position.y <= -2.54f)
            {
                subir = true;
            }
        }
        if(this.transform.position.y >= -0.259f && this.transform.position.y <= 0.041f)
        {
            Paleo3Manager.intense = 11.71f;
        }
        if (this.transform.position.y > -0.917f && this.transform.position.y < -0.259f)
        {
            Paleo3Manager.intense = 9f;
        }
        if (this.transform.position.y < 0.685f && this.transform.position.y > 0.041f)
        {
            Paleo3Manager.intense = 9f;
        }
        if (this.transform.position.y >= 0.685f && this.transform.position.y <= 1.54f)
        {
            Paleo3Manager.intense = 7.5f;
        }
        if (this.transform.position.y >= -1.783f && this.transform.position.y <= -0.917f)
        {
            Paleo3Manager.intense = 7.5f;
        }
        if(this.transform.position.y > 1.54f || this.transform.position.y < -1.783f)
        {
            Paleo3Manager.intense = 4.5f;
        }
        



    }        
}
