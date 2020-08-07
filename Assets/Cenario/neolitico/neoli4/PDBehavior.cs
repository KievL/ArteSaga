using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDBehavior : MonoBehaviour
{
    public float velDescer;
    public float xmin, xmax;
    public bool tocou = false;
    public float velMovimento;
    public float crono = 0;
    public bool perdeu = false;
    public bool perdendo = false;
    // Start is called before the first frame update
    void Start()
    {
        float posX = Random.Range(xmin, xmax);
        this.transform.position = new Vector2(posX, 7.15f);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velDescer);
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Destruir();
    }
    void Mover()
    {
        if(tocou == false)
        {
            if (neoli4Manager.direcao == 0)
            {
                velMovimento = 0;
            }
            if (neoli4Manager.direcao == 1)
            {
                velMovimento = 10;
            }
            if (neoli4Manager.direcao == -1)
            {
                velMovimento = -10;
            }
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(velMovimento, velDescer);
        }        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "trigger1")
        {
            if (neoli4Manager.sup1 == 1)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(-8.17f, -3.05f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup1--;
            }
            if (neoli4Manager.sup1 == 2)
            {
                tocou = true; 
                this.gameObject.transform.position = new Vector2(-7.09f, -3.08f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup1--;
            }

        }
        if (col.gameObject.name == "trigger2")
        {
            if (neoli4Manager.sup2 == 1)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(-5.311f, -3.051f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup2--;
            }
            if (neoli4Manager.sup2 == 2)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(-4.24f, -3.08f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup2--;
            }

        }
        if (col.gameObject.name == "trigger3")
        {
            if (neoli4Manager.sup3 == 1)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(-2.404f, -3.05f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup3--;
            }
            if (neoli4Manager.sup3 == 2)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(-1.33f, -3.08f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup3--;
            }

        }
        if (col.gameObject.name == "trigger4")
        {
            if (neoli4Manager.sup4 == 1)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(0.548f, -3.05f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup4--;
            }
            if (neoli4Manager.sup4 == 2)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(1.63f, -3.08f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup4--;
            }

        }
        if (col.gameObject.name == "trigger5")
        {
            if (neoli4Manager.sup5 == 1)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(3.599f, -3.05f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup5--;
            }
            if (neoli4Manager.sup5 == 2)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(4.69f, -3.08f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup5--;
            }

        }
        if (col.gameObject.name == "trigger6")
        {
            if (neoli4Manager.sup6 == 1)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(6.913f, -3.05f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup6--;
            }
            if (neoli4Manager.sup6 == 2)
            {
                tocou = true;
                this.gameObject.transform.position = new Vector2(8.03f, -3.08f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                neoli4Manager.sup6--;
            }            
        }
        if (col.gameObject.name == "triggerPerder")
        {
            tocou = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            perdeu = true;
            perdendo = true;
            neoli4Manager.vidas--;

        }
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = this.GetComponent<SpriteRenderer>().material.color;
            c.a = f;
            this.GetComponent<SpriteRenderer>().material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    void Destruir()
    {
        if (perdeu == true)
        {
            if (perdendo == true)
            {
                StartCoroutine("FadeOut");
                perdendo = false;
            }
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
