using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gotica4Manager : MonoBehaviour
{
    public static int monsterSpeed = 0;

    public float rateSpawn;
    public float currentRate;
    public GameObject prefab;

    public float maxHeight;
    public float minHeight;

    public int maxMonster;

    public List<GameObject> monsters;

    public float crono = 0;
    public float crono1 = 0;

    public GameObject eyes;

    public int sceneStep = 0;
    public float cronoStep = 0;

    public GameObject tutorial, painel1, painel2;

    public static bool valendo = false;

    public static AudioClip bmtl;
    static AudioSource audioSrc;

    public static int vidas = 3;

    public bool perdeu = false;

    public GameObject perdeuPainel, perdeuTxt, perdeuBtn, painelFinal, perdeuTxt2;

    public int speedStep = 0;

    public GameObject vida1, vida2, vida3, txtHorda1, txtHorda2, txtAtirar;

    // Start is called before the first frame update
    void Start()
    {
        vidas = 3;
        sceneStep = 0;
        cronoStep = 0;
        valendo = false;
        crono = 0;
        crono1 = 0;
        monsterSpeed = 0;
        perdeu = false;
        Time.timeScale = 1f;

        bmtl = Resources.Load<AudioClip>("bmtl");
        audioSrc = GetComponent<AudioSource>();

        for (int i = 0; i < maxMonster; i++)
        {
            GameObject tempMonster = Instantiate(prefab) as GameObject;
            monsters.Add(tempMonster);
            tempMonster.SetActive(false);

        }
        eyes.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (valendo == true)
        {
            currentRate += Time.deltaTime;
            if(crono1<=45f || crono1 >= 52f)
            {
                if(crono1>=52f)
                {
                    txtAtirar.SetActive(true);
                }
                else
                {
                    txtAtirar.SetActive(false);
                }
                if (currentRate > rateSpawn)
                {
                    currentRate = 0;
                    Spawn();

                }
            }            
            monstersSpeed();

            if (crono1 >= 45f && crono1 <=48f)
            {
                txtHorda1.SetActive(true);
                txtHorda2.SetActive(false);
            }
            else if(crono1>=48f && crono1 <= 51f)
            {
                txtHorda1.SetActive(false);
                txtHorda2.SetActive(true);
            }
            else
            {
                txtHorda1.SetActive(false);
                txtHorda2.SetActive(false);
            }

            crono1 += Time.deltaTime;
            if (crono1 >= 52f)
            {
                eyes.SetActive(true);
                rateSpawn = 0.3f;
            }
        }        
        tutorialInicial();

        if (vidas == 0)
        {
            perdeu = true;
        }
        morreu();
        ganhou();
        vidasUpdate();
    }

    void vidasUpdate()
    {
        if (vidas == 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);

        }else if (vidas == 2)
        {
            vida1.SetActive(false);
            vida2.SetActive(true);
            vida3.SetActive(true);
        }
        else if(vidas==1)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(true);
        }
        else
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }

    }

    void ganhou()
    {
        if (crono1 >= 76f)
        {
            painelFinal.SetActive(true);
            if (crono1 >= 76.5f)
            {
                PlayerPrefs.SetInt("gotica", 3);
                PlayerPrefs.Save();
                SceneManager.LoadScene("gotica2");
            }
        }
    }


    void morreu()
    {
        if (perdeu == true)
        {
            audioSrc.Stop();
            perdeuBtn.SetActive(true);
            perdeuPainel.SetActive(true);
            perdeuTxt.SetActive(true);
            perdeuTxt2.SetActive(true);
            Time.timeScale = 0f;

        }
    }

    void tutorialInicial()
    {
        if (sceneStep == 0)
        {
            cronoStep += Time.deltaTime;
            if(cronoStep >= 0.5f){
                tutorial.SetActive(true);
            }
        }
        if (sceneStep == 1)
        {
            tutorial.SetActive(false);
            painel1.SetActive(false);
            painel2.SetActive(true);
            cronoStep += Time.deltaTime;
            if (cronoStep >= 0.5f)
            {
                painel2.SetActive(false);
                sceneStep = 2;
                cronoStep = 0;
                valendo = true;
                audioSrc.PlayOneShot(bmtl);
            }
        }
    }
    public void apertarTutorial()
    {
        sceneStep = 1;
        cronoStep = 0;
    }

    private void Spawn()
    {
        float randomPos = Random.Range(minHeight, maxHeight);

        GameObject tempMonster = null;

        for (int i = 0; i < maxMonster; i++)
        {
            if (monsters[i] != null)
            {
                if (monsters[i].activeSelf == false)
                {
                    tempMonster = monsters[i];
                    break;
                }
            }
            
        }
        if (tempMonster != null)
        {
            tempMonster.transform.position = new Vector3(10.36f, randomPos, 0);
            tempMonster.SetActive(true);
        }
    }

    void monstersSpeed()
    {
        crono += Time.deltaTime;
        if(crono>=17f && speedStep==0)
        {
            monsterSpeed++;
            crono = 0;
            speedStep++;

        }
        if (crono >= 13f && speedStep==1)
        {
            monsterSpeed++;
            crono = 0;
            speedStep++;
            
        }
        if (crono >= 22f && speedStep==2)
        {
            monsterSpeed++;
            crono = 0;
            speedStep++;
        }
        if(crono>=15f && speedStep == 3)
        {
            monsterSpeed++;
            crono = 0;
            speedStep++;
        }
    }

    public void recomecar()
    {
        SceneManager.LoadScene("gotica4");
        vidas = 3;
        sceneStep = 0;
        cronoStep = 0;
        valendo = false;
        crono = 0;
        crono1 = 0;
        monsterSpeed = 0;
        perdeu = false;
        Time.timeScale = 1f;
    }
}
