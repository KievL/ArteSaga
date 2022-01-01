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

    public GameObject livroPag3, livroPag1, livroPag2, livroPag4;

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
    public int GoticaLivro;
    public int RenascLivro;

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

    //Gotica
    public GameObject bloqGotica;
    public GameObject btnAbrirIntroGotic, btnAbrirEsculturaGotic, btnAbrirArquiteturaGotic, btnAbrirPinturasGotic, btnAbrirVitralGotic, btnAbrirIluminurasGotic;
    public GameObject introGotic, esculturaGotic, arquiteturaGotic, pinturasGotic, vitralGotic, iluminurasGotic;
    public GameObject closeIntroGotic, closeEsculturaGotic, closeArquiteturaGotic, closePinturasGotic, closeVitralGotic, closeIluminurasGotic;

    //Renascimento
    public GameObject bloqRenasc;
    public GameObject btnAbrirContextRenasc, btnAbrirRepresentRenasc, btnAbrirCartas, btnsCartasRenasc;
    public GameObject contextRenasc1, contextRenasc2, contextRenasc3, representRenasc1, representRenasc2, cartasRenasc, cartasAbertasRenasc;
    public GameObject closeContextRenasc, closeRepresentRenasc, closeCartasRenasc, closeCartaAbertaRenasc;
    public GameObject t1,t2,t3,t4,t5,t6,t7,t8,t9,t10;

    public int pagContextRenasc = 1;
    public int pagRepresentRenasc=1;

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
        GoticaLivro = PlayerPrefs.GetInt("GoticaLivroStep");
        RenascLivro = PlayerPrefs.GetInt("RenascLivroStep");

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

        if (GoticaLivro >= 1 && page == 3)
        {
            bloqGotica.SetActive(false);
            btnAbrirIntroGotic. SetActive(true);
            btnAbrirArquiteturaGotic.SetActive(true);
            btnAbrirEsculturaGotic.SetActive(true);
            btnAbrirIluminurasGotic.SetActive(true);
            btnAbrirVitralGotic.SetActive(true);
            btnAbrirPinturasGotic.SetActive(true);
        }else if(GoticaLivro!=1 && page==3){
            bloqGotica.SetActive(true);
            btnAbrirIntroGotic. SetActive(false);
            btnAbrirArquiteturaGotic.SetActive(false);
            btnAbrirEsculturaGotic.SetActive(false);
            btnAbrirIluminurasGotic.SetActive(false);
            btnAbrirVitralGotic.SetActive(false);
            btnAbrirPinturasGotic.SetActive(false);
        }

        if(RenascLivro >= 1 && page==3){
            bloqRenasc.SetActive(false);
            btnAbrirContextRenasc.SetActive(true);
            btnAbrirRepresentRenasc.SetActive(true);
            btnAbrirCartas.SetActive(true);

        }else if (RenascLivro!=1 && page==3){
            bloqRenasc.SetActive(true);
            btnAbrirContextRenasc.SetActive(false);
            btnAbrirRepresentRenasc.SetActive(false);
            btnAbrirCartas.SetActive(false);
        }
    }
    public void AbrirLivro()
    {
        page = 0;
        abrirAlgo(); 
        livroPag1.SetActive(true);
        livroPag2.SetActive(false);
        livroPag3.SetActive(false);
        livroPag4.SetActive(false);
        setaDireita.SetActive(true);
        setaEsquerda.SetActive(false);
        bloquearTudo();
        bloqueioPag1.SetActive(true);        
        CanvasLivro.SetActive(true);
        btnAbrirLivro.SetActive(false);               
        closeLivro.SetActive(true);
        tirarBloqueios();
        
    }

    void bloquearTudo()
    {
        bloqueioPag1.SetActive(false);
        bloqEgito.SetActive(false);
        bloqueioPag2.SetActive(false);
        bloqGrecia1.SetActive(false);
        bloqGrecia2.SetActive(false);
        bloqGotica.SetActive(false);
        bloqRenasc.SetActive(false);
    }

    public void passaPagina()
    {
        if (page == 0)
        {
            page = 1;
            abrirAlgo();
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            bloquearTudo();
            livroPag1.SetActive(false);
            livroPag2.SetActive(true);            
            bloqEgito.SetActive(true);
            bloqueioPag2.SetActive(true);
            tirarBloqueios();                               

        }
        else if (page == 1)
        {
            page = 2;
            abrirAlgo();
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            bloquearTudo();
            livroPag2.SetActive(false);
            livroPag3.SetActive(true);
            tirarBloqueios();
                                
        }
        else if(page==2)
        {
            page=3;
            abrirAlgo();
            setaDireita.SetActive(false);
            setaEsquerda.SetActive(true);
            bloquearTudo();
            livroPag4.SetActive(true);
            livroPag3.SetActive(false);
            tirarBloqueios();
        }     
                        
        closeLivro.SetActive(true);    
    }
    public void voltarPagina()
    {
        if (page == 1)
        {
            page = 0;
            abrirAlgo();
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(false);
            bloquearTudo();
            livroPag1.SetActive(true);
            livroPag2.SetActive(false);
            bloqueioPag1.SetActive(true);
            tirarBloqueios();          
            
        }
        else if (page == 2)
        {
            page = 1;
            abrirAlgo();
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            bloquearTudo();
            livroPag2.SetActive(true);
            livroPag3.SetActive(false);            
            bloqEgito.SetActive(true);
            bloqueioPag2.SetActive(true);
            closeLivro.SetActive(true);  
            tirarBloqueios();          
        }else if(page==3){
            page=2;
            abrirAlgo();
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            bloquearTudo();
            livroPag3.SetActive(true);
            livroPag4.SetActive(false);
            bloqGrecia1.SetActive(true);
            bloqGrecia2.SetActive(true);
            tirarBloqueios();

        }        
        closeLivro.SetActive(true); 
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

        btnAbrirIntroGotic.SetActive(false);
        btnAbrirArquiteturaGotic.SetActive(false);
        btnAbrirEsculturaGotic.SetActive(false);
        btnAbrirPinturasGotic.SetActive(false);
        btnAbrirIluminurasGotic.SetActive(false);
        btnAbrirVitralGotic.SetActive(false);

        btnAbrirContextRenasc.SetActive(false);
        btnAbrirRepresentRenasc.SetActive(false);
        btnAbrirCartas.SetActive(false);

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
            livroPag1.SetActive(true);
            livroPag2.SetActive(false);
            livroPag3.SetActive(false);
            livroPag4.SetActive(false);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(false);
            bloqueioPag1.SetActive(true);
            closeLivro.SetActive(true);
        }else if (page == 1)
        {
            livroPag1.SetActive(false);
            livroPag2.SetActive(true);
            livroPag3.SetActive(false);
            livroPag4.SetActive(false);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            bloqueioPag2.SetActive(true);
            bloqEgito.SetActive(true);
            closeLivro.SetActive(true);
        }else if (page == 2)
        {
            livroPag1.SetActive(false);
            livroPag2.SetActive(false);
            livroPag3.SetActive(true);
            livroPag4.SetActive(false);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);            
            bloqGrecia1.SetActive(true);
            bloqGrecia2.SetActive(true);            
            closeLivro.SetActive(true);
        }else if(page==3){
            livroPag1.SetActive(false);
            livroPag2.SetActive(false);
            livroPag3.SetActive(false);
            livroPag4.SetActive(true);
            setaDireita.SetActive(false);
            setaEsquerda.SetActive(true);            
            bloqGotica.SetActive(true);
            bloqRenasc.SetActive(true);         
            closeLivro.SetActive(true);
        }
        abrirAlgo();
        bloquearTudo();
        tirarBloqueios();
        closeLivro.SetActive(true);
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
        }else if (closeContextRenasc.activeSelf)
        {
            pagContextRenasc++;
            checkarPagContextRenasc();
        }
        else if (closeRepresentRenasc.activeSelf)
        {
            pagRepresentRenasc++;
            checkarPagRepresentRenasc();
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
        }else if (closeContextRenasc.activeSelf)
        {
            pagContextRenasc--;
            checkarPagContextRenasc();
        }
        else if (closeRepresentRenasc.activeSelf)
        {
            pagRepresentRenasc--;
            checkarPagRepresentRenasc();
        }

    }

    //Gotica
    public void AbrirIntroGotica(){
        abrirAlgo();
        tirarSetas();
        closeIntroGotic.SetActive(true);
        introGotic.SetActive(true);
    }
    public void AbrirArquiteturaGotica(){
        abrirAlgo();
        tirarSetas();
        closeArquiteturaGotic.SetActive(true);
        arquiteturaGotic.SetActive(true);
    }
    public void AbrirEsculturaGotica(){
        abrirAlgo();
        tirarSetas();
        closeEsculturaGotic.SetActive(true);
        esculturaGotic.SetActive(true);
    }
    public void AbrirVitraisGotica(){
        abrirAlgo();
        tirarSetas();
        closeVitralGotic.SetActive(true);
        vitralGotic.SetActive(true);
    }
    public void AbrirIluminurasGotica(){
        abrirAlgo();
        tirarSetas();
        closeIluminurasGotic.SetActive(true);
        iluminurasGotic.SetActive(true);
    }
    public void AbrirPinturasGotica(){
        abrirAlgo();
        tirarSetas();
        pinturasGotic.SetActive(true);
        closePinturasGotic.SetActive(true);
    }

    //Renascimento
    public void AbrirContextRenasc()
    {
        abrirAlgo();
        tirarSetas();
        pagContextRenasc = 1;
        setaDireitaConteudo.SetActive(true);
        closeContextRenasc.SetActive(true);
        contextRenasc1.SetActive(true);
    }
    public void AbrirRepresentRenasc()
    {
        abrirAlgo();
        tirarSetas();
        pagRepresentRenasc = 1;
        setaDireitaConteudo.SetActive(true);
        closeRepresentRenasc.SetActive(true);
        representRenasc1.SetActive(true);
    }
    public void AbrirCartasRenasc()
    {
        abrirAlgo();
        tirarSetas();
        closeCartasRenasc.SetActive(true);
        btnsCartasRenasc.SetActive(true);
        cartasRenasc.SetActive(true);
    }
    void checkarPagContextRenasc()
    {
        if (pagContextRenasc == 2)
        {
            contextRenasc1.SetActive(false);
            contextRenasc2.SetActive(true);
            contextRenasc3.SetActive(false);
            setaDireitaConteudo.SetActive(true);
            setaEsquerdaConteudo.SetActive(true);
        }
        else if (pagContextRenasc == 3)
        {
            contextRenasc1.SetActive(false);
            contextRenasc2.SetActive(false);
            contextRenasc3.SetActive(true);
            setaDireitaConteudo.SetActive(false);
            setaEsquerdaConteudo.SetActive(true);
        }
        else
        {
            contextRenasc1.SetActive(true);
            contextRenasc2.SetActive(false);
            contextRenasc3.SetActive(false);
            setaDireitaConteudo.SetActive(true);
            setaEsquerdaConteudo.SetActive(false);
        }
    }
    void checkarPagRepresentRenasc()
    {
        if (pagRepresentRenasc == 2)
        {
            representRenasc1.SetActive(false);
            representRenasc2.SetActive(true);
            setaDireitaConteudo.SetActive(false);
            setaEsquerdaConteudo.SetActive(true);
        }        
        else
        {
            representRenasc1.SetActive(true);
            representRenasc2.SetActive(false);
            setaDireitaConteudo.SetActive(true);
            setaEsquerdaConteudo.SetActive(false);
        }
    }    
    public void abrirCartas1Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t1);
    }
    public void abrirCartas2Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t2);
    }
    public void abrirCartas3Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t3);
    }
    public void abrirCartas4Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t4);
    }
    public void abrirCartas5Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t5);
    }    
    public void abrirCartas6Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t6);
    }
    public void abrirCartas7Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t7);
    }
    public void abrirCartas8Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t8);
    }
    public void abrirCartas9Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t9);
    }
    public void abrirCartas10Renasc(){
        closeCartasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(true);
        cartasAbertasRenasc.SetActive(true);
        qualCartaAbrir(t10);
    }
    void qualCartaAbrir(GameObject t){
        t.SetActive(true);
        btnsCartasRenasc.SetActive(false);
    }
    public void fecharCartaAbertaRenasc(){
        cartasAbertasRenasc.SetActive(false);
        closeCartaAbertaRenasc.SetActive(false);
        btnsCartasRenasc.SetActive(true);
        closeCartasRenasc.SetActive(true);
        t1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(false);
        t4.SetActive(false);
        t5.SetActive(false);
        t6.SetActive(false);
        t7.SetActive(false);
        t8.SetActive(false);
        t9.SetActive(false);
        t10.SetActive(false);
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

    //FecharGotica
    public void FecharIntroGotica()
    {
        fecharAlgo();
        closeIntroGotic.SetActive(false);
        introGotic.SetActive(false);

    } 
    public void FecharEsculturasGotica()
    {
        fecharAlgo();
        closeEsculturaGotic.SetActive(false);
        esculturaGotic.SetActive(false);

    } 
    public void FecharArquiteturaGotica()
    {
        fecharAlgo();
        closeArquiteturaGotic.SetActive(false);
        arquiteturaGotic.SetActive(false);

    } 
    public void FecharPinturasGotica()
    {
        fecharAlgo();
        closePinturasGotic.SetActive(false);
        pinturasGotic.SetActive(false);

    } 
    public void FecharIluminurasGotica()
    {
        fecharAlgo();
        closeIluminurasGotic.SetActive(false);
        iluminurasGotic.SetActive(false);

    } 
    public void FecharVitralGotica()

    {
        fecharAlgo();
        closeVitralGotic.SetActive(false);
        vitralGotic.SetActive(false);

    } 
    //Fechar Renasc
    public void FecharContextRenasc()
    {
        fecharAlgo();
        closeContextRenasc.SetActive(false);
        contextRenasc1.SetActive(false);
        contextRenasc2.SetActive(false);
        contextRenasc3.SetActive(false);
        setaDireitaConteudo.SetActive(false);
        setaEsquerdaConteudo.SetActive(false);
    }
    public void FecharRepresentRenasc()
    {
        fecharAlgo();
        closeRepresentRenasc.SetActive(false);
        representRenasc1.SetActive(false);
        representRenasc2.SetActive(false);
        setaDireitaConteudo.SetActive(false);
        setaEsquerdaConteudo.SetActive(false);
    }
    public void FecharCartasRenasc()
    {
        fecharAlgo();
        closeCartasRenasc.SetActive(false);
        cartasRenasc.SetActive(false);
        setaDireitaConteudo.SetActive(false);
        setaEsquerdaConteudo.SetActive(false);
    }
}

    