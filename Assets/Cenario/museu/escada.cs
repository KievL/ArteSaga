using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escada : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pabloCheck;
    public Transform esSubir;
    public Transform esDescer;
    public static bool apertou = false;
    public bool testa = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pabloCheck.position.x >= -1 && pabloCheck.position.x <= -0.523f && apertou == false)
        {
            esSubir.position = new Vector2(-0.719f, -0.5f);
        }
        else
        {
            esSubir.position = new Vector2(-0.719f, 0.876f);
            
        }

        if (pabloCheck.position.x >= 0.035f && pabloCheck.position.x <= 0.277f && apertou == false)
        {
            esDescer.position = new Vector2(-0.138f, -0.17f);
        }
        else
        {
            esDescer.position = new Vector2(-0.138f, 0.934f);

        }

    }    
}
