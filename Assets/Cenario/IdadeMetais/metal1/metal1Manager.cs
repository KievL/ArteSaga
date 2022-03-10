using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class metal1Manager : MonoBehaviour
{
    public GameObject painelInicial;
    public GameObject painelFinal;
    public float crono = 0;
    public GameObject btnFala;
    public int falaStep = 0;
    public int sceneStep = 0;
       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AparecerPainel();
        AparecerFala();
        AcabarCena();
    }
    void AparecerPainel()
    {
        if(sceneStep == 0)
        {
            painelInicial.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 8f)
            {
                crono = 0;
                sceneStep = 1;
            }
        }
        
    }
    void AparecerFala()
    {
        if(sceneStep == 1)
        {
            btnFala.SetActive(true);
            painelInicial.SetActive(false);
        }
    }
    void AcabarCena()
    {
        if(sceneStep == 2)
        {
            btnFala.SetActive(false);
            painelFinal.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 0.5f)
            {
                PlayerPrefs.SetInt("MetalStep", 2);
                PlayerPrefs.Save();
                SceneManager.LoadScene("metal2");
            }
        }
    }
    public void MudarFala()
    {
        falaStep++;
        btnFala.GetComponent<Animator>().SetInteger("falaStep", falaStep);
        if(falaStep == 1)
        {
            sceneStep = 2;
        }
    }
}
