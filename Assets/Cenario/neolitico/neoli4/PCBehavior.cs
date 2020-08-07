using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCBehavior : MonoBehaviour
{
    public float velDescer;
    public float xmin, xmax;
    public float velMovimento;
    public bool tocou = false;
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
        if (col.gameObject.name == "triggerC1")
        {
            if (neoli4Manager.cima1 == 1 && neoli4Manager.sup1 == 0)
            {
                tocou = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.transform.position = new Vector2(-7.7f, -2.65f);
                neoli4Manager.cima1--;
            }            
        }
        if (col.gameObject.name == "triggerC2")
        {
            if (neoli4Manager.cima2 == 1 && neoli4Manager.sup2 == 0)
            {
                tocou = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.transform.position = new Vector2(-4.8f, -2.65f);
                neoli4Manager.cima2--;
            }
        }
        if (col.gameObject.name == "triggerC3")
        {
            if (neoli4Manager.cima3 == 1 && neoli4Manager.sup3 == 0)
            {
                tocou = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.transform.position = new Vector2(-1.91f, -2.65f);
                neoli4Manager.cima3--;
            }
        }
        if (col.gameObject.name == "triggerC4")
        {
            if (neoli4Manager.cima4 == 1 && neoli4Manager.sup4 == 0)
            {
                tocou = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.transform.position = new Vector2(1.05f, -2.65f);
                neoli4Manager.cima4--;
            }
        }
        if (col.gameObject.name == "triggerC5")
        {
            if (neoli4Manager.cima5 == 1 && neoli4Manager.sup5 == 0)
            {
                tocou = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.transform.position = new Vector2(4.09f, -2.65f);
                neoli4Manager.cima5--;
            }
        }
        if (col.gameObject.name == "triggerLixo")
        {
            neoli4Manager.lixoPlace += 0.462f;
            tocou = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            this.transform.position = new Vector2(Random.Range(6.97f, 7.29f), neoli4Manager.lixoPlace);
            this.GetComponent<SpriteRenderer>().sortingOrder = neoli4Manager.orderLayer;
            neoli4Manager.orderLayer--;

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
