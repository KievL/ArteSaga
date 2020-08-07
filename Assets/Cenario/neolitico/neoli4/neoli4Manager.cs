using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class neoli4Manager : MonoBehaviour
{
    public GameObject btnTutorial;
    public GameObject panelInicial;
    public GameObject btnCanvas;

    public bool ativo = false;
    public float crono = 0;
    public static int direcao = 0;
    public int sceneStep = 0;
    public float tempoCair;
    public int TipoPedra;
    public bool temEstoque = false;

    public int esEstoque = 30;
    public int diEstoque = 30;

    public GameObject peEsq;
    public GameObject peDi;
    public GameObject peCima;

    public static int sup1 = 2;
    public static int cima1 = 1;
    public static int sup2 = 2;
    public static int cima2 = 1;
    public static int sup3 = 2;
    public static int cima3 = 1;
    public static int sup4 = 2;
    public static int cima4 = 1;
    public static int sup5 = 2;
    public static int cima5 = 1;
    public static int sup6 = 2;
    public static int cima6 = 1;

    public static float lixoPlace = -3.308f;
    public static int orderLayer = 21;

    public static int vidas = 3;
    public GameObject canvasLose;
    public bool direesq = false;

    public bool won = false;

    public GameObject pontos;
    public float cronoFim = 0;
    public bool cronAtv = true;
    public bool sorteando = false;
    public float cronoFala = 0;
    public bool falaAnim = false;

    // Start is called before the first frame update
    void Start()
    {        
        btnCanvas.SetActive(false);
        panelInicial.SetActive(true);
        btnTutorial.SetActive(false);
        Random random = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        Inicio();
        JogoOn();
        CairPedra();
        Perdeu();
        Ganhar();
    }
    void Inicio()
    {
        if (sceneStep == 0)
        {
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                panelInicial.SetActive(false);
                btnTutorial.SetActive(true);
                sceneStep = 1;
                crono = 0;

            }
        }
        
    }
    void JogoOn()
    {
        if(sceneStep == 9)
        {
            ativo = true;
            btnCanvas.SetActive(true);
        }
    }
    void CairPedra()
    {
        if(ativo == true)
        {
            if(cronAtv == true)
            {
                crono += Time.deltaTime;
            }            
            if(crono >= 2.5f)
            {
                cronAtv = false;
                crono = 0;
                sortear();

            }
        }
    }
    void Instanciar()
    {
        if (TipoPedra == 3)
        {
            cronAtv = true;
            GameObject pedraEs = Instantiate(peCima) as GameObject;

        }
        if (TipoPedra == 1)
        {
            if (esEstoque == 0 || (sup1==0 && sup2 == 0 && sup3 == 0 && sup4 == 0 && sup5 == 0))
            {
                if(sorteando == false)
                {
                    sortear();
                    sorteando = true;
                }                
            }
            else
            {
                cronAtv = true;
                GameObject pedraEs = Instantiate(peEsq) as GameObject;
                esEstoque--;
            }
        }        
        if (TipoPedra == 2)
        {
            if (diEstoque == 0 || (sup1 == 0 && sup2 == 0 && sup3 == 0 && sup4 == 0 && sup5 == 0))
            {
                if (sorteando == false)
                {
                    sortear();
                    sorteando = true;
                }
            }
            else
            {
                cronAtv = true;
                GameObject pedraEs = Instantiate(peDi) as GameObject;
                diEstoque--;
            }
        }
        
        
    }
    void sortear()
    {
        if((sup1 == 0 && sup2 == 0 && sup3 == 0 && sup4 == 0 && sup5 == 0))
        {
            TipoPedra = 3;
        }
        else
        {
            
            TipoPedra = Random.Range(1, 4);
            if (direesq == false && TipoPedra == 2)
            {
                TipoPedra = 1;
            }
            if (direesq == true && TipoPedra == 1)
            {
                TipoPedra = 2;
            }
            if(TipoPedra == 1 && direesq == false)
            {
                direesq = !direesq;

            }
            if (TipoPedra == 2 && direesq == true)
            {
                direesq = !direesq;

            }
        }        
        Instanciar();
        sorteando = false;
    }


    public void mudarFala()
    {
        sceneStep++;
        btnTutorial.GetComponent<Animator>().SetInteger("falaStep", sceneStep);
        if(sceneStep == 8)
        {
            sceneStep++;
            btnTutorial.SetActive(false);
        }
        cronoFala += Time.deltaTime;
        if (cronoFala >= 1f)
        {
            falaAnim = !falaAnim;
            if(falaAnim == true)
            {
                btnTutorial.GetComponent<Animator>().SetBool("EsqDi", true);
            }
            else
            {
                btnTutorial.GetComponent<Animator>().SetBool("EsqDi", false);
            }
            cronoFala = 0;
        }
    }

    public void esquerda()
    {
        direcao = -1;
    }
    public void direita()
    {
        direcao = 1;
    }
    public void parouApertar()
    {
        direcao = 0;
    }
    void Perdeu()
    {
        if(vidas == 0)
        {
            btnCanvas.SetActive(false);
            canvasLose.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void tryAgain()
    {
        sup1 = 2;
        cima1 = 1;
        sup2 = 2;
        cima2 = 1;
        sup3 = 2;
        cima3 = 1;
        sup4 = 2;
        cima4 = 1;
        sup5 = 2;
        cima5 = 1;
        sup6 = 2;
        cima6 = 1;

        lixoPlace = -3.308f;
        orderLayer = 21;
        direcao = 0;
        vidas = 3;
        Time.timeScale = 1;
        SceneManager.LoadScene("neoli4");
    }
    void Ganhar()
    {
        if(sup1 == 0 && sup2 == 0 && sup3 == 0 && sup4 == 0 && sup5 == 0 && 
           cima1 == 0 && cima2 == 0 && cima3 == 0 && cima4 == 0 && cima5 == 0)
        {
            won = true;
        }
        if(won == true)
        {
            pontos.SetActive(false);
            sceneStep = 7;
            ativo = false;
            cronoFim += Time.deltaTime;
            if(cronoFim >= 2f)
            {
                PlayerPrefs.SetInt("NeoliStep", 4);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Neoli5");

            }
        }
    }


}
