using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcoController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    public Animator fade;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        if (transform.position.x >= 59.0f)
        {
            FadeOut();
        }
    }

     void FadeOut()
    {
        fade.SetTrigger("FadeOut");
    }
}
