using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aguiaBaixoBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject aguia;
    public bool passou = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (transform.position.x >= 2.141f && passou == false)
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
