using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathCanvas : MonoBehaviour
{
    public static bool isDead = false;
    public GameObject deathScreen;
    // Start is called before the first frame update
    void Start()
    {
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            deathScreen.SetActive(true);
        }
    }
    public void aceito()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isDead = false;
        primitivoBehaviour.pularLiberado = false;
        primitivoBehaviour.vidas = 3;
        PaleoManager.isCorrendo = false;
        PaleoManager.aguiaNascer = false;
        SpawnAguiaCima.allowed = false;
        SpawnAguiaBaixo.transition = 0;
        PaleoManager.aguasPasssadas = 0;
        primitivoBehaviour.ganhou = false;
        Time.timeScale = 1f;

    }
}
