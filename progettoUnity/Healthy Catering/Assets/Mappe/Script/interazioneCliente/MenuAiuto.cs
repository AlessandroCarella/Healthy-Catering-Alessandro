using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuAiuto : MonoBehaviour
{
    [SerializeField] private GameObject pannelloMenuAiuto;
    [SerializeField] private TextMeshProUGUI testoAiuto;
    [SerializeField] private Button tastoAvanti;
    [SerializeField] private Button tastoIndietro;


    void Start()
    {
        pannelloMenuAiuto.SetActive(false);
    }

    void apriPannelloMenuAiuto()
    {
        List<string> messaggiDiAiuto = new List<string>
        {
            "- Movimenti: Per potersi muovere all'interno del gioco, bisogna utilizzare i tasti W, A, S, D per muoversi rispettivamente in \"Avanti\", \"Sinistra\", \"Indietro\", \"Destra\"."
            "- Interazione con I clienti: Per poter interagire con i clienti si dovr� utilizzare il mouse come puntatore e selezionare il piatto che si vuole servire al cliente quando richiesto attraverso la relativa schermata."
            "- Scelta del piatto: Scegliere il piatto migliore fra quelli disponibili, permette al giocatore di aumentare il suo denaro e il suo punteggio cos� da poter superare il livello. Nel caso dovesse servire ad un cliente con una patologia X un piatto dove � presente un ingrediente non compatibile con essa verr� mostrato un pop up dal quale sar� possibile visualizzare quali degli ingredienti del piatto sono compatibili con la patologia e quali no."
            "- Gestione del denaro: Pi� saranno affini i piatti che verranno serviti pi� incrementer� il denaro del giocatore e pi� ingredienti potr� compare dal negozio."
            "- Gestione magazzino: Sar� possibile scegliere solo i piatti per i quali sono disponibili tutti gli ingredienti nelle quantit� necessarie; quindi, si dovr� tenere conto degli ingredienti disponibili nel proprio magazzino e comprare gli ingredienti mancanti."
            "- Come vengono calcolati I bonus: I bonus denaro e il punteggio vengono calcolati in base all�affinit� del cliente che si sta servendo ed ai parametri del nutriScore e l�ecoScore:\n1.per quanto riguarda il guadagno monetario verr� assegnato:\n\ta.un bonus del dieci percento sulla somma dei costi dei singoli ingredienti usati, a prescindere dall�affinit�\n\tb.un bonus del cinque percento se il piatto � affine alla patologia e alla dieta del cliente\n\tc.ci sar� inoltre una sanzione, sempre del cinque percento nel caso in cui il piatto non fosse affine\n2.per quanto riguarda il punteggio invece ci sar�:\n\ta.un punteggio base di 100 punti se il piatto � affine e, ed in tal caso verranno inoltre assegnati i bonus in base al nutriScore e all�ecoScore che partono da -10 percento nel caso peggiore e + 10 percento nel caso migliore; questi 2 bonus verranno calcolati per tutti e 2 gli indicatori quindi, per esempio: nel caso in cui il giocatore dovesse decidere di servire un piatto con il nutriScore pi� alto ma allo stesso tempo questo piatto inquina molto il punteggio rimarr� invariato."
            "- Interazione con gli NPC: interagire con gli NPC in giro per la citt� permetter� di ottenere suggerimenti utili per servire piatti migliori, sia dal punto di vista dell�affinit� le patologie che dal punto di vista del nutriScore e dell�ecoScore."
        };

    }
}
