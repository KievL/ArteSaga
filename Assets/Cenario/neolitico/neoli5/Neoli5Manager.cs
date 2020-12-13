using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Neoli5Manager : MonoBehaviour
{
    public GameObject btnFala;
    public GameObject painelInicio;
    public GameObject painelFinal;

    public float crono = 0;
    public int sceneStep = 0;

    public int falaStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("NeoLivroStep", 2);       
    }

    // Update is called once per frame
    void Update()
    {
        Inicio();
        Conversa();
        Acabou();
        FinalCena();
    }
    void Inicio()
    {
        if(sceneStep == 0)
        {
            crono += Time.deltaTime;
            painelInicio.SetActive(true);
            if(crono >= 1f)
            {
                sceneStep = 1;
                crono = 0;
            }
        }
    }
    void Conversa()
    {
        if(sceneStep == 1)
        {
            painelInicio.SetActive(false);
            btnFala.SetActive(true);

        }
    }
    void Acabou()
    {
        if(sceneStep == 2)
        {
            crono += Time.deltaTime;
            btnFala.SetActive(false);
            if (crono >= 1f)
            {
                painelFinal.SetActive(true);
                sceneStep = 3;
                crono = 0;
            }
        }
    }
    void FinalCena()
    {
        if(sceneStep == 3)
        {
            crono += Time.deltaTime;
            if(crono>= 6.7f)
            {
                PlayerPrefs.SetInt("NeoliStep", 0);
                PlayerPrefs.Save();
                SceneManager.LoadScene("prehistoria");
            }
        }
    }
    public void nextFala()
    {
        falaStep++;
        btnFala.GetComponent<Animator>().SetInteger("falaStep", falaStep);
        if (falaStep == 2)
        {
            sceneStep = 2;
        }
    }
    
}
