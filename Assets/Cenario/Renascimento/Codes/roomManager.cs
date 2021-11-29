using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roomManager : MonoBehaviour
{
    public GameObject cameraRoom;
    public int sceneStep = 0;

    public Vector2 posCamera0;
    public Vector2 pabloPos0;

    public Vector2 posCamera1;
    public Vector2 pabloPos1;

    public GameObject pablo;

    public GameObject fadeIn, fadeOut;

    public float crono = 0f;

    public Vector2 pabloSpeed;

    public RaycastHit2D hit;

    public GameObject knock, door, doorLight, bag, falas;

    public int falaStep = 0, falaEnd, falaMiniGame, falaAftermatch, falaFinish;
    public Vector2 falaNpc, falaPabloPorta, falaPabloMesa;

    public int bagApearNum, bagTradeNum;
    public Vector2 bagPos1, bagPos2, bagMesa;
    public float mesaPosX;

    public float xDoor;

    public GameObject star, panelFinal, txtFinal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        whichStart();
        if (PlayerPrefs.GetInt("renascStep") == 1)
        {
            GetBack();
            Debug.Log("ue??");
        }
        else
        {
            knockDoor();
            wakeUp();
            Conversa();
            AndarMesa();
        }
        nextFala();
    }

    //Quando inicia a fase    
    void whichStart()
    {
        if (sceneStep == 0)
        {
            if (PlayerPrefs.GetInt("renascStep") == 1)
            {
                cameraRoom.transform.position = new Vector3(posCamera1.x, posCamera1.y, cameraRoom.transform.position.z);
                pablo.transform.position = new Vector3(pabloPos1.x, pabloPos1.y, pablo.transform.position.z);
            }
            else
            {
                cameraRoom.transform.position = new Vector3(posCamera0.x, posCamera0.y, cameraRoom.transform.position.z);
                pablo.transform.position = new Vector3(pabloPos0.x, pabloPos0.y, pablo.transform.position.z);
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                sceneStep++;
            }
        }
        if (sceneStep == 1 && PlayerPrefs.GetInt("renascStep") != 1)
        {
            fadeIn.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                fadeIn.SetActive(false);
                sceneStep++;
                crono = 0;
            }
        }
    }
    void wakeUp()
    {
        if (sceneStep == 2)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = -pabloSpeed;
            if (pablo.transform.position.x <= 1.49f)
            {
                cameraRoom.GetComponent<Rigidbody2D>().velocity = new Vector3(-pabloSpeed.x, 0f, 0f);
            }
            if (pablo.transform.position.x <= -14.86f)
            {
                cameraRoom.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                sceneStep++;
            }
            pablo.GetComponent<Animator>().SetBool("andando", true);
        }
        if (sceneStep == 3)
        {
            pablo.GetComponent<SpriteRenderer>().flipX = false;
            pablo.GetComponent<Animator>().SetBool("andando", false);
            crono += Time.deltaTime;
            if (crono >= 2f)
            {
                crono = 0f;
                sceneStep++;
            }
        }
    }
    void knockDoor()
    {
        if (sceneStep == 4)
        {
            knock.SetActive(true);
            //Som
            crono += Time.deltaTime;
            if (crono >= 1.5f)
            {
                sceneStep++;
                crono = 0;

            }
        }
        else if (sceneStep == 5)
        {
            pablo.GetComponent<SpriteRenderer>().flipX = true;
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                pablo.GetComponent<Animator>().SetBool("andando", true);
                pablo.GetComponent<Rigidbody2D>().velocity = -pabloSpeed;
                cameraRoom.GetComponent<Rigidbody2D>().velocity = new Vector3(-pabloSpeed.x, 0f, 0f);
                if (pablo.transform.position.x <= xDoor)
                {
                    pablo.GetComponent<Animator>().SetBool("andando", false);
                    pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    cameraRoom.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    crono = 0;
                    sceneStep++;
                }
            }
        }
        else if (sceneStep == 6)
        {
            crono += Time.deltaTime;
            if (crono >= 0.7f)
            {
                door.GetComponent<Animator>().SetBool("open", true);
                doorLight.SetActive(true);
                sceneStep++;
                crono = 0;
            }
        }
    }
    void Conversa()
    {
        if (sceneStep == 7)
        {
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                falas.SetActive(true);
                crono = 0;
                sceneStep++;
            }
        }
        if (sceneStep == 8)
        {
            falas.GetComponent<Animator>().SetInteger("falaStep", falaStep);
            if(falaStep== 0 || falaStep == 2 || falaStep == 4 || falaStep == 5)
            {
                falas.transform.position = new Vector2(-23.2f, -0.09f);
            }
            else
            {
                if (falaStep < falaEnd)
                {
                    falas.transform.position = new Vector2(-18.5f, -0.09f);
                }                                   
            }
            if (falaStep == bagApearNum)
            {
                bag.SetActive(true);

            }
            if (falaStep == bagTradeNum)
            {
                bag.transform.position = bagPos1;
            }
            if (falaStep == falaEnd)
            {
                sceneStep++;
            }
        }
        if (sceneStep == 9)
        {
            falas.SetActive(false);
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                door.GetComponent<Animator>().SetBool("open", false);
                doorLight.SetActive(false);
                crono = 0;
                sceneStep++;
            }
        }
        else if (sceneStep == 10)
        {
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                bag.transform.position = bagPos2;
                if (crono >= 1.65f)
                {
                    crono = 0;
                    sceneStep++;
                }                
            }
        }
    }
    void AndarMesa()
    {
        if (sceneStep == 11)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = pabloSpeed;
            bag.GetComponent<Rigidbody2D>().velocity = pabloSpeed;
            pablo.GetComponent<Animator>().SetBool("andando", true);
            cameraRoom.GetComponent<Rigidbody2D>().velocity = new Vector3(pabloSpeed.x, 0f, 0f);
            if (pablo.transform.position.x >= mesaPosX)
            {
                sceneStep++;
            }
        }if (sceneStep == 12)
        {
            falas.GetComponent<Animator>().SetInteger("falaStep", falaStep);
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pablo.GetComponent<Animator>().SetBool("andando", false);
            bag.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            cameraRoom.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
            bag.transform.position = bagMesa;
            falas.SetActive(true);
            falas.transform.position = falaPabloMesa;
            if (falaStep >= falaMiniGame)
            {
                sceneStep++;
            }
        }
        if (sceneStep == 13)
        {
            crono += Time.deltaTime;
            falas.SetActive(false);
            fadeOut.SetActive(true);
            if (crono >= 0.5f)
            {
                SceneManager.LoadScene("renasci1");
            }
        }
    }
    void nextFala()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);            
            if (hit.collider != null && hit.transform.gameObject == falas.gameObject)
            {
                falaStep++;
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject == falas.gameObject)
            {
                falaStep++;
            }
        }
        
    }
    //Depois do minigame
    void GetBack()
    {
        if (sceneStep == 0)
        {
            bag.SetActive(true);
            bag.transform.position = bagMesa;
            falaStep= falaAftermatch;
            fadeIn.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                sceneStep=1;
                crono = 0;
                fadeIn.SetActive(false);
            }
        }
        if (sceneStep == 1)
        {
            falas.SetActive(true);
            falas.transform.position = falaPabloMesa;            
            falas.GetComponent<Animator>().SetInteger("falaStep", falaAftermatch);
            if (falaStep >= falaFinish)
            {
                sceneStep++;
            }
        }
        if (sceneStep == 2)
        {
            falas.SetActive(false);
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                star.SetActive(true);
                txtFinal.SetActive(true);
                panelFinal.SetActive(true);
                if (crono >= 7f)
                {
                    //Sair para a sala dos portais
                }
            }
        }        
    }
}