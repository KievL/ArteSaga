using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aguiaCimaBehaviour : MonoBehaviour
{
    public float speed;
    public float backSpeed;
    public float upSpeed;
    public GameObject aguia;
    public int aguiaSteps = 0;
    public float crono = 0;

    public float downSpeed;
    public float frontSpeed;
    public bool passou = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aguiaSteps == 0)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            if(transform.position.x >= -0.78f)
            {                
                aguia.GetComponent<Animator>().SetInteger("aguiaSteps", 1);
                aguiaSteps = 1;
            }
        }
        if(aguiaSteps == 1)
        {
            crono += Time.deltaTime;
            transform.position += new Vector3(backSpeed, upSpeed, 0) * Time.deltaTime;
            if(crono >= 1f)
            {
                aguiaSteps = 2;
            }
        }
        if(aguiaSteps ==2)
        {
            aguia.GetComponent<Animator>().SetInteger("aguiaSteps", 2);
            transform.position += new Vector3(frontSpeed, downSpeed, 0) * Time.deltaTime;
            if (transform.position.y <= -0.285f)
            {
                aguiaSteps = 3;
            }
        }
        if(aguiaSteps == 3)
        {
            aguia.GetComponent<Animator>().SetInteger("aguiaSteps", 3);
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if(transform.position.x >= 2.141f && passou == false)
        {
            PaleoManager.aguasPasssadas++;
            passou = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("primitivo") && primitivoBehaviour.afetado == false)
        {

            primitivoBehaviour.vidas--;
            primitivoBehaviour.afetado = true;
        }
    }
}
