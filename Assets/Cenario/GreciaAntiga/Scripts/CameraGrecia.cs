using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraGrecia : MonoBehaviour
{
    string scene;
    public string Cena1, Cena2;

    public GameObject pablo;
    Vector3 pabloPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pabloPos = new Vector3(pablo.transform.position.x, this.transform.position.y, this.transform.position.z);
        scene = SceneManager.GetActiveScene().name;

        if(scene== Cena1)
        {
            camGrecia1();
        }
        else if (scene == Cena2)
        {
            camGrecia2();
        }
    }

    void camGrecia1()
    {
        if(pabloPos.x>= -6.08f)
        {
            transform.position = pabloPos;
        }                
    }
    void camGrecia2()
    {
        if (pabloPos.x >= -7.48f && pabloPos.x <= 30.76f)
        {
            transform.position = pabloPos;
        }
    }
}
