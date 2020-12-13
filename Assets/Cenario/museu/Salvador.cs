using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salvador : MonoBehaviour
{
    public GameObject pabloMeuDeus;
    public GameObject refSalv;
    public static bool comprou = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RefSalvador(); 
    }
    void RefSalvador()
    {
        if (pabloMeuDeus.transform.position.x >= 7.109f && pabloMeuDeus.transform.position.x <= 7.5f && comprou ==false)
        {
            refSalv.SetActive(true);
        }
        else
        {
            refSalv.SetActive(false);
        }
    }
}
