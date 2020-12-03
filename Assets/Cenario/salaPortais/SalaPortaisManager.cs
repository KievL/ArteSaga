using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalaPortaisManager : MonoBehaviour
{
    public int SceneStep = 0;
    public GameObject botaoEntrar;
    public GameObject pablo;
    public int portal = 0;
    public int porta2 = 0;
    public GameObject painelFinal;
    public float crono = 0;
    public bool mudarCena = false;
    public GameObject camera1;
    public int cameraStep = 0;
    public float crono1 = 0;

    public float velCamX, velCamY, velOrt;

    public bool xCheck = false;
    public bool yCheck = false;
    public bool ortCheck = false;

    public GameObject textPreHist;   
    public GameObject textIdadeAntiga;


    public GameObject fala;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("museuStep", 3);
        PlayerPrefs.Save();
        painelFinal.SetActive(false); 
        if(PlayerPrefs.GetInt("dentroPreHist") == 2)
        {            
            camera1.transform.position = new Vector3(-1.085198f, -0.466f, camera1.transform.position.z);
            camera1.GetComponent<Camera>().orthographicSize = 0.4006618f;
            pablo.transform.position = new Vector2(-1.078f, -0.498f);
            pablo.GetComponent<SpriteRenderer>().flipX = true;
            SceneStep = 1;
            PlayerPrefs.SetInt("dentroPreHist", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        OQueAconteceu();
        AndarPelaSala();
        AparecerSetas();
        EmQualPortal();
        MudarCenario();
    }
    void OQueAconteceu()
    {
        if(SceneStep == 0)
        {
            if(cameraStep == 0)
            {
                camera1.GetComponent<Camera>().orthographicSize = 0.06387892f;
                crono1 += Time.deltaTime;
                if (crono1 >= 1f)
                {
                    cameraStep++;
                }

            }
            if(cameraStep == 1)
            {

                if(ortCheck == false)
                {
                    camera1.GetComponent<Camera>().orthographicSize += Time.deltaTime / velOrt;
                    if (camera1.GetComponent<Camera>().orthographicSize >= 0.4006618f)
                    {
                        ortCheck = true;
                    }
                }
                if (xCheck == false)
                {
                    camera1.transform.Translate(new Vector2(velCamX, 0) * Time.deltaTime);
                    if(camera1.transform.position.x >= -1.499f)
                    {
                        xCheck = true;
                    }                    
                }
                if (yCheck == false)
                {
                    camera1.transform.Translate(new Vector2(0, velCamY) * Time.deltaTime);
                    if (camera1.transform.position.y <= -0.466f)
                    {
                        yCheck = true;
                    }
                }
                
                if(ortCheck == true && xCheck == true && yCheck == true)
                {
                    cameraStep = 2;
                }
            }
                if(cameraStep == 2)
            {
                fala.SetActive(true);
                cameraStep = 3;
            }        
            
        }
    }
    void AndarPelaSala()
    {
        if(SceneStep == 1)
        {
            pabloGeral.liberado = true;

        }
    }
    void AparecerSetas()
    {
        if(portal != 0)
        {
            botaoEntrar.SetActive(true);

        }       
        else if (porta2 != 0)
        {
            botaoEntrar.SetActive(true);

        }
        else
        {
            botaoEntrar.SetActive(false);
        }  
        
    }
    void EmQualPortal()
    {
        if(pablo.transform.position.x >= -1.351f && pablo.transform.position.x <= -0.808f)
        {
            textPreHist.SetActive(true);
            portal = 1;
        }
        else
        {
            textPreHist.SetActive(false);
            portal = 0;
        }
        if (pablo.transform.position.x >= -0.029f && pablo.transform.position.x <= 0.523f)
        {
            textIdadeAntiga.SetActive(true);
            porta2 = 1;
        }
        else
        {
            textIdadeAntiga.SetActive(false);
            porta2 = 0;
        }
    }
    void MudarCenario()
    {
        if(mudarCena == true && portal == 1)
        {
            painelFinal.SetActive(true);
            crono += Time.deltaTime;
            if(crono >= 1f)
            {
                SceneManager.LoadScene("prehistoria");
            }
        }

        if (mudarCena == true && porta2 == 1)
        {
            painelFinal.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                SceneManager.LoadScene("idadeantiga");
            }
        }
    }
    public void EntrarSala()
    {
        if(portal == 1)
        {
            mudarCena = true;            
        }
        if (porta2 == 1)
        {
            mudarCena = true;
        }
    }
    public void ApertarFala()
    {
        fala.SetActive(false);
        SceneStep = 1;
    }
}
