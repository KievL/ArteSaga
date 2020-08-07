using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botoesEntrar : MonoBehaviour
{
    public Transform jogador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jogador.position.x>= 0.6f && jogador.position.x <= 1.36f&& pablo.cima == false && pablo.liberado == true)
        {
            float posx = jogador.position.x;
            float posy = jogador.position.y;

            this.transform.position = new Vector2(posx + 0.131f, posy + 0.133f);
        }
        else
        {
            this.transform.position = new Vector2(1.416f, 0.608f);
        }
    }
}
