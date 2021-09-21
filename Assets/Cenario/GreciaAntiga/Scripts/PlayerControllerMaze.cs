using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerMaze : MonoBehaviour
{
    public GameObject Espada;
    public GameObject dialogueObject;

    [SerializeField]
    private int dialogueStep = 0;

    public Animator fade;

    private Vector3 targetPosition;

    public float speed;

    [SerializeField]
    private bool isMoving = false;

    private bool espada = false;
    private bool escudo = false;
    bool terminou = false;
    public float crono = 0;

    public GameObject luzFinal, star, txtFinal;
    
    public bool playSound = false;

    void start()
    {
        
        
    }

    void Update()
    {
        EndOfGame();
        if (dialogueObject.activeSelf == true)
        { Time.timeScale = 0.0f; }
        else { Time.timeScale = 1.0f; }

        Dialogue();
        setTargetPosition();
        Move();
    }

    void setTargetPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            targetPosition.x = Camera.main.ScreenToWorldPoint(t.position).x;
            targetPosition.y = Camera.main.ScreenToWorldPoint(t.position).y;
            targetPosition.z = transform.position.z;

            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        targetPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        targetPosition.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        targetPosition.z = transform.position.z;


        if (Input.GetMouseButton(0) && speed > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }
    void Move()
    {
        if (isMoving)
        {
            if (targetPosition.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            if (targetPosition.x < transform.position.x)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            if (terminou == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "EspadaMaze")
        {
            espada = true;
            Destroy(col.gameObject);
        }
        if (col.gameObject.name == "EscudoMaze")
        {
            escudo = true;
            Destroy(col.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Colision");

        if (col.gameObject.name == "EnemyBackup")
        {
            if (espada == true && escudo == true)
            {
                terminou = true;
            }
            else
            {
                Restart();
            }
        }
    }
    void EndOfGame()
    {
        if (terminou)
        {
            if (playSound == false)
            {
                GreekSounds.soundSlash = true;
                playSound = true;
            }            
            luzFinal.SetActive(true);
            crono += Time.deltaTime;
            if (crono >= 1f)
            {
                star.SetActive(true);
                txtFinal.SetActive(true);
                if (crono >= 5f)
                {
                    PlayerPrefs.SetInt("grecia", 1);
                    SceneManager.LoadScene("idadeantiga");
                }                
            }
        }

    }

    void Restart()
    {
        SceneManager.LoadScene("GreciaAntiga7");
    }

    void FadeOut()
    {
        fade.SetTrigger("FadeOut");
    }

    void Dialogue()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Debug.Log("Click2");
                if (hit.transform == dialogueObject.transform)
                {
                    Debug.Log("Click3");
                    if (dialogueStep == 0)
                    {
                        dialogueStep = dialogueStep + 1;
                        dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                    }
                    else
                    {
                        dialogueObject.SetActive(false);
                    }
                }
            }
        }
    }
}