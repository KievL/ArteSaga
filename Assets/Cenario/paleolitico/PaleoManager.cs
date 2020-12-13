using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaleoManager : MonoBehaviour
{
    public static bool isCorrendo = false;
    public float crono1 = 0;
    public float crono2 = 0;
    public float crono3 = 0;
    public float crono4 = 0;
    public float crono5 = 0;
    public bool podeObservar = false;
    public Transform aguia;
    public GameObject pablo;
    public Transform aguia2;
    public bool correr = false;
    public bool aguiaVoar = false;
    public static bool aguiaNascer = false;
    public static int aguasPasssadas = 0;
    public int aguasCheck = 0;
    public GameObject tutoTxt;
    public bool txtAtiv = false;
    public bool pularCena1 = false;
    // Start is called before the first frame update
    void Start()
    {
        tutoTxt.SetActive(false);
        if(PlayerPrefs.GetInt("tutorialPaleo1")==0)
        {
            podeObservar = true;
            
        }
        else
        {
            pularCena1 = true;
            pablo.GetComponent<Animator>().SetBool("pularCenaCorrer", true);
            pablo.GetComponent<Animator>().SetBool("olhar", false);
            aguia.transform.position = new Vector2(this.transform.position.x, 1.298f);
            aguia2.transform.position = new Vector2(this.transform.position.x, 1.4f);
            primitivoBehaviour.pularLiberado = true;
            pablo.transform.position = new Vector3(0, -0.197f, 0);
            podeObservar = false;


        }
        
    }

    // Update is called once per frame
    void Update()
    {
        aguasCheck = aguasPasssadas;
        Observar();
        correndo();
        aguiaDois();

        if (aguasPasssadas >= SpawnAguiaCima.maxInter + SpawnAguiaBaixo.maxInter)
        {
            primitivoBehaviour.ganhou = true;
            PaleoManager.isCorrendo = false;
        }
        if(primitivoBehaviour.ganhou == true && pablo.GetComponent<Transform>().position.x >= 1.97f)
        {
            PlayerPrefs.SetInt("PaleoStep", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Paleo2");
        }
        pulandoCena();
    }

    void Observar()
    {
        if (podeObservar == true)
        {
            crono1 += Time.deltaTime;
            if (crono1 >= 3f)
            {
                pablo.GetComponent<Animator>().SetBool("olhar", true);
                crono2 += Time.deltaTime;
                if(crono2 >= 3f)
                {
                    aguiaPassar();                    
                }                
            }
        }
        
    }
    void aguiaPassar()
    {
        aguia.Translate(new Vector3(0.95f, 0, 0)*Time.deltaTime);
        if(aguia.position.x >= 0)
        {
            pablo.GetComponent<Animator>().SetBool("assustado", true);
        }
        if(aguia.position.x >= 1.83f)
        {
            comecarCorrer();
            
        }
    }
    void comecarCorrer()
    {
        pablo.GetComponent<SpriteRenderer>().flipX = true;
        crono3 += Time.deltaTime;
        if(crono3 >= 2f)
        {
            correr = true;
            pablo.GetComponent<Animator>().SetBool("correr", true);
            pablo.GetComponent<SpriteRenderer>().flipX = false;
            podeObservar = false;
        }

    }
    void correndo()
    {
        if(correr == true)
        {
            pablo.transform.Translate(new Vector2(0.8f, 0)*Time.deltaTime);
            if(pablo.transform.position.x >= 2.357f)
            {                
                aguiaVoar = true;

                correr = false;
            }
        }
    }
    void aguiaDois()
    {
        if(aguiaVoar == true)
        {
            aguia2.transform.Translate(new Vector2(0.95f, 0)* Time.deltaTime);
            if(aguia2.position.x >= 2.357f)
            {
                if(txtAtiv == false)
                {
                    tutoTxt.SetActive(true);
                    txtAtiv = true;
                }
                
                crono4 += Time.deltaTime;
                if (crono4 > 2f)
                {
                    aguiaNascer = true;
                    aguiaVoar = false;
                    primitivoBehaviour.pularLiberado = true;

                }

                isCorrendo = true;
                pablo.transform.position = new Vector3(0, -0.197f, 0);                                
            }
        }
    }
    void pulandoCena()
    {
       
        if (pularCena1 == true)
        {
            
            if (txtAtiv == false)
            {
                tutoTxt.SetActive(true);
                txtAtiv = true;
            }
            crono5 += Time.deltaTime;
            if (crono5 > 2f)
            {

                aguiaNascer = true;
                aguiaVoar = false;
                primitivoBehaviour.pularLiberado = true;

            }

            isCorrendo = true;
            
        }
    }
    public void sairAguia()
    {
        
        PlayerPrefs.SetInt("saidaPrehist", 1);
        SceneManager.LoadScene("prehistoria");
        Time.timeScale = 1f;
    }
}
