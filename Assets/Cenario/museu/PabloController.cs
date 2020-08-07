using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PabloController : MonoBehaviour
{
    // Start is called before the first frame update
    public static float playerTurnAxisTouch = 0;
    public static int deitou = 0;
    public static int deitou1 = 0;
    public static float x = 0;
    public static int posicao = 0;

    public GameObject tut2;

    void Start()
    {        
    }

    // Update is called once per frame
    public void playerDireitaDown()
    {  

        if(pablo.liberado == true)
        {
            tut2.SetActive(false);
                posicao = 1;
        }
               
    }
    public void playerDiretiaUp()
    {


        posicao = 0;
    }

    public void playerLeftDown()
    {
        if (pablo.liberado == true)
        {
            tut2.SetActive(false);
            posicao = -1;
        }
        
    }  
    
}
