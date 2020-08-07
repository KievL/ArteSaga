using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickMove : MonoBehaviour
{


    // Use this for initialization
    void Start()
    { 

    }


    // Update is called once per frame
    void Update()
    {
        // Initiating touch event
        // if touch event takes place
        if(Manager.win == false)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                this.transform.position = new Vector2(touchPos.x, this.transform.position.y);

            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);


                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);


                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        this.transform.position = new Vector2(touchPos.x, this.transform.position.y);
                        break;
                    case TouchPhase.Moved:
                        this.transform.position = new Vector2(touchPos.x, this.transform.position.y);
                        break;
                }
            }
        }
        
    }        
}
