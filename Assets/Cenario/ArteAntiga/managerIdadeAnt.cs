using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerIdadeAnt : MonoBehaviour
{
    public GameObject pablo;
    public GameObject txtEgito;
    public GameObject txtGrecia;
    public GameObject btnEntrar;
    public GameObject cam;
    public GameObject piramide;
    public GameObject painel;


    public int posPablo;

    public bool entraEgito = false;

    public float offsetX, offsetY;

    public bool transition = false;
    public bool transition2 = false;
    public bool transition3 = false;

    public bool aparecerPainel = false;

    // Start is called before the first frame update
    void Start()
    {
        pabloGeral.liberado = true;
    }

    // Update is called once per frame
    void Update()
    {
        voltarPortal();
        aparecerNomes();
        posicaoPablo();
        aparecerBotao();
        entrarEgito();
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
        else
        {
            posPablo = 0;
        }
    }
    void aparecerBotao()
    {
        if (posPablo != 0)
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
        {

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
                if (cam.GetComponent<Camera>().orthographicSize>= 0.09706646)
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
                    SceneManager.LoadScene("Egito1");
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
                    SceneManager.LoadScene("Egito1");
                }
            }
        }
        if(aparecerPainel == true)
        {
            painel.SetActive(true);
        }
    }
}
