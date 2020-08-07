using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkpabloc : MonoBehaviour
{
    public float crono;
    public Transform target;
    public bool chega = false;
    public bool chega2 = false;
    public bool avancar = false;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.15f, 0);
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;


    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (target.position.x >= -1.891f && chega == false){
            avancar = true;                        
        }
        if(avancar == true)
        {
            PabloController.playerTurnAxisTouch = 0;

            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            GetComponent<Animator>().SetBool("para", true);
            chega2 = true;
            crono += Time.deltaTime;
            CameraFollowing.go = false;

            if (crono >= 2f)
            {
                CameraFollowing.cameraType = 2;
                chega = true;
                avancar = false;

            }
        }
        if(target.position.x >= -3.177f && chega2 == false)
        {
            CameraFollowing.go = true;
        }
    }
}
