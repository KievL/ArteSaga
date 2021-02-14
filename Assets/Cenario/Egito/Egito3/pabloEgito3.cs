using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pabloEgito3 : MonoBehaviour
{
    public int direcao = 0;
    public float limLeft, limRight;
    public GameObject pablo;
    public GameObject cam;
    public float pabloVel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        andar();
    }
    void andar()
    {
        if (Egito3Manager.podeAndar == true)
        {
            if(direcao==1 && pablo.transform.position.x <= limRight)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(pabloVel, 0);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if(direcao == -1 && pablo.transform.position.x >= limLeft)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(-pabloVel, 0);
                pablo.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            if(pablo.transform.position.x>= -1.53f && pablo.transform.position.x<= 7.46f)
            {
                cam.transform.position = new Vector3(pablo.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            }

            if (direcao != 0)
            {
                pablo.GetComponent<Animator>().SetBool("correndo", true);
            }
            else
            {
                pablo.GetComponent<Animator>().SetBool("correndo", false);
            }
        }        
    }

    public void AndarDireita()
    {
        direcao = 1;
    }
    public void AndarEsquerda()
    {
        direcao = -1;
    }
    public void parouAndar()
    {
        direcao = 0;
    }
    
}
