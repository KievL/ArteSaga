using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Egito5Manager : MonoBehaviour
{
    public static bool running;
    public float forcaPulo;

    public GameObject pablo;

    public GameObject pfJarro1;
    public GameObject pfJarro2;
    public GameObject coin;

    public static bool noChao;

    public float cronoSpawn = 0;
    public float spawnDeltaTime;
    public bool podeSpawnar = false;

    public static bool bateu = false;
    public bool bateuChild = false;

    public static AudioClip oof;
    public static AudioClip vaso;

    public static AudioClip coinAudio;
    public static bool playCoinSound = false;

    static AudioSource audioSrc;

    public static int coins = 0;
    public static int coinsTotal = 0;

    public Text txtCoin;
    public Text txtHeads;

    public RaycastHit2D hit;

    public GameObject osiris, horus, anubis, isis, neftis, ranum, sobek, thot;
    public static bool osirisB, horusB, anubisB, isisB, neftisB, ranumB, sobekB, thotB;
    public static int cabecas = 0;
    public int aparecerHeads = 0;
    public float timeHeads = 0;

    public GameObject painelFinal;

    public GameObject btnJump, btnTut, btnJumpTut;
    public int tutStep = 0;

    // Start is called before the first frame update
    void Start()
    {

        oof = Resources.Load<AudioClip>("uuh");
        vaso = Resources.Load<AudioClip>("vasoBreak");
        coinAudio = Resources.Load<AudioClip>("coinSound");
        audioSrc = GetComponent<AudioSource>();
        coinsTotal = 0;
        cabecas = 0;
        running = true;
        anubisB = false;
        osirisB = false;
        horusB = false;
        isisB = false;
        sobekB = false;
        ranumB = false;
        neftisB = false;
        thotB = false;
        btnJump.SetActive(false);
        btnTut.SetActive(true);
        btnJumpTut.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnController();
        playCoinSoundMethod();

        txtCoin.text = coins.ToString();
        pegarCabeca();
        txtHeads.text = cabecas.ToString();

    }
    void SpawnController()
    {
        if (podeSpawnar == true)
        {
            cronoSpawn += Time.deltaTime;
            if (cronoSpawn >= spawnDeltaTime)
            {
                SpawnLeva();
                cronoSpawn = 0;
            }
        }
    }
    void SpawnLeva()
    {
        float levaType = Random.Range(0.0f, 1.0f);
        float firstType = Random.Range(0.0f, 1.0f);
        float secType = Random.Range(0.0f, 1.0f);
        if (levaType <= 0.333f)
        {
            if (firstType < 0.5f)
            {
                GameObject jarro1 = Instantiate(pfJarro1) as GameObject;
                jarro1.transform.position = new Vector2(14.66f, -2.57f);
            }
            else
            {
                GameObject jarro1 = Instantiate(pfJarro2) as GameObject;
                jarro1.transform.position = new Vector2(14.66f, -2.57f);
            }
            if (secType < 0.5f)
            {
                GameObject jarro2 = Instantiate(pfJarro1) as GameObject;
                jarro2.transform.position = new Vector2(22.47f, -2.57f);
            }
            else
            {
                GameObject jarro2 = Instantiate(pfJarro2) as GameObject;
                jarro2.transform.position = new Vector2(22.47f, -2.57f);
            }
            GameObject coin1 = Instantiate(coin) as GameObject;
            coin1.transform.position = new Vector2(17.2f, -2.57f);
            GameObject coin2 = Instantiate(coin) as GameObject;
            coin2.transform.position = new Vector2(19.76f, -2.57f);
            coinsTotal += 2;

        }
        else if(levaType >0.333f && levaType <= 0.666f)
        {
            if (firstType < 0.5f)
            {
                GameObject jarro1 = Instantiate(pfJarro1) as GameObject;
                jarro1.transform.position = new Vector2(17.2f, -2.57f);
            }
            else
            {
                GameObject jarro1 = Instantiate(pfJarro2) as GameObject;
                jarro1.transform.position = new Vector2(17.2f, -2.57f);
            }
            GameObject coin1 = Instantiate(coin) as GameObject;
            coin1.transform.position = new Vector2(19.76f, -2.57f);
            coinsTotal++;
        }
        else
        {
            if (firstType < 0.5f)
            {
                GameObject jarro1 = Instantiate(pfJarro1) as GameObject;
                jarro1.transform.position = new Vector2(19.76f, -2.57f);
            }
            else
            {
                GameObject jarro1 = Instantiate(pfJarro2) as GameObject;
                jarro1.transform.position = new Vector2(19.76f, -2.57f);
            }
            GameObject coin1 = Instantiate(coin) as GameObject;
            coin1.transform.position = new Vector2(17.2f, -2.57f);
            coinsTotal++;
        }
    }
    
    public void pabloPular()
    {
        if(podeSpawnar==true && noChao == true)
        {
            pablo.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forcaPulo));
        } 
    }
    public static void bateuJarro()
    {
        bateu = true;
        pabloEgito5Behav.pabloAfetado = true;
        audioSrc.PlayOneShot(oof);
        audioSrc.PlayOneShot(vaso);

    }
    void Bateu()
    {
        if(bateu == true)
        {
            bateuChild = true;
        }
        
    }
    public void recomecar()
    {
        coins = 0;
        coinsTotal = 0;
        cabecas = 0;
        SceneManager.LoadScene("Egito5");
        anubisB = false;
        horusB = false;
        isisB = false;
        neftisB = false;
        sobekB = false;
        ranumB = false;
        thotB = false;
        osirisB = false;

        Time.timeScale = 1f;

    }
    void playCoinSoundMethod()
    {
        if (playCoinSound == true)
        {
            audioSrc.PlayOneShot(coinAudio);
            playCoinSound = false;
        }
    }
    void pegarCabeca()
    {
        timeHeads += Time.deltaTime;
        if (timeHeads >= 10f && aparecerHeads==0)
        {
            aparecerHeads++;
            anubis.SetActive(true);

        }
        if (timeHeads>= 20f && aparecerHeads == 1)
        {
            aparecerHeads++;
            isis.SetActive(true);
        }
        if (timeHeads >= 30f && aparecerHeads == 2)
        {
            aparecerHeads++;
            thot.SetActive(true);
        }
        if (timeHeads >= 40f && aparecerHeads == 3)
        {
            aparecerHeads++;
            sobek.SetActive(true);
        }
        if (timeHeads >= 50f && aparecerHeads == 4)
        {
            aparecerHeads++;
            osiris.SetActive(true);
        }
        if (timeHeads >= 60f && aparecerHeads == 5)
        {
            aparecerHeads++;
            neftis.SetActive(true);
        }
        if (timeHeads >= 70f && aparecerHeads == 6)
        {
            aparecerHeads++;
            ranum.SetActive(true);
        }
        if (timeHeads >= 80f && aparecerHeads == 7)
        {
            aparecerHeads++;
            horus.SetActive(true);
        }
        if (timeHeads >= 90)
        {
            painelFinal.SetActive(true);
            if (timeHeads >= 90.5)
            {
                SceneManager.LoadScene("Egito6");
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.CompareTag("primitivo") && Time.timeScale>0.5f)
            {
                if(hit.transform.gameObject == anubis )
                {
                    anubis.GetComponent<Animator>().SetBool("clickado", true);
                    if (anubisB == false)
                    {
                        cabecas++;
                    }
                    anubisB = true;                    
                }
                if (hit.transform.gameObject == isis)
                {
                    isis.GetComponent<Animator>().SetBool("clickado", true);
                    if (isisB == false)
                    {
                        cabecas++;
                    }
                    isisB = true;
                    
                }
                if (hit.transform.gameObject == thot)
                {
                    thot.GetComponent<Animator>().SetBool("clickado", true);
                    if (thotB == false)
                    {
                        cabecas++;
                    }
                    thotB = true;
                    
                }
                if (hit.transform.gameObject == sobek)
                {
                    sobek.GetComponent<Animator>().SetBool("clickado", true);
                    if (sobekB == false)
                    {
                        cabecas++;
                    }
                    sobekB = true;
                    
                }
                if (hit.transform.gameObject == osiris)
                {
                    osiris.GetComponent<Animator>().SetBool("clickado", true);
                    if (osirisB == false)
                    {
                        cabecas++;
                    }
                    osirisB = true;
                    
                }
                if (hit.transform.gameObject == neftis)
                {
                    neftis.GetComponent<Animator>().SetBool("clickado", true);
                    if (neftisB == false)
                    {
                        cabecas++;
                    }
                    neftisB = true;
                    
                }
                if (hit.transform.gameObject == ranum)
                {
                    ranum.GetComponent<Animator>().SetBool("clickado", true);
                    if (ranumB == false)
                    {
                        cabecas++;
                    }
                    ranumB = true;
                    
                }
                if (hit.transform.gameObject == horus)
                {
                    horus.GetComponent<Animator>().SetBool("clickado", true);
                    if (horusB == false)
                    {
                        cabecas++;
                    }
                    horusB = true;
                    
                }
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.CompareTag("primitivo"))
            {
                if (hit.transform.gameObject == anubis)
                {
                    anubis.GetComponent<Animator>().SetBool("clickado", true);
                    if (anubisB == false)
                    {
                        cabecas++;
                    }
                    anubisB = true;
                    
                }
                if (hit.transform.gameObject == isis)
                {
                    isis.GetComponent<Animator>().SetBool("clickado", true);
                    if (isisB == false)
                    {
                        cabecas++;
                    }
                    isisB = true;
                    
                }
                if (hit.transform.gameObject == thot)
                {
                    thot.GetComponent<Animator>().SetBool("clickado", true);
                    if (thotB == false)
                    {
                        cabecas++;
                    }
                    thotB = true;
                    
                }
                if (hit.transform.gameObject == sobek)
                {
                    sobek.GetComponent<Animator>().SetBool("clickado", true);
                    if (sobekB == false)
                    {
                        cabecas++;
                    }
                    sobekB = true;
                    
                }
                if (hit.transform.gameObject == osiris)
                {
                    osiris.GetComponent<Animator>().SetBool("clickado", true);
                    if (osirisB == false)
                    {
                        cabecas++;
                    }
                    osirisB = true;
                    
                }
                if (hit.transform.gameObject == neftis)
                {
                    neftis.GetComponent<Animator>().SetBool("clickado", true);
                    if (neftisB == false)
                    {
                        cabecas++;
                    }
                    neftisB = true;
                    
                }
                if (hit.transform.gameObject == ranum)
                {
                    ranum.GetComponent<Animator>().SetBool("clickado", true);
                    if (ranumB == false)
                    {
                        cabecas++;
                    }
                    ranumB = true;
                    
                }
                if (hit.transform.gameObject == horus)
                {
                    horus.GetComponent<Animator>().SetBool("clickado", true);
                    if (horusB == false)
                    {
                        cabecas++;
                    }
                    horusB = true;
                    
                }
            }
        }
    }
    public void tutAv()
    {
        tutStep++;
        if (tutStep == 1)
        {
            btnTut.GetComponent<Animator>().SetInteger("tut", 1);
        }
        else if (tutStep == 2)
        {
            btnTut.GetComponent<Animator>().SetInteger("tut", 2);
        }
        else if (tutStep == 3)
        {
            btnTut.SetActive(false);
            btnJumpTut.SetActive(false);
            btnJump.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    public void jumpTut()
    {
        btnTut.SetActive(false);
        btnJumpTut.SetActive(false);
        btnJump.SetActive(true);
        Time.timeScale = 1f;
    }
}
