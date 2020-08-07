using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primitivoBehaviour : MonoBehaviour
{
    public GameObject pablo;
    public float forcaPulo;
    public bool noChao;
    public static bool pularLiberado = false;
    public static int vidas = 3;

    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;

    public GameObject normalUI;

    public static bool ganhou = false;

    public static bool afetado = false;
    public int afetadoContador = 0;
    public float afetCrono = 0;
    public GameObject textTut;

    // Start is called before the first frame update
    void Start()
    {
        vida1.SetActive(false);
        vida2.SetActive(false);
        vida3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PaleoManager.isCorrendo == true && vidas == 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);

        }
        else if(PaleoManager.isCorrendo == true && vidas == 2)
        {
            vida1.SetActive(false);
        }
        else if (PaleoManager.isCorrendo == true && vidas == 1)
        {
            vida2.SetActive(false);
        }
        else if (PaleoManager.isCorrendo == true && vidas == 0)
        {
            vida3.SetActive(false);
        }
        else if (PaleoManager.isCorrendo == true && vidas == -1)
        {
            normalUI.SetActive(false);
            Time.timeScale = 0f;
            deathCanvas.isDead = true;
            PaleoManager.isCorrendo = false;
        }
        if (ganhou == true)
        {
            pablo.transform.Translate(new Vector3(0.8f, 0, 0) * Time.deltaTime);
        }
        Afetado();
    }
    public void Pular()
    {
        if(noChao == true && pularLiberado == true)
        {
            pablo.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forcaPulo));
        }
        textTut.SetActive(false);
    }    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chaoSelva"))
        {
            pablo.GetComponent<Animator>().SetBool("pulando", false);
            noChao = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chaoSelva"))
        {
            pablo.GetComponent<Animator>().SetBool("pulando", true);
            noChao = false;
        }    

    }

    void Afetado()
    {
        Color full = pablo.GetComponent<SpriteRenderer>().color;
        if (afetado == true)
        {
            afetCrono += Time.deltaTime;                                    
            if (afetCrono >= 0.2f)
            {
                afetadoContador++;
                afetCrono = 0;                
            }
            if (afetadoContador % 2 == 0)
            {
                pablo.GetComponent<SpriteRenderer>().color = new Color(full.r, full.g, full.b, 0);
            }
            else
            {
                pablo.GetComponent<SpriteRenderer>().color = new Color(full.r, full.g, full.b, 255);
            }
            if (afetadoContador == 7)
            {
                afetado = false;
                afetadoContador = 0;
            }
        }
    }
}
