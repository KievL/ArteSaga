using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deusBehaviour : MonoBehaviour
{
    public int fellings;
    public GameObject god;
    public float crono = 0;
    public int steps = 0;
    public float velydesc;
    public float velysub;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FellingsGod();
        Voar();
    }
    void FellingsGod()
    {
        fellings = Paleo7Manager.godFellings;
        if (fellings < 0)
        {
            god.GetComponent<Animator>().SetInteger("fellings", 1);
        }
        if(fellings > 0)
        {
            god.GetComponent<Animator>().SetInteger("fellings", 3);

        }
        if(fellings == 0)
        {
            god.GetComponent<Animator>().SetInteger("fellings", 2);
        }
    }
    void Voar()
    {
        if(steps== 0)
        {
            crono += Time.deltaTime;
            god.transform.Translate(new Vector2(0, velydesc) * Time.deltaTime);
            if (crono >= 1f)
            {
                
                steps = 1;
                crono = 0;
            }
        }
        else
        {
            crono += Time.deltaTime;
            god.transform.Translate(new Vector2(0, velysub) * Time.deltaTime);
            if (crono >= 1f)
            {
                
                steps = 0;
                crono = 0;
            }
        }
    }
}
