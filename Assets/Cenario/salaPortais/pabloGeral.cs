using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class pabloGeral : MonoBehaviour
{
    public GameObject elPablo;
    public float velx;
    public static bool liberado = false;
    public int position = 0;
    public float limiteDireita;
    public float limiteEsquerda;
    public bool passouLimiteEs = false;
    public bool passouLimiteDi = false;
    // Start is called before the first frame update
    void Start()
    {
        elPablo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {

        Andar();
        PassarLimite();
    }
    void Andar()
    {
        if(position == 1)
        {
            elPablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velx, 0);
            elPablo.GetComponent<SpriteRenderer>().flipX = false;
            elPablo.GetComponent<Animator>().SetBool("correndo", true);
        }
        if(position == -1)
        {
            elPablo.GetComponent<Rigidbody2D>().velocity = new Vector2(-velx, 0);
            elPablo.GetComponent<SpriteRenderer>().flipX = true;
            elPablo.GetComponent<Animator>().SetBool("correndo", true);
        }
        if(position == 0 && liberado==true)
        {
            elPablo.GetComponent<Animator>().SetBool("correndo", false);
            elPablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    public void IrDireita()
    {
        if (liberado == true && passouLimiteDi == false) 
        {
            position = 1;
        }
    }
    public void IrEsquerda()
    {
        if(liberado == true && passouLimiteEs == false)
        {
            position = -1;
        }
    }
    public void PararAndar()
    {
        position = 0;
    }
    void PassarLimite()
    {
        if(passouLimiteEs == false && elPablo.transform.position.x <= limiteEsquerda)
        {
            position = 0;
            passouLimiteEs = true;
        }
        if (passouLimiteDi == false && elPablo.transform.position.x >= limiteDireita)
        {
            position = 0;
            passouLimiteDi = true;
        }
        if(passouLimiteEs == true && elPablo.transform.position.x >= limiteEsquerda + 0.09f)
        {
            passouLimiteEs = false;
        }
        if (passouLimiteDi == true && elPablo.transform.position.x <= limiteDireita - 0.09f)
        {
            passouLimiteDi = false;
        }
    }
}
