using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bordasControler : MonoBehaviour
{
    public static bool desce = false;
    public Transform bordaCima;
    public Transform bordaBaixo;
    public bool umavez = false;
    public bool sobe = false;
    public float crono = 0;
    public GameObject tut1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(desce == true)
        {
            bordaCima.Translate(new Vector2(0, -0.20f) * Time.deltaTime);
            bordaBaixo.Translate(new Vector2(0, 0.20f) * Time.deltaTime);
        }
        if(bordaCima.position.y <= -0.3502029f && umavez == false)
        {
            bordaCima.Translate(new Vector2(0, 0));
            bordaBaixo.Translate(new Vector2(0, 0));
            desce = false;
            GameObject[] pessoasDestroy = GameObject.FindGameObjectsWithTag("persparados");
            foreach(GameObject pDes in pessoasDestroy)
            {
                GameObject.Destroy(pDes);
            }
            GameObject.Destroy(GameObject.FindGameObjectWithTag("falaprof"));
            GameObject.Destroy(GameObject.FindGameObjectWithTag("falaChanges"));

            GameObject.FindGameObjectWithTag("boia").GetComponent<Transform>().position = new Vector2(0.412f, -0.918f);
            GameObject.FindGameObjectWithTag("boyverde").GetComponent<Transform>().position = new Vector2(0.643f, -0.2266f);
            GameObject.FindGameObjectWithTag("prof").GetComponent<SpriteRenderer>().flipX = true;
            umavez = true;
            sobe = true;

        }
        if(sobe == true)
        {
            bordaCima.Translate(new Vector2(0, 0.20f) * Time.deltaTime);
            bordaBaixo.Translate(new Vector2(0, -0.20f) * Time.deltaTime);
            if(bordaCima.position.y >= 0.278f)
            {
                GameObject[] bords = GameObject.FindGameObjectsWithTag("bordas");
                foreach(GameObject b in bords)
                {
                    GameObject.Destroy(b);
                    
                }
                CameraFollowing.ir = true;
                pablo.liberado = true;
                sobe = false;
                tut1.SetActive(true);
            }
        }
    }   
}
