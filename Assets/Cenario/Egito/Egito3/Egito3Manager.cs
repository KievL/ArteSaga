using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egito3Manager : MonoBehaviour
{
    public GameObject rocha;
    public float multiZRotat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        girarRocha();  
    }
    void girarRocha()
    {
        rocha.transform.Rotate(new Vector3(0, 0, rocha.transform.rotation.z + (multiZRotat * Time.deltaTime)));
    }
}
