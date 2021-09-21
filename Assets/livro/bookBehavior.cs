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

    public GameObject setaDireitaConteudo;
    public GameObject setaEsquerdaConteudo;

    public int page = 0;

    public GameObject livroPag3;
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
    public int EgitoLivro;
    public int GreciaLivro;

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

    //Egito
    public GameObject bloqEgito;

    public GameObject btnAbrirEsculturaEgito;
    public GameObject btnAbrirPinturaEgito;
    public GameObject btnAbrirArquiteturaEgito;

    public GameObject esculturaEgito;
    public GameObject pinturaEgito;
    public GameObject arquiteturaEgito;

    public GameObject closeEsculturaEgito;
    public GameObject closePinturaEgito;
    public GameObject closeArquiteturaEgito;

    //Grecia
    public GameObject bloqGrecia1;
    public GameObject bloqGrecia2;

    public GameObject btnAbrirArquiteturaGrecia;
    public GameObject btnAbrirEsculturaGrecia;
    public GameObject btnAbrirVasosGrecia;

    public GameObject arquiteturaGrecia1, arquiteturaGrecia2, arquiteturaGrecia3;
    public GameObject esculturaGrecia1, esculturaGrecia2, esculturaGrecia3;
    public GameObject vasosGrecia1, vasosGrecia2, vasosGrecia3;

    public GameObject closeArquiteturaGrecia;
    public GameObject closeEsculturaGrecia;
    public GameObject closeVasosGrecia;

    public int pagArquiteturaGrecia = 1;
    public int pagEsculturaGrecia = 1;
    public int pagVasosGrecia = 1;

    // Start is called before the first frame update
    void Start()
    {
        CanvasLivro.SetActive(false);
        btnAbrirLivro.SetActive(true);
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
        EgitoLivro = PlayerPrefs.GetInt("EgitoLivroStep");
        GreciaLivro = PlayerPrefs.GetInt("GreciaLivroStep");
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
        if (EgitoLivro >= 2 && page == 1)
        {
            bloqEgito.SetActive(false);
            btnAbrirEsculturaEgito.SetActive(true);
            btnAbrirPinturaEgito.SetActive(true);
            btnAbrirArquiteturaEgito.SetActive(true);
        }

        if (GreciaLivro == 1 && page == 2)
        {
            bloqGrecia1.SetActive(false);
            btnAbrirArquiteturaGrecia.SetActive(true);
            btnAbrirEsculturaGrecia.SetActive(false);
            btnAbrirVasosGrecia.SetActive(false);
        }else if (GreciaLivro==2 && page == 2)
        {
            bloqGrecia1.SetActive(false);
            bloqGrecia2.SetActive(false);
            btnAbrirArquiteturaGrecia.SetActive(true);
            btnAbrirEsculturaGrecia.SetActive(true);
            btnAbrirVasosGrecia.SetActive(true);
        }
        else if(GreciaLivro==0 && page == 2)
        {
            bloqGrecia1.SetActive(true);
            bloqGrecia2.SetActive(true);
            btnAbrirArquiteturaGrecia.SetActive(false);
            btnAbrirEsculturaGrecia.SetActive(false);
            btnAbrirVasosGrecia.SetActive(false);
        }            

    }
    public void AbrirLivro()
    {
        page = 0;
        abrirAlgo(); 
        livroPag1.SetActive(true);
        livroPag2.SetActive(false);
        livroPag3.SetActive(false);
        setaDireita.SetActive(true);
        setaEsquerda.SetActive(false);
        bloquearTudo();
        bloqueioPag1.SetActive(true);
        tirarBloqueios();
        CanvasLivro.SetActive(true);
        btnAbrirLivro.SetActive(false);               
        closeLivro.SetActive(true);
        
    }

    void bloquearTudo()
    {
        bloqueioPag1.SetActive(false);
        bloqEgito.SetActive(false);
        bloqueioPag2.SetActive(false);
        bloqGrecia1.SetActive(false);
        bloqGrecia2.SetActive(false);
    }

    public void passaPagina()
    {
        if (page == 0)
        {
            page = 1;
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            livroPag1.SetActive(false);
            livroPag2.SetActive(true);
            bloquearTudo();
            bloqEgito.SetActive(true);
            bloqueioPag2.SetActive(true);            
            abrirAlgo();
            tirarBloqueios();
            closeLivro.SetActive(true);            

        }
        else if (page == 1)
        {
            page = 2;
            setaDireita.SetActive(false);
            setaEsquerda.SetActive(true);
            livroPag2.SetActive(false);
            livroPag3.SetActive(true);
            bloquearTudo();
            abrirAlgo();
            tirarBloqueios();
            closeLivro.SetActive(true);                     
        }        
    }
    public void voltarPagina()
    {
        if (page == 1)
        {
            page = 0;
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(false);
            livroPag1.SetActive(true);
            livroPag2.SetActive(false);
            bloquearTudo();
            bloqueioPag1.SetActive(true);
            abrirAlgo();
            tirarBloqueios();
            closeLivro.SetActive(true);            
            
        }
        else if (page == 2)
        {
            page = 1;
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            livroPag2.SetActive(true);
            livroPag3.SetActive(false);
            bloquearTudo();
            bloqEgito.SetActive(true);
            bloqueioPag2.SetActive(true);
            abrirAlgo();
            tirarBloqueios();
            closeLivro.SetActive(true);            
        }
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

        btnAbrirEsculturaEgito.SetActive(false);
        btnAbrirPinturaEgito.SetActive(false);
        btnAbrirArquiteturaEgito.SetActive(false);

        btnAbrirArquiteturaGrecia.SetActive(false);
        btnAbrirEsculturaGrecia.SetActive(false);
        btnAbrirVasosGrecia.SetActive(false);

        closeLivro.SetActive(false);
    }

    void tirarSetas()
    {
        setaDireita.SetActive(false);
        setaEsquerda.SetActive(false);
    }

    public void fecharAlgo()
    {    
        if (page == 0)
        {
            abrirAlgo();
            livroPag1.SetActive(true);
            livroPag2.SetActive(false);
            livroPag3.SetActive(false);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(false);
            bloquearTudo();
            bloqueioPag1.SetActive(true);
            tirarBloqueios();
            closeLivro.SetActive(true);
        }else if (page == 1)
        {
            abrirAlgo();
            livroPag1.SetActive(false);
            livroPag2.SetActive(true);
            livroPag3.SetActive(false);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            bloquearTudo();
            bloqueioPag2.SetActive(true);
            bloqEgito.SetActive(true);
            tirarBloqueios();
            closeLivro.SetActive(true);
        }else if (page == 2)
        {
            abrirAlgo();
            livroPag1.SetActive(false);
            livroPag2.SetActive(false);
            livroPag3.SetActive(true);
            setaDireita.SetActive(false);
            setaEsquerda.SetActive(true);
            bloquearTudo();
            bloqGrecia1.SetActive(true);
            bloqGrecia2.SetActive(true);
            tirarBloqueios();
            closeLivro.SetActive(true);
        }
    }

    //Paleo
    public void AbrirContexto()
    {
        abrirAlgo();
        tirarSetas();
        closeContextoPaleo.SetActive(true);
        contextoPaleo.SetActive(true);


    }
    public void AbrirVenus()
    {
        abrirAlgo();
        tirarSetas();
        closeVenus.SetActive(true);
        venus.SetActive(true);


    }
    public void AbrirGravuras()
    {
        abrirAlgo();
        tirarSetas();
        closeGravuras.SetActive(true);
        gravuras.SetActive(true);


    }
    public void AbrirArtefatos()
    {
        abrirAlgo();
        tirarSetas();
        closeArtefatos.SetActive(true);
        artefatos.SetActive(true);

    }

    //Neo
    public void AbrirContextoNeo()
    {
        abrirAlgo();
        tirarSetas();
        closeContextoNeo.SetActive(true);
        contextNeo.SetActive(true);

    }
    public void AbrirTecelagemNeo()
    {
        abrirAlgo();
        tirarSetas();
        closeTecelagem.SetActive(true);
        tecelagem.SetActive(true);

    }
    public void AbrirPinturas()
    {
        abrirAlgo();
        tirarSetas();
        closePinturas.SetActive(true);
        pinturas.SetActive(true);

    }
    public void AbrirCeramica()
    {
        abrirAlgo();
        tirarSetas();
        closeCeramica.SetActive(true);
        ceramica.SetActive(true);

    }

    //Metais
    public void AbrirContextoMetal()
    {
        abrirAlgo();
        tirarSetas();
        closeContextoMetal.SetActive(true);
        contextMetal.SetActive(true);

    }
    public void AbrirEsculturasMetal()
    {
        abrirAlgo();
        tirarSetas();
        closeEsculturas.SetActive(true);
        esculturasMetal.SetActive(true);

    }
    public void AbrirOuviseria()
    {
        abrirAlgo();
        tirarSetas();
        closeOuviseria.SetActive(true);
        ouviseria.SetActive(true);

    }

    //Egito
    public void AbrirArquitetura()
    {
        abrirAlgo();
        tirarSetas();
        closeArquiteturaEgito.SetActive(true);
        arquiteturaEgito.SetActive(true);

    }
    public void AbrirEscultura()
    {
        abrirAlgo();
        tirarSetas();
        closeEsculturaEgito.SetActive(true);
        esculturaEgito.SetActive(true);

    }
    public void AbrirPinturaEgito()
    {
        abrirAlgo();
        tirarSetas();

        closePinturaEgito.SetActive(true);
        pinturaEgito.SetActive(true);

    }

    //Grecia
    public void AbrirArquiteturaGrecia()
    {
        abrirAlgo();
        tirarSetas();
        pagArquiteturaGrecia = 1;
        setaDireitaConteudo.SetActive(true);
        closeArquiteturaGrecia.SetActive(true);
        arquiteturaGrecia1.SetActive(true);
    }
    public void AbrirEsculturaGrecia()
    {
        abrirAlgo();
        tirarSetas();
        pagEsculturaGrecia = 1;
        setaDireitaConteudo.SetActive(true);
        closeEsculturaGrecia.SetActive(true);
        esculturaGrecia1.SetActive(true);
    }
    public void AbrirVasosGrecia()
    {
        abrirAlgo();
        tirarSetas();
        pagVasosGrecia = 1;
        setaDireitaConteudo.SetActive(true);
        closeVasosGrecia.SetActive(true);
        vasosGrecia1.SetActive(true);
    }

    void checkarPagArquiteturaGrecia()
    {
        if (pagArquiteturaGrecia == 2)
        {
            arquiteturaGrecia1.SetActive(false);
            arquiteturaGrecia2.SetActive(true);
            arquiteturaGrecia3.SetActive(false);
            setaDireitaConteudo.SetActive(true);
            setaEsquerdaConteudo.SetActive(true);
        }
        else if (pagArquiteturaGrecia == 3)
        {
            arquiteturaGrecia1.SetActive(false);
            arquiteturaGrecia2.SetActive(false);
            arquiteturaGrecia3.SetActive(true);
            setaDireitaConteudo.SetActive(false);
            setaEsquerdaConteudo.SetActive(true);
        }
        else
        {
            arquiteturaGrecia1.SetActive(true);
            arquiteturaGrecia2.SetActive(false);
            arquiteturaGrecia3.SetActive(false);
            setaDireitaConteudo.SetActive(true);
            setaEsquerdaConteudo.SetActive(false);
        }
    }
    void checkarPagEsculturaGrecia()
    {
        if (pagEsculturaGrecia == 2)
        {
            esculturaGrecia1.SetActive(false);
            esculturaGrecia2.SetActive(true);
            esculturaGrecia3.SetActive(false);
            setaDireitaConteudo.SetActive(true);
            setaEsquerdaConteudo.SetActive(true);
        }
        else if (pagEsculturaGrecia == 3)
        {
            esculturaGrecia1.SetActive(false);
            esculturaGrecia2.SetActive(false);
            esculturaGrecia3.SetActive(true);
            setaDireitaConteudo.SetActive(false);
            setaEsquerdaConteudo.SetActive(true);
        }
        else
        {
            esculturaGrecia1.SetActive(false);
            esculturaGrecia2.SetActive(false);
            esculturaGrecia3.SetActive(true);
            setaDireitaConteudo.SetActive(true);
            setaEsquerdaConteudo.SetActive(false);
        }
    }
    void checkarPagVasosGrecia()
    {
        if (pagVasosGrecia == 2)
        {
            vasosGrecia1.SetActive(false);
            vasosGrecia2.SetActive(true);
            vasosGrecia3.SetActive(false);
            setaDireitaConteudo.SetActive(true);
            setaEsquerdaConteudo.SetActive(true);
        }
        else if (pagVasosGrecia == 3)
        {
            vasosGrecia1.SetActive(false);
            vasosGrecia2.SetActive(false);
            vasosGrecia3.SetActive(true);
            setaDireitaConteudo.SetActive(false);
            setaEsquerdaConteudo.SetActive(true);
        }
        else
        {
            vasosGrecia1.SetActive(true);
            vasosGrecia2.SetActive(false);
            vasosGrecia3.SetActive(false);
            setaDireitaConteudo.SetActive(true);
            setaEsquerdaConteudo.SetActive(false);
        }
    }

    public void passarConteudo()
    {
        if (closeArquiteturaGrecia.activeSelf)
        {
            pagArquiteturaGrecia++;
            checkarPagArquiteturaGrecia();
        }
        else if (closeEsculturaGrecia.activeSelf)
        {
            pagEsculturaGrecia++;
            checkarPagEsculturaGrecia();
        }
        else if (closeVasosGrecia.activeSelf)
        {
            pagVasosGrecia++;
            checkarPagVasosGrecia();
        }

    }
    public void voltarConteudo()
    {
        if (closeArquiteturaGrecia.activeSelf)
        {
            pagArquiteturaGrecia--;
            checkarPagArquiteturaGrecia();
        }
        else if (closeEsculturaGrecia.activeSelf)
        {
            pagEsculturaGrecia--;
            checkarPagEsculturaGrecia();
        }
        else if (closeVasosGrecia.activeSelf)
        {
            pagVasosGrecia--;
            checkarPagVasosGrecia();
        }

    }


    //FecharGrecia
    public void FecharArquiteturaGrecia()
    {
        fecharAlgo();
        closeArquiteturaGrecia.SetActive(false);
        arquiteturaGrecia1.SetActive(false);
        arquiteturaGrecia2.SetActive(false);
        arquiteturaGrecia3.SetActive(false);
        setaDireitaConteudo.SetActive(false);
        setaEsquerdaConteudo.SetActive(false);
    }
    public void FecharEsculturaGrecia()
    {
        fecharAlgo();
        closeEsculturaGrecia.SetActive(false);
        esculturaGrecia1.SetActive(false);
        esculturaGrecia2.SetActive(false);
        esculturaGrecia3.SetActive(false);
        setaDireitaConteudo.SetActive(false);
        setaEsquerdaConteudo.SetActive(false);
    }
    public void FecharVasosGrecia()
    {
        fecharAlgo();
        closeVasosGrecia.SetActive(false);
        vasosGrecia1.SetActive(false);
        vasosGrecia2.SetActive(false);
        vasosGrecia3.SetActive(false);
        setaDireitaConteudo.SetActive(false);
        setaEsquerdaConteudo.SetActive(false);
    }

    //FecharEgito
    public void FecharPinturaEgito()
    {
        fecharAlgo();
        closePinturaEgito.SetActive(false);
        pinturaEgito.SetActive(false);

    }
    public void FecharEscultura()
    {
        fecharAlgo();
        closeEsculturaEgito.SetActive(false);
        esculturaEgito.SetActive(false);

    }
    public void FecharArquitetura()
    {
        fecharAlgo();
        closeArquiteturaEgito.SetActive(false);
        arquiteturaEgito.SetActive(false);

    }

    //FecharMetais
    public void FecharContextoMetal()
    {
        fecharAlgo();
        closeContextoMetal.SetActive(false);
        contextMetal.SetActive(false);


    }
    public void FecharOuviseria()
    {
        fecharAlgo();
        closeOuviseria.SetActive(false);
        ouviseria.SetActive(false);


    }
    public void FecharEsculturas()
    {
        fecharAlgo();
        closeEsculturas.SetActive(false);
        esculturasMetal.SetActive(false);

    }

    //FecharNeolítico
    public void FecharContextoNeo()
    {
        fecharAlgo();
        closeContextoNeo.SetActive(false);
        contextNeo.SetActive(false);

    }
    public void FecharPinturas()
    {
        fecharAlgo();
        closePinturas.SetActive(false);
        pinturas.SetActive(false);

    }
    public void FecharCeramica()
    {
        fecharAlgo();
        closeCeramica.SetActive(false);
        ceramica.SetActive(false);

    }
    public void FecharTecelagem()
    {
        fecharAlgo();
        closeTecelagem.SetActive(false);
        tecelagem.SetActive(false);

    }

    //FecharPaleo
    public void FecharVenus()
    {
        fecharAlgo();
        closeVenus.SetActive(false);
        venus.SetActive(false);

    }    
    public void FecharContexto()
    {
        fecharAlgo();
        closeContextoPaleo.SetActive(false);
        contextoPaleo.SetActive(false);

    }
    public void FecharGravuras()
    {
        fecharAlgo();
        closeGravuras.SetActive(false);
        gravuras.SetActive(false);

    }
    public void FecharArtefatos()
    {
        fecharAlgo();
        closeArtefatos.SetActive(false);
        artefatos.SetActive(false);

    }

    public void FecharLivro()
    {
        CanvasLivro.SetActive(false);
        btnAbrirLivro.SetActive(true);

    }   


}
