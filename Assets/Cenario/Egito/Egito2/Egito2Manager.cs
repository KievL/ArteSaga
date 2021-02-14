using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Egito2Manager : MonoBehaviour
{
    public GameObject eclipse;
    public GameObject pablo;
    public GameObject cam;
    public GameObject txtNefertari;
    public GameObject falaIni;
    public GameObject seta;
    public GameObject painel;
    public GameObject papiro;
    public GameObject papiroCanvas;
    public GameObject fecharBtn;
    public GameObject tutorial;
    public GameObject esqueleto;
    public GameObject hitMark;
    public GameObject portao;

    public float velEclispse, velPabloIni, velCameraIni;
    public float camOrthoMulti;

    public float esqueletoVelo, esqVeloMulti;

    public int sceneStep = 0;

    public float crono1, cronoTxt;
    public bool txtOn;

    public static bool clickEnigma = false;

    public static bool noPapiro = false;

    public static int acertou = 0;

    public float cronoPerdeu = 0;
    public int perdeuStep = 0;

    public RaycastHit2D hit;

    public static AudioClip hitSound;
    public static AudioClip oof;
    static AudioSource audioSrc;

    public bool fezSom = false;

    public float cronoHit = 0;
    public int hitStep = 0;
    public bool hitMarkApareceu = false;

    public float cronoDoendo = 0;
    public int doendoStep = 0;

    public float cronoAcertou = 0;
    public int acertouStep = 0;

    public float velCamera;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = Resources.Load<AudioClip>("hitSound");
        oof = Resources.Load<AudioClip>("oof");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transitionIni();
        textoNefer();
        pabloAndarIni();
        cameraArrumarIni();
        aparecerFala();
        aparecerSeta();
        jogando();
        abrirPapiro();
        acertouOuNao();
        aparecerHitMark();
        pabloDoendo();
    }
    void transitionIni()
    {
        if(eclipse.transform.position.x >= -22.25)
        {
            eclipse.GetComponent<Rigidbody2D>().velocity = new Vector2(velEclispse, 0);
        }
        else
        {
            eclipse.SetActive(false);
        }
    }
    void textoNefer()
    {
        if (txtOn == true)
        {
            txtNefertari.SetActive(true);
            cronoTxt += Time.deltaTime;
            if (cronoTxt >= 6.2f)
            {
                txtNefertari.SetActive(false);
                txtOn = false;
                sceneStep = 3;
            }
        }

    }
    void pabloAndarIni()
    {
        if (sceneStep == 0)
        {
            if (pablo.transform.position.x <= -0.88f)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPabloIni, 0);
                pablo.GetComponent<Animator>().SetBool("correndo", true);
            }
            else
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                pablo.GetComponent<Animator>().SetBool("correndo", false);
                txtOn = true;
                sceneStep = 1;
            }
        }          
    }
    void cameraArrumarIni()
    {
        if(sceneStep==1)
        {
            if(cam.transform.position.y < 0.37f)
            {
                crono1 += Time.deltaTime;
                if (crono1 >= 1f)
                {
                    cam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velCameraIni);
                    if (cam.GetComponent<Camera>().orthographicSize < 5.007f)
                    {
                        cam.GetComponent<Camera>().orthographicSize += Time.deltaTime * camOrthoMulti;
                    }
                }
            }
            else
            {
                crono1 = 0;
                cam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                sceneStep = 2;
            }            
        }                
    }
    void aparecerFala()
    {
        if (sceneStep == 3)
        {
            falaIni.SetActive(true);
        }
    }
    void aparecerSeta()
    {
        if (sceneStep == 4)
        {
            seta.SetActive(true);
            sceneStep = 5;
        }
    }
    void jogando()
    {
        if(sceneStep==6 && noPapiro == false)
        {
            clickEnigma = true;
            tutorial.SetActive(true);
        }
    }

    public void apertarFala()
    {
        sceneStep = 4;
        falaIni.SetActive(false);
    }
    void abrirPapiro()
    {
        if (noPapiro == false && Input.GetMouseButtonDown(0) && acertou==0)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject == papiro.gameObject)
            {
                clickEnigma = false;
                tutorial.SetActive(false);
                painel.SetActive(true);
                fecharBtn.SetActive(true);
                papiroCanvas.SetActive(true);
                if (sceneStep == 5)
                {
                    seta.SetActive(false);
                    sceneStep = 6;
                }
                noPapiro = true;
            }
        }
        if(noPapiro==false && Input.touchCount > 0 && acertou == 0)
        {
            Touch touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject == papiro.gameObject)
            {
                clickEnigma = false;
                tutorial.SetActive(false);
                painel.SetActive(true);
                fecharBtn.SetActive(true);
                papiroCanvas.SetActive(true);
                if (sceneStep == 5)
                {
                    seta.SetActive(false);
                    sceneStep = 6;
                }
                noPapiro = true;
            }
        }
    }

    void acertouOuNao()
    {
        if (acertou == 1)
        {
            cronoAcertou += Time.deltaTime;
            if(cronoAcertou>=2.3f && acertouStep == 0)
            {
                portao.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2f);
                if(portao.transform.position.y >= 2.99f)
                {
                    portao.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    acertouStep = 1;
                    cronoAcertou = 0;
                }

            }
            if (acertouStep == 1)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(2.5f, 0);
                pablo.GetComponent<Animator>().SetBool("correndo", true);
                if (pablo.transform.position.x >= -0.25f)
                {
                    pablo.GetComponent<SpriteRenderer>().sortingOrder = 0;
                }
                if(pablo.transform.position.x >= 4.28f)
                {
                    cam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velCamera);
                    if(cam.transform.position.y <= -22.11f)
                    {
                        acertouStep = 2;
                    }
                }
            }
            if (acertouStep == 2)
            {
                SceneManager.LoadScene("Egito3");
                cam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        else if(acertou == -1)
        {
            cronoPerdeu += Time.deltaTime;
            if(cronoPerdeu>=1 && perdeuStep == 0)
            {
                esqueleto.GetComponent<Animator>().SetBool("atacando", true);
                esqueleto.GetComponent<Rigidbody2D>().velocity = new Vector2(esqueletoVelo - (Time.deltaTime * esqVeloMulti), 0);
                esqueleto.GetComponent<SpriteRenderer>().sortingOrder = 8;
                if (fezSom == false)
                {
                    audioSrc.PlayOneShot(hitSound);
                    audioSrc.PlayOneShot(oof);
                    fezSom = true;
                }
                
                if (esqueleto.transform.position.x >= -1.715f)
                {
                    cronoPerdeu = 0;
                    perdeuStep = 1;
                    esqueleto.GetComponent<Animator>().SetBool("atacando", false);
                }
            }
            if (perdeuStep == 1)
            {
                esqueleto.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                if (hitMarkApareceu == false)
                {
                    hitStep = 1;
                    hitMarkApareceu = true;
                }

                if (cronoPerdeu >= 0.3f)
                {
                    perdeuStep = 2;
                    cronoPerdeu = 0;
                }
            }
            if (perdeuStep == 2)
            {
                esqueleto.GetComponent<Rigidbody2D>().velocity = new Vector2(-esqueletoVelo*4 + (Time.deltaTime * esqVeloMulti), 0);
                if(esqueleto.transform.position.x <= -2.757f)
                {
                    esqueleto.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    hitMarkApareceu = false;
                    esqueleto.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    perdeuStep = 0;
                    cronoPerdeu = 0;
                    acertou = 0;
                    fezSom = false;
                }
            }

        }
    }

    void aparecerHitMark()
    {        
        if (hitStep == 1)
        {
            hitMark.SetActive(true);
            pablo.GetComponent<Animator>().SetBool("doendo", true);
            doendoStep = 1;
            cronoHit += Time.deltaTime;
            if (cronoHit >= 0.09f)
            {
                hitMark.SetActive(false);
                cronoHit = 0;
                hitStep = 0;
            }
        }
    }
    void pabloDoendo()
    {
        if (doendoStep == 1)
        {
            cronoDoendo += Time.deltaTime;
            if (cronoDoendo >= 0.5f)
            {
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                if (cronoDoendo >= 1.5f)
                {
                    cronoDoendo = 0;
                    doendoStep = 2;
                }
            }
        }
        else if (doendoStep == 2)
        {
            pablo.GetComponent<SpriteRenderer>().flipX = false;
            pablo.GetComponent<Animator>().SetBool("doendo", false);
            doendoStep = 0;
            clickEnigma = true;
            enigmaManager.terminouErrar = true;
            enigmaManager.processoErro = false;
            
        }
    }
   
    public void fecharPapiro()
    {        
        painel.SetActive(false);
        fecharBtn.SetActive(false);
        papiroCanvas.SetActive(false);            
        noPapiro = false;
    }    
}
