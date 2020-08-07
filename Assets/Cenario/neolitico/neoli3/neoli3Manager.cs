using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class neoli3Manager : MonoBehaviour
{
    public GameObject painelInicio;
    public GameObject botaoFala;
    public GameObject painelFinal;
    public float crono = 0;
    public int sceneStep = 0;
    // Start is called before the first frame update
    void Start()
    {
        painelInicio.SetActive(true);
        botaoFala.SetActive(false);
        painelFinal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Inicio();
        Final();
    }
    void Inicio()
    {
        if(sceneStep == 0)
        {
            crono += Time.deltaTime;
            if(crono >= 1f)
            {
                painelInicio.SetActive(false);
                botaoFala.SetActive(true);
                sceneStep = 1;

            }
        }
    }
    void Final()
    {
        if(sceneStep == 6)
        {
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                SceneManager.LoadScene("neoli4");
            }
            painelFinal.SetActive(true);
        }
    }
    public void MudarFalas()
    {
        sceneStep++;
        botaoFala.GetComponent<Animator>().SetInteger("falaStep", sceneStep);
        if(sceneStep == 5)
        {
            crono = 0;
            botaoFala.SetActive(false);
            sceneStep = 6;
        }
    }
}
