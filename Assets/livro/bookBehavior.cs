using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookBehavior : MonoBehaviour
{
    public GameObject CanvasLivro;
    public GameObject btnAbrirLivro;
    public GameObject closeLivro;
    public GameObject setaDireita;
    public GameObject setaEsquerda;
    public int page = 0;
    public GameObject livroPag2;
    public GameObject livroPag1;
    public GameObject bloqueioPag2;
    public GameObject bloqueioPag1;

    //Paleolitico
    public GameObject btnAbrirVenus;
    public GameObject btnAbrirContextoPaleo;
    public GameObject btnAbrirArtefatos;
    public GameObject btnAbrirGravuras;

    public GameObject contextoPaleo;
    public GameObject venus;
    public GameObject artefatos;
    public GameObject gravuras;

    public GameObject closeContextoPaleo;
    public GameObject closeVenus;
    public GameObject closeArtefatos;
    public GameObject closeGravuras;

    public GameObject BloqPaleo1;
    public GameObject BloqPaleo2;

    public int PaleoLivro;
    public int NeoLivro;
    public int MetalLivro;

    //Neolítico
    public GameObject Bloq1Neo;
    public GameObject Bloq2Neo;

    public GameObject btnAbrirContextoNeo;
    public GameObject btnAbrirPinturasNeo;
    public GameObject btnAbrirCeramicaNeo;
    public GameObject btnAbrirTeceNeo;

    public GameObject contextNeo;
    public GameObject pinturas;
    public GameObject ceramica;
    public GameObject tecelagem;

    public GameObject closeContextoNeo;
    public GameObject closeTecelagem;
    public GameObject closeCeramica;
    public GameObject closePinturas;

    //Metais
    public GameObject bloqMetal;

    public GameObject btnAbrirContextoMetal;
    public GameObject btnAbrirEsculturasMetal;
    public GameObject btnAbrirOuviseria;

    public GameObject contextMetal;
    public GameObject esculturasMetal;
    public GameObject ouviseria;

    public GameObject closeContextoMetal;
    public GameObject closeEsculturas;
    public GameObject closeOuviseria;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tirarBloqueios()
    {
        PaleoLivro = PlayerPrefs.GetInt("PaleoLivroStep");
        NeoLivro = PlayerPrefs.GetInt("NeoLivroStep");
        MetalLivro = PlayerPrefs.GetInt("MetalLivroStep");
        if (PaleoLivro >= 2 && page == 0)
        {
            BloqPaleo1.SetActive(false);
            btnAbrirGravuras.SetActive(true);
            btnAbrirContextoPaleo.SetActive(true);

        }
        if (PaleoLivro >= 3 && page == 0)
        {
            BloqPaleo2.SetActive(false);
            btnAbrirArtefatos.SetActive(true);
            btnAbrirVenus.SetActive(true);
        }
        if(NeoLivro >= 2 && page == 0)
        {
            Bloq1Neo.SetActive(false);
            Bloq2Neo.SetActive(false);
            btnAbrirCeramicaNeo.SetActive(true);
            btnAbrirContextoNeo.SetActive(true);
            btnAbrirPinturasNeo.SetActive(true);
            btnAbrirTeceNeo.SetActive(true);

        }
        if(MetalLivro >= 2 && page ==1)
        {
            bloqMetal.SetActive(false);
            btnAbrirContextoMetal.SetActive(true);
            btnAbrirOuviseria.SetActive(true);
            btnAbrirEsculturasMetal.SetActive(true);
            
        }
    }
    public void AbrirLivro()
    {
        page = 0;
        abrirAlgo(); 
        livroPag1.SetActive(true);
        livroPag2.SetActive(false);
        setaDireita.SetActive(true);
        setaEsquerda.SetActive(false);
        tirarBloqueios();
        CanvasLivro.SetActive(true);
        btnAbrirLivro.SetActive(false);               
        closeLivro.SetActive(true);
        bloqueioPag1.SetActive(true);
        bloqueioPag2.SetActive(false);
        
    }

    public void passaPagina()
    {
        page = 1;
        setaDireita.SetActive(false);
        setaEsquerda.SetActive(true);
        livroPag1.SetActive(false);
        livroPag2.SetActive(true);
        abrirAlgo();
        tirarBloqueios();
        closeLivro.SetActive(true);
        bloqueioPag2.SetActive(true);
        bloqueioPag1.SetActive(false);

    }

    public void abrirAlgo()
    {
        btnAbrirContextoPaleo.SetActive(false);
        btnAbrirVenus.SetActive(false);
        btnAbrirGravuras.SetActive(false);
        btnAbrirArtefatos.SetActive(false);

        btnAbrirCeramicaNeo.SetActive(false);
        btnAbrirContextoNeo.SetActive(false);
        btnAbrirPinturasNeo.SetActive(false);
        btnAbrirTeceNeo.SetActive(false);

        btnAbrirContextoMetal.SetActive(false);
        btnAbrirEsculturasMetal.SetActive(false);
        btnAbrirOuviseria.SetActive(false);

        closeLivro.SetActive(false);
    }
    
    public void AbrirContexto()
    {
        abrirAlgo();
        closeContextoPaleo.SetActive(true);
        contextoPaleo.SetActive(true);


    }
    public void AbrirVenus()
    {
        abrirAlgo();
        closeVenus.SetActive(true);
        venus.SetActive(true);


    }
    public void AbrirGravuras()
    {
        abrirAlgo();
        closeGravuras.SetActive(true);
        gravuras.SetActive(true);


    }
    public void AbrirArtefatos()
    {
        abrirAlgo();
        closeArtefatos.SetActive(true);
        artefatos.SetActive(true);

    }

    public void AbrirContextoNeo()
    {
        abrirAlgo();
        closeContextoNeo.SetActive(true);
        contextNeo.SetActive(true);

    }
    public void AbrirTecelagemNeo()
    {
        abrirAlgo();
        closeTecelagem.SetActive(true);
        tecelagem.SetActive(true);

    }
    public void AbrirPinturas()
    {
        abrirAlgo();
        closePinturas.SetActive(true);
        pinturas.SetActive(true);

    }
    public void AbrirCeramica()
    {
        abrirAlgo();
        closeCeramica.SetActive(true);
        ceramica.SetActive(true);

    }
    public void AbrirContextoMetal()
    {
        abrirAlgo();
        closeContextoMetal.SetActive(true);
        contextMetal.SetActive(true);

    }
    public void AbrirEsculturasMetal()
    {
        abrirAlgo();
        closeEsculturas.SetActive(true);
        esculturasMetal.SetActive(true);

    }
    public void AbrirOuviseria()
    {
        abrirAlgo();
        closeOuviseria.SetActive(true);
        ouviseria.SetActive(true);

    }
    public void FecharContextoMetal()
    {
        passaPagina();
        closeContextoMetal.SetActive(false);
        contextMetal.SetActive(false);


    }
    public void FecharOuviseria()
    {
        passaPagina();
        closeOuviseria.SetActive(false);
        ouviseria.SetActive(false);


    }
    public void FecharEsculturas()
    {
        passaPagina();
        closeEsculturas.SetActive(false);
        esculturasMetal.SetActive(false);


    }
    public void FecharContextoNeo()
    {
        AbrirLivro();
        closeContextoNeo.SetActive(false);
        contextNeo.SetActive(false);


    }
    public void FecharPinturas()
    {
        AbrirLivro();
        closePinturas.SetActive(false);
        pinturas.SetActive(false);


    }
    public void FecharCeramica()
    {
        AbrirLivro();
        closeCeramica.SetActive(false);
        ceramica.SetActive(false);


    }
    public void FecharTecelagem()
    {
        AbrirLivro();
        closeTecelagem.SetActive(false);
        tecelagem.SetActive(false);


    }

    public void FecharVenus()
    {
        AbrirLivro();
        closeVenus.SetActive(false);
        venus.SetActive(false);


    }
    public void FecharContexto()
    {
        AbrirLivro();
        closeContextoPaleo.SetActive(false);
        contextoPaleo.SetActive(false);

    }
    public void FecharGravuras()
    {
        AbrirLivro();
        closeGravuras.SetActive(false);
        gravuras.SetActive(false);

    }
    public void FecharArtefatos()
    {
        AbrirLivro();
        closeArtefatos.SetActive(false);
        artefatos.SetActive(false);

    }
    public void FecharLivro()
    {
        CanvasLivro.SetActive(false);
        btnAbrirLivro.SetActive(true);

    }


}
