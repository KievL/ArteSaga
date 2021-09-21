using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    [SerializeField]
    private bool isMoving = false;

    public GameObject colisor;
    public GameObject dialogueObject;
    public GameObject startDialogueObject;
    public GameObject StartPositionDialogue;

    [SerializeField]
    private int dialogueStep = 0;

    //0 = Normal, 1 = Soldado
    public int clothes = 0;
    private int TriggerRei = 0;

    private Vector3 targetPosition;
    private Animator anim;
    public Animator fade;
    public GameObject minotauro, pparado;
    public int grecia6Step = 0;
    public float crono6 = 0f;

    public bool andarLiberado = true;

    Scene scene;

    public string Cena1, Cena2, Cena5;

    public int direcao = 0;

    public RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        dialogueObject.SetActive(false);
        Vector2 DObject = new Vector2(dialogueObject.transform.position.x, dialogueObject.transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        pabloMove();
        AnimationControl();
        NextDialogue();
        StartDialogueWithClick();
        encontrarMinotaur();
        scene = SceneManager.GetActiveScene();
    }

    void FadeOut()
    {
        fade.SetTrigger("FadeOut");
    }   

    void AnimationControl()
    {
        if (clothes == 0)
        {
            if (isMoving && andarLiberado)
            {
                if (direcao==1)
                {
                    anim.SetBool("Walk", true);
                    this.GetComponent<SpriteRenderer>().flipX = false;
                }
                if (direcao==-1)
                {
                    this.GetComponent<SpriteRenderer>().flipX = true;
                    anim.SetBool("Walk", true);
                }
            }
            else
            {
                anim.SetBool("Walk", false);
            }
        }
        else if (clothes == 1)
        {
            if (isMoving)
            {
                if (targetPosition.x > transform.position.x)
                {
                    anim.SetBool("Walk Soldado", true);
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
                if (targetPosition.x < transform.position.x)
                {
                    anim.SetBool("Walk Soldado", true);
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
            }
            else
            {
                anim.SetBool("Parado Soldado", true);
                anim.SetBool("Walk Soldado", false);
            }
        }

    }

    void Dialogue()
    {
        if (scene.name == Cena2)
        {
            dialogueObject.transform.position = new Vector2(this.transform.position.x, dialogueObject.transform.position.y);
        }
        dialogueObject.SetActive(true);
        dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
    }

    void encontrarMinotaur()
    {
        if (scene.name == "GreciaAntiga6")
        {            
            if (grecia6Step ==0)
            {
                this.GetComponent<Animator>().SetBool("Walk", false);
                this.GetComponent<Animator>().SetBool("Parado Soldado", true);
                minotauro.GetComponent<Animator>().SetBool("andando", true);            
                grecia6Step++;
            }
            else if (grecia6Step == 1)
            {
                this.GetComponent<Animator>().SetBool("Walk Soldado", true);
                this.transform.localScale = new Vector3(1.91f, 1.91f, 1.91f);
                this.GetComponent<Rigidbody2D>().velocity = new Vector3(3.5f, 0, 0);
                minotauro.GetComponent<Rigidbody2D>().velocity = new Vector3(-3.5f, 0, 0);
                if (this.transform.position.x>= -3.53f)
                {
                    grecia6Step++;
                }

            }else if (grecia6Step == 2)
            {
                this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                this.GetComponent<Animator>().SetBool("Espantado", true);
                this.GetComponent<Animator>().SetBool("Walk Soldado", false);
                pparado.SetActive(true);
                this.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0, 0);
                minotauro.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0, 0);
                minotauro.GetComponent<Animator>().SetBool("andando", false);
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                crono6 += Time.deltaTime;
                if (crono6 >= 1.5f)
                {                    
                    grecia6Step++;
                }
            }            
            else if (grecia6Step == 3)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                pparado.SetActive(false);
                minotauro.GetComponent<Rigidbody2D>().velocity = new Vector3(-3.5f, 0, 0);
                minotauro.GetComponent<Animator>().SetBool("andando", true);
                this.transform.localScale = new Vector3(1.91f, 1.91f, 1.91f);
                this.GetComponent<SpriteRenderer>().flipX = true;
                this.GetComponent<Animator>().SetBool("Espantado", false);
                this.GetComponent<Animator>().SetBool("Walk Soldado", true);
                this.GetComponent<Rigidbody2D>().velocity = new Vector3(-3.5f, 0, 0);
                if(this.transform.position.x <= -7.69)
                {
                    FadeOut();
                }
            }
        }
    }

    void NextDialogue()
    {
        if (scene.name == "GreciaAntiga4")
        {

        }
        else
        {
            if (dialogueObject.activeSelf)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit, 100.0f))
                    {
                        if (hit.transform == dialogueObject.transform)
                        {
                            if (scene.name == Cena1)
                            {
                                if (dialogueStep < 11)
                                {
                                    if (dialogueStep == 0 || dialogueStep == 1)
                                    {
                                        dialogueObject.transform.position = new Vector2(this.transform.position.x, dialogueObject.transform.position.y);
                                        dialogueStep = dialogueStep + 1;
                                        dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                    }
                                    else
                                    {
                                        dialogueObject.transform.position = new Vector2(StartPositionDialogue.transform.position.x, dialogueObject.transform.position.y);
                                        dialogueStep = dialogueStep + 1;
                                        dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                    }
                                }
                                else
                                {
                                    dialogueStep = 0;
                                    dialogueObject.SetActive(false);
                                    PlayerPrefs.SetInt("GreciaLivroStep", 1);
                                    PlayerPrefs.Save();
                                    FadeOut();
                                }
                            }
                            if (scene.name == Cena2)
                            {
                                if (dialogueStep < 7)
                                {
                                    if (dialogueStep == 3 || dialogueStep == 4)
                                    {
                                        dialogueObject.transform.position = new Vector2(this.transform.position.x, dialogueObject.transform.position.y);
                                        dialogueStep = dialogueStep + 1;
                                        dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                    }
                                    else
                                    {
                                        dialogueObject.transform.position = new Vector2(StartPositionDialogue.transform.position.x, dialogueObject.transform.position.y);
                                        dialogueStep = dialogueStep + 1;
                                        dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                    }
                                }
                                else
                                {
                                    dialogueStep = 0;
                                    dialogueObject.SetActive(false);
                                    PlayerPrefs.SetInt("GreciaLivroStep", 2);
                                    PlayerPrefs.Save();
                                    FadeOut();
                                }
                            }
                            if (scene.name == Cena5)
                            {
                                if (dialogueStep < 3)
                                {
                                    if (dialogueStep == 1)
                                    {
                                        dialogueObject.transform.position = new Vector2(this.transform.position.x, dialogueObject.transform.position.y);
                                        dialogueStep = dialogueStep + 1;
                                        dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                    }
                                    else
                                    {
                                        dialogueObject.transform.position = new Vector2(StartPositionDialogue.transform.position.x, dialogueObject.transform.position.y);
                                        dialogueStep = dialogueStep + 1;
                                        dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                    }
                                    if (dialogueStep == 2)
                                    {
                                        anim.SetBool("Parado Soldado", true);
                                        anim.SetBool("Walk Soldado", false);
                                    }

                                }
                                else
                                {
                                    dialogueStep = 0;
                                    dialogueObject.SetActive(false);
                                    FadeOut();
                                }
                            }
                        }
                    }
                }
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit.collider != null && hit.transform.gameObject == dialogueObject.gameObject)
                    {
                        if (scene.name == Cena1)
                        {
                            if (dialogueStep < 11)
                            {
                                if (dialogueStep == 0 || dialogueStep == 1)
                                {
                                    dialogueObject.transform.position = new Vector2(this.transform.position.x, dialogueObject.transform.position.y);
                                    dialogueStep = dialogueStep + 1;
                                    dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                }
                                else
                                {
                                    dialogueObject.transform.position = new Vector2(StartPositionDialogue.transform.position.x, dialogueObject.transform.position.y);
                                    dialogueStep = dialogueStep + 1;
                                    dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                }
                            }
                            else
                            {
                                dialogueStep = 0;
                                dialogueObject.SetActive(false);
                                PlayerPrefs.SetInt("GreciaLivroStep", 1);
                                PlayerPrefs.Save();
                                FadeOut();
                            }
                        }
                        if (scene.name == Cena2)
                        {
                            if (dialogueStep < 7)
                            {
                                if (dialogueStep == 3 || dialogueStep == 4)
                                {
                                    dialogueObject.transform.position = new Vector2(this.transform.position.x, dialogueObject.transform.position.y);
                                    dialogueStep = dialogueStep + 1;
                                    dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                }
                                else
                                {
                                    dialogueObject.transform.position = new Vector2(StartPositionDialogue.transform.position.x, dialogueObject.transform.position.y);
                                    dialogueStep = dialogueStep + 1;
                                    dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                }
                            }
                            else
                            {
                                dialogueStep = 0;
                                dialogueObject.SetActive(false);
                                PlayerPrefs.SetInt("GreciaLivroStep", 2);
                                PlayerPrefs.Save();
                                FadeOut();
                            }
                        }
                        if (scene.name == Cena5)
                        {
                            if (dialogueStep < 3)
                            {
                                if (dialogueStep == 1)
                                {
                                    dialogueObject.transform.position = new Vector2(this.transform.position.x, dialogueObject.transform.position.y);
                                    dialogueStep = dialogueStep + 1;
                                    dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                }
                                else
                                {
                                    dialogueObject.transform.position = new Vector2(StartPositionDialogue.transform.position.x, dialogueObject.transform.position.y);
                                    dialogueStep = dialogueStep + 1;
                                    dialogueObject.GetComponent<Animator>().SetInteger("animStep", dialogueStep);
                                }
                                if (dialogueStep == 2)
                                {
                                    anim.SetBool("Parado Soldado", true);
                                    anim.SetBool("Walk Soldado", false);
                                }

                            }
                            else
                            {
                                dialogueStep = 0;
                                dialogueObject.SetActive(false);
                                FadeOut();
                            }
                        }
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Colisor")
        {
            anim.SetBool("Espantado", true);
            speed = 0;
            Dialogue();
        }
        if (coll.gameObject.name == "TriggerRei")
        {
            if (TriggerRei == 0)
            {
                andarLiberado = false;
                TriggerRei = 1;
                speed = 0;
                Dialogue();
            }
        }
    }

    void StartDialogueWithClick()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject == startDialogueObject.gameObject)
            {
                if(this.transform.position.x>= 26.04f && this.transform.position.x <= 31.63f)
                {
                    speed = 0;
                    Dialogue();
                    andarLiberado = false;
                    startDialogueObject.SetActive(false);
                }                
            }

        }
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject == startDialogueObject.gameObject)
            {
                if (this.transform.position.x >= 26.04f && this.transform.position.x <= 31.63f)
                {
                    speed = 0;
                    startDialogueObject.SetActive(false);
                    andarLiberado = false;
                    Dialogue();
                }                
            }

        }
    }

    public void AndarEsq()
    {
        if (andarLiberado)
        {
            direcao = -1;
        }

    }
    public void AndarDir()
    {
        if (andarLiberado)
        {
            direcao = 1;
        }

    }
    public void parar()
    {
        if (andarLiberado)
        {
            direcao = 0;
        }

    }

    void pabloMove()
    {
        if (andarLiberado)
        {
            if (direcao == 1)
            {
                if (scene.name == Cena1)
                {        
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                    isMoving = true;
                }
                else if (scene.name == Cena2)
                {
                    if (this.transform.position.x <= 36.24f)
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                        isMoving = true;
                    }
                    else
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        isMoving = false;
                    }                                      
                }
                else if (scene.name == Cena5)
                {                    
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                    isMoving = true;
                }

            }
            else if (direcao == -1)
            {
                if (scene.name == Cena1)
                {
                    if (this.transform.position.x >= -11.26f)
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                        isMoving = true;
                    }
                    else
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        isMoving = false;
                    }
                }
                else if (scene.name == Cena2)
                {
                    if (this.transform.position.x >= -13.11f)
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                        isMoving = true;
                    }
                    else
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        isMoving = false;
                    }
                }
                else if (scene.name == Cena5)
                {
                    if (this.transform.position.x >= -4.55f)
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                        isMoving = true;
                    }
                    else
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        isMoving = false;
                    }
                }
            }
            else
            {
                if (scene.name == Cena1)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    isMoving = false;
                }
                else if (scene.name == Cena2)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    anim.SetBool("Walk", false);
                    isMoving = false;
                }
                else if (scene.name == Cena5)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    anim.SetBool("Walk", false);
                    isMoving = false;
                }

            }
        }
        else
        {
            if (scene.name == Cena2)
            {
                anim.SetBool("Walk", false);
            }
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }    
}