using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehavior : MonoBehaviour
{
    public Vector2 velCoin;
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
        this.GetComponent<Rigidbody2D>().velocity = velCoin; 
    }
    void destruirCoin()
    {
        if(this.transform.position.x <= -16.29f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pablo"))
        {
            Egito5Manager.coins++;
            Egito5Manager.playCoinSound = true;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("pedraEgito"))
        {
            Destroy(this.gameObject);
        }
    }
}
