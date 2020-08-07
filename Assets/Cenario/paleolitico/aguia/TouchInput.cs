using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public LayerMask touchInputMask;
    private List<GameObject> touchList = new List<GameObject>();

    private RaycastHit hit;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

                Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if (Input.GetMouseButtonUp(0))
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            
        }
        if (Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);

                if(Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if(touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }
}
