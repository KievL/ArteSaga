using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paleo3Manager : MonoBehaviour
{
    public GameObject pablo;
    public GameObject caveman1;
    public GameObject caveman2;
    public GameObject buttonFalar;
    public GameObject btnAtirar;
    public GameObject seta;
    public GameObject contador;
    public GameObject palheta;

    public GameObject prefabLanc;
    public GameObject hitMark;

    public static int sceneStep = 0;

    public Vector2 force;
    public static float intense;
    public Transform arrow;
    public float velX;
    public float velY;
    public static float velX1;
    public static float velY1;
    public static bool get = false;
    public static int calcSteps = 0;

    public float test;

    public float clickCoolDown;
    public bool clicked = false;
    public float crono = 0;

    public bool lancaBool = false;
    public float crono2 = 0;
    public float delay;

    public static bool setaParecer = false;

    public static bool ganhou = false;
    public float crono3 = 0;

    public float curTime = 0;
    public GameObject boi;
    public GameObject cameraScene;
    public GameObject finalPainel;
    public GameObject finalPainel2;
    public GameObject circulo;
    public static bool apagar = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        test = intense;
        manWalk();
        mandarAtirar();
        mirar();
        showOrNot();
        lancarHit();
        win();

        if(clicked == true)
        {
            crono += Time.deltaTime;
            if(crono >= clickCoolDown)
            {
                crono = 0;
                clicked = false;
            }
        }
        if(setaParecer == true)
        {
            seta.SetActive(true);
            setaParecer = false;
        }
    }
    void manWalk()
    {
        if(sceneStep == 0)
        {
            pablo.transform.Translate(new Vector2(1.3f, 0) * Time.deltaTime);
            caveman1.transform.Translate(new Vector2(1.3f, 0) * Time.deltaTime);
            caveman2.transform.Translate(new Vector2(1.3f, 0) * Time.deltaTime);
            if(caveman1.transform.position.x >= -4.13f)
            {
                caveman1.GetComponent<Animator>().SetInteger("caveManSteps", 1);
                caveman2.GetComponent<Animator>().SetInteger("caveManSteps", 1);
                pablo.GetComponent<Animator>().SetInteger("animStep", 1);
                sceneStep = 1;
            }
        }
    }
    void mandarAtirar()
    {
        if(sceneStep == 1)
        {
            pablo.GetComponent<Animator>().SetInteger("animStep", 1);
            circulo.SetActive(true);
            buttonFalar.SetActive(true);            
        }
    }
    void mirar()
    {
        if(sceneStep == 2)
        {
            pablo.GetComponent<Animator>().SetInteger("animStep", 2);
            seta.SetActive(true);
            contador.SetActive(true);
            palheta.SetActive(true);
            btnAtirar.SetActive(true);
            sceneStep = 3;
            
        }
    }
    void showOrNot()
    {
        if(calcSteps == 1)
        {
            contador.SetActive(true);
            palheta.SetActive(true);
        }
        else
        {
            contador.SetActive(false);
            palheta.SetActive(false);
        }
    }
    public void btnFalarClick()
    {
        sceneStep = 2;
        buttonFalar.SetActive(false);
        circulo.SetActive(false);
    }
    void lancarHit()
    {
        if(lancaBool == true)
        {
            crono2 += Time.deltaTime;
            if(crono2 >= delay)
            {
                GameObject spear = Instantiate(prefabLanc) as GameObject;
                spear.SetActive(true);
                crono2 = 0;
                lancaBool = false;
            }
            
        }
    }
    public void Calcular()
    {
        if(clicked == false)
        {
            if (calcSteps == 1)
            {
                velX1 = velX * intense;
                velY1 = velY * intense;
                get = true;


                seta.SetActive(false);
                GameObject hitCheck = Instantiate(hitMark) as GameObject;
                hitCheck.SetActive(true);
                lancaBool = true;
                calcSteps = 3;
                clicked = true;

            }
            if (calcSteps == 0)
            {
                velY = Mathf.Abs(Mathf.Sin((arrow.rotation.eulerAngles.z) * Mathf.PI / 180));
                velX = Mathf.Abs(Mathf.Cos((arrow.rotation.eulerAngles.z) * Mathf.PI / 180));
                calcSteps = 1;
            }
            if (calcSteps == 3)
            {
                calcSteps = 0;
            }
        }        
    }
    void win()
    {
        if(ganhou == true)
        {
            boi.GetComponent<SpriteRenderer>().flipX = true;            
        
            crono3 += Time.unscaledDeltaTime;
            if(crono3>= 1f)

            {
                apagar = true;
                cameraScene.GetComponent<Camera>().orthographicSize = 0.9889882f;
                cameraScene.transform.position = new Vector3(4.83f, -2.24f, cameraScene.transform.position.z);
                Time.timeScale = 1;
            }
            if(crono3>= 2.5f)
            {
                finalPainel.SetActive(true);
                finalPainel2.SetActive(true);
            }
            if(crono3 >= 5f)
            {
                PlayerPrefs.SetInt("PaleoStep", 4);
                PlayerPrefs.Save();
                Time.timeScale = 1f;
                SceneManager.LoadScene("Paleo4");
            }            
        }
    }
   
}
