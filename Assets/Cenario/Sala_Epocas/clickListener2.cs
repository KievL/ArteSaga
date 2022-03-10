using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickListener2 : MonoBehaviour
{
    public RaycastHit2D hit;
    public Transform pabloPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.tag == "entrarPre")
            {
                Debug.Log("Click");
                SceneManager.LoadScene("prehistoria");
                SceneManager.UnloadSceneAsync("SalaPortais");
            }
        }
    }
}
