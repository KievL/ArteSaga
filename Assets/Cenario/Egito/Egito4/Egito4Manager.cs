using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Egito4Manager : MonoBehaviour
{
    public GameObject fakeWall;
    public GameObject ball;
    public GameObject ball2;
    public GameObject cam;
    public GameObject pablo;

    public int sceneStep = 0;
    public float crono1 = 0;

    public float velWall, velBallX, velBallY;
    public float rotSpeed;

    public float velPablo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sairBola();
        pabloAssustar();
    }
    void sairBola()
    {
        ball.transform.Rotate(new Vector3(0, 0, rotSpeed));
        if (sceneStep == 0)
        {
            crono1 += Time.deltaTime;
            if (crono1 >= 1.3f)
            {
                fakeWall.GetComponent<Rigidbody2D>().velocity = new Vector2(velWall, 0);
                if (fakeWall.transform.position.x <= -4.07f)
                {
                    fakeWall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    crono1 = 0;
                    sceneStep = 1;
                }
            }
        }
        if (sceneStep == 1)
        {
            crono1 += Time.deltaTime;
            if (crono1 >= 0.7f)
            {
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(velBallX, velBallY);
                if (ball.transform.position.y <= -1.31f)
                {
                    crono1 = 0;
                    sceneStep = 2;
                }
            }
        }
        if (sceneStep == 2)
        {
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(velBallX * 1.4f, 0);
            if (ball.transform.position.x >= 17.41f)
            {
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                sceneStep = 3;
            }
        }
    }
    void pabloAssustar()
    {
        if (sceneStep == 3)
        {
            crono1 += Time.deltaTime;
            cam.transform.position = new Vector3(pablo.transform.position.x, cam.transform.position.y, -10);
            pablo.GetComponent<Animator>().SetBool("correndo", true);
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
            if (crono1 >= 2f)
            {
                crono1 = 0;
                pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                pablo.GetComponent<Animator>().SetBool("correndo", false);
                sceneStep = 4;
            }
        }
        if (sceneStep == 4)
        {
            crono1 += Time.deltaTime;
            cam.transform.position = new Vector3(pablo.transform.position.x, cam.transform.position.y, -10);
            if (crono1 >= 0.7f)
            {
                pablo.GetComponent<SpriteRenderer>().flipX = true;
                crono1 = 0;
                sceneStep = 5;
            }
        }
        if (sceneStep == 5)
        {
            crono1 += Time.deltaTime;
            if (crono1 >= 0.7f)
            {
                pablo.GetComponent<Animator>().SetBool("assustou", true);
                if (crono1 >= 1.5f)
                {
                    pablo.GetComponent<Animator>().SetBool("assustou", false);
                    pablo.GetComponent<SpriteRenderer>().flipX = false;
                    pablo.GetComponent<Animator>().SetBool("correndo", true);
                    sceneStep = 6;
                }
            }
        }
        if (sceneStep == 6)
        {
            pablo.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo, 0);
            ball2.transform.Rotate(new Vector3(0, 0, rotSpeed));
            ball2.GetComponent<Rigidbody2D>().velocity = new Vector2(velPablo*1.4f, 0);
            if(ball2.transform.position.x >= -21.84f)
            {
                SceneManager.LoadScene("Egito5");
            }
        }
    }

}
