using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PabWalkGot1 : MonoBehaviour
{
    public GameObject pablo;
    public int direc = 0;
    public float velPablo;
    public static bool gotic1Liberado = true;

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
    public void AndarEsquerda()
    {
        if (gotic1Liberado == true)
        {
            direc = -1;
            
        }
    }
    public void AndarDireita()
    {
        if (gotic1Liberado == true)
        {
            direc = 1;

        }
    }
    public void paraAndar()
    {
        if (gotic1Liberado == true)
        {
            direc = 0;

        }
    }
}
