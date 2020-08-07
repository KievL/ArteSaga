using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuvemBehavior : MonoBehaviour
{
    public float vel;
    public float posY;
    public float posX;
    public int nuvemStyle;
    // Start is called before the first frame update
    void Start()
    {
        nuvemStyle = Random.Range(2, 6);
        this.GetComponent<Animator>().SetInteger("nuvemStyle", nuvemStyle);
        vel = Random.Range(0.1f, 0.7f);
        posY = Random.Range(3.55f, 4.31f);
        this.transform.position = new Vector2(this.transform.position.x, posY);
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-vel, 0);
        if(this.transform.position.x <= -25.05f)
        {
            Destroy(this.gameObject);
        }
    }
}
