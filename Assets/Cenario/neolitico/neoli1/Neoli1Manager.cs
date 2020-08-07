using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Neoli1Manager : MonoBehaviour
{
    public GameObject introCanvas;
    public GameObject pauseCanvas;
    public GameObject moveCanvas;
    public float crono = 0;
    public int sceneStep = 0;
    public GameObject seta;
    public GameObject pablo;
    public GameObject falaHomem;
    public int falasStep = 0;
    public GameObject help;
    public int madeiraMax;
    public static int madeirasStatic = 0;
    public int madeiras;
    public static bool falando = false;

    public static bool getMadeira = false;

    public GameObject btnTree1;
    public GameObject btnTree2;
    public GameObject btnTree3;
    public GameObject btnTree4;

    public static bool showBtnTree1 = false;
    public static bool showBtnTree2 = false;
    public static bool showBtnTree3 = false;
    public static bool showBtnTree4 = false;

    public static bool tree1Got = false;
    public static bool tree2Got = false;
    public static bool tree3Got = false;
    public static bool tree4Got = false;

    public bool quebrando1 = false;
    public bool quebrando2 = false;
    public bool quebrando3 = false;
    public bool quebrando4 = false;

    public int breakingStep = 0;

    public GameObject btnQuebrar;

    public static int woodTaken = 0;
    public static int woodBuildHouse = 0;
    public GameObject woodIcon;
    public Text textWood;
    public GameObject textWoo2GO;

    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;

    public GameObject btnConstruir;
    public GameObject casaConstrucao;
    public GameObject casaConstrucao1;
    public int buildStep = 0;
    public bool building = false;
    public GameObject btnBuild;
    public int houseStep = 0;
    public int contadorCasa = 0;
    public int btnCont = 0;
    public bool terminouCasa = false;

    public GameObject hmFalaDois;
    public int falaStep = 0;

    public GameObject fade;
    public float crono4 = 0;

    public Camera cam;
    public GameObject bear;
    public GameObject sky;

    public GameObject mont1;
    public GameObject mont2;

    public GameObject thundFx;
    public GameObject thundFx2;
    public GameObject thundFx3;
    public GameObject thundFx4;
    public GameObject camera1;
    public float crono5 = 0;

    public float cronoBater = 0;
    public bool bateu = false;


    // Start is called before the first frame update
    void Start()
    {
        introCanvas.SetActive(true);
        moveCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        seta.SetActive(false);
        falaHomem.SetActive(false);
        btnTree1.SetActive(false);
        btnTree2.SetActive(false);
        btnTree3.SetActive(false);
        help.SetActive(false);
        btnQuebrar.SetActive(false);
        woodIcon.SetActive(false);
        textWoo2GO.SetActive(false);
        btnConstruir.SetActive(false);
        casaConstrucao.SetActive(true);
        casaConstrucao1.SetActive(true);
        btnBuild.SetActive(false);
        hmFalaDois.SetActive(false);
        fade.SetActive(false);
        bear.SetActive(false);
        thundFx.SetActive(false);
        thundFx2.SetActive(false);
        thundFx3.SetActive(false);
        thundFx4.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        madeiras = madeirasStatic;

        Introducao();
        EncontrarHomem();
        Falas();
        pegarMadeira();
        MostrarBotoes();
        quebrandoTree1();
        quebrandoTree2();
        quebrandoTree3();
        quebrandoTree4();
        aumentarWood();
        mudarAnim();
        construcao();
        stepChecker();
        urso();
        finalStep();
        hitt();
        if(quebrando1 == false && quebrando2 == false && quebrando3 == false && quebrando4 == false)
        {
            camera1.transform.eulerAngles = new Vector3(camera1.transform.eulerAngles.x, camera1.transform.eulerAngles.y, 0);  
        }

    }
    void Introducao()
    {
        if(sceneStep == 0)
        {
            crono += Time.deltaTime;
            if(crono >= 8)
            {
                moveCanvas.SetActive(true);
                introCanvas.SetActive(false);
                pauseCanvas.SetActive(true);
                seta.SetActive(true);
                crono = 0;
                sceneStep = 1;
            }
        }

    }
    void EncontrarHomem()
    {
        if(sceneStep ==1 && pablo.transform.position.x >= 6.65f)
        {
            sceneStep = 2;
        }
        if (sceneStep == 2)
        {
            falando = true;
            moveCanvas.SetActive(false);
            seta.SetActive(false);
            crono += Time.deltaTime;
            if(crono >= 1.5f)
            {
                falaHomem.SetActive(true);
                sceneStep = 3;
            }

        }
    }
    void Falas()
    {
        falaHomem.GetComponent<Animator>().SetInteger("falaStep", falasStep);
        if(falasStep == 6)
        {
            falaHomem.SetActive(false);
            sceneStep = 7;
        }
    }
    public void falasClick()
    {
        falasStep++;
    }
    void pegarMadeira()
    {
        if(sceneStep == 7)
        {           
            pabloAndar.resolver = true;
            getMadeira = true;
            help.SetActive(true);
            moveCanvas.SetActive(true);
            woodIcon.SetActive(true);
            textWoo2GO.SetActive(true);
            sceneStep = 8;

        }
    }
    void MostrarBotoes()
    {
        if(showBtnTree1== true && woodBuildHouse != 4)
        {
            btnTree1.SetActive(true);
        }
        else
        {
            btnTree1.SetActive(false);
        }
        if (showBtnTree2 == true && woodBuildHouse != 4)
        {
            btnTree2.SetActive(true);
        }
        else
        {
            btnTree2.SetActive(false);
        }
        if (showBtnTree3 == true && woodBuildHouse != 4)
        {
            btnTree3.SetActive(true);
        }
        else
        {
            btnTree3.SetActive(false);
        }
        if (showBtnTree4 == true && woodBuildHouse != 4)
        {
            btnTree4.SetActive(true);
        }
        else
        {
            btnTree4.SetActive(false);
        }
    }
    public void quebrarMadeira1()
    {       
        showBtnTree1 = false;
        quebrando1 = true;       

    }
    public void quebrarMadeira2()
    {
        showBtnTree2 = false;
        quebrando2 = true;

    }
    public void quebrarMadeira3()
    {        
        showBtnTree3 = false;
        quebrando3 = true;

    }
    public void quebrarMadeira4()
    {
        showBtnTree4 = false;
        quebrando4 = true;

    }
    void quebrandoTree1()
    {
        if (quebrando1 == true)
        {
            moveCanvas.SetActive(false);
            if (breakingStep == 0)
            {
                if(pablo.transform.position.x > -7.476f)
                {
                    pablo.GetComponent<SpriteRenderer>().flipX = true;
                    pablo.transform.Translate(new Vector2(-3, 0) * Time.deltaTime);
                    pabloNeo1B.playable = false;
                    pablo.GetComponent<Animator>().SetBool("isWalking", true);
                }
                if(pablo.transform.position.x < -7.797f)
                {
                    pablo.GetComponent<SpriteRenderer>().flipX = false;
                    pablo.transform.Translate(new Vector2(3, 0) * Time.deltaTime);
                    pabloNeo1B.playable = false;
                    pablo.GetComponent<Animator>().SetBool("isWalking", true);
                }
                if(pablo.transform.position.x <= -7.476f && pablo.transform.position.x >= -7.797f)
                {
                    pablo.GetComponent<Animator>().SetBool("endWood", false);
                    breakingStep = 1;
                }
            }
            if(breakingStep == 1)
            {
                btnQuebrar.SetActive(true);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                pablo.GetComponent<Animator>().SetBool("isBreaking", true);
            }
            if (woodTaken == 4)
            {
                quebrando1 = false;
                pablo.GetComponent<Animator>().SetBool("endWood", true);
                pablo.GetComponent<Animator>().SetBool("isBreaking", false);
                pablo.GetComponent<Animator>().SetBool("tocouTela", false);
                pablo.GetComponent<Animator>().SetBool("isWalking", false);
                btnQuebrar.SetActive(false);
                moveCanvas.SetActive(true);
                pabloNeo1B.playable = true;
                woodTaken = 0;
                tree1Got = true;
                breakingStep = 0;

            }
        }        
    }
    void quebrandoTree2()
    {
        if (quebrando2 == true)
        {
            moveCanvas.SetActive(false);
            if (breakingStep == 0)
            {
                if (pablo.transform.position.x > -2.85f)
                {
                    pablo.GetComponent<SpriteRenderer>().flipX = true;
                    pablo.transform.Translate(new Vector2(-3, 0) * Time.deltaTime);
                    pabloNeo1B.playable = false;
                    pablo.GetComponent<Animator>().SetBool("isWalking", true);
                }
                if (pablo.transform.position.x < -3.12f)
                {
                    pablo.GetComponent<SpriteRenderer>().flipX = false;
                    pablo.transform.Translate(new Vector2(3, 0) * Time.deltaTime);
                    pabloNeo1B.playable = false;
                    pablo.GetComponent<Animator>().SetBool("isWalking", true);
                }
                if (pablo.transform.position.x <= -2.85f && pablo.transform.position.x >= -3.12f)
                {
                    pablo.GetComponent<Animator>().SetBool("endWood", false);
                    breakingStep = 1;
                }
            }
            if (breakingStep == 1)
            {
                btnQuebrar.SetActive(true);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                pablo.GetComponent<Animator>().SetBool("isBreaking", true);
            }
            if (woodTaken == 4)
            {
                quebrando2 = false;
                pablo.GetComponent<Animator>().SetBool("endWood", true);
                pablo.GetComponent<Animator>().SetBool("isBreaking", false);
                pablo.GetComponent<Animator>().SetBool("tocouTela", false);
                pablo.GetComponent<Animator>().SetBool("isWalking", false);
                btnQuebrar.SetActive(false);
                moveCanvas.SetActive(true);
                pabloNeo1B.playable = true;
                woodTaken = 0;
                tree2Got = true;
                breakingStep = 0;

            }
        }
    }
    void quebrandoTree3()
    {
        if (quebrando3 == true)
        {
            moveCanvas.SetActive(false);
            if (breakingStep == 0)
            {
                if (pablo.transform.position.x > 2.36f)
                {
                    pablo.GetComponent<SpriteRenderer>().flipX = true;
                    pablo.transform.Translate(new Vector2(-3, 0) * Time.deltaTime);
                    pabloNeo1B.playable = false;
                    pablo.GetComponent<Animator>().SetBool("isWalking", true);
                }
                if (pablo.transform.position.x < 2.14f)
                {
                    pablo.GetComponent<SpriteRenderer>().flipX = false;
                    pablo.transform.Translate(new Vector2(3, 0) * Time.deltaTime);
                    pabloNeo1B.playable = false;
                    pablo.GetComponent<Animator>().SetBool("isWalking", true);
                }
                if (pablo.transform.position.x <= 2.36f && pablo.transform.position.x >= 2.14f)
                {
                    pablo.GetComponent<Animator>().SetBool("endWood", false);
                    breakingStep = 1;
                }
            }
            if (breakingStep == 1)
            {
                btnQuebrar.SetActive(true);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                pablo.GetComponent<Animator>().SetBool("isBreaking", true);
            }
            if (woodTaken == 4)
            {
                quebrando3 = false;
                pablo.GetComponent<Animator>().SetBool("endWood", true);
                pablo.GetComponent<Animator>().SetBool("isBreaking", false);
                pablo.GetComponent<Animator>().SetBool("tocouTela", false);
                pablo.GetComponent<Animator>().SetBool("isWalking", false);
                btnQuebrar.SetActive(false);
                moveCanvas.SetActive(true);
                pabloNeo1B.playable = true;
                woodTaken = 0;
                tree3Got = true;
                breakingStep = 0;
            }
        }
    }
    void quebrandoTree4()
    {
        if (quebrando4 == true)
        {
            moveCanvas.SetActive(false);
            if (breakingStep == 0)
            {
                if (pablo.transform.position.x > -12.6f)
                {
                    pablo.GetComponent<SpriteRenderer>().flipX = true;
                    pablo.transform.Translate(new Vector2(-3, 0) * Time.deltaTime);
                    pabloNeo1B.playable = false;
                    pablo.GetComponent<Animator>().SetBool("isWalking", true);
                }
                if (pablo.transform.position.x < -13.05f)
                {
                    pablo.GetComponent<SpriteRenderer>().flipX = false;
                    pablo.transform.Translate(new Vector2(3, 0) * Time.deltaTime);
                    pabloNeo1B.playable = false;
                    pablo.GetComponent<Animator>().SetBool("isWalking", true);
                }
                if (pablo.transform.position.x <= -12.6f && pablo.transform.position.x >= - 13.05f)
                {
                    pablo.GetComponent<Animator>().SetBool("endWood", false);
                    breakingStep = 1;
                }
            }
            if (breakingStep == 1)
            {
                btnQuebrar.SetActive(true);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                pablo.GetComponent<Animator>().SetBool("isBreaking", true);
            }
            if (woodTaken == 4)
            {
                quebrando4 = false;
                pablo.GetComponent<Animator>().SetBool("endWood", true);
                pablo.GetComponent<Animator>().SetBool("isBreaking", false);
                pablo.GetComponent<Animator>().SetBool("tocouTela", false);
                pablo.GetComponent<Animator>().SetBool("isWalking", false);
                btnQuebrar.SetActive(false);
                moveCanvas.SetActive(true);
                pabloNeo1B.playable = true;
                woodTaken = 0;
                tree4Got = true;
                breakingStep = 0;
            }
        }
    }
    void aumentarWood()
    {
        textWood.text = woodBuildHouse+"/4";
    }
    void mudarAnim()
    {
        if (tree1Got)
        {
            tree1.GetComponent<Animator>().SetBool("broken", true);
        }
        if (tree2Got)
        {
            tree2.GetComponent<Animator>().SetBool("broken", true);
        }
        if (tree3Got)
        {
            tree3.GetComponent<Animator>().SetBool("broken", true);
        }
        if (tree4Got)
        {
            tree4.GetComponent<Animator>().SetBool("broken", true);
        }
    }
    public void construir()
    {
        buildStep++;
        building = true;        
        pabloNeo1B.playable = false;
        pablo.GetComponent<Animator>().SetBool("endWood", false);        

    }
    void construcao()
    {
        if (woodBuildHouse == 4 && pablo.transform.position.x >= 5.73f && pablo.transform.position.x <= 11.06f && building == false)
        {
            btnConstruir.SetActive(true);
        }else
        {
            btnConstruir.SetActive(false);
        }
        if(building == true && buildStep == 1)
        {
            btnBuild.SetActive(true);
            moveCanvas.SetActive(false);
            if (pablo.transform.position.x < 7.63f)
            {
                pablo.GetComponent<Animator>().SetBool("isWalking", true);
                pablo.transform.Translate(new Vector2(3, 0) * Time.deltaTime);
                pablo.GetComponent<SpriteRenderer>().flipX = false;
                
            }
            if(pablo.transform.position.x > 8.58f)
            {
                pablo.GetComponent<Animator>().SetBool("isWalking", true);
                pablo.transform.Translate(new Vector2(-3, 0) * Time.deltaTime);
                pablo.GetComponent<SpriteRenderer>().flipX = true;
            }
            if(pablo.transform.position.x >= 7.63f && pablo.transform.position.x <= 8.58f)
            {
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                pablo.GetComponent<Animator>().SetBool("isWalking", false);
                pablo.GetComponent<Animator>().SetBool("isBreaking", true);
                buildStep = 2;
            }
        }
        casaConstrucao.GetComponent<Animator>().SetInteger("houseStep", houseStep);
        casaConstrucao1.GetComponent<Animator>().SetInteger("houseStep", houseStep);
    }
    public void clickBuild()
    {
        if(buildStep == 2)
        {
            if(bateu == false) {
                pablo.GetComponent<Animator>().SetBool("tocouTela", true);
                btnCont++;
                bateu = true;
                if (btnCont == 2)
                {
                    contadorCasa++;
                    btnCont = 0;
                    woodBuildHouse--;
                }
                if (contadorCasa == 4)
                {

                    houseStep++;
                    building = false;
                    contadorCasa = 0;
                    buildStep = 0;
                    pabloNeo1B.playable = true;
                    moveCanvas.SetActive(true);
                    pablo.GetComponent<Animator>().SetBool("endWood", true);
                    btnBuild.SetActive(false);
                    pablo.GetComponent<Animator>().SetBool("isBreaking", false);
                }
            }            
        }        
    }
    void hitt()
    {
        if(bateu == true)
        {
            cronoBater += Time.deltaTime;
            if(cronoBater >= 0.33f) {
                pablo.GetComponent<Animator>().SetBool("tocouTela", false);
                bateu = false;
                cronoBater = 0;
            }
        }
    }
    void stepChecker()
    {
        if(houseStep == 4 && terminouCasa == false)
        {
            terminouCasa = true;    
            pablo.GetComponent<SpriteRenderer>().flipX = false;
            moveCanvas.SetActive(false);
            pabloNeo1B.playable = false;
        }
        if(terminouCasa == true && sceneStep == 8)
        {
            help.SetActive(false);
            hmFalaDois.SetActive(true);
            moveCanvas.SetActive(false);
            pabloNeo1B.playable = false;
            hmFalaDois.GetComponent<Animator>().SetInteger("falaStep", falaStep);
            if(falaStep == 2)
            {
                sceneStep = 9;
            }
        }
        if(sceneStep == 9)
        {
            moveCanvas.SetActive(false);
            pabloNeo1B.playable = false;
            fade.SetActive(true);
            crono4 += Time.deltaTime;
            hmFalaDois.SetActive(false);
            if (crono4 >= 6f)
            {
                sceneStep = 10;
            }
        }
        
    }
    void urso()
    {
        if(sceneStep == 10)
        {
            Color corDoBixo;
            corDoBixo.a = 255;
            corDoBixo.g = 63;
            corDoBixo.r = 63;
            corDoBixo.b = 63;

            Color corToc;
            corToc.a = 255;
            corToc.r = 142;
            corToc.g = 142;
            corToc.b = 142;

            CameraSeguir.allow = false;
            bear.SetActive(true);
            pablo.SetActive(false);
            fade.SetActive(false);
            sky.GetComponent<SpriteRenderer>().color = corDoBixo;
            mont1.GetComponent<SpriteRenderer>().color = corDoBixo;
            mont2.GetComponent<SpriteRenderer>().color = corDoBixo;
            tree3.GetComponent<SpriteRenderer>().color = corToc;
            woodIcon.SetActive(false);
            textWoo2GO.SetActive(false);
            cam.orthographicSize = 1.900383f;
            cam.transform.position = new Vector3(4.98f, 0 , -10);
            sceneStep = 11;
            thundFx.SetActive(true);
            thundFx2.SetActive(true);
            thundFx3.SetActive(true);
            thundFx4.SetActive(true);
            crono = 0;
        }
        

    }
    void finalStep()
    {
        if(sceneStep == 11)
        {
            crono5 += Time.deltaTime;
            if(crono5 >= 2f)
            {
                SceneManager.LoadScene("neoli2");
                PlayerPrefs.SetInt("NeoliStep", 2);
                PlayerPrefs.Save();
            }
        }
    }
    public void mudarFala2()
    {
        falaStep++;
    }
}