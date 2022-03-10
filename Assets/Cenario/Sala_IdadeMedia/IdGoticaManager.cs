using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdGoticaManager : MonoBehaviour
{
    public float goticaX1, goticaX2, renascX1, renascX2;

    int portalNum, entrandoNum;
    public GameObject pablo, cameraScene;
    public GameObject goticaName, renascName;

    public GameObject btnEntrar, painelEntrarG, painelEntrarR, painelVoltar;

    public Vector3 goticaBack, renascBack, goticaCamBack, renascCamBack;

    bool entrando=false;
    float crono = 0;
    float pabloX;
    public float limEsq;


    // Start is called before the first frame update
    void Start()
    {
        pabloGeral.liberado=true;
        
    }

    // Update is called once per frame
    void Update()
    {
        pabloX = pablo.transform.position.x;
        aparecerNamePortais();
        whichPortal();
        entrandoPortal();
        voltarSalaPortais();
        ondeNascer();
    }

    void ondeNascer(){
        switch(PlayerPrefs.GetInt("portalMedia")){
            case 0:
                pabloGeral.liberado=true;
            break;
            case 1: 
                cameraScene.transform.position = goticaCamBack;
                pablo.GetComponent<SpriteRenderer>().flipX=true;
                pablo.transform.position = goticaBack;             
                crono+=Time.deltaTime;
                painelVoltar.SetActive(true);
                if(crono>=1f){
                    painelVoltar.SetActive(false);
                    crono=0f;
                    pabloGeral.liberado = true;
                    PlayerPrefs.SetInt("portalMedia", 0);
                    PlayerPrefs.Save();
                }
            break;
            case 2: 
                cameraScene.transform.position = renascCamBack;
                pablo.GetComponent<SpriteRenderer>().flipX=true;
                pablo.transform.position = renascBack;             
                crono+=Time.deltaTime;
                painelVoltar.SetActive(true);
                if(crono>=1f){
                    painelVoltar.SetActive(false);
                    crono=0f;
                    pabloGeral.liberado = true;
                    PlayerPrefs.SetInt("portalMedia", 0);
                    PlayerPrefs.Save();
                }
            break;
        }
    }
    void voltarSalaPortais(){
        if(pabloX <= limEsq){
            PlayerPrefs.SetInt("dentroPreHist", 4);
            SceneManager.LoadScene("SalaPortais");
        }
    }

    void whichPortal(){
        if(pabloX >= goticaX1 && pabloX<=goticaX2){
            portalNum=1;
        }else if(pabloX>= renascX1 && pabloX<= renascX2){
            portalNum=2;
        }else{
            portalNum=0;
        }
    }

    void aparecerNamePortais(){
        getPortal(1, goticaName);
        getPortal(2, renascName);

        if(portalNum!=0){
            btnEntrar.SetActive(true);

        }else{
            btnEntrar.SetActive(false);
        }
    }

    void getPortal(int ptNum, GameObject ptGO){
        if(ptNum==portalNum){
            ptGO.SetActive(true);
        }else{
            ptGO.SetActive(false);
        }
    }

     public void entrarPortal(){
        if(pabloGeral.liberado){
            entrandoNum=portalNum;
            pabloGeral.liberado=false;            
            painelEntrarG.SetActive(true);
            entrando=true;
            switch(entrandoNum){
                case 1:
                    painelEntrarG.SetActive(true);
                break;
                case 2:
                    painelEntrarR.SetActive(true);
                break;
                }
        }        
    }

    void entrandoPortal(){
        if(entrando){
            crono+=Time.deltaTime;
            if(crono>=1.5f){
                switch(entrandoNum){
                case 1:
                    switch(PlayerPrefs.GetInt("gotica")){
                        case 1:
                            SceneManager.LoadScene("gotica2");
                        break;
                        case 2:
                            SceneManager.LoadScene("gotica2");
                        break;
                        case 3:
                            SceneManager.LoadScene("gotica2");
                        break;
                        case 4:
                            SceneManager.LoadScene("gotica2");
                        break;
                        case 5:
                            SceneManager.LoadScene("gotica2");
                        break;
                        default:
                            SceneManager.LoadScene("gotica1");
                        break;
                    }
                    SceneManager.LoadScene("gotica1");
                break;
                case 2:
                    SceneManager.LoadScene("renasciRoom");
                break;
                }
            }        
        }
    }
}
