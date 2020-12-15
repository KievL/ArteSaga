using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class opcoesManager : MonoBehaviour
{
    public GameObject txtCerteza, txtPronto, btnSim, btnNao, btnVoltar;
    public bool certeza = false;
    public bool apagou = false;
    public float crono = 0;
    // Start is called before the first frame update
    void Start()
    {
        txtPronto.SetActive(false);
        txtCerteza.SetActive(false);
        btnSim.SetActive(false);
        btnNao.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        apagouCheck();
        certezaCheck();
    }
    void apagouCheck()
    {
        if (apagou == true)
        {
            crono += Time.deltaTime;
            if(crono >= 5f)
            {
                apagou = false;
                crono = 0;
            }
        }
    }
    void certezaCheck()
    {
        if (certeza == true)
        {
            txtCerteza.SetActive(true);
            btnSim.SetActive(true);
            btnNao.SetActive(true);
        }
    }
    public void apagarTd()
    {
        certeza = true;
    }
    public void apagarSim()
    {
        PlayerPrefs.DeleteAll();
        apagou = true;
        certeza = false;
        crono = 0;
        txtPronto.SetActive(true);
        txtCerteza.SetActive(false);
        btnSim.SetActive(false);
        btnNao.SetActive(false);

    }
    public void apagarNao()
    {
        apagou = false;
        certeza = false;
        txtPronto.SetActive(false);
        txtCerteza.SetActive(false);
        btnSim.SetActive(false);
        btnNao.SetActive(false);
    }
    public void voltar()
    {
        SceneManager.LoadScene("Menu");
    }
}
