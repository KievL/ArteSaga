using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pabloMoves : MonoBehaviour
{
    public bool direita = false;
    public Transform elPablo;
    public bool liberado = true;
    public bool esquerda = false;
    public static float velocidade = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        if(direita== true)
        {
            if(velocidade <= 0.6f)
            {
                velocidade += Time.deltaTime;
            }
            else{
                velocidade = 0.6f;
            }
            

        }
        if(esquerda == true)
        {
            if(velocidade >= -0.6f)
            {
                velocidade -= Time.deltaTime;
            }
            else
            {
                velocidade = -0.6f;
            }
        }
        if(direita ==false && velocidade > 0 && esquerda == false)
        {
            velocidade -= Time.deltaTime;
        }
        if (direita == false && velocidade < 0 && esquerda == false)
        {
            velocidade += Time.deltaTime;
        }
    }
    public void toTheRightDown()
    {
        if(elPablo.position.x <= 2.829f && liberado == true && esquerda == false)
        {
            direita = true;
        }        
    }
    public void toTheRightUp()
    {
        direita = false;        
    }
    public void toTheLeftDown()
    {
        if (elPablo.position.x >= -2.063f && liberado == true && direita == false)
        {
            esquerda = true;
        }
    }
    public void toTheLeftUp()
    {
        esquerda = false;
    }
}
