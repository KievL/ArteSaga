using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstroBehavior : MonoBehaviour
{
    public float velMonster;

    public bool bateuIgreja = false;

    public Rigidbody2D rb;
    public GameObject go;

    public bool dead = false;

    public float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (Gotica4Manager.monsterSpeed == 0)
        {
            velMonster = 3f;
        } else if (Gotica4Manager.monsterSpeed == 1)
        {
            velMonster = 4f;
        }
        else if (Gotica4Manager.monsterSpeed == 2)
        {
            velMonster = 5f;
        }
        else if (Gotica4Manager.monsterSpeed == 3)
        {
            velMonster = 6f;
        }
        else if (Gotica4Manager.monsterSpeed == 4)
        {
            velMonster = 7f;
        }
        else if (Gotica4Manager.monsterSpeed == 5)
        {
            velMonster = 8f;
        }
        else if (Gotica4Manager.monsterSpeed == 6)
        {
            velMonster = 9f;
        }
        else if (Gotica4Manager.monsterSpeed == 7)
        {
            velMonster = 10f;
        }
        else
        {
            velMonster = 11f;
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            rb.velocity = new Vector3(-velMonster, 0, 0);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector3(0, -fallSpeed, 0);
            go.GetComponent<Animator>().SetBool("morreu", true);
        }

        if(go.transform.position.y <= -6.62f)
        {
            Destroy(go.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish")==true && bateuIgreja==false)
        {
            Debug.Log("foi");
            Gotica4Manager.vidas = Gotica4Manager.vidas - 1;
            bateuIgreja = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish") == true && bateuIgreja == false)
        {
            Gotica4Manager.vidas = Gotica4Manager.vidas - 1;
            bateuIgreja = true;
        }
        if (collision.gameObject.CompareTag("light") && dead==false)
        {
            Destroy(collision.gameObject);
            dead = true;
        }
    }    
}
