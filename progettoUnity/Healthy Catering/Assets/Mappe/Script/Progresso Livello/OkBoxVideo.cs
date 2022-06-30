using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class OkBoxVideo : MonoBehaviour
{
    [SerializeField] private GameObject pannello;
    [SerializeField] private TextMeshProUGUI titolo;
    [SerializeField] private TextMeshProUGUI testo;
    [SerializeField] private Image immagineOGIF;

    public static readonly int WASD = 0;
    public static readonly int salto = 1;
    public static readonly int sprint = 2;
    public static readonly int parlaZio = 3;
    public static readonly int vaiAlRistorante = 4;
    public static readonly int meccanicheServireCompatibile = 5;
    public static readonly int meccanicheServireNonCompatibile = 6;
    public static readonly int finitiIngredienti = 7;
    public static readonly int doveEIlNegozio = 8;
    public static readonly int interazioneNPC = 9;
    
    public static bool WASDmostrato = false;
    public static bool saltoMostrato = false;
    public static bool sprintMostrato = false;
    public static bool parlaZioMostrato = false;
    public static bool vaiAlRistoranteMostrato = false;
    public static bool meccanicheServireCompatibileMostrato = false;
    public static bool meccanicheServireNonCompatibileMostrato = false;
    public static bool finitiIngredientiMostrato = false;
    public static bool doveEIlNegozioMostrato = false;
    public static bool interazioneNPCMostrato = false;
    
    List<string> titoli = new List<string>
    {
        "wasd",
        "salto",
        "sprint",
        "parlaZio",
        "vaiAlRistorante",
        "Come servire un cliente compatibile",
        "Come servire un cliente non compatibile",
        "Controllare l'inventario del magazzino del Negozio",
        "Rifornire il Magazzino visitando il Negozio",
        "Acquisire informazioni interagendo con i passanti"
    };

    List<string> testi = new List<string>
    {
        "testo wasd",
        "testo salto",
        "testo sprint",
        "testo parlaZio",
        "testo vaiAlRistorante",
        "COMPATIBILE per poter interagire con i clienti si dovr� utilizzare il mouse come puntatore e selezionare il <color=#B5D99C>piatto</color> che si vuole servire al cliente quando richiesto attraverso la relativa schermata.",
        "NON COMPATIBILEPer poter interagire con i clienti si dovr� utilizzare il mouse come puntatore e selezionare il <color=#B5D99C>piatto</color> che si vuole servire al cliente quando richiesto attraverso la relativa schermata.",
        "testo sono finiti gli ingredienti per fare i piatti",
        "testo Dov'e' il negozio",
        "Interagire con gli <color=#B5D99C>NPC</color> in giro per la citt� permetter� di ottenere <color=#B5D99C>suggerimenti</color> utili per servire piatti migliori, sia dal punto di vista dell�affinit� le patologie che dal punto di vista del nutriScore e dell�ecoScore."
    };

    [SerializeField] private UnityEvent playerStop;
    [SerializeField] private UnityEvent playerRiprendiMovimento;

    void Start()
    {
        pannello.SetActive(false);
        titolo.text = "";
        testo.text = "";
        setImmagineDefault();
    }

    public void apriOkBoxVideo(int posizione)
    {
        pauseGame();
        pannello.SetActive(true);
        playerStop.Invoke();
        PuntatoreMouse.abilitaCursore();
        CambioCursore.cambioCursoreNormale();

        if (posizione < titoli.Count)
        {
            titolo.text = titoli[posizione];
            testo.text = testi[posizione];
            cambiaImmagine(posizione);
        }
        else
        {
            titolo.text = "errore";
            testo.text = "";
            setImmagineDefault();
        }
    }

    public void chiudiOkBoxVideo()
    {
        PuntatoreMouse.disabilitaCursore();
        pannello.SetActive(false);
        playerRiprendiMovimento.Invoke();

        titolo.text = "";
        testo.text = "";
        resumeGame();
    }

    private void cambiaImmagine(int posizione)
    {
        Sprite nuovaImmagine = Resources.Load<Sprite>("immaginiOGifOkBoxVideo/" + "immagineOGifOkBoxVideo " + titoli[posizione]);
        if (nuovaImmagine == null)
        {
            setImmagineDefault();
        }
        else
        {
            immagineOGIF.sprite = nuovaImmagine;
        }
    }

    private void setImmagineDefault (){
        immagineOGIF.sprite = Resources.Load<Sprite>("immaginiOGifOkBoxVideo/immagineOGifOkBoxVideoDefault"); 
    }

    /// <summary>
    /// Metodo per ripristinare lo scorrere del tempo in gioco
    /// </summary>
    void resumeGame()
    {
        Time.timeScale = 1f; //sblocca il tempo
    }

    /// <summary>
    /// Metodo per bloccare lo scorrere del tempo in gioco.
    /// </summary>
    void pauseGame()
    {
        Time.timeScale = 0f; //blocca il tempo
    }
}
