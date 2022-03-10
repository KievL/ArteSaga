using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookScript : MonoBehaviour
{
    public GameObject btnBook;
    public GameObject bookPanel;
    public static bool bookOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bookOpen == false)
        {
            btnBook.SetActive(true);
        }
        else
        {
            btnBook.SetActive(false);
        }
    }
    public void openBook()
    {
        bookOpen = true;
        bookPanel.SetActive(true);

    }
    public void closeBook()
    {
        bookOpen = false;
        bookPanel.SetActive(false);
    }

}
