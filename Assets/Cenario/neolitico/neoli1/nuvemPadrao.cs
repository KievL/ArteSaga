using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuvemPadrao : MonoBehaviour
{
    public float vel;
    public int nuvemStyle;
    // Start is called before the first frame update
    void Start()
    {
        nuvemStyle = Random.Range(2, 6);
        this.GetComponent<Animator>().SetInteger("nuvemStyle", nuvemStyle);
        vel = Random.Range(0.1f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-vel, 0);
        if (this.transform.position.x <= -25.05f)
        {
            Destroy(this.gameObject);
        }
    }
}
