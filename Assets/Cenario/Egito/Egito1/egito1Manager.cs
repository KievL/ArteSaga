using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egito1Manager : MonoBehaviour
{
    public GameObject piramide;
    public float velPiramide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        piramideWalk();
    }
    void piramideWalk()
    {
        if(piramide.transform.position.x >= -74.5f)
        {
            piramide.GetComponent<Rigidbody2D>().velocity = new Vector2(velPiramide, 0);
        }
        else
        {
            piramide.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        
    }
}
