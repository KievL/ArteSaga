using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private Vector2 startpos;
    public float scrollSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        if(PaleoManager.isCorrendo == true)
        {
            float newPos = Mathf.Repeat(Time.time * scrollSpeed, 4);
            transform.position = startpos + Vector2.left * newPos;
        }
        
    }
}
