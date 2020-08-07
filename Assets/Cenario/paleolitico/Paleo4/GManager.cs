using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    public Camera cam;
    public GameObject caveman;
    public GameObject fala;

    public float crono1 = 0;
    public int sceneStep = 0;
    public float crono2 = 0;
    public int falaStep = 1;
    public GameObject livroBtn;

    public GameObject seta;
    // Start is called before the first frame update
    void Start()
    {
        seta.SetActive(false);
        livroBtn.SetActive(false);
        if (PlayerPrefs.GetInt("PaleoLivroStep") < 2)
        {
            PlayerPrefs.SetInt("PaleoLivroStep", 2);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        pintura();
        cameraIr();
    }
    void pintura()
    {
        if(sceneStep == 0)
        {
            crono1 += Time.deltaTime;
            if(crono1 >= 2.5f)
            {
                
                cam.orthographicSize += Time.deltaTime;
                if(cam.orthographicSize >= 5)
                {
                    sceneStep = 2;
                    livroBtn.SetActive(true);
                    fala.SetActive(true);
                    seta.SetActive(true);
                }
            }
        }
    }    
    
    void cameraIr()
    {
        if(sceneStep == 3)
        {
            crono2 += Time.deltaTime;
            if(crono2 >= 1f)
            {
                if(cam.transform.position.x <= 4.79f)
                {
                    cam.transform.Translate(new Vector2(2, 0) * Time.deltaTime);

                }
                else
                {
                    crono2 = 0;
                    sceneStep = 4;
                }             
            }
        }
        if(sceneStep == 4)
        {            
            crono2 += Time.deltaTime;
            if(crono2 >= 3f)
            {
                if(cam.transform.position.x >= 0f)
                {
                    cam.transform.Translate(new Vector2(-2, 0) * Time.deltaTime);
                }
                else
                {
                    sceneStep = 5;
                }
            }
        }
        if(sceneStep == 5)
        {
            if(cam.transform.position.y >= -0.96f)
            {
                cam.transform.Translate(new Vector2(0, -0.6f) * Time.deltaTime);
                cam.orthographicSize -= 2.7f * Time.deltaTime;
                crono2 = 0;
            }
            else
            {
                crono2 += Time.deltaTime;
                if(crono2 >= 2f)
                {
                    cam.orthographicSize -= 2.7f * Time.deltaTime;
                    if(cam.orthographicSize <= 0.0001971183f)
                    {
                        sceneStep = 6;
                        crono2 = 0;
                    }   
                }
            }
        }
        if(sceneStep == 6)
        {
            crono2 += Time.deltaTime;
            if(crono2 >= 1f)
            {
                SceneManager.LoadScene("fazerVenus");
            }
        }
    }
    public void clickouVenus()
    {
        if(sceneStep == 2)
        {
            falaStep++;
            fala.GetComponent<Animator>().SetInteger("falaStep", falaStep);
            if(falaStep == 5)
            {
                fala.SetActive(false);
                sceneStep = 3;
            }
            
        }
        

    }
}
