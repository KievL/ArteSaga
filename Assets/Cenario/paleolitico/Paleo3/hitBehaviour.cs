using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBehaviour : MonoBehaviour
{
    public Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>().position = new Vector3(-6.38f, -1.42f, 0);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        force = new Vector2(Paleo3Manager.velX1, Paleo3Manager.velY1);
        this.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Transform>().position.y <= -3.06f)
        {
            Destroy(this.gameObject);

        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Animal")
        {
            Paleo3Manager.ganhou = true;
            Time.timeScale = 0f;
        }
    }
}
