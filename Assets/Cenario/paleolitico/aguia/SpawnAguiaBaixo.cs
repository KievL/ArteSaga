using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAguiaBaixo : MonoBehaviour
{
    public float rateSpawn;
    public float currentRate;
    public GameObject prefab;

    public float maxHeight;
    public float minHeight;

    public int maxAguia;

    public List<GameObject> aguia;

    public static int maxInter;
    public static int transition = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxInter = maxAguia;
        for(int i = 0; i< maxAguia; i++)
        {
            GameObject tempAguia = Instantiate(prefab) as GameObject;
            aguia.Add(tempAguia);
            tempAguia.SetActive(false);
            
        }
    }   

    // Update is called once per frame
    void Update()
    {
        currentRate += Time.deltaTime;
        if(currentRate > rateSpawn)
        {
            currentRate = 0;
            if(PaleoManager.aguiaNascer == true)
            {
                Spawn();
                transition++;
            }
            
        }
        if (transition == maxAguia+1)
        {
            SpawnAguiaCima.allowed = true;
        }
    }
    private void Spawn()
    {
        float randomPos = Random.Range(minHeight, maxHeight);

        GameObject tempAguia = null;

        for(int i  = 0; i < maxAguia; i++)
        {
            if (aguia[i].activeSelf == false)
            {
                tempAguia = aguia[i];
                break;
            }
        }
        if(tempAguia != null)
        {
            tempAguia.transform.position = new Vector3(transform.position.x, randomPos, transform.position.z);
            tempAguia.SetActive(true);
        }
    }
}
