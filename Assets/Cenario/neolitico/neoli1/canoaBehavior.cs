using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canoaBehavior : MonoBehaviour
{
    public float crono = 0;
    public GameObject canoa;  
    public bool movimento = false;
    public float tempoLimite;
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canoaMover();
    }
    void canoaMover()
    {
        if(movimento == false)
        {
            crono += Time.deltaTime;
            canoa.transform.Translate(new Vector2(0, -velocidade) * Time.deltaTime);
            if (crono >= tempoLimite)
            {
                movimento = true;
                crono = 0;
            }

        }
        else
        {
            crono += Time.deltaTime;
            canoa.transform.Translate(new Vector2(0, velocidade) * Time.deltaTime);
            if (crono >= tempoLimite)
            {
                movimento = false;
                crono = 0;
            }
        }
    }
}
