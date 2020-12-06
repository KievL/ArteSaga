using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egito1Manager : MonoBehaviour
{
    public GameObject piramide;
    public GameObject piramideOfc;
    public GameObject chao1;
    public GameObject chao2;
    public GameObject chao3;
    public GameObject chao4;
    public GameObject pablo;
    public GameObject fundo;
    public GameObject fala1;
    public GameObject fala2;
    public GameObject cam;
    public GameObject defensor;
    public GameObject btnFalas;
    public GameObject btnCorrect;
    public GameObject btnWrong;
    public GameObject hitMark;

    public float velo;
    public float velMultiplicador;

    public float velPabloInicial;
    public float velMultiplicadorPablo;

    public float velFundo;
    public float velFundoMultiplicador;

    public float velPiramide;

    public bool tutorial = false;
    public bool tutorialAux = false;

    public int sceneStep = 0;
    public float camVelS1;
    public float camVelMultiS1;
    public float pabloVelS1;

    public bool pressButton = false;

    public bool errou = false;
    public bool errarAux = false;
    public float errarTimer=0;
    public float hitTimer = 0;
    public float hitApareceu = 0;
    public bool aparecerHit = false;

    public static AudioClip hitSound;
    public static AudioClip oof;
    static AudioSource audioSrc;


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
        //Aparecer Botao
        aparecerBotao();
        //Aparecer Botao

        //Cena Inicial
        piramideWalk();
        areiaWalk();
        pabloAndando();
        moverFundo();
        //Cena Inicial

        //Tutorial
        tutorialFala();
        //Tutorial

        //Scene 1
        andarPiramide();
        //Scene 1

        //Errar
        errouMethod();
        aparecerBotoes();
        //Errar
    }

    //Cena inicial
    void piramideWalk()
    {
        if(piramide.transform.position.x >= -74.5f)
        {
            piramide.GetComponent<Rigidbody2D>().velocity = new Vector2(velPiramide, 0);
        }
        else
        {
            piramide.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        
    }
    void areiaWalk()
    {
        if(velo<0f)
        {
            velo = velo - Time.deltaTime*velMultiplicador;
            chao1.GetComponent<Rigidbody2D>().velocity = new Vector2(velo, 0);
            chao2.GetComponent<Rigidbody2D>().velocity = new Vector2(velo, 0);
            chao3.GetComponent<Rigidbody2D>().velocity = new Vector2(velo, 0);
            chao4.GetComponent<Rigidbody2D>().velocity = new Vector2(velo, 0);
            piramideOfc.GetComponent<Rigidbody2D>().velocity = new Vector2(velo, 0);
            defensor.GetComponent<Rigidbody2D>().velocity = new Vector2(velo, 0);
        }
        else
        {
            piramideOfc.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            chao1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            chao2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            chao3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            chao4.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            defensor.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    void pabloAndando()
    {
        if (velPabloInicial > 0f)
        {
            velPabloInicial = velPabloInicial - Time.deltaTime * velMultiplicadorPablo;
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPabloInicial, 0);
            pablo.GetComponent<Animator>().SetBool("correndo", true);
        }
        else
        {
           pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
           pablo.GetComponent<Animator>().SetBool("correndo", false);
            if (tutorialAux == false)
            {
                tutorial = true;
            }
           
        }
    }
    void moverFundo()
    {
        if(velFundo < 0f)
        {
            velFundo = velFundo - Time.deltaTime * velFundoMultiplicador;
            fundo.GetComponent<Rigidbody2D>().velocity = new Vector2(velFundo, 0);
        }
        else
        {
            fundo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    //Cenal inicial

    //AparecerBotao
    void aparecerBotao()
    {
        if (pressButton == true)
        {
            btnFalas.SetActive(true);
        }
        else
        {
            btnFalas.SetActive(false);
        }
    }
    //AparecerBotao

    //Tutorial
    void tutorialFala()
    {
        if(tutorial == true)
        {
            pressButton = true;
            tutorialAux = true;
            tutorial = false;
            fala1.SetActive(true);

        }
    }
    public void avancarTutorial()
    {
        fala1.SetActive(false);
        fala2.SetActive(false);
        pressButton = false;
        sceneStep++;
        
    }
    //Tutorial

    //SceneStep1
    void andarPiramide()
    {
        if (sceneStep == 1)
        {
            if(camVelS1 >0)
            {
                camVelS1 -= Time.deltaTime * camVelMultiS1;
                cam.GetComponent<Rigidbody2D>().velocity = new Vector2(camVelS1, 0);
            }
            else
            {
                cam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                pressButton = true;
                fala2.SetActive(true);
                sceneStep++;
            }
            if(pablo.transform.position.x <= 6f)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(pabloVelS1, 0);
                pablo.GetComponent<Animator>().SetBool("correndo", true);
            }
            else
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                pablo.GetComponent<Animator>().SetBool("correndo", false);
            }
        } 
    }
    //SceneStep1

    //Errar
    public void errouEnigma()
    {
        if (errarAux == false)
        {
            errou = true;
        }
    }

    void errouMethod()
    {
        if(errou == true)
        {
            audioSrc.PlayOneShot(hitSound);
            audioSrc.PlayOneShot(oof);
            errarAux = true;
            defensor.GetComponent<Animator>().SetBool("atacando", true);
            errou = false;
        }
        if (errarAux == true)
        {
            if (hitTimer <= 0.3f && aparecerHit==false)
            {
                hitTimer += Time.deltaTime;
            }
            else
            {
                aparecerHit = true;
                hitMark.SetActive(true);
                if (hitApareceu <= 0.1f)
                {
                    hitApareceu += Time.deltaTime;
                }
                else
                {                    
                    hitMark.SetActive(false);
                }

            }
            
            if (errarTimer < 0.7f)
            {
                errarTimer += Time.deltaTime;
            }
            else
            {
                hitTimer = 0;
                hitApareceu = 0;
                aparecerHit = false;
                defensor.GetComponent<Animator>().SetBool("atacando", false);
                errarAux = false;
                errarTimer = 0;
            }
        }
    }
    void aparecerBotoes()
    {
        if (sceneStep == 3)
        {
            btnCorrect.SetActive(true);
            btnWrong.SetActive(true);
        }
    }
    //Errar


}
