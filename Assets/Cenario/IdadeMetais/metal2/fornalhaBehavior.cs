using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fornalhaBehavior : MonoBehaviour
{
    public GameObject andarBtn;
    public GameObject canvasFornalha;
    public GameObject btnFornalha;
    public GameObject moldeCanvas;

    public GameObject painelFinal;

    public bool derramou1 = false;
    public bool derramou2 = false;

    //MOLDE GAMEOBJECTS
    public GameObject baldeBronze;
    public GameObject bronze;
    public GameObject botarBronzeAnimacao;
    public GameObject moldeBronzeFinal;
    public float cronoBronze = 0;
    public bool derramando1 = false;

    public GameObject baldeOuro;
    public GameObject ouro;
    public GameObject botarOuroAnimacao;
    public GameObject moldeOuroFinal;
    public float cronoOuro = 0;
    public bool derramando2 = false;

    public GameObject liquido;
    public Color liqCor;
    public Color liqMudar;
    public float colorG = 1f;
    public float colorB = 1f;

    public static int liquidoTipo = -1;
    public static bool esquentando = false;
    public static bool minerioPronto = false;
    public bool mudardeCor = true;
    public float crono = 0;
    public static bool misturaPronta = false;

    public GameObject liq1;
    public GameObject liq2;
    public GameObject liqPronto;

    public static int tipoMistura1 = -1;
    public static int tipoMistura2 = -1;

    public GameObject mistOuro;
    public GameObject mistBronze;

    public float CronoFinal = 0;
    public static bool acabou = false;

    public GameObject fornalha;

    // Start is called before the first frame update
    void Start()
    {
        liqCor = liquido.GetComponent<SpriteRenderer>().color;
        liquido.SetActive(false);

        liqMudar.a = 1;
        liqMudar.r = 1;
        liqMudar.g = 1;
        liqMudar.b = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Esquentar();
        Derramando1();
        Acabar();
        mudarSprite();
    }

    public void esquentarFerro()
    {

        esquentando = true;
        liquidoTipo = 1;
        SairCanvasFornalha();
        checkarTipos();
    }
    public void esquentarCobre()
    {
        esquentando = true;
        liquidoTipo = 2;
        SairCanvasFornalha();
        checkarTipos();
    }
    public void esquentarOuro()
    {
        esquentando = true;
        liquidoTipo = 3;
        SairCanvasFornalha();
        checkarTipos();
    }

    public void esquentarEstanho()
    {
        esquentando = true;
        liquidoTipo = 4;
        SairCanvasFornalha();
        checkarTipos();
    }
    void checkarTipos()
    {
        if(tipoMistura1 == -1)
        {
           if(liquidoTipo == 1 || liquidoTipo == 3)
            {
                tipoMistura1 = 0;
            }
            else
            {
                tipoMistura1 = 1;
            }
        }
        if(metal2Manager.mistura1Ready == true && tipoMistura2 == -1)
        {
            if(tipoMistura1 == 0)
            {
                tipoMistura2 = 1;
            }
            else
            {
                tipoMistura2 = 0;
            }
        }
    }

    void SairCanvasFornalha()
    {
        metal2Manager.esquentando = true;
        andarBtn.SetActive(true);
        canvasFornalha.SetActive(false);        
    }

    void Esquentar()
    {

        if(esquentando == true)
        {
            liquido.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 4 && mudardeCor == true)
            {
                minerioPronto = true;
                liquido.GetComponent<SpriteRenderer>().color = Color.red;
            }        
                        
        }
    }

    public void tirarMineral()
    {
        if(metal2Manager.qntsLiqs == 0)
        {            
            liq1.SetActive(true);
            metal2Manager.qntsLiqs++;
        }else if(metal2Manager.qntsLiqs == 1)
        {
            liq2.SetActive(true);
            metal2Manager.qntsLiqs++;
        }
        crono = 0;
        metal2Manager.esquentando = false;
        esquentando = false;
        liquido.GetComponent<SpriteRenderer>().color = Color.white;
        liquido.SetActive(false);
        minerioPronto = false;
    }

    public void misturar()
    {
        if(metal2Manager.qntsLiqs == 2)
        {
            metal2Manager.qntsLiqs++;
            liq1.SetActive(false);
            liq2.SetActive(false);
            liqPronto.SetActive(true);
            misturaPronta = true;

        }
    }
    public void tirarMistura()
    {
        liqPronto.SetActive(false);
        metal2Manager.qntsLiqs = 0;
        if(tipoMistura1 == 0)
        {
            mistOuro.SetActive(true);

        }
        else
        {
            mistBronze.SetActive(true);
        }
        metal2Manager.mistura1Ready = true;
        if(tipoMistura2 != -1)
        {
            if(tipoMistura2 == 0)
            {
                mistOuro.SetActive(true);
            }
            else
            {
                mistBronze.SetActive(true);
            }
            metal2Manager.mistura2Ready = true;
        }
        minerioPronto = false;
        misturaPronta = false;
    }
    public void abrirCanvasMolde()
    {
        andarBtn.SetActive(false);
        moldeCanvas.SetActive(true);
    }
    public void derramar1()
    {
        if(derramou1 == false)
        {
            baldeBronze.SetActive(false);
            bronze.SetActive(false);
            botarBronzeAnimacao.SetActive(true);
            derramando1 = true;
            derramou1 = true;
        }
    }
    public void derramar2()
    {
        if (derramou2 == false)
        {
            baldeOuro.SetActive(false);
            ouro.SetActive(false);
            botarOuroAnimacao.SetActive(true);
            derramando2 = true;
            derramou2 = true;
        }
    }
    void Derramando1()
    {
        if(derramando1 == true)
        {
            cronoBronze += Time.deltaTime;
            if(cronoBronze >= 0.7f)
            {
                botarBronzeAnimacao.SetActive(false);
                moldeBronzeFinal.SetActive(true);
                baldeBronze.SetActive(true);
                derramando1 = false;
            }
        }
        if (derramando2 == true)
        {
            cronoOuro += Time.deltaTime;
            if (cronoOuro >= 0.7f)
            {
                botarOuroAnimacao.SetActive(false);
                moldeOuroFinal.SetActive(true);
                baldeOuro.SetActive(true);
                derramando2 = false;
            }
        }


    }
    void Acabar()
    {
        if(derramou1 == true && derramou2 == true)
        {
            CronoFinal += Time.deltaTime;
            if(CronoFinal>= 2f)
            {
                mistOuro.SetActive(false);                
                mistBronze.SetActive(false);
                moldeCanvas.SetActive(false);
                if(CronoFinal>= 3.5f)
                {
                    painelFinal.SetActive(true);
                    if(CronoFinal>= 4f)
                    {
                        PlayerPrefs.SetInt("MetalStep", 3);
                        PlayerPrefs.Save();
                        SceneManager.LoadScene("metal3");
                    }
                }
            }
        }
    }
    void mudarSprite()
    {
        if (esquentando == true)
        {
            fornalha.GetComponent<Animator>().SetBool("esquentando", true);

        }
        else
        {
            fornalha.GetComponent<Animator>().SetBool("esquentando", false);
        }
    }
}
