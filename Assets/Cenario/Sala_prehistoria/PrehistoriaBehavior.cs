using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrehistoriaBehavior : MonoBehaviour
{
    public GameObject painelInicial;
    public float crono = 0;
    public int sceneStep = 0;
    public GameObject botaoEntrar;
    public int lugarPortais = 0;
    public GameObject pablo;
    public bool tping = false;
    public GameObject painelFinal;
    public GameObject paleoTxt;
    public GameObject neoTxt;
    public GameObject metalTxt;

    public GameObject seta;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SairPortalPreHist") == 1)
        {
            seta.SetActive(true);
            PlayerPrefs.SetInt("SairPortalPreHist", 0);
        }
        else
        {
            seta.SetActive(false);
        }

        if (PlayerPrefs.GetInt("saidaPrehist") == 1)
        {
            Time.timeScale = 1f;
            pablo.transform.position = new Vector2(0.155f, pablo.transform.position.y);
            PlayerPrefs.SetInt("saidaPrehist", 0);
            neoTxt.SetActive(false);
            metalTxt.SetActive(false);
        }        
        painelInicial.SetActive(true);
        botaoEntrar.SetActive(false);
        painelFinal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InicioPainel();
        AparecerSeta();
        qualPortal();
        teleportando();
        AparecerTxt();
        SairDoPortal();
    }
    void InicioPainel()
    {
        if(sceneStep == 0)
        {
            crono += Time.deltaTime;
            if(crono>= 1f)
            {
                painelInicial.SetActive(false);
                sceneStep = 1;
                PrePabloBehavior.liberado = true;
                crono = 0;
            }
        }
    }
    void AparecerSeta()
    {
        if(lugarPortais != 0)
        {
            botaoEntrar.SetActive(true);
        }
        else
        {
            botaoEntrar.SetActive(false);
        }
    }
    void qualPortal()
    {
        if(pablo.transform.position.x >= -0.038f && pablo.transform.position.x <= 0.449f)
        {
            lugarPortais = 1;
        }
        else if (pablo.transform.position.x >= 0.918f && pablo.transform.position.x <= 1.248f)
        {
            lugarPortais = 2;
        }
        else if (pablo.transform.position.x >= 1.696f && pablo.transform.position.x <= 2.307f)
        {
            lugarPortais = 3;
        }
        else
        {
            lugarPortais = 0;
        }

    }
    public void entrarPortal()
    {
        tping = true;
        PrePabloBehavior.liberado = false;
           
    }

    void teleportando()
    {
        
        if(tping == true)
        {
            painelFinal.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 3f)
            {
                int StepPaleo = PlayerPrefs.GetInt("PaleoStep");
                int StepNeoli = PlayerPrefs.GetInt("NeoliStep");
                if (lugarPortais == 1)
                {
                    if (StepPaleo == 1 || StepPaleo == 0)
                    {
                        deathCanvas.isDead = false;
                        primitivoBehaviour.pularLiberado = false;
                        primitivoBehaviour.vidas = 3;
                        PaleoManager.isCorrendo = false;
                        PaleoManager.aguiaNascer = false;
                        SpawnAguiaCima.allowed = false;
                        SpawnAguiaBaixo.transition = 0;
                        PaleoManager.aguasPasssadas = 0;
                        primitivoBehaviour.ganhou = false;
                        primitivoBehaviour.afetado = false;
                        PlayerPrefs.SetInt("tutorialPaleo1", 0);
                        SceneManager.LoadScene("Paleolitico");
                    }
                    if (StepPaleo == 2)
                    {
                        SceneManager.LoadScene("Paleo2");
                    }
                    if (StepPaleo == 3)
                    {
                        SceneManager.LoadScene("throwArrowScene");
                    }
                    if (StepPaleo == 4)
                    {
                        SceneManager.LoadScene("Paleo4");
                    }
                    if (StepPaleo == 5)
                    {
                        SceneManager.LoadScene("Paleo6");
                    }
                    if (StepPaleo == 6)
                    {
                        SceneManager.LoadScene("Paleo7");
                    }
                }
                if (lugarPortais == 2)
                {
                    if (StepNeoli == 0 || StepNeoli == 1)
                    {
                        SceneManager.LoadScene("neoli1");
                    }
                    if (StepNeoli == 2)
                    {
                        SceneManager.LoadScene("neoli2");
                    }
                    if (StepNeoli == 3)
                    {
                        SceneManager.LoadScene("Neoli3");
                    }
                    if (StepNeoli == 4)
                    {
                        SceneManager.LoadScene("Neoli5");
                    }                    
                }
                if(lugarPortais == 3)
                {
                    SceneManager.LoadScene("metal1");
                }
            }
        }
    }
    void AparecerTxt()
    {
        if(lugarPortais == 1)
        {
            paleoTxt.SetActive(true);

        }else if(lugarPortais == 2)
        {
            neoTxt.SetActive(true);

        }
        else if(lugarPortais == 3)
        {
            metalTxt.SetActive(true);
        }
        else
        {
            paleoTxt.SetActive(false);
            neoTxt.SetActive(false);
            metalTxt.SetActive(false);
        }
    }
    void SairDoPortal()
    {
        if(pablo.transform.position.x <= -1.0718f)
        {

            PlayerPrefs.SetInt("dentroPreHist", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("SalaPortais");
        }
    }
}
