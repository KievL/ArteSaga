using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metal2Manager : MonoBehaviour
{
    public GameObject tutorialBtn;
    public GameObject painelInicial;
    public GameObject btnFornalha;
    public GameObject btnMistura;
    public GameObject btnMolde;
    public GameObject btnAndar;
    public GameObject btnColetarMinerio;
    public GameObject btnTirarMistura;

    public GameObject canvasFornalha;

    public GameObject pablo;

    public GameObject btnOuro;
    public GameObject btnFerro;
    public GameObject btnEstanho;
    public GameObject btnCobre;

    public GameObject btnBotarForma;

    public GameObject tutEspere, tutEsquentar, tutMisturar, tutTirarMistura, tutTirarMinerio, tutMoldes;

    public float crono = 0;
    public int sceneStep = 0;
    public int tutStep = 0;

    public static int qntsLiqs = 0;

    public bool jogoValendo = false;
    public static bool esquentando = false;

    public static bool mistura1Ready = false;
    public static bool mistura2Ready = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorialBtn.SetActive(false);
        painelInicial.SetActive(true);
        btnFornalha.SetActive(false);
        btnMistura.SetActive(false);
        btnMolde.SetActive(false);
        btnAndar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InicioTutorial();
        ComecarJogo();
        aparecerBotoes();
        tirarMinerio();
        aparecerMissoes();
    }

    void InicioTutorial()
    {
        if(sceneStep == 0)
        {
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                painelInicial.SetActive(false);
                tutorialBtn.SetActive(true);
                crono = 0;
            }
        }
    }

    void ComecarJogo()
    {
        if(sceneStep == 1){
            tutorialBtn.SetActive(false);
            btnAndar.SetActive(true);
            jogoValendo = true;
            
        }
    }

    public void nextTutorial()
    {
        tutStep++;
        tutorialBtn.GetComponent<Animator>().SetInteger("tutorialStep", tutStep);
        if (tutStep == 3)
        {
            sceneStep = 1;
        }
    }

    public void AbrirFornalha()
    {
        btnAndar.SetActive(false);
        btnFornalha.SetActive(false);
        canvasFornalha.SetActive(true);
        if(mistura1Ready == false && fornalhaBehavior.tipoMistura1 == -1)
        {
            btnOuro.SetActive(true);
            btnFerro.SetActive(true);
            btnCobre.SetActive(true);
            btnEstanho.SetActive(true);
        }else if(mistura1Ready == false && fornalhaBehavior.tipoMistura1 == 0)
        {
            if(fornalhaBehavior.liquidoTipo == 1)
            {
                btnOuro.SetActive(true);
                btnFerro.SetActive(false);
            }
            else
            {
                btnOuro.SetActive(false);
                btnFerro.SetActive(true);
            }
            btnCobre.SetActive(false);
            btnEstanho.SetActive(false);

        }
        else if (mistura1Ready == false && fornalhaBehavior.tipoMistura1 == 1)
        {
            if (fornalhaBehavior.liquidoTipo == 2)
            {
                btnEstanho.SetActive(true);
                btnCobre.SetActive(false);
            }
            else
            {
                btnEstanho.SetActive(false);
                btnCobre.SetActive(true);
            }
            btnOuro.SetActive(false);
            btnFerro.SetActive(false);

        }else if(mistura2Ready == false && fornalhaBehavior.tipoMistura2 == -1 && mistura1Ready == true)
        {
            if(fornalhaBehavior.tipoMistura1 == 0)
            {
                btnOuro.SetActive(false);
                btnFerro.SetActive(false);
                btnCobre.SetActive(true);
                btnEstanho.SetActive(true);
            }
            else
            {
                btnOuro.SetActive(true);
                btnFerro.SetActive(true);
                btnCobre.SetActive(false);
                btnEstanho.SetActive(false);
            }            
        }else if(mistura2Ready == false && fornalhaBehavior.tipoMistura2 == 0)
        {
            if(fornalhaBehavior.liquidoTipo == 1)
            {
                btnOuro.SetActive(true);
                btnFerro.SetActive(false);
            }
            else
            {
                btnOuro.SetActive(false);
                btnFerro.SetActive(true);
            }
            btnEstanho.SetActive(false);
            btnCobre.SetActive(false);
        }
        else if (mistura2Ready == false && fornalhaBehavior.tipoMistura2 == 1)
        {
            if (fornalhaBehavior.liquidoTipo == 2)
            {
                btnEstanho.SetActive(true);
                btnCobre.SetActive(false);
            }
            else
            {
                btnEstanho.SetActive(false);
                btnCobre.SetActive(true);
            }
            btnOuro.SetActive(false);
            btnFerro.SetActive(false);
        }
    }

    void aparecerBotoes()
    {
        if(pablo.transform.position.x >= -5.33f && pablo.transform.position.x <= -3.15f && jogoValendo == true && esquentando == false && qntsLiqs <2
            && mistura2Ready == false)
        {
            btnFornalha.SetActive(true);
        }
        else
        {
            btnFornalha.SetActive(false);
        }

        if(qntsLiqs == 2 && pablo.transform.position.x >= -2.01f && pablo.transform.position.x <= 1.85f)
        {
            btnMistura.SetActive(true);
        }
        else
        {
            btnMistura.SetActive(false);
        }
        if (pablo.transform.position.x >= -2.01f && pablo.transform.position.x <= 1.85f && fornalhaBehavior.misturaPronta == true)
        {
            btnTirarMistura.SetActive(true);
        }
        else
        {
            btnTirarMistura.SetActive(false);
        }
        if(mistura2Ready == true)
        {
            btnBotarForma.SetActive(true);
        }
        else
        {
            btnBotarForma.SetActive(false);
        }
        if(pablo.transform.position.x >= 3.51f && pablo.transform.position.x <= 6.14f && mistura1Ready == true && mistura2Ready == true && fornalhaBehavior.acabou == false)
        {
            btnMolde.SetActive(true);
        }
        else
        {
            btnMolde.SetActive(false);
        }
    }
    void tirarMinerio()
    {
        if(fornalhaBehavior.minerioPronto == true && pablo.transform.position.x >= -5.33f && pablo.transform.position.x <= -3.15f)
        {
            btnColetarMinerio.SetActive(true);

        }
        else
        {
            btnColetarMinerio.SetActive(false);
        }
    }
    public void AbrirMisturaCanvas()
    {

    }
    void aparecerMissoes()
    {
        if (esquentando == true && fornalhaBehavior.minerioPronto == false)
        {
            tutEspere.SetActive(true);
            tutEsquentar.SetActive(false);
            tutMisturar.SetActive(false);
            tutMoldes.SetActive(false);
            tutTirarMinerio.SetActive(false);
            tutTirarMistura.SetActive(false);
        }else if (fornalhaBehavior.minerioPronto == true)
        {
            tutEspere.SetActive(false);
            tutEsquentar.SetActive(false);
            tutMisturar.SetActive(false);
            tutMoldes.SetActive(false);
            tutTirarMinerio.SetActive(true);
            tutTirarMistura.SetActive(false);
        }else if(mistura1Ready == true && mistura2Ready == true && fornalhaBehavior.acabou == false)
        {
            tutEspere.SetActive(false);
            tutEsquentar.SetActive(false);
            tutMisturar.SetActive(false);
            tutMoldes.SetActive(true);
            tutTirarMinerio.SetActive(false);
            tutTirarMistura.SetActive(false);
        }
        else if (jogoValendo == true && esquentando == false && qntsLiqs < 2)
        {
            tutEspere.SetActive(false);
            tutEsquentar.SetActive(true);
            tutMisturar.SetActive(false);
            tutMoldes.SetActive(false);
            tutTirarMinerio.SetActive(false);
            tutTirarMistura.SetActive(false);
        }
        else if (qntsLiqs == 2)
        {
            tutEspere.SetActive(false);
            tutEsquentar.SetActive(false);
            tutMisturar.SetActive(true);
            tutMoldes.SetActive(false);
            tutTirarMinerio.SetActive(false);
            tutTirarMistura.SetActive(false);
        }else if (fornalhaBehavior.misturaPronta == true)
        {
            tutEspere.SetActive(false);
            tutEsquentar.SetActive(false);
            tutMisturar.SetActive(false);
            tutMoldes.SetActive(false);
            tutTirarMinerio.SetActive(false);
            tutTirarMistura.SetActive(true);
        }
        else
        {
            tutEspere.SetActive(false);
            tutEsquentar.SetActive(false);
            tutMisturar.SetActive(false);
            tutMoldes.SetActive(false);
            tutTirarMinerio.SetActive(false);
            tutTirarMistura.SetActive(false);
        }
    }
}
