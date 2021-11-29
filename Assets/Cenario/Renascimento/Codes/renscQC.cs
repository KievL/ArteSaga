using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class renscQC : MonoBehaviour
{
    public GameObject block1, block2, block3, block4, block5, block6, block7, block8, block9, block10;
    public GameObject text1, text2, text3, text4, text5, text6, text7, text8, text9, text10;
    public GameObject closeX, backgroundPanel, fadeIn, fadeOut, tutorial, btnTutorial;
    public GameObject text1Canvas, text2Canvas, text3Canvas, text4Canvas, text5Canvas, text6Canvas, text7Canvas, text8Canvas, text9Canvas, text10Canvas;
    public GameObject block1Canvas, block2Canvas, block3Canvas, block4Canvas, block5Canvas, block6Canvas, block7Canvas, block8Canvas, block9Canvas, block10Canvas;

    public bool allowClicks = false;
    public bool allowClickBlock = false;
    public bool allowClickTexts = false;

    bool skiptut = false;

    int blockOpen = 0;
    int textOpen = 0;

    int openBlocks = 0;

    bool ganhou = false;

    float cronoDelay = 0;
    bool activateDelay = false;

    public RaycastHit2D hit;

    public int sceneStep = 0;
    float crono = 0;

    public int acertos = 0;

    bool unlockGame = false;
    // Start is called before the first frame update
    void Start()
    {
        fadeIn.SetActive(true);
        skiptut = false;
    }

    // Update is called once per frame
    void Update()
    {
        startGame();
        EndTutorial();
        ClicksBlock();
        delayTime();
        correctChoose();
        fimMiniGame();
    }

    void startGame()
    {
        if (sceneStep == 0)
        {
            crono += Time.deltaTime;
            if (crono >= 0.5f)
            {
                tutorial.SetActive(true);
                crono = 0;
                sceneStep++;
            }
        }
    }
    public void SkipTutorial()
    {        
        if (unlockGame)
        {
            btnTutorial.SetActive(true);
            backgroundPanel.SetActive(false);
            tutorial.SetActive(false);
            allowClicks = true;
        }
        else
        {
            skiptut = true;
        }
    }

    void EndTutorial()
    {
        if (skiptut == true)
        {
            fadeIn.GetComponent<Animator>().SetInteger("fadeStep", 1);
            tutorial.SetActive(false);
            crono += Time.deltaTime;
            if (crono >= 0.5f)
            {
                fadeIn.SetActive(false);
                skiptut = false;
                crono = 0;
                allowClicks = true;
                allowClickBlock = true;
                allowClickTexts = true;
                unlockGame = true;
                btnTutorial.SetActive(true);
            }
        }
    }

    void ClicksBlock()
    {
        if (allowClicks)
        {
            if (Input.GetMouseButtonDown(0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                //ImageBlocks
                if (hit.collider != null && hit.transform.gameObject == block1.gameObject)
                {
                    if (allowClickBlock)
                    {                        
                        openTheCanvaBlock(1);
                        blockOpen = 1;
                    }
                    else if (allowClickBlock == false && blockOpen == 1)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == block2.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvaBlock(2);
                        blockOpen = 2;
                    }
                    else if (allowClickBlock == false && blockOpen == 2)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == block3.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvaBlock(3);
                        blockOpen = 3;
                    }
                    else if (allowClickBlock == false && blockOpen == 3)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == block4.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvaBlock(4);
                        blockOpen = 4;
                    }
                    else if (allowClickBlock == false && blockOpen == 4)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == block5.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvaBlock(5);
                        blockOpen = 5;
                    }
                    else if (allowClickBlock == false && blockOpen == 5)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == block6.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvaBlock(6);
                        blockOpen = 6;
                    }
                    else if (allowClickBlock == false && blockOpen == 6)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == block7.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvaBlock(7);
                        blockOpen = 7;
                    }
                    else if (allowClickBlock == false && blockOpen == 7)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == block8.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvaBlock(8);
                        blockOpen = 8;
                    }
                    else if (allowClickBlock == false && blockOpen == 8)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == block9.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvaBlock(9);
                        blockOpen = 9;
                    }
                    else if (allowClickBlock == false && blockOpen == 9)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == block10.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvaBlock(10);
                        blockOpen = 10;
                    }
                    else if (allowClickBlock == false && blockOpen == 10)
                    {
                        reOpenTheCanvaBlock(blockOpen);
                    }
                }

                //TextBlocks
                if (hit.collider != null && hit.transform.gameObject == text1.gameObject)
                {
                    if (allowClickBlock)
                    {
                        openTheCanvasText(1);
                        textOpen = 1;
                    }else if(allowClickTexts==false && textOpen == 1)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == text2.gameObject)
                {
                    if (allowClickTexts)
                    {
                        openTheCanvasText(2);
                        textOpen = 2;
                    }
                    else if (allowClickTexts == false && textOpen == 2)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == text3.gameObject)
                {
                    if (allowClickTexts)
                    {
                        openTheCanvasText(3);
                        textOpen = 3;
                    }
                    else if (allowClickTexts == false && textOpen == 3)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == text4.gameObject)
                {
                    if (allowClickTexts)
                    {
                        openTheCanvasText(4);
                        textOpen = 4;
                    }
                    else if (allowClickTexts == false && textOpen == 4)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == text5.gameObject)
                {
                    if (allowClickTexts)
                    {
                        openTheCanvasText(5);
                        textOpen = 5;
                    }
                    else if (allowClickTexts == false && textOpen == 5)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == text6.gameObject)
                {
                    if (allowClickTexts)
                    {
                        openTheCanvasText(6);
                        textOpen = 6;
                    }
                    else if (allowClickTexts == false && textOpen == 6)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == text7.gameObject)
                {
                    if (allowClickTexts)
                    {
                        openTheCanvasText(7);
                        textOpen = 7;
                    }
                    else if (allowClickTexts == false && textOpen == 7)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == text8.gameObject)
                {
                    if (allowClickTexts)
                    {
                        openTheCanvasText(8);
                        textOpen = 8;
                    }
                    else if (allowClickTexts == false && textOpen == 8)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == text9.gameObject)
                {
                    if (allowClickTexts)
                    {
                        openTheCanvasText(9);
                        textOpen = 9;
                    }
                    else if (allowClickTexts == false && textOpen == 9)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }
                if (hit.collider != null && hit.transform.gameObject == text10.gameObject)
                {
                    if (allowClickTexts)
                    {
                        openTheCanvasText(10);
                        textOpen = 10;
                    }
                    else if (allowClickTexts == false && textOpen == 10)
                    {
                        reOpenTheCanvaText(textOpen);
                    }
                }

            }


            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null && hit.transform.gameObject == block1.gameObject)
                {

                }                
            }
        }
    }

    void openTheCanvaBlock(int numBlock)
    {
        allowClickBlock = false;
        allowClicks = false;
        if (numBlock == 1)
        {
            block1Canvas.SetActive(true);
            block1.GetComponent<Animator>().SetBool("virado", true);
            
        }else if (numBlock == 2)
        {
            block2Canvas.SetActive(true);
            block2.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numBlock == 3)
        {
            block3Canvas.SetActive(true);
            block3.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numBlock == 4)
        {
            block4Canvas.SetActive(true);
            block4.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numBlock == 5)
        {
            block5Canvas.SetActive(true);
            block5.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numBlock == 6)
        {
            block6Canvas.SetActive(true);
            block6.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numBlock == 7)
        {
            block7Canvas.SetActive(true);
            block7.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numBlock == 8)
        {
            block8Canvas.SetActive(true);
            block8.GetComponent<Animator>().SetBool("virado", true);
        }        
        else if (numBlock == 9)
        {
            block9Canvas.SetActive(true);
            block9.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numBlock == 10)
        {
            block10Canvas.SetActive(true);
            block10.GetComponent<Animator>().SetBool("virado", true);
        }
        openBlocks++;
        btnTutorial.SetActive(false);
        closeX.SetActive(true);
        backgroundPanel.SetActive(true);
    }

    void openTheCanvasText(int numText)
    {
        allowClickTexts = false;
        allowClicks = false;
        if (numText == 1)
        {
            text1Canvas.SetActive(true);
            text1.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numText == 2)
        {
            text2Canvas.SetActive(true);
            text2.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numText == 3)
        {
            text3Canvas.SetActive(true);
            text3.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numText == 4)
        {
            text4Canvas.SetActive(true);
            text4.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numText == 5)
        {
            text5Canvas.SetActive(true);
            text5.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numText == 6)
        {
            text6Canvas.SetActive(true);
            text6.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numText == 7)
        {
            text7Canvas.SetActive(true);
            text7.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numText == 8)
        {
            text8Canvas.SetActive(true);
            text8.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numText == 9)
        {
            text9Canvas.SetActive(true);
            text9.GetComponent<Animator>().SetBool("virado", true);
        }
        else if (numText == 10)
        {
            text10Canvas.SetActive(true);
            text10.GetComponent<Animator>().SetBool("virado", true);
        }
        openBlocks++;
        closeX.SetActive(true);
        btnTutorial.SetActive(false);
        backgroundPanel.SetActive(true);
    }

    void reOpenTheCanvaBlock(int numBlock)
    {
        allowClicks = false;
        closeX.SetActive(true);
        backgroundPanel.SetActive(true);
        btnTutorial.SetActive(false);

        if (numBlock == 1)
        {
            block1Canvas.SetActive(true);        
        }
        else if (numBlock == 2)
        {
            block2Canvas.SetActive(true);
        }
        else if (numBlock == 3)
        {
            block3Canvas.SetActive(true);
        }
        else if (numBlock == 4)
        {
            block4Canvas.SetActive(true);
        }
        else if (numBlock == 5)
        {
            block5Canvas.SetActive(true);
        }
        else if (numBlock == 6)
        {
            block6Canvas.SetActive(true);
        }
        else if (numBlock == 7)
        {
            block7Canvas.SetActive(true);
        }
        else if (numBlock == 8)
        {
            block8Canvas.SetActive(true);
        }
        else if (numBlock == 9)
        {
            block9Canvas.SetActive(true);
        }
        else if (numBlock == 10)
        {
            block10Canvas.SetActive(true);
        }


    }

    void reOpenTheCanvaText(int numText)
    {
        allowClicks = false;
        closeX.SetActive(true);
        backgroundPanel.SetActive(true);
        btnTutorial.SetActive(false);

        if (numText == 1)
        {
            text1Canvas.SetActive(true);
        }
        else if (numText == 2)
        {
            text2Canvas.SetActive(true);
        }
        else if (numText == 3)
        {
            text3Canvas.SetActive(true);
        }
        else if (numText == 4)
        {
            text4Canvas.SetActive(true);
        }
        else if (numText == 5)
        {
            text5Canvas.SetActive(true);
        }
        else if (numText == 6)
        {
            text6Canvas.SetActive(true);
        }
        else if (numText == 7)
        {
            text7Canvas.SetActive(true);
        }
        else if (numText == 8)
        {
            text8Canvas.SetActive(true);
        }
        else if (numText == 9)
        {
            text9Canvas.SetActive(true);
        }
        else if (numText == 10)
        {
            text10Canvas.SetActive(true);
        }
    }

    public void closeBlocks() {
        block1Canvas.SetActive(false);
        block2Canvas.SetActive(false);
        block3Canvas.SetActive(false);
        block4Canvas.SetActive(false);
        block5Canvas.SetActive(false);
        block6Canvas.SetActive(false);
        block7Canvas.SetActive(false);
        block8Canvas.SetActive(false);
        block9Canvas.SetActive(false);
        block10Canvas.SetActive(false);

        text1Canvas.SetActive(false);
        text2Canvas.SetActive(false);
        text3Canvas.SetActive(false);
        text4Canvas.SetActive(false);
        text5Canvas.SetActive(false);
        text6Canvas.SetActive(false);
        text7Canvas.SetActive(false);
        text8Canvas.SetActive(false);
        text9Canvas.SetActive(false);
        text10Canvas.SetActive(false);

        backgroundPanel.SetActive(false);
        btnTutorial.SetActive(true);
        closeX.SetActive(false);

        if (openBlocks == 1)
        {
            allowClicks = true;
        }
        else if (openBlocks == 2)
        {
            checkIfWins();
        }
        else if (openBlocks == 0)
        {
            allowClicks = true;
            allowClickBlock = true;
            allowClickTexts = true;
            text1.GetComponent<Animator>().SetBool("virado", false);
            text2.GetComponent<Animator>().SetBool("virado", false);
            text3.GetComponent<Animator>().SetBool("virado", false);
            text4.GetComponent<Animator>().SetBool("virado", false);
            text5.GetComponent<Animator>().SetBool("virado", false);
            text6.GetComponent<Animator>().SetBool("virado", false);
            text7.GetComponent<Animator>().SetBool("virado", false);
            text8.GetComponent<Animator>().SetBool("virado", false);
            text9.GetComponent<Animator>().SetBool("virado", false);
            text10.GetComponent<Animator>().SetBool("virado", false);
            block1.GetComponent<Animator>().SetBool("virado", false);
            block2.GetComponent<Animator>().SetBool("virado", false);
            block3.GetComponent<Animator>().SetBool("virado", false);
            block4.GetComponent<Animator>().SetBool("virado", false);
            block5.GetComponent<Animator>().SetBool("virado", false);
            block6.GetComponent<Animator>().SetBool("virado", false);
            block7.GetComponent<Animator>().SetBool("virado", false);
            block8.GetComponent<Animator>().SetBool("virado", false);
            block9.GetComponent<Animator>().SetBool("virado", false);
            block10.GetComponent<Animator>().SetBool("virado", false);
      
        }
    }

    void checkIfWins()
    {
        if (blockOpen == textOpen)
        {
            ganhou = true;
        }
        else
        {
            openBlocks = 0;
            activateDelay = true;
        }
    }

    void delayTime()
    {
        if (activateDelay == true)
        {
            cronoDelay += Time.deltaTime;
            if (cronoDelay >= 1f)
            {
                closeBlocks();
                activateDelay = false;
                cronoDelay = 0f;
            }
        }
    }

    void correctChoose()
    {
        if (ganhou == true)
        {
            cronoDelay += Time.deltaTime;
            if (cronoDelay >= 1f)
            {
                if (blockOpen == 1)
                {
                    block1.SetActive(false);
                    text1.SetActive(false);
                }
                else if (blockOpen == 2)
                {
                    block2.SetActive(false);
                    text2.SetActive(false);
                }
                else if (blockOpen == 3)
                {
                    block3.SetActive(false);
                    text3.SetActive(false);
                }
                else if (blockOpen == 4)
                {
                    block4.SetActive(false);
                    text4.SetActive(false);
                }
                else if (blockOpen == 5)
                {
                    block5.SetActive(false);
                    text5.SetActive(false);
                }
                else if (blockOpen == 6)
                {
                    block6.SetActive(false);
                    text6.SetActive(false);
                }
                else if (blockOpen == 7)
                {
                    block7.SetActive(false);
                    text7.SetActive(false);
                }
                else if (blockOpen == 8)
                {
                    block8.SetActive(false);
                    text8.SetActive(false);
                }
                else if (blockOpen == 9)
                {
                    block9.SetActive(false);
                    text9.SetActive(false);
                }
                else if (blockOpen == 10)
                {
                    block10.SetActive(false);
                    text10.SetActive(false);
                }
                cronoDelay = 0;
                openBlocks = 0;
                acertos++;
                allowClicks = true;
                allowClickBlock = true;
                allowClickTexts = true;
                ganhou = false;
            }            
        }
    }

    void fimMiniGame()
    {
        if (acertos == 10)
        {
            cronoDelay += Time.deltaTime;
            if (cronoDelay >= 1f)
            {
                PlayerPrefs.SetInt("renascStep", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene("RenasciRoom");
            }
        }
    }

    public void ReabrirTutorial()
    {
        btnTutorial.SetActive(false);
        backgroundPanel.SetActive(true);
        tutorial.SetActive(true);
        allowClicks = false;
    }
}
