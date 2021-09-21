using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public RaycastHit2D hit;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float cronoHit = 0;
    public float cadencia = 0.8f;

    public float crono = 0;

    public bool free = true;

    // Update is called once per frame
    void Update()
    {
        if (Gotica4Manager.valendo == true)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= 320f)
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                Atirar();
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                Atirar();
            }
            cronoHit += Time.deltaTime;
            if (cronoHit >= cadencia)
            {
                free = true;
            }
            crono += Time.deltaTime;

            if (crono >= 52)
            {
                cadencia = 0.0001f;
            }
        }

        
    }

    void Atirar()
    {
        if (free == true)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            cronoHit = 0;
            free = false;
        }
        
    }
}
