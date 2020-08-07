using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faladoVei : MonoBehaviour
{
    public static bool falar = false;
    public float crono = 0;
    public float crono2 = 0;
    public float crono3 = 0;
    public float crono4 = 0;
    public float crono5 = 0;
    public float crono6 = 0;
    public bool pabloCorrer = false;
    public Transform elPablo;
    public static float runStep = 0;
    public bool baldeDerrubado = false;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(falar == true)
        {
            crono += Time.deltaTime;
            if(crono >=2)
            {
                GameObject.FindGameObjectWithTag("ferro").GetComponent<Transform>().position = new Vector2(8.138f, -0.7886f);
                pabloCorrer = true;
                falar = false;
            }
        }
        if(pabloCorrer == true)
        {
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("comer", false);
            GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = false;
            crono2 += Time.deltaTime;
            if(crono2 >= 1)
            {
                GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = true;
                runStep = 1;
                pabloCorrer = false;
            }
        }
        if(runStep== 1)
        {
            crono3 += Time.deltaTime;
            if(crono3 >= 1)
            {
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", true);
                elPablo.Translate(new Vector2(-0.6f, 0) * Time.deltaTime);
                if(elPablo.position.x <= 7.00649f)
                {
                    elPablo.Translate(new Vector2(0, 0));
                    runStep = 2;
                }
            }
        }
        if(runStep == 2)
        {
            GameObject.Destroy(GameObject.FindGameObjectWithTag("prof"));
            GameObject.Destroy(GameObject.FindGameObjectWithTag("recep"));
            GameObject.Destroy(GameObject.FindGameObjectWithTag("boyverde"));
            GameObject.Destroy(GameObject.FindGameObjectWithTag("boia"));

            GameObject.FindGameObjectWithTag("limpeza").GetComponent<Transform>().position = new Vector2(-0.192f, -0.843f);
            GameObject.FindGameObjectWithTag("balde").GetComponent<Transform>().position = new Vector2(-0.037f, -0.849f);
            CameraFollowing.cameraType = 7;
        }
        if(runStep == 4)
        {
            GameObject pabl = GameObject.FindGameObjectWithTag("pablo");
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", true);
            GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = true;
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().Translate(new Vector2(-0.75f, 0) * Time.deltaTime);
            if(baldeDerrubado == false && pabl.GetComponent<Transform>().position.x <= -0.007687639f)
            {
                GameObject.Destroy(GameObject.FindGameObjectWithTag("balde"));
                GameObject.Destroy(GameObject.FindGameObjectWithTag("balde2"));
                GameObject.FindGameObjectWithTag("balde3").GetComponent<Transform>().position = new Vector2(-0.141f, -0.843f);
                baldeDerrubado = true;
            }
            if(pabl.GetComponent<Transform>().position.x <= -2.372f)
            {
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando",false);
                GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().Translate(new Vector2(0, 0));
                runStep = 5;
            }
        }
        if(runStep == 5)
        {
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("surpreso", true);
            crono4 += Time.deltaTime;
            if(crono4 >= 3f)
            {
                runStep = 6;
            }
        }
        if(runStep== 6)
        {
            GameObject.FindGameObjectWithTag("pablo").GetComponent<SpriteRenderer>().flipX = false;
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("surpreso", false);
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", true);
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().Translate(new Vector2(0.75f, 0) * Time.deltaTime);
            if(GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().position.x >= -0.042f)
            {
                runStep = 7;
            }
        }
        if(runStep == 7)
        {
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("andando", false);
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().Translate(new Vector2(0.75f, 0) * Time.deltaTime);
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("escorregando", true);
            if(GameObject.FindGameObjectWithTag("pablo").GetComponent<Transform>().position.x >= 0.989)
            {
                runStep = 8;
            }

        }
        if(runStep== 8)
        {
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetBool("escorregando", false);
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetInteger("fasequeda", 1);
            crono5 += Time.deltaTime;
            if(crono5>= 1.3f)
            {
                runStep = 9;
            }
        }
        if(runStep == 9)
        {
            //Faz a animação de cair e depois manda o comando para mudar a câmera
            GameObject.FindGameObjectWithTag("pablo").GetComponent<Animator>().SetInteger("fasequeda", 2);
            crono6 += Time.deltaTime;
            if(crono6 >= 2f)
            {
                pabloCaido.comecar = true;
                runStep = -1;
            }
        }
    }
}
