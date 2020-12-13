using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pablo : MonoBehaviour
{
    public Transform targetPablo;
    public float teste;
    public static bool poderMover = true;
    public float cron = 0;
    public static bool liberado = false;
    public static bool cima = false;
    public static bool teste2 = false;
    public static int places = 0;
    public bool tentando = false;
    public static bool fominha = false;
    public static int fomeStep = 0;
    public static bool ajudapfv = false;
    public static bool cancelalogo = false;
    public static bool direitp = true;
    public GameObject pabloPessoa;
    public float velocidade;
    public float cronoh = 0;
    public bool foraLimiteEs = false;
    public bool foraLimiteDi = false;

    public bool setaParou = false;
    public GameObject setaCanvas;



    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;

    }

    // Update is called once per frame
    void Update()
    {
        AparecerSeta();
        teste = targetPablo.position.x;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float movimento = Input.GetAxis("Horizontal");
        //Anda no andar de baixo
        if (cima == false && places == 0) {
            
            //Anda normal
            if (targetPablo.position.x >= -3.41f && poderMover == true && targetPablo.position.x <= 2.72f && liberado == true)
            {
                rb.velocity = new Vector2(PabloController.playerTurnAxisTouch, 0);
            }


            //Volta na esquerda   
            if (targetPablo.position.x > -4f && targetPablo.position.x < 1f && liberado == true)
            {
                             
                if (targetPablo.position.x >= -3.41f && poderMover == true)
                {

                }
                else
                {
                    poderMover = false;
                    rb.velocity = new Vector2(0.3f, 0);
                    SpriteRenderer sr1 = GetComponent<SpriteRenderer>();
                    GetComponent<Animator>().SetBool("andando", true);
                    PabloController.x = 0;
                    sr1.flipX = false;
                    GetComponent<Animator>().SetBool("andando", true);

                    cron += Time.deltaTime;
                    if (cron > 1)
                    {
                        GetComponent<Animator>().SetBool("andando", false);
                        cron = 0;
                    }
                    PabloController.deitou1 = 0;


                }
                
                
            }
            //Volta na direita
            if (targetPablo.position.x > 1f && targetPablo.position.x < 3.5f && liberado == true)
            {
                if (targetPablo.position.x <= 2.72 && poderMover == true)
                {

                }
                else
                {
                    poderMover = false;
                    rb.velocity = new Vector2(-0.3f, 0);
                    SpriteRenderer sr1 = GetComponent<SpriteRenderer>();
                    GetComponent<Animator>().SetBool("andando", true);
                    PabloController.x = 0;
                    sr1.flipX = true;


                    cron += Time.deltaTime;
                    if (cron > 1)
                    {
                        GetComponent<Animator>().SetBool("andando", false);
                        cron = 0;
                    }
                    PabloController.deitou = 0;


                }
            }
            if(targetPablo.position.x >= 5.39f && poderMover == true && liberado ==true)
            {
                rb.velocity = new Vector2(PabloController.playerTurnAxisTouch, 0);

            }
            if(targetPablo.position.x >= 8.25f)
            {
                direitp = false;
                PabloController.deitou = 0;
                if (PabloController.playerTurnAxisTouch > 0)
                {
                    rb.velocity = new Vector2(0, 0);
                }
                

            }else
            {
                direitp = true;
            }

        }        
        //Anda na sala
        if(places == 1)
        {
            if (targetPablo.position.x >= -3.115f && poderMover == true && targetPablo.position.x <= -1.125f && liberado == true)
            {
                rb.velocity = new Vector2(PabloController.playerTurnAxisTouch, 0);
            }
            if(targetPablo.position.x>= -1.239f && tentando == false)
            {
                rb.velocity = new Vector2(0, 0);
                
            }
            if (PabloController.playerTurnAxisTouch < 0 && targetPablo.position.x >= -1.239f)
            {
                tentando = true;
                rb.velocity = new Vector2(PabloController.playerTurnAxisTouch, 0);
            }
            if (targetPablo.position.x < -1.239f)
            {
                tentando = false;
            }
            if(targetPablo.position.x <= -3.098f)
            {
                if (fominha == true)
                {
                    targetPablo.position = new Vector2(1.014f, -0.924f);
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(1.016193f, -0.8539994f, -10.63f);
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 0.4311894f;
                    CameraFollowing.ir = true;
                    places = 0;
                    GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

                }
                if (fominha == false && fomeStep == 0 && cancelalogo == false)
                {
                    poderMover = false;
                    liberado = false;
                    PabloController.deitou1 = 0;
                    rb.velocity = new Vector2(0, 0);
                    targetPablo.position = new Vector2(1.014f, -0.924f);
                    
                    GetComponent<Animator>().SetBool("andando", false);
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(1.016193f, -0.8539994f, -10.63f);
                    GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
                    CameraFollowing.zum = true;
                    cancelalogo = true;
                                                                                
                }                
            }
            if (ajudapfv == true)
            {
                cronoh += Time.deltaTime;
                if (cronoh >= 8.3f)
                {
                    GetComponent<Animator>().SetBool("fome", false);
                    CameraFollowing.zum2 = true;
                }
            }
        }

        //Libera a animação nos limites do museu
        if (targetPablo.position.x >= -3.36f && targetPablo.position.x <= 2.67f && liberado == true)
        {            
            poderMover = true;
        }
        if(liberado == true)
        {
            pabloAndarOk();
            ChegouLimite();
        }
    }   
    void pabloAndarOk()
    {
        if(PabloController.posicao == 1 && foraLimiteDi == false)
        {
            pabloPessoa.GetComponent<Animator>().SetBool("andando", true);
            pabloPessoa.GetComponent<SpriteRenderer>().flipX = false;
            pabloPessoa.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidade, 0);            
        }
        if (PabloController.posicao == -1 && foraLimiteEs== false)
        {
            pabloPessoa.GetComponent<Animator>().SetBool("andando", true);
            pabloPessoa.GetComponent<SpriteRenderer>().flipX = true;
            pabloPessoa.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidade, 0);
        }
        if (PabloController.posicao == 0)
        {
            pabloPessoa.GetComponent<Animator>().SetBool("andando", false);
            pabloPessoa.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

    }
    void ChegouLimite()
    {
        if (pabloPessoa.transform.position.x <= -3.257f && foraLimiteEs == false && places == 0)
        {
            foraLimiteEs = true;
            PabloController.posicao = 0;
        }
        if(pabloPessoa.transform.position.x >= 2.765f && fominha == false && foraLimiteDi == false && places == 0)
        {
            foraLimiteDi = true;
            PabloController.posicao = 0;
        }
        if (foraLimiteDi == true && pabloPessoa.transform.position.x <= 2.741f && places == 0)
        {
            foraLimiteDi = false;
        }                       
        if(foraLimiteEs == true && pabloPessoa.transform.position.x >= -3.232f && places ==0)
        {
            foraLimiteEs = false;
        }
        if(places == 1 && foraLimiteDi == false && pabloPessoa.transform.position.x >= 0.076f)
        {
            foraLimiteDi = true;
            PabloController.posicao = 0;

        }
        if (foraLimiteDi == true && pabloPessoa.transform.position.x <= 0.035f && places == 1)
        {
            foraLimiteDi = false;
        }
        if(pabloPessoa.transform.position.x >= 8.24f && foraLimiteDi == false)
        {
            foraLimiteDi = true;
            PabloController.posicao = 0;
        }
        if(pabloPessoa.transform.position.x <= 8.13f && foraLimiteDi == true && pabloPessoa.transform.position.x >= 6.4f)
        {
            foraLimiteDi = false;
        }
    }
    void AparecerSeta()
    {
        if(lanchonete.comerDown == true)
        {
            setaParou = true;
        }
        if(fominha == true && places == 0 && targetPablo.transform.position.x <= 4.124f && setaParou == false)
        {
            setaCanvas.SetActive(true);
        }
        else
        {
            setaCanvas.SetActive(false);
        }
    }
    
}
