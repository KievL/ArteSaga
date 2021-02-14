using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMovinh : MonoBehaviour
{
    public GameObject wall1, wall2, wall3;
    public float limLeft;
    public Vector2 frontPlace;
    public Vector2 wallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Egito5Manager.running == true)
        {
            wall1.GetComponent<Rigidbody2D>().velocity = wallSpeed;
            wall2.GetComponent<Rigidbody2D>().velocity = wallSpeed;
            wall3.GetComponent<Rigidbody2D>().velocity = wallSpeed;
        }
        if(wall1.transform.position.x <= limLeft)
        {
            wall1.transform.position = frontPlace;
        }
        if (wall2.transform.position.x <= limLeft)
        {
            wall2.transform.position = frontPlace;
        }
        if (wall3.transform.position.x <= limLeft)
        {
            wall3.transform.position = frontPlace;
        }        
    }
}
