using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotica2Manager : MonoBehaviour
{
    public GameObject pablo, parallaxWall, cameraGO, blackScreen;

    public RaycastHit2D hit;

    public float blackScreenSpeed, cameraStartSpeed, parallaxSpeed;

    public int sceneStep = 0;
    public float crono = 0;

    public GameObject padre, padrePainel, padreConversa, painelPadre2, painelPadre3;

    public bool apertouPadre = false;
    public int stepPadre = 0;
    int falaPadreStep = 0;

    public GameObject homemAzul, homemAzulConversa, meninoConversa;

    public int stepHomemAzul = 0;
    int falaHomemStep = 0;
    public bool apertouHomemAzul = false;

    public int stepMenino = 0;
    int falaMeninoStep = 0;

    public GameObject questMark, btnEsq, btnDir;

    public GameObject menino, andaime, tutorialAnd, borda1, borda2, borda3, pablosegurando;
    public GameObject btnAndaimeEsq, btnAndaimeDir, pedra, parede1, parede2;

    public float cronoMinigame = 0;
    public int minigameStep = 0;
    public int andaimeDirec = 0;
    public float andaimeVel, intervalPedra;
    public float cronoPedra = 0;

    public GameObject painelDeath, txt1Death, txt2Death, btnDeath;

    public int tutorialStep = 0;
    bool moveuMenino = false;

    public static bool bateuPedra = false;

    public GameObject falaFinal, coroa, panelFinal, lightFinal;
    public int falaFinalStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (bateuPedra == true)
        {
            Time.timeScale = 1f;
            bateuPedra = false;
            sceneStep = 4;
        }
        pabloGotWalk2.gotic2Liberado = false;
    }

    // Update is called once per frame
    void Update()
    {
        wallMovement();
        falaPadre();
        stepsGotica();
        falaHomemAzul();
        questPosition();       

        //Scene steps
        
    }
    void stepsGotica()
    {
        if (PlayerPrefs.GetInt("gotica") == 1)
        {
            if (sceneStep == 0)
            {
                blackScreen.GetComponent<Rigidbody2D>().velocity = new Vector2(blackScreenSpeed, 0);
                parallaxWall.GetComponent<Rigidbody2D>().velocity = new Vector2(blackScreenSpeed, 0);
                cameraGO.GetComponent<Rigidbody2D>().velocity = new Vector2(cameraStartSpeed, 0);
                if (blackScreen.transform.position.x <= -24.82f)
                {
                    blackScreen.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    parallaxWall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    cameraGO.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    sceneStep = 1;
                }
            }
            if (sceneStep == 1)
            {
                pabloGotWalk2.gotic2Liberado = true;
            }
        }
        else if (PlayerPrefs.GetInt("gotica") == 2)
        {
            if (sceneStep == 0)
            {
                pabloGotWalk2.gotic2Liberado = false;
                crono += Time.deltaTime;
                blackScreen.transform.position = new Vector3(-24.82f, blackScreen.transform.position.y, blackScreen.transform.position.z);               
                cameraGO.transform.position = new Vector3(22.82f, -2.2f, cameraGO.transform.position.z);
                pablo.transform.position = new Vector3(22.786f, -2.748f, pablo.transform.position.z);
                parallaxWall.transform.position = new Vector3(2.390397f, -0.3354006f, parallaxWall.transform.position.z);
                cameraGO.GetComponent<Camera>().orthographicSize = 1.659771f;
                painelPadre3.SetActive(true);
                if (crono >= 1f)
                {
                    sceneStep = 1;
                    crono = 0;
                }

            }
            if (sceneStep == 1)
            {
                padreConversa.SetActive(true);
                padreConversa.GetComponent<Animator>().SetInteger("padreCStep", 3);
                falaPadreStep = 3;               
                painelPadre3.SetActive(false);

                sceneStep = 2;
            }
            if (sceneStep == 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null && hit.transform.gameObject == padreConversa.gameObject)
                    {
                        falaPadreStep++;

                    }
                }
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit.collider != null && hit.transform.gameObject == padreConversa.gameObject)
                    {
                        falaPadreStep++;
                    }
                }
                if (falaPadreStep >= 4)
                {
                    sceneStep = 3;
                }
            }
            if (sceneStep == 3)
            {
                padreConversa.SetActive(false);
                crono += Time.deltaTime;
                if (crono >= 1f)
                {
                    padrePainel.SetActive(true);
                    if (crono >= 1.5f)
                    {
                        cameraGO.transform.position = new Vector3(17.330f, 0f, cameraGO.transform.position.z);
                        cameraGO.GetComponent<Camera>().orthographicSize = 5f;
                        parallaxWall.transform.position = new Vector3(-45.88988f, 0.08f, parallaxWall.transform.position.z);
                        pabloGotWalk2.gotic2Liberado = true;
                        padrePainel.SetActive(false);
                        sceneStep = 4;
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt("gotica")==3)
        {
            if (sceneStep == 0)
            {
                pabloGotWalk2.gotic2Liberado = false;
                crono += Time.deltaTime;
                blackScreen.transform.position = new Vector3(-24.82f, blackScreen.transform.position.y, blackScreen.transform.position.z);
                parallaxWall.transform.position = new Vector3(-45.48989f, 0.08f, -118.7656f);
                cameraGO.GetComponent<Camera>().orthographicSize = 1.659771f;
                cameraGO.transform.position = new Vector3(16.66f, -2.487f, cameraGO.transform.position.z);
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                pablo.transform.position = new Vector3(17.02f, -2.748f, pablo.transform.position.z);
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                pablo.GetComponent<Animator>().SetBool("correndo", false);

                painelPadre3.SetActive(true);
                if (crono >= 1f)
                {
                    sceneStep = 1;
                    crono = 0;
                }
                falaHomemStep = 2;
            }
            else if (sceneStep == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null && hit.transform.gameObject == homemAzulConversa.gameObject)
                    {
                        falaHomemStep++;

                    }
                }
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit.collider != null && hit.transform.gameObject == homemAzulConversa.gameObject)
                    {
                        falaHomemStep++;
                    }
                }
                homemAzulConversa.GetComponent<Animator>().SetInteger("homemCStep", falaHomemStep);
                homemAzulConversa.SetActive(true);
                
                painelPadre3.SetActive(false);
                if (falaHomemStep >= 4)
                {
                    sceneStep = 2;
                    crono = 0;
                }
            }
            else if (sceneStep == 2)
            {
                homemAzulConversa.SetActive(false);
                crono += Time.deltaTime;
                padrePainel.SetActive(true);
                if (crono >= 0.5f)
                {
                    parallaxWall.transform.position = new Vector3(8.64f, 0.08f, -118.7656f);
                    cameraGO.GetComponent<Camera>().orthographicSize = 1.659771f;
                    cameraGO.transform.position = new Vector3(10.2f, -2.54f, cameraGO.transform.position.z);
                    pablo.GetComponent<SpriteRenderer>().flipX = false;
                    pablo.transform.position = new Vector3(9.73f, -2.732f, pablo.transform.position.z);
                    pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    pablo.GetComponent<Animator>().SetBool("correndo", false);
                    if (crono >= 1f)
                    {
                        crono = 0;
                        padrePainel.SetActive(false);
                        sceneStep = 3;
                    }
                }
            }else if (sceneStep == 3)
            {
                meninoConversa.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null && hit.transform.gameObject == meninoConversa.gameObject)
                    {
                        falaMeninoStep++;

                    }
                }
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit.collider != null && hit.transform.gameObject == meninoConversa.gameObject)
                    {
                        falaMeninoStep++;
                    }
                }
                if (falaMeninoStep >= 2f)
                {
                    sceneStep = 4;
                }
                meninoConversa.GetComponent<Animator>().SetInteger("falaMeninoStep", falaMeninoStep);
            }
            else if(sceneStep==4)
            {
                meninoConversa.SetActive(false);
                padrePainel.SetActive(true);
                crono += Time.deltaTime;
                if (crono >= 0.5f)
                {
                    parede1.SetActive(true);
                    parede2.SetActive(true);
                    pablo.SetActive(false);
                    pablosegurando.SetActive(true);
                    homemAzul.SetActive(false);
                    parallaxWall.SetActive(false);
                    blackScreen.SetActive(false);
                    cameraGO.GetComponent<Camera>().orthographicSize = 5f;
                    cameraGO.transform.position = new Vector3(9.87f, 0f, cameraGO.transform.position.z);
                    btnDir.SetActive(false);
                    btnEsq.SetActive(false);
                    andaime.SetActive(true);
                    
                    menino.transform.position = new Vector3(10.061f, -1.401f, 0f);
                }
                if (crono >= 1f)
                {
                    tutorialAnd.SetActive(true);
                    sceneStep = 5;

                }
            }else if (sceneStep == 5)
            {
                tutorialAnd.GetComponent<Animator>().SetInteger("tutStep", tutorialStep);
                if (tutorialStep >= 2f)
                {
                    tutorialAnd.SetActive(false);
                    sceneStep = 6;
                    borda1.SetActive(true);
                }
            }else if (sceneStep == 6)
            {
                btnAndaimeDir.SetActive(true);
                btnAndaimeEsq.SetActive(true);
                if (andaimeDirec == 1)
                {
                    andaime.GetComponent<Rigidbody2D>().velocity = new Vector2(andaimeVel, 0f);
                    
                }
                else if (andaimeDirec == -1)
                {
                    andaime.GetComponent<Rigidbody2D>().velocity = new Vector2(-andaimeVel, 0f);

                }
                else
                {
                    andaime.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0f);

                }
                menino.GetComponent<Animator>().SetBool("batendo", true);

                cairPedras();
                cronoMinigame += Time.deltaTime;
                if (cronoMinigame >= 15f)
                {
                    minigameStep++;
                    cronoMinigame = 0;
                    moveuMenino = false;
                }
                if (minigameStep == 0f)
                {
                    menino.transform.position = new Vector3(andaime.transform.position.x - 0.0649f, -1.401f, 0f);
                    borda1.transform.position = new Vector3(andaime.transform.position.x, -2.230738f, 0f);
                }

                if (minigameStep == 1)
                {
                    borda2.transform.position = new Vector3(andaime.transform.position.x, -2.230738f, 0f);
                    borda1.SetActive(false);
                    borda2.SetActive(true);
                    borda3.SetActive(false);
                    andaime.GetComponent<Animator>().SetInteger("andStep", 1);
                    menino.transform.position = new Vector3(andaime.transform.position.x-0.0649f, -0.065f, 0f);                   
                    
                }
                else if (minigameStep == 2)
                {
                    borda3.transform.position = new Vector3(andaime.transform.position.x, -2.230738f, 0f);
                    borda1.SetActive(false);
                    borda2.SetActive(false);
                    borda3.SetActive(true);
                    andaime.GetComponent<Animator>().SetInteger("andStep", 2);
                    menino.transform.position = new Vector3(andaime.transform.position.x - 0.0649f, 1.301f, 0f);
                    

                }
                else if (minigameStep == 3)
                {
                    andaime.GetComponent<Animator>().SetInteger("andStep", 3);
                    padrePainel.SetActive(false);
                    sceneStep = 7;
                    crono = 0f;
                    menino.transform.position = new Vector3(andaime.transform.position.x - 0.0649f, 2.63f, 0f);
                    menino.GetComponent<Animator>().SetBool("batendo", false);

                    andaimeDirec = 0;
                }
            }
            if (sceneStep == 7)
            {
                crono += Time.deltaTime;
                if (crono >= 0.5f)
                {
                    padrePainel.SetActive(true);
                    if (crono >= 1f)
                    {
                        menino.GetComponent<Animator>().SetBool("batendo", true);
                        cameraGO.transform.position = new Vector3(10.86f, 2.48f, cameraGO.transform.position.z);
                        cameraGO.GetComponent<Camera>().orthographicSize = 1.58f;
                        andaime.transform.position = new Vector3(10.87f, 0.838f, andaime.transform.position.z);
                        menino.transform.position = new Vector3(10.92f, menino.transform.position.y, menino.transform.position.z);
                        menino.GetComponent<SpriteRenderer>().flipX = true;
                        if (crono >= 3.5f)
                        {
                            padrePainel.SetActive(false);
                            crono = 0f;
                            sceneStep = 8;
                        }

                    }
                }
                andaime.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            }
            if (sceneStep == 8)
            {
                crono += Time.deltaTime;
                padrePainel.SetActive(true);
                if (crono >= 0.5f)
                {
                    pablosegurando.SetActive(false);
                    pablo.SetActive(true);
                    homemAzul.SetActive(true);
                    padre.SetActive(true);
                    cameraGO.transform.position = new Vector3(13.66f, -2.1f, cameraGO.transform.position.z);
                    cameraGO.GetComponent<Camera>().orthographicSize = 2.267745f;
                    menino.transform.position = new Vector3(11.73f, -2.726f, 0f);
                    menino.GetComponent<Animator>().SetBool("batendo", false);
                    pablo.transform.position = new Vector3(13.1f, -2.748f, 0f);
                    pablo.GetComponent<SpriteRenderer>().flipX = true;
                    pablo.GetComponent<Animator>().SetBool("correndo", false);
                    homemAzul.transform.position = new Vector3(14.216f, -2.722f, 0f);
                    homemAzul.GetComponent<SpriteRenderer>().flipX = true;
                    padre.transform.position = new Vector3(15.39f, -2.819f, 0f);
                    if (crono >= 1f)
                    {
                        falaFinal.SetActive(true);
                        crono = 0f;
                        sceneStep = 9;
                    }
                }
            }
            if (sceneStep == 9)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null && hit.transform.gameObject == falaFinal.gameObject)
                    {
                        falaFinalStep++;

                    }
                }
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit.collider != null && hit.transform.gameObject == falaFinal.gameObject)
                    {
                        falaFinalStep++;

                    }
                }

                falaFinal.GetComponent<Animator>().SetInteger("falaStep", falaFinalStep);
                if (falaFinalStep >= 3)
                {
                    sceneStep = 10;
                    falaFinal.SetActive(false);
                    padrePainel.SetActive(false);
                }
            }
            if (sceneStep == 10)
            {
                crono += Time.deltaTime;
                if (crono >= 1f)
                {
                    padrePainel.SetActive(true);
                    if (crono >= 1.5f)
                    {
                        cameraGO.transform.position = new Vector3(22.81f, 2.92f, cameraGO.transform.position.z);
                        cameraGO.GetComponent<Camera>().orthographicSize = 0.6990842f;
                        if (crono >= 2.5f)
                        {
                            coroa.SetActive(true);
                            if (crono >= 4f)
                            {
                                lightFinal.SetActive(true);
                                if (crono >= 4.8f)
                                {
                                    panelFinal.SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }       
    }
    void wallMovement()
    {
        if(pablo.transform.position.x >= -4.309999f && pablo.transform.position.x <= 17.33003f && pabloGotWalk2.gotic2Liberado == true)
        {
            cameraGO.transform.position = new Vector3(pablo.transform.position.x, 0, cameraGO.transform.position.z);
            if (pabloGotWalk2.direcParallax == 1 && pabloGotWalk2.gotic2Liberado == true)
            {
                parallaxWall.GetComponent<Rigidbody2D>().velocity = new Vector2(-parallaxSpeed, 0);
            }else if(pabloGotWalk2.direcParallax == -1 && pabloGotWalk2.gotic2Liberado == true  )
            {
                parallaxWall.GetComponent<Rigidbody2D>().velocity = new Vector2(parallaxSpeed, 0);
            }
            else
            {
                parallaxWall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        else
        {
            parallaxWall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }        
    }

    void falaHomemAzul()
    {
        if (Input.GetMouseButtonDown(0) && apertouHomemAzul == false && PlayerPrefs.GetInt("gotica") == 2)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject == homemAzul.gameObject)
            {
                crono = 0;
                apertouHomemAzul = true;
                pabloGotWalk2.gotic2Liberado = false;

            }
        }
        if (Input.touchCount > 0 && apertouHomemAzul == false && PlayerPrefs.GetInt("gotica") == 2)
        {
            Touch touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject == homemAzul.gameObject)
            {
                crono = 0;
                apertouHomemAzul = true;
                pabloGotWalk2.gotic2Liberado = false;
            }
        }
        if(apertouHomemAzul==true && PlayerPrefs.GetInt("gotica") == 2)
        {
            if (stepHomemAzul == 0){
                crono += Time.deltaTime;
                padrePainel.SetActive(true);
                if (crono >= 0.5f)
                {
                    parallaxWall.transform.position = new Vector3(-45.48989f, 0.08f, -118.7656f);
                    cameraGO.GetComponent<Camera>().orthographicSize = 1.659771f;
                    cameraGO.transform.position = new Vector3(16.66f, -2.487f, cameraGO.transform.position.z);
                    pablo.GetComponent<SpriteRenderer>().flipX = true;
                    pablo.transform.position = new Vector3(17.02f, -2.748f, pablo.transform.position.z);
                    pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    pablo.GetComponent<Animator>().SetBool("correndo", false);

                    stepHomemAzul = 1;
                    crono = 0;
                }
            }
            if (stepHomemAzul == 1)
            {
                crono += Time.deltaTime;
                if (crono >= 0.5f)
                {
                    homemAzulConversa.SetActive(true);
                    stepHomemAzul = 2;
                    crono = 0;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.transform.gameObject == homemAzulConversa.gameObject)
                {
                    falaHomemStep++;

                }
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null && hit.transform.gameObject == homemAzulConversa.gameObject)
                {
                    falaHomemStep++;
                }
            }
            homemAzulConversa.GetComponent<Animator>().SetInteger("homemCStep", falaHomemStep);
            if (falaHomemStep >= 2)
            {
                crono += Time.deltaTime;
                painelPadre2.SetActive(true);
                if (crono >= 0.5f)
                {
                    SceneManager.LoadScene("gotica4");
                }

            }
        }
    }

    void falaPadre()
    {
        if (Input.GetMouseButtonDown(0) && apertouPadre == false && PlayerPrefs.GetInt("gotica")==1)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject == padre.gameObject)
            {
                apertouPadre = true;
                pabloGotWalk2.gotic2Liberado = false;

            }
        }
        if (Input.touchCount > 0 && apertouPadre==false && PlayerPrefs.GetInt("gotica") == 1)
        {
            Touch touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject == padre.gameObject)
            {
                apertouPadre = true;
                pabloGotWalk2.gotic2Liberado = false;
            }
        }
        if (apertouPadre == true && PlayerPrefs.GetInt("gotica") == 1)
        {
            if (stepPadre == 0)
            {
                crono += Time.deltaTime;
                padrePainel.SetActive(true);
                if (crono >= 0.5f)
                {
                    cameraGO.transform.position = new Vector3(22.82f, -2.2f, cameraGO.transform.position.z);
                    pablo.GetComponent<SpriteRenderer>().flipX = false;
                    pablo.transform.position = new Vector3(22.786f, -2.748f, pablo.transform.position.z);
                    cameraGO.GetComponent<Camera>().orthographicSize = 1.659771f;
                    stepPadre = 1;
                    crono = 0;
                }                
            }
            if (stepPadre == 1)
            {
                crono += Time.deltaTime;
                if (crono >= 0.5f)
                {
                    padreConversa.SetActive(true);
                    stepPadre = 2;
                    crono = 0;
                }
            }            
            if (Input.GetMouseButtonDown(0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.transform.gameObject == padreConversa.gameObject)
                {
                    falaPadreStep++;                   

                }
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null && hit.transform.gameObject == padreConversa.gameObject)
                {
                    falaPadreStep++;
                }
            }
            padreConversa.GetComponent<Animator>().SetInteger("padreCStep", falaPadreStep);
            if (falaPadreStep >= 3)
            {
                crono += Time.deltaTime;
                painelPadre2.SetActive(true);
                if (crono >= 0.5f)
                {
                    SceneManager.LoadScene("gotica3");
                }
                
            }

        }


    }
    void questPosition()
    {
        if (PlayerPrefs.GetInt("gotica") == 1)
        {
            questMark.transform.position = new Vector3(23.86f, -1.53f, 0f);
        }else if(PlayerPrefs.GetInt("gotica") == 2)
        {
            questMark.transform.position = new Vector3(16.23f, -1.53f, 0f);
        }
        else if (PlayerPrefs.GetInt("gotica") == 3)
        {
            questMark.transform.position = new Vector3(16.23f, 5.71f, 0f);
        }

        
    }

    void cairPedras()
    {
            cronoPedra += Time.deltaTime;
            if (cronoPedra >= intervalPedra)
            {
                spawnarPedra();
                cronoPedra = 0;
            }
        
        if (bateuPedra == true)
        {
            painelDeath.SetActive(true);
            txt1Death.SetActive(true);
            txt2Death.SetActive(true);
            btnDeath.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void tryAgain()
    {
        SceneManager.LoadScene("gotica2");
        Time.timeScale = 1f;
    }

    void spawnarPedra()
    {
        GameObject pedrada = Instantiate(pedra) as GameObject;
        pedrada.transform.position = new Vector3(Random.Range(2.83f, 17.48f), 5.56f, 0);
        pedrada.SetActive(true);
    }

    public void tutorialAndaime()
    {
        tutorialStep++;

    }

    public void andaimeEsq()
    {
        andaimeDirec = -1;
    }
    public void andaimeDir()
    {
        andaimeDirec = 1;
    }
    public void andaimeParar()
    {
        andaimeDirec = 0;
    }

}
