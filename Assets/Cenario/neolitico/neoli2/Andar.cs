using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour
{
    public GameObject pablo;
    public int direc;
    public int direcao;
    public float velMax;
    public static bool resolver = false;

    // Start is called before the first frame update
    void Start()
    {
        pablo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        direc = direcao;
        if (neoli2Manager.ocupado == false)
        {
            if (direcao == 1 && pablo.transform.position.x<= 8.88f)
            {

                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velMax, 0);

            }
            else if (direcao == -1 && pablo.transform.position.x >= -9.16f)
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
        if(pablo.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            pablo.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (pablo.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            pablo.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (pablo.GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            pablo.GetComponent<Animator>().SetBool("running", true);
        }
        else
        {
            pablo.GetComponent<Animator>().SetBool("running", false);
        }
    }
    public void IrDireita()
    {
        direcao = 1;
        if (resolver == true)
        {
            Neoli1Manager.falando = false;
            resolver = false;
        }
    }
    public void IrEsquerda()
    {
        direcao = -1;
        if (resolver == true)
        {
            Neoli1Manager.falando = false;
            resolver = false;
        }
    }
    public void parouAndar()
    {
        direcao = 0;
    }
}
