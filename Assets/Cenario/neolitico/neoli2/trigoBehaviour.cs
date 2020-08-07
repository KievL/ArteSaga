using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigoBehaviour : MonoBehaviour
{
    public float vida = 0;
    public int vidaAnim = 0;
    public int estado = 1;
    public float crono = 0;
    public float tempoLarva;
    public bool terLarva = false;

    public GameObject btn1;
    public GameObject btnCuidar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Situacao();
        MudarAparencia();
        adoecer();
        desaparecerBotao();
    }
    void Situacao()
    {
        if(neoli2Manager.ativo == true)
        {
            if (doente())
            {
                if (vida > 0)
                {
                    vida -= Time.deltaTime;
                }
            }
            else
            {
                if (vida <= 20)
                {
                    vida += Time.deltaTime;
                }
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
    void adoecer()
    {
        if(neoli2Manager.ativo == true)
        {
            tempoLarva += Time.deltaTime;
        }        
        if(tempoLarva >= 32 && terLarva == false)
        {
            terLarva = true;
                        
        }
        if (terLarva == true)
        {
            estado = 0;
        }
    }
    void desaparecerBotao()
    {
        if(vidaAnim != 2)
        {
            btn1.SetActive(false);
        }
        if(terLarva == false)
        {
            btnCuidar.SetActive(false);
        }
    }
    public bool doente()
    {
        if(estado == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void colher()
    {
        if(doente() == false)
        {
            vida = 0;
            tempoLarva = 0;
            neoli2Manager.trigos++;
        }
    }    
    public void cuidar()
    {
        tempoLarva = 0;
        terLarva = false;
        estado = 1;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "primitivo" && vidaAnim == 2)
        {
            btn1.SetActive(true);
        }
        if (collision.gameObject.name == "primitivo" && doente())
        {
            btnCuidar.SetActive(true);
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "primitivo")
        {
            btn1.SetActive(false);
            btnCuidar.SetActive(false);

        }
    }
}
