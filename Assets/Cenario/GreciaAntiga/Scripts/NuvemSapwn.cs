using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuvemSapwn : MonoBehaviour
{


    public GameObject nuvem;

    public float Y1, Y2, cronoLimit;
    public float crono = 0;
    [SerializeField]
    private Vector2 screnBounds;

    // Start is called before the first frame update
    void Start()
    {
        screnBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Spawnar();
    }

    void Spawnar()
    {
        crono += Time.deltaTime;
        if (crono >= cronoLimit)
        {
            GameObject spawnNuvem = Instantiate(nuvem) as GameObject;
            spawnNuvem.transform.position = new Vector2(this.transform.position.x, Random.Range(Y1, Y2));
            crono = 0;
        }
    }
}
