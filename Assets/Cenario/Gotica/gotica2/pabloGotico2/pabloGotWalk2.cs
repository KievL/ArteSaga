using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pabloGotWalk2 : MonoBehaviour
{
    public GameObject pablo;
    public int direc = 0;
    public float velPablo;
    public static bool gotic2Liberado = true;
    public static int direcParallax;

    public bool bateuEsquerda = false;
    public bool bateuDireita = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pabloCorrendo();
    }
    void pabloCorrendo()
    {
        if (direc == 0)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pablo.GetComponent<Animator>().SetBool("correndo", false);
        }
        if(pablo.transform.position.x>= -10.51002f && pablo.transform.position.x <= 23.08998f && gotic2Liberado == true)
        {
            bateuEsquerda = false;
            bateuDireita = false;
            if (direc == 1)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                pablo.GetComponent<Animator>().SetBool("correndo", true);
            }
            if (direc == -1)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(-velPablo, 0);
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                pablo.GetComponent<Animator>().SetBool("correndo", true);
            }
        }
        else if(pablo.transform.position.x < -10.51002f)
        {
            bateuEsquerda = true;
        }else if(pablo.transform.position.x > 23.08998f)
        {
            bateuDireita = true;
        }

        if(bateuEsquerda==true && pablo.GetComponent<Rigidbody2D>().velocity.x < 0 && gotic2Liberado == true)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pablo.GetComponent<Animator>().SetBool("correndo", false);
        }
        if(bateuEsquerda == true && pablo.transform.position.x < -10.51002f && gotic2Liberado == true)
        {
            if (direc == 1)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                pablo.GetComponent<Animator>().SetBool("correndo", true);
            }
        }

        if (bateuDireita == true && pablo.GetComponent<Rigidbody2D>().velocity.x > 0 && gotic2Liberado == true)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pablo.GetComponent<Animator>().SetBool("correndo", false);
        }
        if (bateuDireita == true && pablo.transform.position.x > 23.08998f && gotic2Liberado == true)
        {
            if (direc == -1)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(-velPablo, 0);
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                pablo.GetComponent<Animator>().SetBool("correndo", true);
            }
        }

    }
    public void AndarEsquerda()
    {
        if (gotic2Liberado == true)
        {
            direc = -1;
            direcParallax = -1;

        }
    }
    public void AndarDireita()
    {
        if (gotic2Liberado == true)
        {
            direc = 1;
            direcParallax = 1;
        }
    }
    public void paraAndar()
    {
        if (gotic2Liberado == true)
        {
            direc = 0;
            direcParallax = 0;

        }
    }
}