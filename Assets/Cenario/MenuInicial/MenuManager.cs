using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int museuStep;
    public GameObject painel;
    public float crono = 0;
    public bool botarPainel = false;
    public bool apertouBotao = false;
    // Start is called before the first frame update
    void Start()
    {
        painel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(botarPainel == true)
        {
            crono += Time.deltaTime;
            if(crono>= 5f)
            {
                museuStep = PlayerPrefs.GetInt("museuStep");
                if (museuStep == 3)
                {
                    SceneManager.LoadScene("SalaPortais");
                }
                if (museuStep == 0)
                {
                    SceneManager.LoadScene("Museu");
                }
            }
        }
    }
    public void Jogar()
    { 
        if(apertouBotao == false)
        {
            botarPainel = true;
            painel.SetActive(true);
            apertouBotao = true;

        }
        
        
    }
}
