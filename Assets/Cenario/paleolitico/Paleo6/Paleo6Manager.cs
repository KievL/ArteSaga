using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paleo6Manager : MonoBehaviour
{
    public GameObject btn;
    public float crono = 0;
    public int SceneStep = 0;
    public GameObject caveman;
    public GameObject pablo;
    public float velx;
    public SpriteRenderer caveColor;
    public Color colorr;
    public float velColor;

    public SpriteRenderer primColor;
    public Color colorr2;
    public float crono2 = 0;
    public GameObject venus;
    public int falaDoCara = 0;
    public GameObject fala;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PaleoLivroStep", 3);
        btn.SetActive(false);
        colorr = caveColor.color;
        colorr2 = primColor.color;
    }

    // Update is called once per frame
    void Update()
    {
        btnAparecer();
        irParaRitual();
    }
    void btnAparecer()
    {
        if(SceneStep == 0)
        {
            crono += Time.deltaTime;
            if (crono >= 1.5f)
            {
                btn.SetActive(true);
                SceneStep = -1;
                crono = 0;
            }
        }
        
    }
    void irParaRitual()
    {        
            if (SceneStep == 1)
            {
                caveman.GetComponent<Animator>().SetInteger("cavemanStep", 1);
                caveman.transform.Translate(new Vector2(velx, 0) * Time.deltaTime);
                colorr.r -= Time.deltaTime * velColor;
                colorr.g -= Time.deltaTime * velColor;
                colorr.b -= Time.deltaTime * velColor;
                caveColor.color = colorr;

                if (caveman.transform.position.x <= -5.8f)
                {
                    crono += Time.deltaTime;
                    if (crono >= 1f)
                    {
                        pablo.GetComponent<SpriteRenderer>().flipX = false;
                        crono2 += Time.deltaTime;
                        if (crono2 >= 1f)
                        {
                            pablo.transform.Translate(new Vector2(-velx, 0) * Time.deltaTime);
                            pablo.GetComponent<Animator>().SetInteger("pabloStep", 1);
                            if (pablo.transform.position.x >= -2.65f)
                            {
                                venus.SetActive(false);
                                SceneStep = 2;
                            }
                        }


                    }
                    else
                    {
                        pablo.GetComponent<SpriteRenderer>().flipX = true;
                    }


                }

            }
            if (SceneStep == 2)
            {
                pablo.transform.position = new Vector2(pablo.transform.position.x, -1.84f);
                SceneStep = 3;
            }
            if (SceneStep == 3)
            {
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                pablo.GetComponent<Animator>().SetInteger("pabloStep", 2);

                pablo.transform.Translate(new Vector2(velx, 0) * Time.deltaTime);
                colorr2.r -= Time.deltaTime * velColor;
                colorr2.g -= Time.deltaTime * velColor;
                colorr2.b -= Time.deltaTime * velColor;
                primColor.color = colorr2;
                if (pablo.transform.position.x <= -11.23f)
                {
                    PlayerPrefs.SetInt("PaleoStep", 6);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Paleo7");
                }

            
        }
        
        
    }
    public void mudarInt()
    {

        falaDoCara++;
        fala.GetComponent<Animator>().SetInteger("falaStep", falaDoCara);
        if (falaDoCara == 2)
        {
            fala.SetActive(false);
            SceneStep = 1;
        }
    }

}
