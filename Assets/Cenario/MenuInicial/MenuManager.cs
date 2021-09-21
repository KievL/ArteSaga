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

    float cronoMusic = 0f;

    public static AudioClip intro;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        painel.SetActive(false);
        intro = Resources.Load<AudioClip>("intro");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.PlayOneShot(intro);
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
    void playMusic()
    {
        crono += Time.deltaTime;
        if (crono >= 130)
        {
            audioSrc.PlayOneShot(intro);
            crono = 0;
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
    public void Opcoes()
    {
        SceneManager.LoadScene("Opcoes");
    }
    public void Sair()
    {
        Application.Quit();
    }
}
