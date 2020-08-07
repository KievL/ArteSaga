using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paleo2Manager : MonoBehaviour
{
    public GameObject pablo;
    public GameObject caveman1;
    public GameObject caveman2;
    public GameObject fala;
    public int managerSteps = 0;
    public float crono = 0;

    // Start is called before the first frame update
    void Start()
    {
        fala.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CorrerDireita();
        Parar();
        HomensIr();
        HomensPara();
        AparacerFala();
        sairCacar();
    }
    void CorrerDireita()
    {
        if (managerSteps == 0)
        {                        
            pablo.GetComponent<Transform>().transform.Translate(new Vector2(3f, 0) * Time.deltaTime);                 
            if (pablo.GetComponent<Transform>().position.x >= -4.4f)
            {
                managerSteps = 1;
            }
        }
        
    }
    void Parar()
    {
        if(pablo.GetComponent<Transform>().position.x > -4.4f && managerSteps == 1)
        {
            pablo.GetComponent<Animator>().SetInteger("animStep", 1);
            managerSteps = 2;
        }
    }
    void HomensIr()
    {
        if(managerSteps == 2)
        {
            if(caveman1.GetComponent<Transform>().position.x >= 1.08f)
            {
                caveman1.GetComponent<SpriteRenderer>().flipX = true;
                caveman1.GetComponent<Transform>().Translate(new Vector2(-3f, 0) * Time.deltaTime);
            }
            if (caveman2.GetComponent<Transform>().position.x >= 4.28f)
            {
                caveman2.GetComponent<SpriteRenderer>().flipX = true;
                caveman2.GetComponent<Transform>().Translate(new Vector2(-3f, 0) * Time.deltaTime);

            }
            else
            {
                managerSteps = 3;
            }
        }
    }
    void HomensPara()
    {
        if(managerSteps == 3)
        {
            caveman1.GetComponent<Animator>().SetInteger("caveManSteps", 1);
            caveman2.GetComponent<Animator>().SetInteger("caveManSteps", 1);
            managerSteps = 4;
        }
    }
    void AparacerFala()
    {
        if(managerSteps == 4)
        {
            fala.SetActive(true);
        }
    }
    public void OnClickCacar()
    {
        managerSteps = 5;
    }
    void sairCacar()
    {
        if(managerSteps == 5)
        {
            fala.SetActive(false);
            caveman1.GetComponent<Animator>().SetInteger("caveManSteps", 2);
            caveman2.GetComponent<Animator>().SetInteger("caveManSteps", 2);
            caveman2.GetComponent<Transform>().Translate(new Vector2(-3f, 0) * Time.deltaTime);
            caveman1.GetComponent<Transform>().Translate(new Vector2(-3f, 0) * Time.deltaTime);
            if(caveman2.GetComponent<Transform>().position.x <= -6.52f)
            {                
                crono += Time.deltaTime;
                if(crono >= 1)
                {
                    pablo.GetComponent<Animator>().SetInteger("animStep", 2);
                    pablo.GetComponent<Transform>().transform.Translate(new Vector2(-3f, 0) * Time.deltaTime);
                }
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                if(pablo.GetComponent<Transform>().position.x <= -11.26f)
                {
                    PlayerPrefs.SetInt("PaleoStep", 3);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("throwArrowScene");
                }
                
            }            
        }
    }
}
