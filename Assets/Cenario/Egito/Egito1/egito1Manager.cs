using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class egito1Manager : MonoBehaviour
{
    public GameObject piramide;
    public GameObject piramideOfc;
    public GameObject chao1;
    public GameObject chao2;
    public GameObject chao3;
    public GameObject chao4;
    public GameObject chao5;
    public GameObject chao6;
    public GameObject chao7;
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

    public float velAreia, velf1, velf2, velf3, velf4, velf5;
    public GameObject f1, f2, f3, f4, f5, f12, f22,f32,f42,f52;
    public float velMultiplicador;
    public float velEclipse;
    public GameObject eclipse;

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
        

        //Cena Inicial
        piramideWalk();
        areiaWalk();
        pabloAndando();
        paralaxSpeed();
        transition();
        //moverFundo();
        //Cena Inicial
        /*
        //Tutorial
        tutorialFala();
        //Tutorial

        //Scene 1
        andarPiramide();
        //Scene 1

        //Aparecer Botao
        aparecerBotao();
        //Aparecer Botao

        //Errar
        errouMethod();
        aparecerBotoes();
        //Errar
        */
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
        if(velAreia<0f)
        {
            chao1.GetComponent<Rigidbody2D>().velocity = new Vector2(velAreia, 0);
            chao2.GetComponent<Rigidbody2D>().velocity = new Vector2(velAreia, 0);
            chao3.GetComponent<Rigidbody2D>().velocity = new Vector2(velAreia, 0);
            chao4.GetComponent<Rigidbody2D>().velocity = new Vector2(velAreia, 0);
            chao5.GetComponent<Rigidbody2D>().velocity = new Vector2(velAreia, 0);
            chao6.GetComponent<Rigidbody2D>().velocity = new Vector2(velAreia, 0);
            chao7.GetComponent<Rigidbody2D>().velocity = new Vector2(velAreia, 0);

        }       
    }
    void pabloAndando()
    {
        if (velPabloInicial > 0f)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPabloInicial, 0);
            pablo.GetComponent<Animator>().SetBool("correndo", true);
            cam.GetComponent<Rigidbody2D>().velocity = new Vector2(velPabloInicial, 0);
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
    void paralaxSpeed()
    {
        f1.GetComponent<Rigidbody2D>().velocity = new Vector2(velf1, 0);
        f12.GetComponent<Rigidbody2D>().velocity = new Vector2(velf1, 0);
        f2.GetComponent<Rigidbody2D>().velocity = new Vector2(velf2, 0);
        f22.GetComponent<Rigidbody2D>().velocity = new Vector2(velf2, 0);
        f3.GetComponent<Rigidbody2D>().velocity = new Vector2(velf3, 0);
        f32.GetComponent<Rigidbody2D>().velocity = new Vector2(velf3, 0);
        f4.GetComponent<Rigidbody2D>().velocity = new Vector2(velf4, 0);
        f42.GetComponent<Rigidbody2D>().velocity = new Vector2(velf4, 0);
        f5.GetComponent<Rigidbody2D>().velocity = new Vector2(velf5, 0);
        f52.GetComponent<Rigidbody2D>().velocity = new Vector2(velf5, 0);
    }
    void transition()
    {
        if(cam.transform.position.x >= 6.959995f)
        {
            eclipse.GetComponent<Rigidbody2D>().velocity = new Vector2(velEclipse, 0);
            if(cam.transform.position.x >= 11.63999f)
            {
                SceneManager.LoadScene("Egito2");
            }
        }
    }
    /*
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
    */

}
