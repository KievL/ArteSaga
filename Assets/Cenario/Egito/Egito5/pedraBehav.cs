using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedraBehav : MonoBehaviour
{
    public Vector2 speedNormal;
    public Vector2 speedFoward;
    public Vector2 speedBack;

    public float avancarDuration=0;
    public float normalHitDuration = 0;

    public bool avancando = false;
    public bool avancando2 = false;
    public bool normalToBack = false;

    public float rotationSpeed;

    public GameObject pedra;
    public GameObject canvasPerdeu;
    public bool perdeu = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        avancar();
        avancadoMethod();
        if (perdeu == false)
        {
            pedra.transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }
        else
        {
            pedra.transform.Rotate(new Vector3(0, 0, 0));
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pablo"))
        {
            Time.timeScale = 0;
            perdeu = true;
            canvasPerdeu.SetActive(true);
        }
    }
    void avancar()
    {
        if (Egito5Manager.bateu == true)
        {
            avancando = true;
            Egito5Manager.bateu = false;
        }
        if(avancando == true)
        {
            avancarDuration = 0;
            normalToBack = false;
            avancando = false;
            avancando2 = true;
        }
    }
    void avancadoMethod()
    {
        if (avancando2 == true)
        {
            avancarDuration += Time.deltaTime;
            if (avancarDuration <= 0.55f)
            {
                pedra.GetComponent<Rigidbody2D>().velocity = speedFoward;
            }
            else
            {
                pedra.GetComponent<Rigidbody2D>().velocity = speedNormal;                
                normalHitDuration = 0;
                normalToBack = true;
                avancando2 = false;
            }
        }
        if (normalToBack == true)
        {
            normalHitDuration += Time.deltaTime;
            if (normalHitDuration >= 6f)
            {
                pedra.GetComponent<Rigidbody2D>().velocity = speedBack;
            }            
            if(pedra.transform.position.x <= -13.54f)
            {
                pedra.GetComponent<Rigidbody2D>().velocity = speedNormal;
                normalHitDuration = 0;
                normalToBack = false;
            }
        }
    }

}
