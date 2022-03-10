using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boy2walker : MonoBehaviour
{
    public float crono;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.15f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        crono += Time.deltaTime;
        if (crono > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
