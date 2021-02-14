using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Egito3Manager : MonoBehaviour
{
    public GameObject cam;
    public GameObject pablo;
    public GameObject tutorial;

    public float velCam;
    public float velPablo;

    public static bool podeAndar = false;

    public int sceneStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("EgitoStep", 1);
    }

    // Update is called once per frame
    void Update()
    {
        cenaInicial();
        passou();
    }
    void cenaInicial()
    {
        if (sceneStep == 0)
        {
            if (cam.transform.position.y >= -2.16f)
            {
                cam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velCam);
            }
            else
            {
                cam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                
                
            }
            if(pablo.transform.position.x <= cam.transform.position.x)
            {
                pablo.GetComponent<Animator>().SetBool("correndo", true);
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
            }
            else
            {
                pablo.GetComponent<Animator>().SetBool("correndo", false);
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                podeAndar = true;
                tutorial.SetActive(true);
                sceneStep = 1;
            }
        }
    }
    void passou()
    {
        if (sceneStep == 1)
        {
            if(pablo.transform.position.x >= 10.17f)
            {
                podeAndar = false;
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
                if(pablo.transform.position.x>= 12.7f)
                {
                    SceneManager.LoadScene("Egito4");
                }
            }
        }
    }
}
