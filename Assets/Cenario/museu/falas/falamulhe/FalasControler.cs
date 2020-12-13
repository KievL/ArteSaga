using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalasControler : MonoBehaviour
{
    public static bool inicio = false;
    public float cronom = 0;
    public int actualFala=1;
    public GameObject tut2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inicio == true)
        {
            GetComponent<Animator>().SetInteger("derc", actualFala);

        }
        if(actualFala >= 6)
        {            
            inicio = false;
            cronom += Time.deltaTime;
            if(cronom >= 1.5f)
            {
                bordasControler.desce = true;
            }
        }
    }
    public void Mudar()
    {
        tut2.SetActive(false);
        if(inicio == true)
        {
            actualFala = actualFala + 1;
        }
        
    }    
}
