using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pabloCaido : MonoBehaviour
{
    public static bool comecar = false;
    public static bool levantar = false;
    public static bool mudar_de_cena = false;
    public float crono = 0;
    public float crono2 = 0;
    public float crono3 = 0;
    public float crono4 = 0;
    public float crono5 = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (comecar == true)
        {
            //Muda a posicao e tamanho da camera para mostrar pablo caido
            CameraFollowing.ir = false;
            CameraFollowing.go = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(3.263f, 3.343f, -10f);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 0.07229972f;
            crono += Time.deltaTime;
            if (crono >= 2.5f)
            {
                crono4 += Time.deltaTime;
                if(crono4 >= 2f)
                {
                    levantar = true;
                }
                GameObject.FindGameObjectWithTag("light").GetComponent<Animator>().SetBool("claro", true);
                crono2 += Time.deltaTime;
                if(crono2 >= 3.42f)
                {

                    GameObject.FindGameObjectWithTag("light").GetComponent<Animator>().SetBool("claro", false);


                    comecar = false;
                }
            }
        }
        if (levantar == true)
        {
            GameObject.FindGameObjectWithTag("pabloCaido").GetComponent<Animator>().SetBool("acordar", true);
            crono3 += Time.deltaTime;
            if (crono3 >= 4.5f)
            {                
                mudar_de_cena = true;
                levantar = false;
            }
        }
        if(mudar_de_cena == true)
        {
            crono5 += Time.deltaTime;
            if(crono5 >= 1f)
            {
                GameObject.Destroy(GameObject.FindGameObjectWithTag("pabloCaido"));
                SceneManager.LoadScene("SalaPortais");
                mudar_de_cena = false;
            }
        }
    }
}
