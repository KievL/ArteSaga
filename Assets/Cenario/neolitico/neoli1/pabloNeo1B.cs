using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pabloNeo1B : MonoBehaviour
{
    public GameObject pablo;
    public float compensation;
    public bool subiu = false;
    public bool desceu = false;
    public static bool playable = true;
    

    public 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCorrendo())
        {

            if (playable == true)
            {
                pablo.GetComponent<Animator>().SetBool("isWalking", true);
            }
            subiu = false;
            if(desceu == false)
            {
                pablo.transform.position = new Vector2(pablo.transform.position.x, pablo.transform.position.y - compensation);
                desceu = true;
            }
        }
        else
        {
            desceu = false;
            if(playable == true)
            {
                pablo.GetComponent<Animator>().SetBool("isWalking", false);
            }
            if(subiu == false)
            {
                pablo.transform.position = new Vector2(pablo.transform.position.x, pablo.transform.position.y + compensation);
                subiu = true;
            }
            
        }
        if(saberLado() > 0)
        {
            pablo.GetComponent<SpriteRenderer>().flipX = false;
        }if(saberLado()< 0)
        {
            pablo.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    bool isCorrendo()
    {
        float vel = pablo.GetComponent<Rigidbody2D>().velocity.x;
        if(vel != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    int saberLado()
    {
        float vel = pablo.GetComponent<Rigidbody2D>().velocity.x;
        if (vel > 0)
        {
            return 1;
        }
        else if(vel<0)
        {
            return -1;
        }
        else
        {
            return 0;
        }               
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Neoli1Manager.getMadeira == true)
        {
            if (collision.gameObject.name == "arvore1" && Neoli1Manager.tree1Got==false)
            {
                Neoli1Manager.showBtnTree1 = true;
            }
            if (collision.gameObject.name == "arvore2" && Neoli1Manager.tree2Got == false)
            {
                Neoli1Manager.showBtnTree2 = true;
            }
            if (collision.gameObject.name == "arvore3" && Neoli1Manager.tree3Got == false)
            {
                Neoli1Manager.showBtnTree3 = true;
            }
            if (collision.gameObject.name == "arvore4" && Neoli1Manager.tree4Got == false)
            {
                Neoli1Manager.showBtnTree4 = true;
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Neoli1Manager.getMadeira == true)
        {
            if (collision.gameObject.name == "arvore1" && Neoli1Manager.tree1Got == false)
            {
                Neoli1Manager.showBtnTree1 = false;
            }
            if (collision.gameObject.name == "arvore2" && Neoli1Manager.tree2Got == false)
            {
                Neoli1Manager.showBtnTree2 = false;
            }
            if (collision.gameObject.name == "arvore3" && Neoli1Manager.tree3Got == false)
            {
                Neoli1Manager.showBtnTree3 = false;
            }
            if (collision.gameObject.name == "arvore4" && Neoli1Manager.tree4Got == false)
            {
                Neoli1Manager.showBtnTree4 = false;
            }
        }
    }
}
