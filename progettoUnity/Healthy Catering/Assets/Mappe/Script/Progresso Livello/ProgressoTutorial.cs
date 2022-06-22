using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Classe dedicata alla gestione del tutorial del livello 0
/// </summary>
public class ProgressoTutorial : MonoBehaviour
{
    [Header("Video tutorial")]
    [SerializeField] private GameObject canvasVideoTutorial;

    [Header("Obbiettivi Tutorial")]
    //testo obbiettivo da cambiare di volta in volta
    [SerializeField] private TextMeshProUGUI obbiettivoTesto;
    //toggle obbiettivo 
    [SerializeField] private Toggle obbiettivoToggle;
    //se vero, il tutorial dei comandi base, viene saltato
    public bool skipTutorialComandi;

    private void Start()
    {
        canvasVideoTutorial.SetActive(false);
        //le disattivo per attivarle solo nel momento opportuno - Questi elementi sono nel loro specifico pannello, che va attivato poi quando serve.
        obbiettivoTesto.gameObject.SetActive(false);
        obbiettivoToggle.gameObject.SetActive(false);
    }
    
    private void riproduciVideo()
    {
        canvasVideoTutorial.SetActive(true);

    }

    /// <summary>
    /// Metodo che attiva il TextMeshProUGUI dell'obbiettivo e quello del toggle<br></br>
    /// </summary>
    public void attivaObbiettiviTutorial()
    {
        obbiettivoTesto.gameObject.SetActive(true);
        obbiettivoToggle.gameObject.SetActive(true);
    }
    /// <summary>
    /// cambia colore testo obbiettivo in verde e imposta il toogle su vero.
    /// Il codice verde � 181, 216, 156, 255<br></br>
    /// </summary>
    private void setObbiettivoCompletato()
    {
        obbiettivoTesto.color = new Color32(181, 216, 156, 255);
        obbiettivoToggle.isOn = true;
    }

    /// <summary>
    /// Cambia il colore in bianco del testo e setta il toogle su falso<br></br>
    /// </summary>
    private void resetObbiettivoCompletato()
    {
        obbiettivoTesto.color = Color.white;
        obbiettivoToggle.isOn = false;
    }

    /// <summary>
    /// Imposta la variabile di skip del tutorial su true
    /// </summary>
    public void skipComandiTutorial()
    {
        skipTutorialComandi = true;
    }

    //TESTO OBBIETTIVI

    private void setObbiettivoComandiMovimentoBase()
    {
        obbiettivoTesto.text = "Premi <color=#B5D99C>W,A,S,D</color> per camminare.";
    }

    private void setObbiettivoComandiSalto()
    {
        obbiettivoTesto.text = "Premi <color=#B5D99C>Spazio</color> per saltare.";
    }

    private void setObbiettivoComandiSprint()
    {
        obbiettivoTesto.text = "Premi <color=#B5D99C>Shift</color> per correre.";
    }

    private void setObbiettivoRaggiungiRistorante()
    {
        obbiettivoTesto.text = "Raggiungi il <color=#B5D99C>Ristorante</color>.";
    }

   
}
