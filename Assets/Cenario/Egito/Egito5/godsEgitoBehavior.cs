using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godsEgitoBehavior : MonoBehaviour
{
    public Vector2 velo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocidade();
    }
    void velocidade()
    {
        this.GetComponent<Rigidbody2D>().velocity = velo;
        if(this.transform.position.x <= -13.58f)
        {
            Destroy(this.gameObject);
        }
    }
}
