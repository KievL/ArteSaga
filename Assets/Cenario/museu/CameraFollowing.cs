using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector2 test;
    public static bool ir = false;
    public static int cameraType = 0;
    public static bool go = false;
    public float cameraAsc = 0;
    public float sec = 0;
    public bool camDone = false;
    public bool chega;
    public float crono;
    public int changinParts=0;
    public Camera camera1;

    //Câmera dar zoomout
    public bool vecx = false;
    public bool vecy = false;
    public bool ort = false;

    //Fome
    public static bool zum = false;
    public static bool zum2 = false;

    //ComerZoomOut
    public float crono3 = 0;

    //Limpeza
    public float crono4 = 0;
    public float crono5 = 0;
    public float crono6 = 0;
    public float crono7 = 0;

    public GameObject tut2;
    public bool apareceuTut = false;

    

    void LateUpdate()
    {
        if(ir == true)
        {
            Vector3 desiredPosition = target.position + offset;         
            Vector2 hi = target.position;
            if (hi.x > -2.84f && hi.x < 2.17f)
            {
                transform.position = desiredPosition;
            }
        }

        if(go == true)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector2 hi = target.position;
            transform.position = desiredPosition;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(cameraType == 1)
        {
            Camera cam = GetComponent<Camera>();
            sec += Time.deltaTime;
            if (sec > 2.5f && camDone == false)
            {
                cameraAsc += Time.deltaTime;
                cam.orthographicSize += cameraAsc/40;
            }
            if(cam.orthographicSize >= 0.43f)
            {
                camDone = true;                
                offset.y = 0.07f;
                cameraType = 3;
            }
            
        }
        if(cameraType == 3 && chega ==false)
        {
            transform.Translate(new Vector2(0.16f, 0) * Time.deltaTime);
            if(transform.position.x >= -1.45f)
            {
                transform.Translate(new Vector3(0, 0, 0));
                chega = true;
                FalasControler.inicio = true;
                if(apareceuTut == false)
                {
                    tut2.SetActive(true);
                    apareceuTut = true;
                }
                
            }
        }
        if(cameraType == 2)
        {                      
            transform.Translate(new Vector3(0, 0.16f) * Time.deltaTime);                       
        }
        if(cameraType==2 && transform.position.y >= -0.799899f)
        {
            transform.Translate(new Vector3(0,0,0));
            cameraType = 1;
        }

        //Zoom para entrar na sala
        if (cameraType == 4)
        {
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", false);           
            
            //Mudar de lugar
            if(changinParts == 0)
            {
                float posz = transform.position.z;
                transform.position = new Vector3(-2.306632f, 3.25f, posz);
                camera1.orthographicSize = 0.4f;
                GameObject.FindGameObjectWithTag("pablo").transform.position = new Vector2(-2.9329f, 3.1458f);
                changinParts = 3;                
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            //Arrumar a câmera
            if(changinParts == 3)
            {                
                if(ort== false)
                {                    
                        pablo.places = 1;
                        pablo.poderMover = true;
                        pablo.liberado = true;
                        cameraType = 24;
                        changinParts = 0;                                            
                }

            }
        }
        if(zum == true)
        {
            Camera cam = GetComponent<Camera>();
            cam.orthographicSize -= Time.deltaTime/10;
            if (cam.orthographicSize <= 0.3022456f)
            {
                Debug.Log("por aqui ta indo");
                pablo.ajudapfv = true;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("fome", true);
                
                zum = false;
            }
        }
        if(zum2 == true)
        {
            pablo.fomeStep = 2;
            Camera cam = GetComponent<Camera>();
            cam.orthographicSize += Time.deltaTime/20;
            if (cam.orthographicSize >= 0.4311894f)
            {

                pablo.fominha = true;
                pablo.poderMover = true;
                pablo.liberado = true;
                CameraFollowing.ir = true;
                pablo.places = 0;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                pablo.ajudapfv = false;
                zum2 = false;
            }
        }
        if(cameraType == 5)
        {
            
            Camera cam = GetComponent<Camera>();
            if(cam.orthographicSize>= 0.2751461f)
            {
                cam.orthographicSize -= Time.deltaTime / 6;                
            }
            else
            {
                crono3 += Time.deltaTime;
                if (crono3 >= 6)
                {
                    cameraType = 6;
                }
            }

            if(this.transform.position.x<= 7.494)
            {
                this.transform.Translate(new Vector2(0.3f, 0) * Time.deltaTime);                                  
            }
               
        }  
        if(cameraType == 6)
        {
            this.transform.Translate(new Vector2(0.3f, 0) * Time.deltaTime);
            if(this.transform.position.x >= 7.708f)
            {
                GameObject.FindGameObjectWithTag("velho").GetComponent<Transform>().position = new Vector2(8.0518f, -0.673f);
                GameObject.FindGameObjectWithTag("falaVei").GetComponent<Animator>().SetInteger("falaStep", 1);
                GameObject.FindGameObjectWithTag("falaVei").GetComponent<Transform>().position = new Vector2(7.97f, -0.754f);
                soundMuseum.tocarLiberado = false;
                cameraType = 30;
            }
        } 
        if(cameraType == 7)
        {            
            this.transform.position = new Vector3(-0.136708f, -0.8539994f, -10.63f);
            Camera cam = GetComponent<Camera>();
            cam.orthographicSize = 0.4337385f;
            crono4 += Time.deltaTime;
            if(crono4>= 2.5f)
            {
                cameraType = 8;
            }

        }
        if(cameraType == 8)
        {
            this.transform.position = new Vector3(-0.126f, -1.07f, -10.63f);
            Camera cam = GetComponent<Camera>();
            cam.orthographicSize = 0.13656f;
            crono5 += Time.deltaTime;
            if(crono5 >= 4)
            {
                GameObject.FindGameObjectWithTag("limpeza").GetComponent<Animator>().SetInteger("esfregar", 1);
                crono6 += Time.deltaTime;
                if(crono6 >= 0.6f)
                {
                    GameObject.FindGameObjectWithTag("balde2").GetComponent<Transform>().position = new Vector2(-0.037f, -0.849f);
                    GameObject.FindGameObjectWithTag("limpeza").GetComponent<Animator>().SetInteger("esfregar", 2);
                    GameObject.FindGameObjectWithTag("limpeza").GetComponent<Transform>().Translate(new Vector2(-0.4f, 0) * Time.deltaTime);
                    faladoVei.runStep = 3;
                    crono7 += Time.deltaTime;
                    if(crono7 >= 2)
                    {
                        cameraType = 9;
                    }                    
                }
            }
        }
        if(cameraType == 9)
        {
            this.transform.position = new Vector3(1.787f, -0.867f, -10.63f);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 0.4406323f;
            GameObject.Destroy(GameObject.FindGameObjectWithTag("limpeza"));
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().transform.position = new Vector2(2.65f, -0.924f);
            ir = true;
            go = true;
            faladoVei.runStep = 4;
            cameraType = 10;
            
        }
        CameraIrCima();
        
    }
    void CameraIrCima()
    {
        if (pablo.places == 1 && (target.position.x <= -2.31f || target.position.x >= -0.6f)){
            ir = false;
            go = false;
        }
        if (pablo.places == 1 && (target.position.x > -2.31f && target.position.x < -0.6f)){
            ir = true;
            go = true;
        }
    }
}
