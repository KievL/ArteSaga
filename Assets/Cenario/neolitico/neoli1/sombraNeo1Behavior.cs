using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sombraNeo1Behavior : MonoBehaviour
{
    public GameObject pabloOriginal;
    public GameObject sombra;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flipSombra();
        positionSombra();
        animacaoSombra();
    }
    void flipSombra()
    {
        if(pabloOriginal.GetComponent<SpriteRenderer>().flipX == true)
        {
            sombra.GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {
            sombra.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    void positionSombra()
    {
        sombra.transform.position = new Vector2(pabloOriginal.transform.position.x, this.transform.position.y);

    }
    void animacaoSombra()
    {
        sombra.GetComponent<Animator>().SetBool("isWalking", pabloOriginal.GetComponent<Animator>().GetBool("isWalking"));
        sombra.GetComponent<Animator>().SetBool("isBreaking", pabloOriginal.GetComponent<Animator>().GetBool("isBreaking"));
        sombra.GetComponent<Animator>().SetBool("tocouTela", pabloOriginal.GetComponent<Animator>().GetBool("tocouTela"));
        sombra.GetComponent<Animator>().SetBool("endWood", pabloOriginal.GetComponent<Animator>().GetBool("endWood"));
        sombra.GetComponent<Animator>().SetBool("isBuilding", pabloOriginal.GetComponent<Animator>().GetBool("isBuilding"));
    }
}
