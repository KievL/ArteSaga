using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedraBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject go;
    public float velY;

    float crono = 0f;
    bool caiu = false;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0f, velY);
    }

    // Update is called once per frame
    void Update()
    {
        if (caiu == true)
        {
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                Destroy(this.gameObject);
            }
            rb.velocity = new Vector2(0f, 0f);
            go.GetComponent<Animator>().SetBool("caiu", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bordas") && caiu==false)
        {
            gotica2Manager.bateuPedra = true;
        }
        if (collision.gameObject.CompareTag("chaoSelva") && caiu==false)
        {         
            caiu = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bordas") && caiu == false)
        {
            gotica2Manager.bateuPedra = true;
        }
        if (collision.gameObject.CompareTag("chaoSelva") && caiu == false)
        {
            caiu = true;
        }
    }
}
