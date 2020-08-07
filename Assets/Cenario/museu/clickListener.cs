using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickListener : MonoBehaviour
{
    
    public RaycastHit2D hit;
    public Transform pabloPos;

    //Para escada------
    public bool foi = false;
    public bool es = true;
    public float crono;
    public bool sobe = false;
    public bool paraSubir = false;
    public bool anda = false;

    public bool foi2 = false;
    public bool es2 = true;
    public float crono2;
    public bool sobe2 = false;
    public bool paraSubir2 = false;
    public bool anda2 = false;

    public int checker = 0;
    public bool forChecker = false;
    //----------------

    //Para entrar na sala
    public bool entrar;
    //--------------------



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        
        //Tocou em que gameObject
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.tag == "btnSubir")
            {
                foi = true;
            }
            if(hit.collider != null && hit.transform.gameObject.tag == "btnDescer")
            {
                foi2 = true;
            }
            if (hit.collider != null && hit.transform.gameObject.tag == "btnEntrar")
            {
                entrar = true;
            }
            if (hit.collider != null && hit.transform.gameObject.tag == "btnComer")
            {
                lanchonete.comerDown = true;
                lanchonete.dinheiro = 1;              
            }
            if (hit.collider != null && hit.transform.gameObject.tag == "falaVei")
            {
                GameObject.Destroy(GameObject.FindGameObjectWithTag("falaVei"));
                faladoVei.falar = true;
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.tag == "btnSubir")
            {
                foi = true;
            }
            if (hit.collider != null && hit.transform.gameObject.tag == "btnDescer")
            {
                foi2 = true;
            }
            if (hit.collider != null && hit.transform.gameObject.tag == "btnEntrar")
            {
                entrar = true;
            }
            if (hit.collider != null && hit.transform.gameObject.tag == "btnComer")
            {
                lanchonete.comerDown = true;
                lanchonete.dinheiro = 1;
            }
            if (hit.collider != null && hit.transform.gameObject.tag == "falaVei")
            {
                GameObject.Destroy(GameObject.FindGameObjectWithTag("falaVei"));
                faladoVei.falar = true;
            }

        }
        //----------------------------------
        //Se apertar no botão pra subir e descer a escada
        if(foi == true)
        {
            pablo.liberado = false;
            pablo.poderMover = false;
            Rigidbody2D rb = GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>();
            //Se estiver na direita da escada
            if(pabloPos.position.x< -0.855f && paraSubir == false && (checker == 0 || checker == 1))
            {
                es = false;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = false;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", true);
                pabloPos.Translate(new Vector2(0.21f, 0) * Time.deltaTime);
                checker = 1;
                crono = 0;
            }
            if(es == false && pabloPos.position.x >= -0.855f)
            {
                GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = false;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", false);
                pabloPos.Translate(new Vector2(0, 0));                             
                
                crono += Time.deltaTime;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                if (crono > 0.5f)
                {
                    es = true;
                    sobe = true;

                }
            }
            if (pabloPos.position.x >= -0.855f && paraSubir == false && (checker == 0 || checker == 2))
            {

                GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = true;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", true);
                pabloPos.Translate(new Vector2(-0.21f, 0) * Time.deltaTime);
                es = true;
                checker = 2;
                
            }
            if(es == true && pabloPos.position.x < -0.855f)
            {
                GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = false;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", false);
                pabloPos.Translate(new Vector2(0, 0));
                escada.apertou = true;
                crono += Time.deltaTime;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                if (crono > 0.5f)
                {
                    es = false;
                    sobe = true;


                }
            }
            if(sobe == true)
            {

                
                if(forChecker == false)
                {
                    GameObject[] escada = GameObject.FindGameObjectsWithTag("paAtras");
                    foreach (GameObject esc in escada)
                    {
                        float posx = esc.GetComponent<Transform>().position.x;
                        float posy = esc.GetComponent<Transform>().position.y;
                        float posz = esc.GetComponent<Transform>().position.z;
                        esc.GetComponent<Transform>().position = new Vector3(posx, posy, posz - 0.03f);
                        forChecker = true;
                    }
                }
                
                GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = false;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", true);
                if(checker == 2)
                {
                    pabloPos.Translate(new Vector2(0.75f, 0.46f) * Time.deltaTime);
                }
                else
                {
                    pabloPos.Translate(new Vector2(0.535f, 0.46f) * Time.deltaTime);
                }
                
                if (pabloPos.position.x >= -0.00785f && pabloPos.position.y >= -0.2f)
                {
                    sobe = false;
                    paraSubir = true;
                }
            }
            if(paraSubir == true)
            {
                
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                pabloPos.Translate(new Vector2(0.3f, 0) * Time.deltaTime);
                if (pabloPos.position.x >= 0.128f)
                {
                    GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", false);
                    pabloPos.Translate(new Vector2(0, 0));
                    escada.apertou = false;
                    pablo.liberado = true;
                    pablo.poderMover = true;
                    foi = false;
                    pablo.cima = true;
                    paraSubir = false;
                    checker = 0;
                    crono = 0;
                    forChecker = false;
                }
                
                
                
                
            }
            
        }

        if(foi2 == true)
        {            
            pablo.liberado = false;
            pablo.poderMover = false;
            Rigidbody2D rb = GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>();
            if(paraSubir2 == false){
                GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = true;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", true);
                pabloPos.Translate(new Vector2(-0.21f, 0) * Time.deltaTime);
                es2 = true;
            }
            if(es2 == true && pabloPos.position.x <= -0.0145f)
            {                
                escada.apertou = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                pabloPos.Translate(new Vector2(-0.65f, -0.75f) * Time.deltaTime);
                if(pabloPos.position.y <= -0.924f)
                {
                    paraSubir2 = true;
                    es2 = false;
                }                
            }
            if (paraSubir2 == true)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                pabloPos.Translate(new Vector2(-0.3f, 0) * Time.deltaTime);
                if (pabloPos.position.x <= -0.872f)
                {
                    GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", false);
                    pabloPos.Translate(new Vector2(0, 0));
                    escada.apertou = false;
                    pablo.liberado = true;
                    pablo.poderMover = true;
                    foi2 = false;
                    pablo.cima = false;
                    paraSubir2 = false;
                    GameObject[] escada2 = GameObject.FindGameObjectsWithTag("paAtras");
                    foreach (GameObject esc2 in escada2)
                    {
                        float posx2 = esc2.GetComponent<Transform>().position.x;
                        float posy2 = esc2.GetComponent<Transform>().position.y;
                        float posz2 = esc2.GetComponent<Transform>().position.z;
                        esc2.GetComponent<Transform>().position = new Vector3(posx2, posy2, posz2 + 0.03f);                        
                    }
                }
            }

        }
        //---------------------------------------

        //Entrar na sala
        if (entrar == true)
        {
            pablo.liberado = false;
            pablo.poderMover = false;
            CameraFollowing.cameraType = 4;
            entrar = false;
        }
        //---------------------
    }
    
}

