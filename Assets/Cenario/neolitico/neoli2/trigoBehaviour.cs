using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigoBehaviour : MonoBehaviour
{
    public float vida = 0;
    public int vidaAnim = 0;
    public int estado = 1;
    public float crono = 0;

    public GameObject btn1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Situacao();
        MudarAparencia();
        desaparecerBotao();
    }
    void Situacao()
    {
        if(neoli2Manager.ativo == true)
        {            
                if (vida <= 20)
                {
                    vida += Time.deltaTime;
                }            
        }        
    }
    void MudarAparencia()
    {
        if(vida>=0f && vida <= 10f)
        {
            vidaAnim = 0;
            this.GetComponent<Animator>().SetInteger("vida", vidaAnim);

        }
        if(vida>10f && vida <= 19.9f)
        {
            vidaAnim = 1;
            this.GetComponent<Animator>().SetInteger("vida", vidaAnim);
        }
        if (vida > 19.9)
        {
            vidaAnim = 2;
            this.GetComponent<Animator>().SetInteger("vida", vidaAnim);
        }
    }
   
    void desaparecerBotao()
    {
        if(vidaAnim != 2)
        {
            btn1.SetActive(false);
        }        
    }    
    public void colher()
    {        
            vida = 0;
            neoli2Manager.trigos++;        
    }        
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "primitivo" && vidaAnim == 2)
        {
            btn1.SetActive(true);
        }        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "primitivo")
        {
            btn1.SetActive(false);

        }
    }
}
