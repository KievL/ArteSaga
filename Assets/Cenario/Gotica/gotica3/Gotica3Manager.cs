using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gotica3Manager : MonoBehaviour
{

    public GameObject zerograu, trintagrau, sessentagrau, noventagrau, umvintegrau, umcinquentagrau;

    public bool trocarLiberado = false;
    public bool ganhouJa = false;

    public RaycastHit2D hit;

    public bool trocar1 = false;
    public bool trocar2 = false;
    public bool trocar3 = false;
    public bool trocar4 = false;
    public bool trocar5 = false;
    public bool trocar6 = false;

    public bool trocado1 = false;
    public bool trocado2 = false;
    public bool trocado3 = false;
    public bool trocado4 = false;
    public bool trocado5 = false;
    public bool trocado6 = false;

    public float crono = 0;
    public int sceneStep = 0;
    public int tutorialStep = 0;

    public GameObject papel, camerazinha, painelFinal, tutorial, painelInicial, correto;
    public float velPapel, velCamera;

    public GameObject linhas1, linhas2, linhas3, linhas4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trocarUm();
        trocarDois();
        trocarTres();
        trocarQuatro();
        trocarCinco();
        trocarSeis();
        clickVitral();
        ganhou();
        Riscos();

        if (sceneStep == 0)
        {
            trocarLiberado = false;
            if (tutorialStep == 0)
            {
                crono += Time.deltaTime;
                if (crono >= 0.5f)
                {
                    tutorial.SetActive(true);
                }
            }
            if (tutorialStep == 1)
            {
                crono += Time.deltaTime;
                tutorial.SetActive(false);
                painelInicial.GetComponent<Animator>().SetInteger("painelIniStep", 1);
                if (crono >= 0.5f)
                {
                    crono = 0;
                    sceneStep = 1;
                    painelInicial.SetActive(false);
                    trocarLiberado = true;
                }

            }

            
        }

        if (sceneStep == 3)
        {
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                correto.SetActive(true);
            }
            if (crono >= 3.5f)
            {
                papel.GetComponent<Rigidbody2D>().velocity = new Vector2(velPapel, 0);
                linhas1.GetComponent<Rigidbody2D>().velocity = new Vector2(velPapel, 0);
                linhas2.GetComponent<Rigidbody2D>().velocity = new Vector2(velPapel, 0);
                linhas3.GetComponent<Rigidbody2D>().velocity = new Vector2(velPapel, 0);
                linhas4.GetComponent<Rigidbody2D>().velocity = new Vector2(velPapel, 0);
                camerazinha.GetComponent<Rigidbody2D>().velocity = new Vector2(velCamera, 0);
                if(camerazinha.transform.position.x<= -2.64f)
                {
                    papel.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    camerazinha.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    sceneStep = 4;
                    crono = 0;
                }
            }
            
        }
        if (sceneStep == 4)
        {
            crono += Time.deltaTime;
            if (crono >= 3f)
            {
                painelFinal.SetActive(true);
                if (crono >= 5f)
                {
                    SceneManager.LoadScene("gotica2");
                    PlayerPrefs.SetInt("gotica", 2);
                }
            }
        }
    }

    void clickVitral()
    {
        if (trocarLiberado == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.transform.gameObject == zerograu.gameObject)
                {
                    trocar1 = true;

                }
                if (hit.collider != null && hit.transform.gameObject == trintagrau.gameObject)
                {
                    trocar2 = true;

                }
                if (hit.collider != null && hit.transform.gameObject == sessentagrau.gameObject)
                {
                    trocar3 = true;

                }
                if (hit.collider != null && hit.transform.gameObject == noventagrau.gameObject)
                {
                    trocar4 = true;

                }
                if (hit.collider != null && hit.transform.gameObject == umvintegrau.gameObject)
                {
                    trocar5 = true;

                }
                if (hit.collider != null && hit.transform.gameObject == umcinquentagrau.gameObject)
                {
                    trocar6 = true;

                }
            }


            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null && hit.transform.gameObject == zerograu.gameObject)
                {
                    trocar1 = true;
                }
                if (hit.collider != null && hit.transform.gameObject == trintagrau.gameObject)
                {
                    trocar2 = true;
                }
                if (hit.collider != null && hit.transform.gameObject == sessentagrau.gameObject)
                {
                    trocar3 = true;
                }
                if (hit.collider != null && hit.transform.gameObject == noventagrau.gameObject)
                {
                    trocar4 = true;
                }
                if (hit.collider != null && hit.transform.gameObject == umvintegrau.gameObject)
                {
                    trocar5 = true;
                }
                if (hit.collider != null && hit.transform.gameObject == umcinquentagrau.gameObject)
                {
                    trocar6 = true;
                }

            }


        }
    }

    public void avancarTutorial()
    {
        tutorialStep = 1;
        crono = 0;
    }

    void trocarUm()
    {
        if (trocar1 == true)
        {
            if (trocado1 == false)
            {
                Quaternion target = Quaternion.Euler(0, 0, 180);
                zerograu.transform.rotation = Quaternion.Slerp(zerograu.transform.rotation, target, 2);
                zerograu.transform.position = new Vector3(-2.67f, 0.09f, zerograu.transform.position.z);
                trocado1 = true;
                trocar1 = false;
            }
            else
            {
                Quaternion target = Quaternion.Euler(0, 0, 0);
                zerograu.transform.rotation = Quaternion.Slerp(zerograu.transform.rotation, target, 2);
                zerograu.transform.position = new Vector3(-2.59f, -0.06f, zerograu.transform.position.z);
                trocado1 = false;
                trocar1 = false;
            }
        }
    }
    void trocarDois()
    {
        if (trocar2 == true)
        {
            if (trocado2 == false)
            {
                Quaternion target = Quaternion.Euler(180, 180, 0);
                trintagrau.transform.rotation = Quaternion.Slerp(trintagrau.transform.rotation, target, 2);
                trintagrau.transform.position = new Vector3(-2.392f, 0.05f, trintagrau.transform.position.z);
                trocado2 = true;
                trocar2 = false;
            }
            else
            {
                Quaternion target = Quaternion.Euler(0, 0, 0);
                trintagrau.transform.rotation = Quaternion.Slerp(trintagrau.transform.rotation, target, 2);
                trintagrau.transform.position = new Vector3(-2.59f, -0.18f, trintagrau.transform.position.z);
                trocado2 = false;
                trocar2 = false;
            }
        }
    }
    void trocarTres()
    {
        if (trocar3 == true)
        {
            if (trocado3 == false)
            {
                Quaternion target = Quaternion.Euler(0, 0, 180);
                sessentagrau.transform.rotation = Quaternion.Slerp(sessentagrau.transform.rotation, target, 2);
                sessentagrau.transform.position = new Vector3(-2.362f, -0.014f, sessentagrau.transform.position.z);
                trocado3 = true;
                trocar3 = false;
            }
            else
            {
                Quaternion target = Quaternion.Euler(0, 0, 0);
                sessentagrau.transform.rotation = Quaternion.Slerp(sessentagrau.transform.rotation, target, 2);
                sessentagrau.transform.position = new Vector3(-2.59f, -0.18f, sessentagrau.transform.position.z);
                trocado3 = false;
                trocar3 = false;
            }
        }
    }
    void trocarQuatro()
    {
        if (trocar4 == true)
        {
            if (trocado4 == false)
            {
                Quaternion target = Quaternion.Euler(0, 0, 180);
                noventagrau.transform.rotation = Quaternion.Slerp(noventagrau.transform.rotation, target, 2);
                noventagrau.transform.position = new Vector3(-2.327f, -0.021f, noventagrau.transform.position.z);
                trocado4 = true;
                trocar4 = false;
            }
            else
            {
                Quaternion target = Quaternion.Euler(0, 0, 0);
                noventagrau.transform.rotation = Quaternion.Slerp(noventagrau.transform.rotation, target, 2);
                noventagrau.transform.position = new Vector3(-2.59f, -0.18f, noventagrau.transform.position.z);
                trocado4 = false;
                trocar4 = false;
            }
        }
    }
    void trocarCinco()
    {
        if (trocar5 == true)
        {
            if (trocado5 == false)
            {
                Quaternion target = Quaternion.Euler(0, 0, 180);
                umvintegrau.transform.rotation = Quaternion.Slerp(umvintegrau.transform.rotation, target, 2);
                umvintegrau.transform.position = new Vector3(-2.283f, -0.015f, umvintegrau.transform.position.z);
                trocado5 = true;
                trocar5 = false;
            }
            else
            {
                Quaternion target = Quaternion.Euler(0, 0, 0);
                umvintegrau.transform.rotation = Quaternion.Slerp(umvintegrau.transform.rotation, target, 2);
                umvintegrau.transform.position = new Vector3(-2.59f, -0.18f, umvintegrau.transform.position.z);
                trocado5 = false;
                trocar5 = false;
            }
        }
    }
    void trocarSeis()
    {
        if (trocar6 == true)
        {
            if (trocado6 == false)
            {
                Quaternion target = Quaternion.Euler(0, 0, 180);
                umcinquentagrau.transform.rotation = Quaternion.Slerp(umcinquentagrau.transform.rotation, target, 2);
                umcinquentagrau.transform.position = new Vector3(-2.42f, 0.289f, umcinquentagrau.transform.position.z);
                trocado6 = true;
                trocar6 = false;
            }
            else
            {
                Quaternion target = Quaternion.Euler(0, 0, 0);
                umcinquentagrau.transform.rotation = Quaternion.Slerp(umcinquentagrau.transform.rotation, target, 2);
                umcinquentagrau.transform.position = new Vector3(-2.71f, -0.25f, umcinquentagrau.transform.position.z);
                trocado6 = false;
                trocar6 = false;
            }
        }
    }
    void ganhou()
    {
        if (trocado1 == true && trocado2 == true && trocado3==false && trocado4==true && trocado5==false && trocado6 == true)
        {
            if (ganhouJa == false)
            {
                sceneStep = 3;
                ganhouJa = true;
            }
            
            trocarLiberado = false;
        }


    }

    void Riscos()
    {
        if(trocado4 == true)
        {
            linhas3.SetActive(true);
        }
        else
        {
            linhas3.SetActive(false);
        }

        if((trocado1==false && trocado5==false&& trocado6==false)||
            (trocado3 == false && trocado5 == false && trocado6 == false)||
            (trocado1 == true && trocado5 == true && trocado6 == true)||
            (trocado1 == true && trocado6 == true && trocado3==false)||
            (trocado1 == false && trocado6 == true && trocado3 == true && trocado5==true)

            )
        {
            linhas4.SetActive(true);
        }
        else
        {
            linhas4.SetActive(false);
        }

        if((trocado4==true && trocado2==true &&trocado1==false && trocado5 ==false)||
            (trocado4 == false && trocado2 ==false && trocado1 == true && trocado5 == true)||
            (trocado4 == false && trocado2 == false && trocado1 == false && trocado5 == false)||
            (trocado4 == true&& trocado2 == true && trocado1 == true && trocado5 == true))
        {
            linhas2.SetActive(false);
        }
        else
        {
            linhas2.SetActive(true);
        }

        if ((trocado2 == false && trocado3 == false) || (trocado2 == true && trocado3 == true) ||
            (trocado5 == false && trocado6 == false) || (trocado5 == true && trocado6 == true))
        {
            linhas1.SetActive(false);

        }
        else
        {
            linhas1.SetActive(true);
        }
                
    }

}
