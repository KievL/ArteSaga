using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pabloEgito5Behav : MonoBehaviour
{
    public GameObject chao;
    public bool noChaoHelp;
    public GameObject pablo;

    public static bool pabloAfetado = false;
    public bool pabloPiscar = false;
    public float afetadoTempo = 0;
    public float tempoPiscar = 0;
    public int piscarStep = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Egito5Manager.noChao = noChaoHelp;
        pabloFoiAfetado();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == chao.gameObject)
        {
            noChaoHelp = true;
            pablo.GetComponent<Animator>().SetBool("noChao", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == chao.gameObject)
        {
            noChaoHelp = false;
            pablo.GetComponent<Animator>().SetBool("noChao", false);

        }        
    }
    void pabloFoiAfetado()
    {
        if (pabloAfetado == true)
        {
            afetadoTempo = 0;
            pabloPiscar = true;
            pabloAfetado = false;
        }
        if (pabloPiscar == true)
        {
            afetadoTempo += Time.deltaTime;
            if (afetadoTempo <= 2f)
            {
                tempoPiscar += Time.deltaTime;
                if (tempoPiscar >= 0.175f)
                {
                    if (piscarStep == 0)
                    {
                        pablo.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                        piscarStep = 1;
                    }
                    else
                    {
                        pablo.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                        piscarStep = 0;
                    }
                    tempoPiscar = 0;
                }
            }
            else
            {
                pablo.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                tempoPiscar = 0;
                afetadoTempo = 0f;
                pabloPiscar = false;
            }
        }
    }
    
}
