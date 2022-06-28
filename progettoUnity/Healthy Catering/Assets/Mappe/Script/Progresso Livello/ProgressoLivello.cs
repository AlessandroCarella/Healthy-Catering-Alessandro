using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections.Generic;

/// <summary>
/// Classe che gestisce gli obbiettivi del livello, ovvero il numero di clienti da servire ed il punteggio da raggiungere.
/// </summary>
public class ProgressoLivello : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scrittaObbiettivo;
    [SerializeField] private Color32 coloreRaggiuntoObbiettivo;
    //da eventualmente eliminare se esiste un modo per accedere al punteggio nella classe player
    private int punteggioPlayer;
    private Player giocatore;
    [SerializeField] Interactor interazioni;
    [Header("Obbiettivo numero Clienti da Servire")]
    [SerializeField] private TextMeshProUGUI obbiettivoUno;
    [SerializeField] private Toggle obbiettivoUnoToogle;
    [SerializeField] private int numeroClientiDaServire = 3;
    private int numeroClientiServiti;
    //testo da visualizzare, da modificare le stringhe se si volesse aggiungere un colore alle parole
    private string testoObbietivo1;                                         
    private bool obbiettivoUnoRaggiunto = false;

    [Header("Obbiettivo Punteggio da Raggiungere")]
    [SerializeField] private TextMeshProUGUI obbiettivoDue;
    [SerializeField] private Toggle obbiettivoDueToogle;
    [SerializeField] private int punteggioMassimo = 200;
    //testo da visualizzare, da modificare le stringhe se si volesse aggiungere un colore alle parole
    private string testoObbietivo2;                                        
    private bool obbiettivoDueRaggiunto = false;

    [Header("Fine Livello")]
    //pannello che mostra le scritte di fine livello ed il bottone per tornare al menu iniziale, quando attivo, parte in automatico l'animazione impostasta con il file .anim
    [SerializeField] private GameObject schermataFineLivello;         
    //Testo da inizializzare con il valore del punteggio del giocatore raggiunto a fine livello.
    [SerializeField] private TextMeshProUGUI valorePunteggioPlayer;
    public UnityEvent disattivaElementiFineLivello;


    private void Start()
    {
        giocatore = interazioni.getPlayer();
        //disattivare la schermata per evitare che l'animazione parti fin da subito (N.B. L'animazione � impostata per avviarsi all'attivazione dell'oggetto per semplicit� � per dover scrivere molti meno controlli)
        schermataFineLivello.SetActive(false);
        valorePunteggioPlayer.gameObject.SetActive(false);
        //Se il livello � il livello tutorial la schermata obbiettivi non si attiva (da attivare successivamente)
        if (PlayerSettings.livelloSelezionato != 0)
        {
            valoriInizialiTesto();
        } else
        {
            disattivaSoloObbiettivi();
        }
    }

    private void Update()
    {
        //controllo costante dell'obbiettivi raggiunti, eventualmente questo controllo pu� essere spostato altrove in base a come verr� strutturato il gioco successivamente.
        if(obbiettiviRaggiunti())
        {
            attivazioneSchermataFineLivello();
        }
    }

    private void valoriInizialiTesto()
    {
        testoObbietivo1 = "Servire " + numeroClientiDaServire + " clienti. Clienti serviti: " + numeroClientiServiti + "/" + numeroClientiDaServire;
        obbiettivoUno.text = testoObbietivo1;
        testoObbietivo2 = "Raggiungi un punteggio pari a " + punteggioMassimo + ". Punteggio attuale " + 0 + "/" + punteggioMassimo;
        obbiettivoDue.text = testoObbietivo2;
    }

    /// <summary>
    /// Aggiornamento dei parametri per il controllo degli obbiettivi.<br></br>
    /// Il testo degll'obbiettivi si aggiorna in automatico i valori aggiornati.
    /// </summary>
    /// <param name="punteggio">Punteggio raggiunto dal giocatore</param>
    public void servitoCliente(int punteggio)
    {
        punteggioPlayer = punteggio;
        numeroClientiServiti++;
        testoObbietivo1 = "Servire " + numeroClientiDaServire + " clienti. Clienti serviti: " + numeroClientiServiti + "/" + numeroClientiDaServire;
        obbiettivoUno.text = testoObbietivo1;
        testoObbietivo2 = testoObbietivo2 = "Raggiungi un punteggio pari a " + punteggioMassimo + ". Punteggio attuale " + punteggio + "/" + punteggioMassimo;
        obbiettivoDue.text = testoObbietivo2;
        controlloProgressiObbiettivo(punteggio);
    }

    /// <summary>
    /// Controllo e aggiornamento degli obbiettivi del livello.<br></br>
    /// Se un obbiettivo � stato raggiunto, il testo si colora con il <strong>coloreRaggiuntoObbiettivo</strong> ed il Toggle si setta su True.
    /// </summary>
    /// <param name="punteggio">Punteggio raggiunto dal giocatore</param>
    private void controlloProgressiObbiettivo(int punteggio)
    {
        if(numeroClientiServiti == numeroClientiDaServire)
        {
            obbiettivoUnoToogle.isOn = true;
            obbiettivoUno.color = coloreRaggiuntoObbiettivo;
            obbiettivoUnoRaggiunto = true;
        }
        if (punteggio >= punteggioMassimo)
        {
            obbiettivoDueToogle.isOn = true;
            obbiettivoDue.color = coloreRaggiuntoObbiettivo;
            obbiettivoDueRaggiunto = true;
        } else
        {
            //Solo l'obbiettivo due si pu� resettare perch� il punteggio pu� diminuire ma il numero dei clienti serviti no
            obbiettivoDueToogle.isOn = false;
            obbiettivoDue.color = Color.white;
        }
    }

    /// <summary>
    /// Controllo se entrambi gli obbiettivi sono stati raggiunti.
    /// </summary>
    /// <returns>Restituisce true se entrambi gli obbiettivi sono stati raggiunti, falso se anche uno dei due obbiettivi non � stato raggiunto.</returns>
    public bool obbiettiviRaggiunti()
    {
        if (obbiettivoUnoRaggiunto && obbiettivoDueRaggiunto)
            return true;
        else
            return false;
    }


    //Il metodo eventualmente pu� essere eliminato per inserire il suo contenuto altrove, oppure pu� essere espanso in base alle necessit�.
    private void attivazioneSchermataFineLivello()
    {
        schermataFineLivello.SetActive(true);
        valorePunteggioPlayer.gameObject.SetActive(true);
        valorePunteggioPlayer.text = "Punteggio raggiunto: " + punteggioPlayer.ToString();
        disattivaElementiFineLivello.Invoke();
        PuntatoreMouse.abilitaCursore();
        disattivaObbiettiviETesto();
       // GameObject.FindObjectOfType<Camera>().transform.position = new Vector3(0, 4000, 0);       //sposta la telecamera in ciealo
    }


    /// <summary>
    /// Disattiva gli elementi degli obbiettivi.
    /// </summary>
    private void disattivaObbiettiviETesto()
    {
        obbiettivoUno.gameObject.SetActive(false);
        obbiettivoUnoToogle.gameObject.SetActive(false);
        obbiettivoDue.gameObject.SetActive(false);
        obbiettivoDueToogle.gameObject.SetActive(false);
        scrittaObbiettivo.gameObject.SetActive(false);
    }

    /// <summary>
    /// Disattiva tutti gli elementi tranne la scritta Obbiettivo
    /// </summary>
    private void disattivaSoloObbiettivi()
    {
        obbiettivoUno.gameObject.SetActive(false);
        obbiettivoUnoToogle.gameObject.SetActive(false);
        obbiettivoDue.gameObject.SetActive(false);
        obbiettivoDueToogle.gameObject.SetActive(false);
    }

    public void attivaSoloObbiettivi()
    {
        obbiettivoUno.gameObject.SetActive(true);
        obbiettivoUnoToogle.gameObject.SetActive(true);
        obbiettivoDue.gameObject.SetActive(true);
        obbiettivoDueToogle.gameObject.SetActive(true);
    }

    /// <summary>
    /// Metodo che salva il progresso livello e carica il menu Iniziale
    /// </summary>
    public void tornaAlMenuPrincipale()
    {
        Database.aggiornaDatabaseOggetto(aggiornaGiocatore());
        PlayerSettings.salvaProgressoLivello1(true);
        SelezioneLivelli.caricaMenuPrincipale();
    }

    /// <summary>
    /// Legge da file la lista dei player presenti e poi aggiorna il punteggio del giocatore.
    /// </summary>
    /// <returns>Lista giocatori aggiornata</returns>
    private List<Player> aggiornaGiocatore()
    {
        List<Player> listaPlayer = Database.getDatabaseOggetto(new Player());
        int i = 0;
        foreach(Player temp in listaPlayer)
        {
            if(temp.nome == listaPlayer[i].nome)
            {
                listaPlayer[i].punteggio[PlayerSettings.livelloSelezionato] = punteggioPlayer;
                break;
            }
            i++;
        }
        return listaPlayer;
    }
}
