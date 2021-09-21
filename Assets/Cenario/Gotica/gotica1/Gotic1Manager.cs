using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gotic1Manager : MonoBehaviour
{
    public GameObject cameraGotic, pablo, chuva1, chuva2;
    public int sceneStep = 0;
    public float crono = 0;

    public float velPablo;

    public float velocidadeCamera, velCameraY;

    public float cameraSizeAce;

    public GameObject raio1, raio2, telaFinal;

    public ParticleSystem ps;

    public GameObject notredameText, depoisTempTxt;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        startCamera();
    }

    void startCamera()
    {
        if (sceneStep == 0)
        {
            crono += Time.deltaTime;
            if (crono >= 2.5f)
            {
                crono = 0;
                sceneStep=1;
            }
        }
        if (sceneStep == 1)
        {
            cameraGotic.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocidadeCamera);
            if(cameraGotic.transform.position.y<= 2.03f)
            {
                chuva2.SetActive(true);           
                sceneStep = 2;
            }
        }
        if (sceneStep == 2)
        {
            if (cameraGotic.transform.position.y <= 0.14f)
            {
                chuva1.SetActive(false);
                sceneStep = 3;
            }
        }
        if (sceneStep == 3)
        {
            if (cameraGotic.transform.position.y <= -2.81f)
            {
                cameraGotic.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                sceneStep = 4;
            }
        }
        if (sceneStep == 4)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
            pablo.GetComponent<SpriteRenderer>().flipX = false;
            pablo.GetComponent<Animator>().SetBool("correndo", true);
            if(pablo.transform.position.x >= -7.02f)
            {
                sceneStep = 5;
            }
        }
        if (sceneStep == 5)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
            pablo.GetComponent<SpriteRenderer>().flipX = false;
            pablo.GetComponent<Animator>().SetBool("correndo", true);
            cameraGotic.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
            if(pablo.transform.position.x >= 0.99f)
            {
                sceneStep = 6;
            }
        }
        if (sceneStep == 6)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pablo.GetComponent<Animator>().SetBool("correndo", false);
            cameraGotic.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            sceneStep = 7;
        }
        if (sceneStep == 7)
        {

            int ok = 0;
            bool sizeOk = false;
            bool yOk = false;
            if (cameraGotic.GetComponent<Camera>().orthographicSize<= 4.512677f)
            {
                cameraGotic.GetComponent<Camera>().orthographicSize += cameraSizeAce;
                
            }
            else
            {
                if (sizeOk == false)
                {
                    ok++;
                    sizeOk = true;
                }

            }
            if(cameraGotic.transform.position.y <= 0.26){
                cameraGotic.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velCameraY);
                
            }
            else
            {
                cameraGotic.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                if (yOk == false)
                {
                    ok++;
                    yOk = true;
                }
            }
            if (ok == 2)
            {
                raio1.SetActive(true);
                crono += Time.deltaTime;
                if (crono >= 0.6f)
                {
                    notredameText.SetActive(true);                    
                    sceneStep = 8;
                    crono = 0;
                }
            }
        }
        if (sceneStep == 8)
        {
            crono += Time.deltaTime;
            if (crono >= 4)
            {
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                pablo.GetComponent<Animator>().SetBool("correndo", true);
                if(pablo.transform.position.x>= 8.47f)
                {
                    sceneStep = 9;
                    crono = 0;
                }
            }
        }
        if (sceneStep == 9)
        {
            raio2.SetActive(true);
            telaFinal.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 2.5f)
            {
                depoisTempTxt.SetActive(true);
                if (crono >= 7.2f)
                {
                    PlayerPrefs.SetInt("gotica", 1);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("gotica2");
                }
            }
        }
    }
}
