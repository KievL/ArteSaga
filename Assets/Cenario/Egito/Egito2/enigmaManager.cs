using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enigmaManager : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    public GameObject g;
    public GameObject h;
    public GameObject i;
    public GameObject j;
    public GameObject k;
    public GameObject l;
    public GameObject m;
    public GameObject n;
    public GameObject o;
    public GameObject p;
    public GameObject q;
    public GameObject r;
    public GameObject s;
    public GameObject t;
    public GameObject u;
    public GameObject v;
    public GameObject x;
    public GameObject y;
    public GameObject z;

    public string selected1;
    public string selected2;
    public string selected3;
    public string selected4;
    public string selected5;

    public int selectStep = 1;

    public RaycastHit2D hit;

    public bool podeClikar = true;

    public bool respondeu = false;

    public static bool terminouErrar = false;
    public static bool processoErro = false;

    public float cronoAcertou = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clickarHiero();
        acertouOuNao();
        terminouDeErrar();
        acertou();
    }

    void clickarHiero()
    {
        
        if (Egito2Manager.clickEnigma == true && podeClikar==true && Egito2Manager.noPapiro==false){
            if (Input.GetMouseButtonDown(0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.transform.gameObject == a.gameObject)
                {
                    preencherSelected("a", a);
                }
                if (hit.collider != null && hit.transform.gameObject == b.gameObject)
                {
                    preencherSelected("b",b);
                }
                if (hit.collider != null && hit.transform.gameObject == c.gameObject)
                {
                    preencherSelected("c",c);
                }
                if (hit.collider != null && hit.transform.gameObject == d.gameObject)
                {
                    preencherSelected("d",d);
                }
                if (hit.collider != null && hit.transform.gameObject == e.gameObject)
                {
                    preencherSelected("e",e);
                }

                if (hit.collider != null && hit.transform.gameObject == f.gameObject)
                {
                    preencherSelected("f",f);
                }

                if (hit.collider != null && hit.transform.gameObject == g.gameObject)
                {
                    preencherSelected("g",g);
                }
                if (hit.collider != null && hit.transform.gameObject == h.gameObject)
                {
                    preencherSelected("h",h);
                }

                if (hit.collider != null && hit.transform.gameObject == i.gameObject)
                {
                    preencherSelected("i",i);
                }

                if (hit.collider != null && hit.transform.gameObject == j.gameObject)
                {
                    preencherSelected("j",j);
                }

                if (hit.collider != null && hit.transform.gameObject == k.gameObject)
                {
                    preencherSelected("k",k);
                }

                if (hit.collider != null && hit.transform.gameObject == l.gameObject)
                {
                    preencherSelected("l",l);
                }

                if (hit.collider != null && hit.transform.gameObject == m.gameObject)
                {
                    preencherSelected("m",m);
                }
                if (hit.collider != null && hit.transform.gameObject == n.gameObject)
                {
                    preencherSelected("n",n);
                }
                if (hit.collider != null && hit.transform.gameObject == o.gameObject)
                {
                    preencherSelected("o",o);
                }
                if (hit.collider != null && hit.transform.gameObject == p.gameObject)
                {
                    preencherSelected("p",p);
                }
                if (hit.collider != null && hit.transform.gameObject == q.gameObject)
                {
                    preencherSelected("q",q);
                }
                if (hit.collider != null && hit.transform.gameObject == r.gameObject)
                {
                    preencherSelected("r",r);
                }
                if (hit.collider != null && hit.transform.gameObject == s.gameObject)
                {
                    preencherSelected("s",s);
                }
                if (hit.collider != null && hit.transform.gameObject == t.gameObject)
                {
                    preencherSelected("t",t);
                }
                if (hit.collider != null && hit.transform.gameObject == u.gameObject)
                {
                    preencherSelected("u",u);
                }
                if (hit.collider != null && hit.transform.gameObject == v.gameObject)
                {
                    preencherSelected("v",v);
                }
                if (hit.collider != null && hit.transform.gameObject == x.gameObject)
                {
                    preencherSelected("x",x);
                }
                if (hit.collider != null && hit.transform.gameObject == y.gameObject)
                {
                    preencherSelected("y",y);
                }
                if (hit.collider != null && hit.transform.gameObject == z.gameObject)
                {
                    preencherSelected("z",z);
                }                
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null && hit.transform.gameObject == a.gameObject)
                {
                    preencherSelected("a",a);
                }
                if (hit.collider != null && hit.transform.gameObject == b.gameObject)
                {
                    preencherSelected("b",b);
                }
                if (hit.collider != null && hit.transform.gameObject == c.gameObject)
                {
                    preencherSelected("c",c);
                }
                if (hit.collider != null && hit.transform.gameObject == d.gameObject)
                {
                    preencherSelected("d",d);
                }
                if (hit.collider != null && hit.transform.gameObject == e.gameObject)
                {
                    preencherSelected("e",e);
                }

                if (hit.collider != null && hit.transform.gameObject == f.gameObject)
                {
                    preencherSelected("f",f);
                }
                
                if (hit.collider != null && hit.transform.gameObject == g.gameObject)
                {
                    preencherSelected("g",g);
                }
                if (hit.collider != null && hit.transform.gameObject == h.gameObject)
                {
                    preencherSelected("h",h);
                }

                if (hit.collider != null && hit.transform.gameObject == i.gameObject)
                {
                    preencherSelected("i",i);
                }

                if (hit.collider != null && hit.transform.gameObject == j.gameObject)
                {
                    preencherSelected("j",j);
                }

                if (hit.collider != null && hit.transform.gameObject == k.gameObject)
                {
                    preencherSelected("k",k);
                }

                if (hit.collider != null && hit.transform.gameObject == l.gameObject)
                {
                    preencherSelected("l",l);
                }

                if (hit.collider != null && hit.transform.gameObject == m.gameObject)
                {
                    preencherSelected("m",m);
                }
                if (hit.collider != null && hit.transform.gameObject == n.gameObject)
                {
                    preencherSelected("n",n);
                }
                if (hit.collider != null && hit.transform.gameObject == o.gameObject)
                {
                    preencherSelected("o",o);
                }
                if (hit.collider != null && hit.transform.gameObject == p.gameObject)
                {
                    preencherSelected("p",p);
                }
                if (hit.collider != null && hit.transform.gameObject == q.gameObject)
                {
                    preencherSelected("q",q);
                }
                if (hit.collider != null && hit.transform.gameObject == r.gameObject)
                {
                    preencherSelected("r",r);
                }
                if (hit.collider != null && hit.transform.gameObject == s.gameObject)
                {
                    preencherSelected("s",s);
                }
                if (hit.collider != null && hit.transform.gameObject == t.gameObject)
                {
                    preencherSelected("t",t);
                }
                if (hit.collider != null && hit.transform.gameObject == u.gameObject)
                {
                    preencherSelected("u",u);
                }
                if (hit.collider != null && hit.transform.gameObject == v.gameObject)
                {
                    preencherSelected("v",v);
                }                
                if (hit.collider != null && hit.transform.gameObject == x.gameObject)
                {
                    preencherSelected("x",x);
                }
                if (hit.collider != null && hit.transform.gameObject == y.gameObject)
                {
                    preencherSelected("y",y);
                }
                if (hit.collider != null && hit.transform.gameObject == z.gameObject)
                {
                    preencherSelected("z",z);
                }
            }
    }
    }
    void preencherSelected(string letra, GameObject hiero)
    {
        if (selectStep == 1)
        {
            selected1 = letra;
            hiero.GetComponent<SpriteRenderer>().color = new Color(1, 0.121568f, 0);
            selectStep++;
        }
        else if (selectStep == 2)
        {
            if(letra!= selected1)
            {
                hiero.GetComponent<SpriteRenderer>().color = new Color(1, 0.121568f, 0);
                selected2 = letra;
                selectStep++;
            }            
        }
        else if (selectStep == 3)
        {
            if(letra!= selected1 && letra != selected2)
            {
                hiero.GetComponent<SpriteRenderer>().color = new Color(1, 0.121568f, 0);
                selected3 = letra;
                selectStep++;
            }
        }
        else if (selectStep == 4)
        {
            if (letra != selected1 && letra != selected2 && letra!= selected3)
            {
                hiero.GetComponent<SpriteRenderer>().color = new Color(1, 0.121568f, 0);
                selected4 = letra;
                selectStep++;
            }            
        }
        else if (selectStep==5)
        {
            if (letra != selected1 && letra != selected2 && letra != selected3 && letra != selected4)
            {
                hiero.GetComponent<SpriteRenderer>().color = new Color(1, 0.121568f, 0);
                selected5 = letra;
                selectStep++;
            }
        }

        if (selectStep == 6)
        {
            respondeu = true;            
        }
    }
    void acertouOuNao()
    {
        if (respondeu == true)
        {
            if (selected1 == "m" && selected2 == "o" && selected3 == "r"&& selected4 == "t"&& selected5 == "e")
            {
                Egito2Manager.acertou = 1;
                
            }
            else
            {
                if (processoErro == false)
                {
                    Egito2Manager.acertou = -1;
                    processoErro = true;
                }
            }
            Egito2Manager.clickEnigma = false;
            respondeu = false;
        }
    }

    void acertou()
    {
        if(Egito2Manager.acertou == 1)
        {
            cronoAcertou += Time.deltaTime;
            if (cronoAcertou >= 1.3f)
            {
                m.GetComponent<SpriteRenderer>().color = new Color(0.058823f, 1, 0);
                o.GetComponent<SpriteRenderer>().color = new Color(0.058823f, 1, 0);
                r.GetComponent<SpriteRenderer>().color = new Color(0.058823f, 1, 0);
                t.GetComponent<SpriteRenderer>().color = new Color(0.058823f, 1, 0);
                e.GetComponent<SpriteRenderer>().color = new Color(0.058823f, 1, 0);
            }
        }
    }

    void terminouDeErrar()
    {
        if (terminouErrar == true)
        {
            selected1 = null;
            selected2 = null;
            selected3 = null;
            selected4 = null;
            selected5 = null;
            selectStep = 1;
            a.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            b.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            c.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            d.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            e.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            f.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            g.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            h.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            i.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            j.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            k.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            l.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            m.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            n.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            o.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            p.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            q.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            r.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            s.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            t.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            u.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            v.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            x.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            y.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            z.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            terminouErrar = false;
        }
    }
}
