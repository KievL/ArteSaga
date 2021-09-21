using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public RaycastHit2D hit;
    public float posX;
    public float posY;

    public float velBala = 10f;

    public float velX, velY;

    public Rigidbody2D rb;

    public float crono = 0;
    // Start is called before the first frame update
    void Start()
    {
        posX = (((Input.mousePosition.x)*17.8f)/1130f)-8.9f;
        posY = ((Input.mousePosition.y)/64)-5;

        float distTotal = Mathf.Sqrt(Mathf.Pow(posX + 3.485f, 2) + Mathf.Pow(posY - 0.86f, 2));

        velX = (posX + 3.485f) * velBala / distTotal;
        velY = (posY - 0.86f) * velBala / distTotal;

        rb.velocity = new Vector2(velX, velY);
    }

    // Update is called once per frame
    void Update()
    {
        crono += Time.deltaTime;
        if (crono >= 1f)
        {
            Destroy(this.gameObject);
        }
           
    }  
}
