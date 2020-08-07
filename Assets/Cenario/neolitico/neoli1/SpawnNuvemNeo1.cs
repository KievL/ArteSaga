using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNuvemNeo1 : MonoBehaviour
{
    public GameObject nuvem;
    public float crono = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawnar();
    }
    void Spawnar()
    {
        crono += Time.deltaTime;
        if(crono >= 10f)
        {
            GameObject spawnNuvem = Instantiate(nuvem) as GameObject;
            crono = 0;
        }
    }
}
