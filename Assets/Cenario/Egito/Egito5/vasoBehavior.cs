using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vasoBehavior : MonoBehaviour
{
    public Vector2 velVaso;

    public float pedraPos;
    public GameObject pedra;
    public GameObject pablo;
    // Start is called before the first frame update
    void Start()
    {
        pedra = GameObject.FindGameObjectWithTag("pedraEgito");
    }

    // Update is called once per frame
    void Update()
    {
        pedraPos = pedra.transform.position.x;
        this.GetComponent<Rigidbody2D>().velocity = velVaso;
        if(this.transform.position.x <= pedraPos + 3.85f)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pablo"))
        {
            Egito5Manager.bateuJarro();
            Destroy(this.gameObject);
        }
    }
}
