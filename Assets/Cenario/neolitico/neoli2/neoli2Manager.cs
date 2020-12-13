using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class neoli2Manager : MonoBehaviour
{
    public static bool ocupado = false;

    public GameObject painelInicial;
    public GameObject canvasMove;
    public GameObject canvasButtons;
    public GameObject falaHome;
    public GameObject painelSegund;
    public GameObject homem;

    public GameObject btnTrigo1;
    public GameObject btnTrigo2;
    public GameObject btnTrigo3;
    public GameObject btnTrigo4;
    public GameObject btnTrigo5;
    public GameObject btnTrigo6;
    public GameObject btnTrigo7;
    public GameObject btnTrigo8;
    public GameObject panelFinal;
    public GameObject texto;

    public GameObject setaDireita;
    public GameObject bolsaTrigo;

    public float crono3 = 0;
    public int sceneStep = 0;
    public float crono = 0;
    public int falaStep = 0;

    public static bool ativo = false;
    public static int trigos = 0;
    public bool won = false;
    public GameObject tut;
    public float tutTime = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        canvasMove.SetActive(false);
        canvasButtons.SetActive(true);
        falaHome.SetActive(false);
        painelSegund.SetActive(false);
        homem.SetActive(true);
        btnTrigo1.SetActive(false);
        btnTrigo2.SetActive(false);
        btnTrigo3.SetActive(false);
        btnTrigo4.SetActive(false);
        btnTrigo5.SetActive(false);
        btnTrigo6.SetActive(false);
        btnTrigo7.SetActive(false);
        btnTrigo8.SetActive(false);
        texto.SetActive(false);
        panelFinal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        ComecoCena();
        transicao();
        FaladoHomem();
        textoMudar();
        AparacerSeta();
        win();
    }
   
    void ComecoCena()
    {
        if(sceneStep == 0)
        {
            crono += Time.deltaTime;
            if(crono>= 4.5f)
            {
                painelInicial.SetActive(false);
                falaHome.SetActive(true);
            }
        }
        
    }
    void transicao()
    {
        if(sceneStep == 1)
        {
            crono += Time.deltaTime;
            painelSegund.SetActive(true);
            if(crono >= 0.5f)
            {
                homem.SetActive(false);
            }
            if(crono >= 1f)
            {
                tut.SetActive(true);
                
            }
        }
    }
    public void iniciar()
    {
        texto.SetActive(true);
        bolsaTrigo.SetActive(true);
        painelSegund.SetActive(false);
        canvasMove.SetActive(true);
        tut.SetActive(false);
        sceneStep = 2;
        ativo = true;
    }
    public void mudarFala()
    {
        falaStep++;
        if(falaStep == 6)
        {
            sceneStep= 1;
            crono = 0;
            falaHome.SetActive(false);
        }
    }
    void FaladoHomem()
    {
        falaHome.GetComponent<Animator>().SetInteger("falaStep", falaStep);        
    }
    void textoMudar()
    {
        texto.GetComponent<Text>().text = trigos + " / 7"; 
    }
    void win()
    {
        if(trigos == 7)
        {
            won = true;
        }
        if(won == true)
        {
            panelFinal.SetActive(true);
            crono3 += Time.deltaTime;
            if(crono3 >= 1)
            {
                SceneManager.LoadScene("Neoli3");
                PlayerPrefs.SetInt("NeoliStep", 3);
            }
        }
    }
    void AparacerSeta()
    {
        if (guaxBehavior.roubando == true)
        {
            setaDireita.SetActive(true);
        }
        else
        {
            setaDireita.SetActive(false);
        }
    }
}
