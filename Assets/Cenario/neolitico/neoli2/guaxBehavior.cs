using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guaxBehavior : MonoBehaviour
{
    public Vector2 posOut;
    public Vector2 posIn;

    public bool pronto = false;
    public static bool roubando = false;
    public bool primeiro = true;
    public float crono = 0;
    public float tempoDepois;
    public float crono2 = 0;

    public GameObject guax;

    public int vidaGuax = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        prepararRoubo();
        roubandoTrigo();
        guaxVida();
    }
    void prepararRoubo()
    {
        if(neoli2Manager.ativo == true)
        {
            crono += Time.deltaTime;
            if(crono >= tempoDepois)
            {
                roubando = true;
            }           
                           
        }
    }
    void roubandoTrigo()
    {
        if(roubando == true)
        {
            guax.SetActive(true);
            crono2 += Time.deltaTime;
            if(crono2 >= 1.5f)
            {
                neoli2Manager.trigos--;
                crono2 = 0;
            }
            if(neoli2Manager.trigos == 0)
            {
                if(primeiro == true)
                {
                    primeiro = false;
                    tempoDepois = 15;
                }
                roubando = false;
                crono = 0;
            }

        }
        if(roubando == false)
        {
            guax.SetActive(false); ;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "primitivo")
        {
            roubando = false;
            crono = 0;
            allowed = false;
            if (primeiro == true)
            {
                primeiro = false;
                tempoDepois = 15;
            }
        }
    }*/
    public void baterGuax()
    {
        vidaGuax--;
    }
    void guaxVida()
    {
        if (vidaGuax <= 0)
        {
            roubando = false;
            crono = 0;
            if (primeiro == true)
            {
                primeiro = false;
                tempoDepois = 15;
            }
            vidaGuax = 4;
            guax.SetActive(false);
        }
    }
}
