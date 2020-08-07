using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class pabloAndar : MonoBehaviour
{
    public Transform elPablo;
    public float velx = 0;
    public GameObject pablo;
    public float velMax;
    public int direcao;
    public int direc;
    public static bool resolver = false;
    public bool naoPodeEsquerda = false;
    public bool naoPodeDireita = false;

    // Start is called before the first frame update
    void Start()
    {
        pablo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        direc = direcao;
        if(Neoli1Manager.falando == false)
        {
            if (direcao == 1)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velMax, 0);
            }
            else if (direcao == -1)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(-velMax, 0);
            }
            else
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        else
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if(pablo.transform.position.x <= -14.3f && direcao == -1)
        {
            parouAndar();
            naoPodeEsquerda = true;
        }
        if(pablo.transform.position.x >= -14f)
        {
            naoPodeEsquerda = false;
        }
        
        if (pablo.transform.position.x >= 21.57f && direcao == 1)
        {
            parouAndar();
            naoPodeDireita = true;
        }
        if (pablo.transform.position.x <= 21.2f)
        {
            naoPodeDireita = false;
        }



    }
    public void IrDireita()
    {
        if(naoPodeDireita == false)
        {
            direcao = 1;
            if (resolver == true)
            {
                Neoli1Manager.falando = false;
                resolver = false;
            }
        }
        
    }
    public void IrEsquerda()
    {
        if(naoPodeEsquerda == false)
        {
            direcao = -1;
            if (resolver == true)
            {
                Neoli1Manager.falando = false;
                resolver = false;
            }
        }        
    }
    public void parouAndar()
    {
        direcao = 0;
    }
   
}
