using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pabloMetal2 : MonoBehaviour
{
    public GameObject pablo;
    public float velocidade;
    public int estado = 0;
    public bool limiteEsq = false;
    public bool limiteDi = false;
    public bool limitou = false;

    // Start is called before the first frame update
    void Start()
    {
        pablo = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        checarEstado();
        checarLimites();
    }

    public void AndarDireita()
    {
        estado = 1;
        
    }
    public void AndarEsquerda()
    {
        estado = -1;
    }

    public void ParouAndar()
    {
        estado = 0;
    }
    void checarEstado()
    {
        if(estado == 1 && limiteDi == false)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidade, 0);
            pablo.GetComponent<SpriteRenderer>().flipX = false;
            pablo.GetComponent<Animator>().SetBool("isAndando", true);
        }
        if (estado == -1 && limiteEsq == false)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidade, 0);
            pablo.GetComponent<SpriteRenderer>().flipX = true;
            pablo.GetComponent<Animator>().SetBool("isAndando", true);
        }
        if(estado == 0)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pablo.GetComponent<Animator>().SetBool("isAndando", false);
        }

       
    }
    void checarLimites()
    {
        if (pablo.transform.position.x <= -7.99f && pablo.transform.position.x < 0)
        {
            if(limitou == false)
            {
                estado = 0;
                limitou = true;
            }            
            limiteEsq = true;
        }
        if(pablo.transform.position.x >= -7.80f && pablo.transform.position.x < 0)
        {
            limiteEsq = false;
            limitou = false;
        }

        if (pablo.transform.position.x >= 7.91f && pablo.transform.position.x > 0)
        {
            if (limitou == false)
            {
                estado = 0;
                limitou = true;
            }
            limiteDi = true;
        }
        if (pablo.transform.position.x <= 7.77f && pablo.transform.position.x > 0)
        {
            limiteDi = false;
            limitou = false;
        }

    }
}
