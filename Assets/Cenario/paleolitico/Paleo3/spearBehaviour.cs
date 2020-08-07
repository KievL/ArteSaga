using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearBehaviour : MonoBehaviour
{


    public float inSee;

    public Vector2 force;
    public SpriteRenderer rnd;
    public bool apagando = false;

    public float gravity;
    public float DeltaS;
    public float vovoat;
    public float parcela2;

    public float timeGround;

    public float crono1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>().position = new Vector3(-6.38f, -1.42f, 0);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        force = new Vector2(Paleo3Manager.velX1, Paleo3Manager.velY1);
        this.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        rnd = this.GetComponent<SpriteRenderer>();
        
    }
    // Update is called once per frame
    void Update()
    {  
        if(apagando == false)
        {
            vovoat = Paleo3Manager.velY1 / gravity; 
            DeltaS = (Mathf.Pow(Paleo3Manager.velY1, 2) / (2 * gravity))+0.94f;
            parcela2 = Mathf.Sqrt((DeltaS * 2) / gravity);
            timeGround = parcela2 + vovoat;
            this.transform.Rotate(new Vector3(0, 0, -115.3f / timeGround) * Time.deltaTime);
            
        }
        

        if(this.GetComponent<Transform>().position.y <= -2.364f && apagando == false)
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine("FadeOut");           
            apagando = true;
            Paleo3Manager.setaParecer = true;
        }
        if(apagando == true)
        {
            crono1 += Time.deltaTime;
            if (crono1 >= 2f)
            {
                Destroy(this.gameObject);
            }
        }
        if(Paleo3Manager.apagar == true){
            Destroy(this.gameObject);
        }

    }
    IEnumerator FadeOut()
    {
        for(float f = 1f; f>= -0.05f; f-= 0.05f)
        {
            Color c = rnd.material.color;
            c.a = f;
            rnd.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
   
}
