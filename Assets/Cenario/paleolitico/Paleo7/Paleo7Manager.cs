using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Paleo7Manager : MonoBehaviour
{
    public GameObject pablo;
    public GameObject caveman;
    public int sceneStep = 0;
    public float crono = 0;
    public float velx;
    public GameObject Deus;
    public GameObject falaDeus;
    public GameObject perguntaDeus;
    public GameObject btnCanvas1;
    public GameObject btnCanvas2;
    public GameObject q1a1;
    public GameObject q1a2;
    public GameObject q1a3;
    public GameObject q1a4;
    public GameObject q2a1;
    public GameObject q2a2;
    public GameObject q2a3;
    public GameObject q2a4;
    public Color red;
    public Color green;
    public Color white;
    public bool q1resp = false;
    public bool q2resp = false;
    public static int godFellings = 0;
    public GameObject resposta1;
    public GameObject resposta2;
    public GameObject sombra;
    public bool aparecerSombra = false;
    public float cronoSombra = 0;
    public float cronoSombra2 = 0;
    public bool cronoIr = false;
    public float cronoDesapear = 0;
    public bool sombraFinal = false;
    public GameObject fadeOutCanvas;
    public float finalCrono = 0;
    public float finalCrono2 = 0;
    public GameObject venom;

    // Start is called before the first frame update
    void Start()
    {
        btnCanvas1.SetActive(false);
        btnCanvas2.SetActive(false);
        Deus.SetActive(false);
        falaDeus.SetActive(false);
        perguntaDeus.SetActive(false);
        white = q1a1.GetComponent<Image>().color;
        red.g = 0f;
        red.b = 0f;
        red.r = 255f;
        red.a = 255f;
        green.r = 0f;
        green.g = 255f;
        green.b = 0f;
        green.a = 255f;

    }

    // Update is called once per frame
    void Update()
    {
        Andar();
        ParaDancar();
        ChegarDeus();
        PerguntaDeus();
        ProxQuest();
        RespFinal();
        SombraDeus();
    }
    void Andar()
    {
        if(sceneStep == 0)
        {
            pablo.transform.Translate(new Vector2(velx, 0) * Time.deltaTime);
            caveman.transform.Translate(new Vector2(velx, 0) * Time.deltaTime);
            if(caveman.transform.position.x <= -6.2f)
            {
                sceneStep = 1;
            }

        }
    }
    void ParaDancar()
    {
        if(sceneStep== 1)
        {
            venom.SetActive(true);
            caveman.GetComponent<SpriteRenderer>().flipX = false;
            caveman.GetComponent<Animator>().SetInteger("cavemanStep", 1);
            
            pablo.GetComponent<Animator>().SetInteger("pabloStep", 1);
            crono += Time.deltaTime;
            if(crono >= 2f)
            {
                pablo.GetComponent<Animator>().SetInteger("pabloStep", 2);
                caveman.GetComponent<Animator>().SetInteger("cavemanStep", 2);
                sceneStep = 2;
                crono = 0;
            }


        }
    }
    void ChegarDeus()
    {
        if(sceneStep == 2)
        {
            crono += Time.deltaTime;
            cronoSombra2 += Time.deltaTime;
            if(cronoSombra2>= 5.3f && cronoIr == false)
            {
                aparecerSombra = true;
                cronoIr = true;
            }
            if (crono >= 6f)
            {
                
                Deus.SetActive(true);
                pablo.GetComponent<Animator>().SetInteger("pabloStep", 3);
                caveman.GetComponent<Animator>().SetInteger("cavemanStep", 3);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                crono = 0;
                sceneStep = 3;
            }
        }        
    }
    void SombraDeus()
    {
       if(aparecerSombra == true)
        {
            sombra.SetActive(true);
            cronoSombra += Time.deltaTime;
            if(cronoSombra >= 1.42f)
            {
                sceneStep = 5;
                sombra.SetActive(false);
                aparecerSombra = false;
            }
        }
    }
  
    void PerguntaDeus()
    {
        if(sceneStep == 5)
        {
            perguntaDeus.SetActive(true);
        }
    }
    public void mudarPergunta()
    {
        if(sceneStep == 5)
        {
            sceneStep++;
            perguntaDeus.GetComponent<Animator>().SetInteger("questStepss", 1);
            btnCanvas1.SetActive(true);
        }       
        if(sceneStep == 8)
        {
            sceneStep++;
            perguntaDeus.GetComponent<Animator>().SetInteger("questStepss", 3);
            btnCanvas2.SetActive(true);
        }
    }
    
    public void quest1a1()
    {
        if(q1resp == false)
        {
            q1a1.GetComponent<Image>().color = red;
            q1a3.GetComponent<Image>().color = green;
            sceneStep = 7;
            crono = 0;
            q1resp = true;
            godFellings--;
        }        
    }
    public void quest1a2()
    {
        if (q1resp == false)
        {
            q1a2.GetComponent<Image>().color = red;
            q1a3.GetComponent<Image>().color = green;
            sceneStep = 7;
            crono = 0;
            q1resp = true;
            godFellings--;
        }
    }
    public void quest1a3()
    {
        if (q1resp == false)
        {            
            q1a3.GetComponent<Image>().color = green;
            sceneStep = 7;
            crono = 0;
            q1resp = true;
            godFellings++;
        }
    }
    public void quest1a4()
    {
        if (q1resp == false)
        {
            q1a4.GetComponent<Image>().color = red;
            q1a3.GetComponent<Image>().color = green;
            sceneStep = 7;
            crono = 0;
            q1resp = true;
            godFellings--;
        }
    }
    public void quest2a1()
    {
        if (q2resp == false)
        {
            q2a1.GetComponent<Image>().color = red;
            q2a3.GetComponent<Image>().color = green;
            sceneStep = 10;
            crono = 0;
            q2resp = true;
            godFellings--;
        }
    }
    public void quest2a2()
    {
        if (q2resp == false)
        {
            q2a2.GetComponent<Image>().color = red;
            q2a3.GetComponent<Image>().color = green;
            sceneStep = 10;
            crono = 0;
            q2resp = true;
            godFellings--;
        }
    }
    public void quest2a3()
    {
        if (q2resp == false)
        {
            q2a3.GetComponent<Image>().color = green;
            sceneStep = 10;
            crono = 0;
            q2resp = true;
            godFellings++;
        }
    }
    public void quest2a4()
    {
        if (q2resp == false)
        {
            q2a4.GetComponent<Image>().color = red;
            q2a3.GetComponent<Image>().color = green;
            sceneStep = 10;
            crono = 0;
            q2resp = true;
            godFellings--;
        }
    }
    void ProxQuest()
    {
         if(sceneStep == 7)
        {
            resposta1.SetActive(true);
            crono += Time.deltaTime;
            if(crono >= 2f)
            {
                resposta1.SetActive(false);
                btnCanvas1.SetActive(false);
                perguntaDeus.GetComponent<Animator>().SetInteger("questStepss", 2);
                sceneStep = 8;
                crono = 0;
            }
        }
    }
    void RespFinal()
    {
        if(sceneStep == 10)
        {
            resposta2.SetActive(true);
            crono += Time.deltaTime;
            if(crono >= 2f)
            {
                btnCanvas2.SetActive(false);
                perguntaDeus.SetActive(false);
                resposta2.SetActive(false);
                sceneStep = 11;
                crono = 0;
            }
        }
        if(sceneStep == 11)
        {
            cronoDesapear += Time.deltaTime;
            if (cronoDesapear >= 1.2f && sombraFinal == false)
            {
                cronoDesapear = 0;
                sombra.SetActive(true);
                sombraFinal = true;
            }
            crono += Time.deltaTime;
            if(crono >= 2f)
            {
                Deus.SetActive(false);

            }
            if(cronoDesapear >= 1.55f && sombraFinal == true)
            {
                sombra.SetActive(false);
            }
            finalCrono += Time.deltaTime;
            if(finalCrono >= 5f)
            {
                fadeOutCanvas.SetActive(true);
                finalCrono2 += Time.deltaTime;
                if(finalCrono2 >= 7f)
                {
                    PlayerPrefs.SetInt("PaleoStep", 0);
                    PlayerPrefs.SetInt("PaleoBook", 2);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("prehistoria");
                }
            }
        }
    }
    
}

