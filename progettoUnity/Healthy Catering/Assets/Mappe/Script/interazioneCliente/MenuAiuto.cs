using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuAiuto : MonoBehaviour
{
    private bool pannelloMenuAiutoAperto;

    [SerializeField] private GameObject pannelloMenuAiuto;
    [SerializeField] private TextMeshProUGUI titoloTestoAiuto;
    [SerializeField] private TextMeshProUGUI testoAiuto;
    [SerializeField] private Button tastoAvanti;
    [SerializeField] private Button tastoIndietro;
    [SerializeField] private TextMeshProUGUI testoNumeroPannelloAttuale;
    [SerializeField] private Image immagineSchermata;

    private int ultimaPosizione = 0;//cosi la prima volta apre il primo messaggio

    private List<string> titoliMessaggiDiAiuto = new List<string>
    {
        "Comandi Movimento del gioco:",
        "Interazione con i clienti:",
        "Scelta del piatto:",
        "Gestione del denaro:",
        "Gestione magazzino:",
        "Come vengono calcolati I bonus:",
        "Interazione con gli NPC:",
        "Rifornirsi di ingredienti dal negozio:",
        "Visionare il ricettario:",
        "Criteri di vittoria e game Over:",
    };
    
    private List<string> messaggiDiAiuto = new List<string>
    {
        "Per potersi muovere all'interno del gioco, bisogna utilizzare i tasti \"" + Utility.coloreVerde + "W" + Utility.fineColore + "\", \"" + Utility.coloreVerde + "A" + Utility.fineColore + "\", \"" + Utility.coloreVerde + "S" + Utility.fineColore + "\", " + Utility.coloreVerde + "D" + Utility.fineColore + "\" per muoversi rispettivamente in \"" +Utility.coloreVerde + "Avanti" + Utility.fineColore + "\", \"" + Utility.coloreVerde + "Sinistra" + Utility.fineColore + "\", \"" + Utility.coloreVerde + "Indietro" + Utility.fineColore + "\", \"" + Utility.coloreVerde + "Destra" + Utility.fineColore + "\". In più premendo il tasto \"" + Utility.coloreVerde + "Spazio" + Utility.fineColore + "\" è possibile saltare. Premendo il tasto \"" + Utility.coloreVerde + "Shift" + Utility.fineColore + "\" è possibile correre.",
        "Per poter interagire con i clienti si dovrà utilizzare il mouse e selezionare il " + Utility.colorePiatti + "piatto" + Utility.fineColore + " che si vuole servire al cliente quando richiesto attraverso la relativa schermata. Per avviare l'interazione con un cliente al bancone, bisogna inquadrarlo e premere il tasto \"" + Utility.coloreVerde + "E" + Utility.fineColore + "\".",
        "Scegliere il piatto migliore fra quelli disponibili, permette al giocatore di aumentare il suo denaro e il suo punteggio così da poter superare il livello. Nel caso si dovesse servire ad un <color=#B5D99C>cliente</color> con una " + Utility.colorePatologia + "patologia" + Utility.fineColore + " X un " + Utility.colorePiatti+ "piatto" + Utility.fineColore + " dove è presente un " + Utility.coloreIngredienti + "ingrediente" + Utility.fineColore + " non compatibile con essa verrà mostrato un pop up dal quale sarà possibile visualizzare quali degli " + Utility.coloreIngredienti + "ingrediente" + Utility.fineColore + " del " + Utility.colorePiatti + "piatto" + Utility.fineColore + " sono compatibili con la " + Utility.colorePatologia + "patologia" + Utility.fineColore + " e quali no. Stesso discorso nel caso in cui si dovesse scegliere un piatto non compatibile con la " + Utility.coloreDieta + "dieta" + Utility.fineColore + " del " + Utility.coloreVerde + "cliente" + Utility.fineColore + ".",
        Utility.colorePiatti + "Più saranno affini i piatti che verranno serviti" + Utility.fineColore + " più incrementerà il denaro del giocatore e più ingredienti potrà compare dal negozio.",
        "Sarà possibile scegliere solo i " + Utility.colorePiatti + "piatti" + Utility.fineColore + " per i quali " + Utility.coloreVerde + "sono disponibili tutti gli ingredienti nelle quantità necessarie" + Utility.fineColore + "; quindi, si dovrà tenere conto degli ingredienti disponibili nel proprio magazzino e comprare gli ingredienti mancanti. É possibile visionoare lo stato del magazzino aprendo il programma \"" + Utility.coloreVerde + "MyInventory" + Utility.fineColore + "\", accessibile nel computer presente nell'ufficio del ristorante.",
        "I <color=#B5D99C>bonus denaro</color> e il <color=#B5D99C>punteggio</color> vengono calcolati in base all’affinità del cliente che si sta servendo ed ai parametri del " + Utility.coloreVerde + "nutriScore" + Utility.fineColore + " e  l'" + Utility.coloreVerde + "ecoScore" + Utility.fineColore + ":\n1. Per quanto riguarda il guadagno monetario verrà assegnato:\n• Un bonus del dieci percento sulla somma dei costi dei singoli ingredienti usati, a prescindere dall’affinità\n• Un bonus del cinque percento se il piatto è affine alla patologia e alla dieta del cliente\n• Ci sarà inoltre una sanzione, sempre del cinque percento nel caso in cui il piatto non fosse affine\n2. Per quanto riguarda il punteggio invece ci sarà:\n• Un punteggio base di 100 punti se il piatto è affine e, ed in tal caso verranno inoltre assegnati i bonus in base al nutriScore e all’ecoScore che partono da -10 percento nel caso peggiore e + 10 percento <u>nel</u> caso migliore; questi 2 bonus verranno calcolati per tutti e 2 gli indicatori quindi, per esempio: nel caso in cui il giocatore dovesse decidere di servire un piatto con il nutriScore più alto ma allo stesso tempo questo piatto inquina molto il punteggio rimarrà invariato.",
        "Interagire con gli <color=#B5D99C>NPC</color> in giro per la città permetterà di ottenere <color=#B5D99C>suggerimenti</color> utili per servire piatti migliori, sia dal punto di vista dell’affinità le patologie che dal punto di vista del " + Utility.coloreVerde + "nutriScore" + Utility.fineColore +  " e dell'" + Utility.coloreVerde +  "ecoScore" + Utility.fineColore + ".",
        "Per acquistare nuovi " + Utility.coloreIngredienti + "ingredienti " + Utility.fineColore + "per il ristorante, bisogna recarsi al " + Utility.coloreVerde + "negozio" + Utility.fineColore + ". Interagendo con il negoziante, sarà possibile scegliere gli ingredienti da acquistare con i soldi a disposizione.",
        "Sul bancone del ristorante è presente il " + Utility.coloreVerde + "ricettario" + Utility.fineColore + " dove è possibile visionare tutte le ricette presenti nel gioco e tutte le ricette realizzabili con un " + Utility.coloreIngredienti + "ingrediente" + Utility.fineColore + ". In più è possibile visionare anche la scheda tecnica di un "  + Utility.coloreIngredienti + "ingrediente" + Utility.fineColore + " e di un " + Utility.colorePiatti+ "piatto" + Utility.fineColore +".",
        "Ad inizio livello verrano visualizzati i criteri per terminare un livello, come per esempio servire un numero X di clienti e raggiungere un punteggio pari a Y. É possibile visionare il progresso degli obbiettivi nella sezione obbiettivi in alto a destra. Una volta superati entrambi gli obbiettivi, il livello sarà considerato terminato e si avvia la schermata di fine livello dopo è possibile avere un breve riepilogo e tornare al menu principale. Il game over, invece, avviene se dopo X clienti serviti, non si raggiungono gli obbiettivi prefissati, oppure non si ha a disposizione il denaro per acquisire nuovi ingredienti. In tal caso, si avvia la schermata di game Over, dove è possibile tornare al menu principale."
    };

    private Animazione animazione;
    List<string> nomiAnimazioni = new List<string>
    {
        "movimenti",
        "default",
        "default",
        "default",
        "default",
        "default",
        "default",
        "default",
        "default",
        "default",
    };

    void Start()
    {
        pannelloMenuAiuto.SetActive(false);

        pannelloMenuAiutoAperto = false;

        tastoAvanti.onClick.AddListener(mostraProssimoMessaggioDiAiuto);
        tastoIndietro.onClick.AddListener(mostraPrecedenteMessaggioDiAiuto);

        testoNumeroPannelloAttuale.text = 1.ToString();

        gestisciBottoniAvantiDietro(ultimaPosizione);

        animazione = immagineSchermata.GetComponent<Animazione>();
    }

    public void apriPannelloMenuAiuto()
    {
        pannelloMenuAiuto.SetActive(true);
        pannelloMenuAiutoAperto = true;

        titoloTestoAiuto.text = titoliMessaggiDiAiuto[ultimaPosizione];
        testoAiuto.text = messaggiDiAiuto[ultimaPosizione];
        cambiaImmagineSchermataAiuto(ultimaPosizione);
    }

    public void chiudiPannelloMenuAiuto()
    {
        pannelloMenuAiuto.SetActive(false);
        pannelloMenuAiutoAperto = false;
    }

    public bool getPannelloMenuAiutoAperto()
    {
        return pannelloMenuAiutoAperto;
    }

    void mostraProssimoMessaggioDiAiuto()
    {
        int prossimaPosizione = ultimaPosizione;
        if (ultimaPosizione != messaggiDiAiuto.Count - 1)
        {
            prossimaPosizione = ultimaPosizione + 1;
        }
        titoloTestoAiuto.text = titoliMessaggiDiAiuto[prossimaPosizione];
        testoAiuto.text = messaggiDiAiuto[prossimaPosizione];
        cambiaImmagineSchermataAiuto(prossimaPosizione);

        ultimaPosizione = prossimaPosizione;//aggiorno l'ultima posizione

        aggiornaTestoNumeroPannelloAttuale(ultimaPosizione);

        gestisciBottoniAvantiDietro(ultimaPosizione);
    }

    private void mostraPrecedenteMessaggioDiAiuto()
    {
        int precedentePosizione = ultimaPosizione;
        if (ultimaPosizione != 0)
        {
            precedentePosizione = ultimaPosizione - 1;
        }
        titoloTestoAiuto.text = titoliMessaggiDiAiuto[precedentePosizione];
        testoAiuto.text = messaggiDiAiuto[precedentePosizione];
        cambiaImmagineSchermataAiuto(precedentePosizione);

        ultimaPosizione = precedentePosizione;//aggiorno l'ultima posizione

        aggiornaTestoNumeroPannelloAttuale(ultimaPosizione);

        gestisciBottoniAvantiDietro(ultimaPosizione);
    }

    private void cambiaImmagineSchermataAiuto(int ultimaPosizione)
    {
        animazione.caricaAnimazione("immaginiAiuto", nomiAnimazioni[ultimaPosizione], "default");
    }

    private void aggiornaTestoNumeroPannelloAttuale(int ultimaPosizione)
    {
        testoNumeroPannelloAttuale.text = (ultimaPosizione + 1).ToString();
    }

    private void gestisciBottoniAvantiDietro(int posizione)
    {
        //tasto avanti
        if (posizione == messaggiDiAiuto.Count - 1)
        {
            tastoAvanti.interactable = false;
        }
        else
        {
            tastoAvanti.interactable = true;
        }

        //tasto indietro
        if (posizione == 0)
        {
            tastoIndietro.interactable = false;
        }
        else
        {
            tastoIndietro.interactable = true;
        }
    }
}
