using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanchonete : MonoBehaviour
{
    public Transform pabloTransform;
    public Transform botaoComer;
    public bool btnCanShow = true;
    public static bool comerDown = false;
    public int fases = 0;
    public float crono1 = 0;
    public float crono2 = 0;
    public static int dinheiro = 0;
    public bool destroi = false;
    SpriteRenderer rend;

    public GameObject portaoFechado;
    public GameObject portaoAberto;
    public GameObject portaoAberto2;
    public GameObject luz;
    // Start is called before the first frame update
    void Start()
    {
        rend = GameObject.FindGameObjectWithTag("money").GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("PaleoStep", 1);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (pablo.fominha == true && pabloTransform.position.x >= 2.675992f && pabloTransform.position.x <= 4.152f)
        {
            pabloTransform.position = new Vector3(7.024f, -0.923f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(7.634f, -0.8539994f, -10.63f);
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        if (pabloTransform.position.x <= 6.85f && pabloTransform.position.x >= 6)
        {
            pabloTransform.position = new Vector3(2.64f, -0.926f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(2.029f, -0.8539994f, -10.63f);
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        if (pabloTransform.position.x >= 7.795f && btnCanShow == true)
        {
            float posx = GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().position.x;
            float posy = GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().position.y;
            float posz = GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().position.z;
            botaoComer.position = new Vector3(posx, posy + 0.21f, posz);
        }
        else
        {
            botaoComer.position = new Vector2(8.125f, 0.053f);
        }
        if (comerDown == true)
        {
            portaoFechado.transform.position = new Vector3(-3.217f, -0.276f, -0.4f);
            luz.transform.position = new Vector2(-3.82f, -0.2829132f);
            portaoAberto.transform.position = new Vector2(-3.614f, -0.6279132f);
            portaoAberto2.transform.position = new Vector2(-3.529f, -0.342f);
            Rigidbody2D rb = GameObject.FindGameObjectWithTag("pablo").GetComponent<Rigidbody2D>();
            pablo.liberado = false;
            pablo.poderMover = false;
            rb.velocity = new Vector2(0, 0);
            crono1 += Time.deltaTime;
            if (fases == 0)
            {
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", false);
                if (crono1 >= 0.65f)
                {
                    fases = 1;
                }
            }
            if (fases == 1)
            {
                GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = true;
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", true);
                pabloTransform.Translate(new Vector2(-0.6f, 0) * Time.deltaTime);
                if (pabloTransform.position.x <= 7.364004f)
                {
                    Salvador.comprou = true;
                    GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = false;
                    GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", false);
                    GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("comer", true);
                    pabloTransform.Translate(new Vector2(0, 0));

                    fases = 2;
                }
            }
            if (fases == 2)
            {
                CameraFollowing.cameraType = 5;
                fases = 3;
            }
            if (fases == 3)
            {

            }
        }
        if (dinheiro == 1)
        {
            StartCoroutine("FadeOut");
            float posx2 = GameObject.FindGameObjectWithTag("pablo").transform.position.x;
            float posy2 = GameObject.FindGameObjectWithTag("pablo").transform.position.y;
            GameObject.FindGameObjectWithTag("money").transform.position = new Vector2(posx2 + 0.096f, posy2 + 0.125f);
            destroi = true;
            dinheiro = 2;

        }
        if (dinheiro == 2)
        {

            GameObject.FindGameObjectWithTag("money").GetComponent<Transform>().Translate(new Vector2(0, 0.19f) * Time.deltaTime);

        }

        if(destroi == true)
        {
            crono2 += Time.deltaTime;
            if (crono2 >= 2)
            {
                dinheiro = 3;
                GameObject.Destroy(GameObject.FindGameObjectWithTag("money"));
                destroi = false;
            }
        }



    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
