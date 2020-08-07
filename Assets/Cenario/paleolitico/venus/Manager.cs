using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public float crono = 0;
    public int sceneStep = 0;
    public float intervalo;

    public GameObject pena;
    public GameObject argilex;
    public GameObject osso;

    public int fallStep = 0;

    public static int pontuacao = 0;
    public int pont = 0;

    public static int objType;

    public static bool win = false;

    public GameObject cumbuca;
    public GameObject venus;
    public GameObject cumbucaShader;
    public GameObject venusShader;

    public Text text;

    public int ptmMax;

    public float crono2 = 0;
    public float crono3 = 0;

    public GameObject explosion;
    public GameObject btnDestruir;
    public GameObject txtHeh;

    // Start is called before the first frame update
    void Start()
    {
        cumbucaShader.SetActive(false);
        venusShader.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        contagem();
        queda();
        pont = pontuacao;
        ganhou();
        animationVenus();
        text.text = "Pontuação: " + pontuacao;

    }
    void contagem()
    {
        if(sceneStep == 0)
        {
            crono += Time.deltaTime;
            if(crono > 2f)
            {
                sceneStep = 1;
                crono = 0;
            }
        }
    }
    void queda()
    {       
        if(sceneStep == 1)
        {
            crono += Time.deltaTime;
            if(crono >= intervalo)
            {
                if (fallStep % 4 == 0)
                {
                    objType = 0;
                    GameObject argila = Instantiate(argilex) as GameObject;
                    argila.SetActive(true);
                    
                }
                else
                {
                    int type = Random.Range(1, 3);
                    if(type == 1)
                    {
                        objType = 2;
                        GameObject penaa = Instantiate(pena) as GameObject;
                        penaa.SetActive(true);

                    }
                    else
                    {
                        objType = 3;
                        GameObject ossox = Instantiate(osso) as GameObject;
                        ossox.SetActive(true);
                    }

                }
                crono = 0;
                fallStep++;
            }
        }
    }
    void ganhou()
    {
        if(pontuacao == ptmMax)
        {
            sceneStep = 2;
            win = true;
            
        }  
        if(sceneStep == 2)
        {
            crono2 += Time.deltaTime;
            if(crono2 >= 2.5f)
            {
                crono3 += Time.deltaTime;
                if (crono3 >= 3f)
                {
                    crono3 = 0;
                    sceneStep = 3;
                }
                cumbucaShader.SetActive(true);
                venusShader.SetActive(false);
                cumbucaShader.transform.position = new Vector2(cumbuca.transform.position.x, cumbuca.transform.position.y);
            }
        }
        if(sceneStep == 3)
        {
            PlayerPrefs.SetInt("PaleoStep", 5);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Paleo6");
        }
    }
    void animationVenus() {
        if (pontuacao >= 0 && pontuacao <4)
        {
            venus.GetComponent<Animator>().SetInteger("venusSteps", 0);
        } if (pontuacao >= 4 && pontuacao < 8)
        {
            venus.GetComponent<Animator>().SetInteger("venusSteps", 1);

        } if (pontuacao >= 8 && pontuacao < 12)
        {
            venus.GetComponent<Animator>().SetInteger("venusSteps", 2);

        } if (pontuacao >= 12 && pontuacao < 16)
        {
            venus.GetComponent<Animator>().SetInteger("venusSteps", 3);
            
        }
        if(pontuacao >= 16)
        {
            venus.GetComponent<Animator>().SetInteger("venusSteps", 4);
        }
             
    }
    public void desaparecerTut()
    {
        txtHeh.SetActive(false);
        Destroy(btnDestruir.gameObject);
    }
}
