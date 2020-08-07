using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconMadeiraBeh : MonoBehaviour
{
    public GameObject pablo;
    public SpriteRenderer madeira;
    public bool foi = false;
    public float cron = 0;
    // Start is called before the first frame update
    void Start()
    {
        madeira = this.GetComponent<SpriteRenderer>();
        pablo = GameObject.FindGameObjectWithTag("boia");
        this.transform.position = new Vector2(pablo.transform.position.x + 0.64f, pablo.transform.position.y + 0.9f);
        
    }

    // Update is called once per frame
    void Update()
    {
        cron += Time.deltaTime;
        this.transform.Translate(new Vector2(0, 0.9f) * Time.deltaTime);
        
        if(foi == false)
        {
            StartCoroutine("FadeOut");
            foi = true;
        }
        if(cron >= 1)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = madeira.material.color;
            c.a = f;
            madeira.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
