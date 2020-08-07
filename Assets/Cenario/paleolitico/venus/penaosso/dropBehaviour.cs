using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropBehaviour : MonoBehaviour
{
    public float xmin, xmax;
    public float velY;
    public float yFall;

    public float yLim;
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        type = Manager.objType;
        float place = Random.Range(xmin, xmax);
        this.transform.position = new Vector3(place, yFall, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector2(0, velY) * Time.deltaTime);
        if(type == 0)
        {
            if (this.transform.position.y <= yLim)
            {
                if (Manager.pontuacao != 0)
                {
                    
                    Manager.pontuacao -= 1;
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            if (this.transform.position.y <= yLim)
            {                                                   
                Destroy(this.gameObject);
                
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name== "ce5cb9ce2087490")
        {
            if (type == 0)
            {
                Manager.pontuacao += 1;
                Destroy(this.gameObject);
                
            }
            else
            {
                if(Manager.pontuacao != 0 && Manager.win == false)
                {
                    Manager.pontuacao -= 1;
                    
                }
                Destroy(this.gameObject);

            }
        }
    }
}
