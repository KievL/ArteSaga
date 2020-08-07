using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnBehaviour : MonoBehaviour
{
    public GameObject pablo;
    public bool batendo = false;
    public bool btnTempo = false;
    public float crono = 0;
    public Camera cam;
    public float ang;
    public GameObject prefab;
    public int woodLim = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(btnTempo == true)
        {
            
            crono += Time.deltaTime;
            if(crono >= 0.23f)
            {
                pablo.GetComponent<Animator>().SetBool("tocouTela", false);
                btnTempo = false;
                batendo = false;
                crono = 0;
            }
            cam.orthographicSize += 0.2f * crono;
            cam.transform.eulerAngles = new Vector3(0, 0, ang);
            ang += Time.deltaTime * 3.65f;
        }
    }
    public void bater()
    {
        if (batendo == false)
        {
            GameObject wood = Instantiate(prefab) as GameObject;
            ang = -0.84f;
            cam.transform.eulerAngles = new Vector3(0, 0, -0.84f);
            cam.orthographicSize = 4.45f;
            btnTempo = true;
            pablo.GetComponent<Animator>().SetBool("tocouTela", true);
            batendo = true;
            woodLim++;
            if(woodLim == 2)
            {
                Neoli1Manager.woodTaken++;
                Neoli1Manager.woodBuildHouse++;
                woodLim = 0;
            }            
        }                            
    }
}
