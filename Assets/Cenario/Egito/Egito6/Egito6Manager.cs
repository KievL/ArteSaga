using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Egito6Manager : MonoBehaviour
{
    public GameObject pablo;
    public Vector2 velPablo;
    public int sceneStep=1;

    public GameObject startBtn, imgTut;
    public GameObject enigmaGeral;

    public bool comecou = false;
    public float tempoEnigma;

    public Text txtTempo;

    public int head1, head2, head3;
    public int headRandom1, headRandom2, headRandom3;
    public Text txtHead1, txtHead2, txtHead3;
    public GameObject head1GO, head2GO, head3GO;

    public bool ganhou = false;

    public float crono1 = 0;

    public GameObject osiris, horus, anubis, isis, neftis, ranum, sobek, thot;

    static AudioSource audioSrc;
    public static AudioClip tobe;
    public static AudioClip pointsSound;
    public bool pointsDisplayed = false;
    public static AudioClip endSound;
    public bool endDisplayed = false;

    public bool tobeBool = false;

    public GameObject pedra;
    public Vector2 velPedra;

    public float rotationSpeed;

    public GameObject canvasDeath;

    public GameObject painelBlack, btnRecomecar, btnTryAgain;

    public GameObject canvasWin, panelWhite, panelBlackWin, txtPont, txtMoedas, txtGods, txtTime, coin, god, clock,
        btnGo, coins, gods, time, finalScore;
    public float cronoWin = 0;
    public int winStep = 0;
    public Text textCoins, textGods, textTime, textFinalScore;
    public static float finalScoreGeral;



    // Start is called before the first frame update
    void Start()
    {
        tobe = Resources.Load<AudioClip>("tobecontinued");
        pointsSound = Resources.Load<AudioClip>("pointsEg6");
        endSound = Resources.Load<AudioClip>("endEg6");
        audioSrc = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        Chegando();
        Tuto();
        noEnigma();
        changeHeads();
        perdeuEnigma();
        ganhouEnigma();
    }
    void Chegando()
    {
        if (sceneStep == 1)
        {
            pablo.GetComponent<Animator>().SetBool("running", true);
            pablo.GetComponent<Rigidbody2D>().velocity = velPablo;
            if(pablo.transform.position.x >= -4.66f)
            {
                sceneStep++;
            }
        }
    }
    void Tuto()
    {
        if (sceneStep == 2)
        {
            pablo.GetComponent<Animator>().SetBool("running", false);
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            startBtn.SetActive(true);
            imgTut.SetActive(true);
            sceneStep++;

        }
    }
    public void comecarEnigma()
    {
        comecou = true;
        imgTut.SetActive(false);
        startBtn.SetActive(false);
    }
    void noEnigma()
    {
        if(sceneStep==3 && comecou == true)
        {
            headRandom1 = UnityEngine.Random.Range(1, 8);
            headRandom2 = UnityEngine.Random.Range(1, 8);
            if (headRandom2 != headRandom1)
            {
                headRandom3 = UnityEngine.Random.Range(1, 8);
                if(headRandom3!=headRandom2 && headRandom3!= headRandom1)
                {
                    sceneStep++;
                }
            }
        }
        if(sceneStep==4 && comecou == true && ganhou==false)
        {
            textoHeads();
            txtTempo.text = Math.Round(tempoEnigma, 2).ToString();
            if (ganhou == false)
            {
                tempoEnigma -= Time.deltaTime;
            }
            enigmaGeral.SetActive(true);
            if (Egito5Manager.anubisB == true)
            {
                anubis.SetActive(true);
            }
            if (Egito5Manager.horusB == true)
            {
                horus.SetActive(true);

            }
            if (Egito5Manager.isisB == true)
            {
                isis.SetActive(true);
            }
            if (Egito5Manager.neftisB == true)
            {
                neftis.SetActive(true);
            }
            if (Egito5Manager.sobekB == true)
            {
                sobek.SetActive(true);
            }
            if (Egito5Manager.osirisB == true)
            {
                osiris.SetActive(true);
            }
            if (Egito5Manager.ranumB == true)
            {
                ranum.SetActive(true);
            }
            if (Egito5Manager.thotB == true)
            {
                thot.SetActive(true);
            }
        }
    }
    public void dir1()
    {
        if (ganhou == false)
        {
            head1++;
            loopHeads();
        }
        
    }
    public void dir2()
    {
        if (ganhou == false)
        {
            head2++;
            loopHeads();
        }
        
    }
    public void dir3()
    {
        if (ganhou == false)
        {
            head3++;
            loopHeads();
        }
        
    }
    public void esq1()
    {
        if (ganhou == false)
        {
            head1--;
            loopHeads();
        }
        
    }
    public void esq2()
    {
        if (ganhou == false)
        {
            head2--;
            loopHeads();
        }
        
    }
    public void esq3()
    {
        if (ganhou == false)
        {
            head3--;
            loopHeads();
        }
        
    }
    void loopHeads()
    {
        if (head1 < 1)
        {
            head1 = 8;
        }
        if (head1 > 8)
        {
            head1 = 1;
        }
        if (head2 < 1)
        {
            head2 = 8;
        }
        if (head2 > 8)
        {
            head2 = 1;
        }
        if (head3 < 1)
        {
            head3 = 8;
        }
        if (head3 > 8)
        {
            head3 = 1;
        }
    }
    void changeHeads()
    {
        if (head1 == 1)
        {
            head1GO.GetComponent<Animator>().SetInteger("cabe3", 1);
        }
        else if (head1 == 2)
        {
            head1GO.GetComponent<Animator>().SetInteger("cabe3", 2);
        }
        else if (head1 == 3)
        {
            head1GO.GetComponent<Animator>().SetInteger("cabe3", 3);
        }
        else if (head1 == 4)
        {
            head1GO.GetComponent<Animator>().SetInteger("cabe3", 4);
        }
        else if (head1 == 5)
        {
            head1GO.GetComponent<Animator>().SetInteger("cabe3", 5);
        }
        else if (head1 == 6)
        {
            head1GO.GetComponent<Animator>().SetInteger("cabe3", 6);
        }
        else if (head1 == 7)
        {
            head1GO.GetComponent<Animator>().SetInteger("cabe3", 7);
        }
        else
        {
            head1GO.GetComponent<Animator>().SetInteger("cabe3", 8);
        }

        if (head2 == 1)
        {
            head2GO.GetComponent<Animator>().SetInteger("cabe3", 1);
        }
        else if (head2 == 2)
        {
            head2GO.GetComponent<Animator>().SetInteger("cabe3", 2);
        }
        else if (head2 == 3)
        {
            head2GO.GetComponent<Animator>().SetInteger("cabe3", 3);
        }
        else if (head2 == 4)
        {
            head2GO.GetComponent<Animator>().SetInteger("cabe3", 4);
        }
        else if (head2 == 5)
        {
            head2GO.GetComponent<Animator>().SetInteger("cabe3", 5);
        }
        else if (head2 == 6)
        {
            head2GO.GetComponent<Animator>().SetInteger("cabe3", 6);
        }
        else if (head2 == 7)
        {
            head2GO.GetComponent<Animator>().SetInteger("cabe3", 7);
        }
        else
        {
            head2GO.GetComponent<Animator>().SetInteger("cabe3", 8);
        }

        if (head3 == 1)
        {
            head3GO.GetComponent<Animator>().SetInteger("cabe3", 1);
        }
        else if (head3 == 2)
        {
            head3GO.GetComponent<Animator>().SetInteger("cabe3", 2);
        }
        else if (head3 == 3)
        {
            head3GO.GetComponent<Animator>().SetInteger("cabe3", 3);
        }
        else if (head3 == 4)
        {
            head3GO.GetComponent<Animator>().SetInteger("cabe3", 4);
        }
        else if (head3 == 5)
        {
            head3GO.GetComponent<Animator>().SetInteger("cabe3", 5);
        }
        else if (head3 == 6)
        {
            head3GO.GetComponent<Animator>().SetInteger("cabe3", 6);
        }
        else if (head3 == 7)
        {
            head3GO.GetComponent<Animator>().SetInteger("cabe3", 7);
        }
        else
        {
            head3GO.GetComponent<Animator>().SetInteger("cabe3", 8);
        }
    }
    void textoHeads()
    {
        if (headRandom1 == 1)
        {
            txtHead1.text = "Ísis";
        }
        if (headRandom1 == 2)
        {
            txtHead1.text = "Néftis";
        }
        if (headRandom1 == 3)
        {
            txtHead1.text = "Hórus";
        }
        if (headRandom1 == 4)
        {
            txtHead1.text = "Thoth";
        }
        if (headRandom1 == 5)
        {
            txtHead1.text = "Osíris";
        }
        if (headRandom1 == 6)
        {
            txtHead1.text = "Sobek";
        }
        if (headRandom1 == 7)
        {
            txtHead1.text = "Anúbis";
        }
        if (headRandom1 == 8)
        {
            txtHead1.text = "Rá";
        }

        if (headRandom2 == 1)
        {
            txtHead2.text = "Ísis";
        }
        if (headRandom2 == 2)
        {
            txtHead2.text = "Néftis";
        }
        if (headRandom2 == 3)
        {
            txtHead2.text = "Hórus";
        }
        if (headRandom2 == 4)
        {
            txtHead2.text = "Thoth";
        }
        if (headRandom2 == 5)
        {
            txtHead2.text = "Osíris";
        }
        if (headRandom2 == 6)
        {
            txtHead2.text = "Sobek";
        }
        if (headRandom2 == 7)
        {
            txtHead2.text = "Anúbis";
        }
        if (headRandom2 == 8)
        {
            txtHead2.text = "Rá";
        }

        if (headRandom3 == 1)
        {
            txtHead3.text = "Ísis";
        }
        if (headRandom3 == 2)
        {
            txtHead3.text = "Néftis";
        }
        if (headRandom3 == 3)
        {
            txtHead3.text = "Hórus";
        }
        if (headRandom3 == 4)
        {
            txtHead3.text = "Thoth";
        }
        if (headRandom3 == 5)
        {
            txtHead3.text = "Osíris";
        }
        if (headRandom3 == 6)
        {
            txtHead3.text = "Sobek";
        }
        if (headRandom3 == 7)
        {
            txtHead3.text = "Anúbis";
        }
        if (headRandom3 == 8)
        {
            txtHead3.text = "Rá";
        }
    }

    void ganhouEnigma()
    {
        if(headRandom1==head1 && headRandom2 == head2 && headRandom3 == head3)
        {
            ganhou = true;
        }
        if (ganhou == true)
        {
            cronoWin += Time.deltaTime;
            if (cronoWin >= 1.5f && winStep==0)
            {
                enigmaGeral.SetActive(false);
                winStep = 1;

            }
            if (cronoWin >= 2.25f && winStep == 1)
            {
                canvasWin.SetActive(true);
                winStep = 2;                    
            }
            if (cronoWin >= 3.45f&& winStep == 2)
            {
                panelBlackWin.SetActive(true);
                txtPont.SetActive(true);
                if (pointsDisplayed == false)
                {
                    audioSrc.PlayOneShot(pointsSound);
                    pointsDisplayed = true;
                }

            }
            if (cronoWin >= 3.55f && winStep == 2)
            {
                txtMoedas.SetActive(true);
                coin.SetActive(true);
                coins.SetActive(true);
                textCoins.text = Egito5Manager.coins.ToString()+"/"+Egito5Manager.coinsTotal.ToString();
            }
            if (cronoWin >= 4.55f && winStep == 2)
            {
                txtGods.SetActive(true);
                god.SetActive(true);
                gods.SetActive(true);
                textGods.text = Egito5Manager.cabecas.ToString() + "/8";
            }
            if (cronoWin >= 5.45f && winStep == 2)
            {
                txtTime.SetActive(true);
                time.SetActive(true);
                clock.SetActive(true);
                textTime.text = Math.Round(tempoEnigma,1).ToString() + "/15";
            }
            if (cronoWin >= 6.55f && winStep == 2)
            {
                if (endDisplayed == false)
                {
                    audioSrc.PlayOneShot(endSound);
                    endDisplayed = true;
                }
                if (Egito5Manager.coinsTotal == 0)
                {
                    finalScoreGeral = ((((Egito5Manager.coins / 30) + (Egito5Manager.cabecas / 8)) * 4000) + (tempoEnigma * 2000 / 11)) / 10;
                }
                else
                {
                    finalScoreGeral = ((((Egito5Manager.coins / Egito5Manager.coinsTotal) + (Egito5Manager.cabecas / 8)) * 4000) + (tempoEnigma * 2000 / 11)) / 10;
                }                
                finalScore.SetActive(true);
                textFinalScore.text = "Score: "+Math.Round(finalScoreGeral,0).ToString();
                if(finalScoreGeral> PlayerPrefs.GetFloat("egitoHighScore"))
                {
                    PlayerPrefs.SetFloat("egitoHighScore", finalScoreGeral);
                }
                btnGo.SetActive(true);
                PlayerPrefs.SetInt("EgitoLivroStep", 3);
                PlayerPrefs.SetInt("EgitoStep", 0);
            }
        }
    }

    void perdeuEnigma()
    {
        if (tempoEnigma <= 0f)
        {
            sceneStep = 5;
            enigmaGeral.SetActive(false);
            if (tobeBool == false)
            {
                audioSrc.PlayOneShot(tobe);
                tobeBool = true;
            }

        }
        if (sceneStep == 5)
        {
            crono1 += Time.deltaTime;

            if (crono1 < 3.47f)
            {
                pedra.GetComponent<Rigidbody2D>().velocity = velPedra;
                pedra.transform.Rotate(new Vector3(0, 0, rotationSpeed));
            }
            
            if(crono1>= 3.27f)
            {
                pablo.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (crono1 >= 3.47f)
            {
                canvasDeath.SetActive(true);                
                pedra.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                pedra.transform.Rotate(new Vector3(0, 0, 0));
            }
            if(crono1 >= 8.57f)
            {
                painelBlack.SetActive(true);
                btnRecomecar.SetActive(true);
                btnTryAgain.SetActive(true);
            }
        }
    }
    public void voltarMiniGame()
    {
        SceneManager.LoadScene("Egito5");
        Egito5Manager.anubisB = false;
        Egito5Manager.osirisB = false;
        Egito5Manager.horusB = false;
        Egito5Manager.isisB = false;
        Egito5Manager.sobekB = false;
        Egito5Manager.ranumB = false;
        Egito5Manager.neftisB = false;
        Egito5Manager.thotB = false;

    }
    public void tryAgainEnigma()
    {
        SceneManager.LoadScene("Egito6");
    }

    public void acabar()
    {

        SceneManager.LoadScene("idadeantiga");
    }
}
