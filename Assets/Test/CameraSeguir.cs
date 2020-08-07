using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;
    public static bool allow = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        if (allow == true)
        {            
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
        
    }
}
