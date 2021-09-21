using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class managerIdadeAnt : MonoBehaviour
{
    public GameObject pablo;
    public GameObject txtEgito;
    public GameObject txtGrecia;
    public GameObject txtRoma;
    public GameObject btnEntrar;
    public GameObject cam;
    public GameObject piramide;
    public GameObject painel;
    public GameObject painelGreciaEntrar;
    public GameObject backLight;
    public GameObject backDark;
    public GameObject btnBook;
    public GameObject bookSeta;

    public int posPablo;

    public bool entraEgito = false;
    bool entraGrecia = false;

    public float crono = 0;

    public float offsetX, offsetY;

    public bool transition = false;
    public bool transition2 = false;
    public bool transition3 = false;

    public bool aparecerPainel = false;

    int whichStart = 0;
    int sceneStep = 0;

    bool liberouinicial = true;

    // Start is called before the first frame update
    void Start()
    {
        pabloGeral.liberado = false;
        if (PlayerPrefs.GetInt("EgitoStep") == 2)
        {
            whichStart = 1;
        }
        else if(PlayerPrefs.GetInt("grecia") == 1)
        {
            whichStart = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        voltarPortal();
        aparecerNomes();
        posicaoPablo();
        aparecerBotao();
        entrarEgito();
        entrarGrecia();
        startScene();
    }
    void voltarPortal()
    {
        if(pablo.transform.position.x <= -1.178f && pabloGeral.liberado == true)
        {
            PlayerPrefs.SetInt("dentroPreHist", 3);
            PlayerPrefs.Save();
            SceneManager.LoadScene("SalaPortais");
        }
    }
    void aparecerNomes()
    {
        if(posPablo==1 && pabloGeral.liberado == true)
        {
            txtEgito.SetActive(true);
        }
        else
        {
            txtEgito.SetActive(false);
        }
        if (posPablo==2 && pabloGeral.liberado == true)
        {
            txtGrecia.SetActive(true);
        }
        else
        {
            txtGrecia.SetActive(false);
        }
        if(posPablo == 3 && pabloGeral.liberado == true)
        {
            txtRoma.SetActive(true);
        }
        else
        {
            txtRoma.SetActive(false);
        }
    }
    void posicaoPablo()
    {
        if(pablo.transform.position.x >= -0.46f && pablo.transform.position.x <= 0.546f)
        {
            posPablo = 1;
        }
        else if(pablo.transform.position.x >= 1.09f && pablo.transform.position.x <= 2.36f)
        {
            posPablo = 2;
        }
        else if (pablo.transform.position.x >= 2.728f && pablo.transform.position.x <= 4.226f)
        {
            posPablo = 3;
        }
        else
        {
            posPablo = 0;
        }
    }
    void aparecerBotao()
    {
        if (posPablo == 1 && pabloGeral.liberado == true)
        {
            btnEntrar.SetActive(true);
        }
        else if (posPablo == 2 && pabloGeral.liberado == true)
        {
            btnEntrar.SetActive(true);
        }
        else
        {
            btnEntrar.SetActive(false);
        }

    }
    public void EntrarPortal()
    {
        if(posPablo == 1 && pabloGeral.liberado == true)
        {
            entraEgito = true;
            pabloGeral.liberado = false;
        }
        if (posPablo == 2 && pabloGeral.liberado == true)
        {
            entraGrecia = true;
            pabloGeral.liberado = false;
        }
    }
    void entrarGrecia()
    {
        if (entraGrecia)
        {
            painelGreciaEntrar.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 1.5f)
            {
                PlayerPrefs.SetInt("grecia", 1);
                SceneManager.LoadScene("GreciaAntiga");
            }
        }    
    }
    void entrarEgito()
    {

        if (entraEgito == true )
        {
            if(pablo.transform.position.x <= -0.057f && transition==false)
            {
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                cam.transform.position = new Vector3(pablo.transform.position.x + offsetX, offsetY, cam.transform.position.z);
                if (cam.GetComponent<Camera>().orthographicSize>= 0.0883)
                {
                    cam.GetComponent<Camera>().orthographicSize = cam.GetComponent<Camera>().orthographicSize - Time.deltaTime;
                }
                else
                {
                    aparecerPainel = true;
                    transition = true;
                    
                }
                
            }
            if(pablo.transform.position.x > -0.057f && transition == false && transition2==false)
            {
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                cam.transform.position = new Vector3(pablo.transform.position.x + offsetX, offsetY, cam.transform.position.z);
                if (cam.GetComponent<Camera>().orthographicSize >= 0.09706646)
                {
                    cam.GetComponent<Camera>().orthographicSize = cam.GetComponent<Camera>().orthographicSize - Time.deltaTime;
                }
                else
                {
                    transition2 = true;
                }
            }
            if (transition2 == true && transition3==false)
            {
                if(pablo.transform.position.x > -0.057f)
                {
                    cam.transform.position = new Vector3(pablo.transform.position.x + offsetX, offsetY, cam.transform.position.z);
                    pablo.GetComponent<Animator>().SetBool("correndo", true);
                    pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.7f, 0);
                }
                else
                {
                    aparecerPainel = true;
                    transition3 = true;

                }                
            }
            if (transition3 == true)
            {
                piramide.GetComponent<SpriteRenderer>().sortingOrder = 5;
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                if(pablo.transform.position.x <= 0.257)
                {
                    cam.transform.position = new Vector3(pablo.transform.position.x + offsetX, offsetY, cam.transform.position.z);
                    pablo.GetComponent<Animator>().SetBool("correndo", true);
                    pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0.7f, 0);
                }
                else
                {
                    pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    if (PlayerPrefs.GetInt("EgitoStep") == 0)
                    {
                        SceneManager.LoadScene("Egito1");
                    }
                    else
                    {
                        SceneManager.LoadScene("Egito3");
                    }
                    
                }

            }
            if (transition == true) {
                piramide.GetComponent<SpriteRenderer>().sortingOrder = 5;

                if (pablo.transform.position.x <= 0.257)
                {
                    cam.transform.position = new Vector3(pablo.transform.position.x + offsetX, offsetY, cam.transform.position.z);
                    pablo.GetComponent<Animator>().SetBool("correndo", true);
                    pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0.7f, 0);

                }
                else
                {
                    pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    if (PlayerPrefs.GetInt("EgitoStep") == 0)
                    {
                        SceneManager.LoadScene("Egito1");
                    }
                    else
                    {
                        SceneManager.LoadScene("Egito3");
                    }
                }
            }
        }
        if(aparecerPainel == true)
        {
            painel.SetActive(true);
        }
    }
    void startScene()
    {
        if (whichStart == 1)
        {
            if (sceneStep == 0)
            {
                pablo.transform.position = new Vector3(-0.037f, -1.0397f, pablo.transform.position.z);
                backLight.SetActive(true);
                crono += Time.deltaTime;
                if (crono >= 1f)
                {
                    sceneStep++;
                    crono = 0f;
                
                }

            }
            else if (sceneStep == 1)
            {
                PlayerPrefs.SetInt("EgitoStep", 0);
                PlayerPrefs.Save();
                backLight.SetActive(false);
                bookSeta.SetActive(true);
                pabloGeral.liberado = true;
                sceneStep = 2;

            }
            
        }
        else if (whichStart == 2)
        {
            if (sceneStep == 0)
            {
                if (liberouinicial)
                {
                    pabloGeral.liberado = true;

                }
                else
                {
                    pabloGeral.liberado = false;
                }
                liberouinicial = false;
                pablo.transform.position = new Vector3(1.254f, -1.0397f, pablo.transform.position.z);
                backDark.SetActive(true);
                crono += Time.deltaTime;
                if (crono >= 1f)
                {
                    sceneStep++;
                    crono = 0f;

                }

            }
            else if (sceneStep == 1)
            {
                backDark.SetActive(false);
                PlayerPrefs.SetInt("grecia", 0);
                PlayerPrefs.Save();
                pabloGeral.liberado = true;
                bookSeta.SetActive(true);
                sceneStep = 2;

            }
        }
        else
        {
            pabloGeral.liberado = true;
        }
    }
}
