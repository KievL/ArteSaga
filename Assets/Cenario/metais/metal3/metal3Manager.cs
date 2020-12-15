using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class metal3Manager : MonoBehaviour
{
    public GameObject fala;
    public GameObject painelInicial;
    public GameObject painelFinal;
    public int sceneStep = 0;
    public float crono = 0;
    public int falaStep = 0;
    public GameObject finalCanvas;
    // Start is called before the first frame update
    void Start()
    {
        painelFinal.SetActive(false);
        PlayerPrefs.SetInt("MetalLivroStep", 2);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {        
        PainelAparecer();
        falaAparacer();
        acabarCena();
    }
    void PainelAparecer()
    {
        if(sceneStep == 0)
        {
            painelInicial.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 0.5f)
            {
                sceneStep = 1;
                painelInicial.SetActive(false);
                crono = 0;
            }
        }
        
        
    }
    void falaAparacer()
    {
        if(sceneStep == 1)
        {
            fala.SetActive(true);
        }
        
    }
    void acabarCena()
    {
        if(sceneStep == 2)
        {
            fala.SetActive(false);
            painelFinal.SetActive(true);
            finalCanvas.SetActive(true);
            crono += Time.deltaTime;
            if(crono >= 7f)
            {
                SceneManager.LoadScene("prehistoria");
            }
        }
    }
    public void proxFala()
    {
        falaStep++;
        fala.GetComponent<Animator>().SetInteger("falaStep", falaStep);
        if(falaStep == 1)
        {
            sceneStep = 2;
        }

           
    }

}
