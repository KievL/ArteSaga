using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesBehavior : MonoBehaviour
{
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Neoli1Manager.tree3Got == true)
        {
            tree1.GetComponent<Animator>().SetBool("cortada", true);
        }
        if (Neoli1Manager.tree2Got == true)
        {
            tree2.GetComponent<Animator>().SetBool("cortada", true);
        }
        if (Neoli1Manager.tree1Got == true)
        {
            tree3.GetComponent<Animator>().SetBool("cortada", true);
        }
        if (Neoli1Manager.tree4Got == true)
        {
            tree4.GetComponent<Animator>().SetBool("cortada", true);
        }


    }
}
