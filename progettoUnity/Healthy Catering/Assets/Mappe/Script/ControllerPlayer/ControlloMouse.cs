using UnityEngine;

/// <summary>
/// Classe per la gestione della camera del gioco<para>
/// <strong>Da aggiungere a:</strong><br></br>
/// Camera principale del gioco.
/// </para>
/// </summary>
public class ControlloMouse : MonoBehaviour
{
    private ControllerInput controlloStick;
    [Header("Impostazioni Camera")]
    [SerializeField] private Transform posizioneCameraIniziale;         //deve essere il primo elemento nel contenitore del giocatore per l'autoset
    [SerializeField] private float posizioneCameraFovMassimo = 0.51f;  
    private Camera cameraGioco;
    [Header("Impostazioni Mouse")]
    [SerializeField] private float sensibilitaMouse = 10f;     //50 valore mediano, max 100
    [SerializeField] private float rangeVisuale = 90f;

    [Header("Impostazioni Controller")]
    [SerializeField] private float sensibilitaStick = 100f;     //250 max value

    private Transform modelloPlayer;
    private float xRotation = 0f;
    private float mouseX;
    private float mouseY;
    bool puoCambiareVisuale;
    private float posizioneZcamera;
    private Vector2 movimentoStick;

    void Start()
    {
        inizializzazioneElementi();
    }

    void Update()
    {
        sensibilitaMouse = PlayerSettings.caricaImpostazioniSensibilita();
        sensibilitaStick = PlayerSettings.caricaImpostazioniSensibilitaStick();
        if (puoCambiareVisuale)
        {
            controlliInputVisuale();
            movimentoEffettivoMouse();
        }
        if(!Interactor.pannelloAperto)
        {
            aggiornamentoFovInGame();
        }
    }

    /// <summary>
    /// Il metodo alla disattivazione dell'oggetto, disattiva il controller.
    /// </summary>
    private void OnDisable()
    {
        controlloStick.Disable();
    }

    /// <summary>
    /// Inizializzazione elementi iniziali classe.
    /// </summary>
    private void inizializzazioneElementi()
    {
        controlloStick = new ControllerInput();
        controlloStick.Enable();
        movimentoStick = new Vector2();
        modelloPlayer = this.transform.parent.transform;
        if (posizioneCameraIniziale == null)
            try
            {
                posizioneCameraIniziale = modelloPlayer.gameObject.GetComponentsInChildren<Transform>()[1];
            }
            catch (MissingComponentException)
            {
                Debug.Log("Posizione Camera non trovata.");
            }
        posizioneZcamera = posizioneCameraIniziale.transform.position.z;
        if (PlayerSettings.caricaPrimoAvvioSettaggiSensibilita() == 0)
        {
            PlayerSettings.salvaPrimoAvvioSettaggiSensibilita();
            PlayerSettings.salvaImpostazioniSensibilita(sensibilitaMouse);
            PlayerSettings.salvaImpostazioniSensibilita(sensibilitaStick);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.puoCambiareVisuale = true;
        cameraGioco = GetComponent<Camera>();
        aggiornamentoFovInGame();
    }

    /// <summary>
    /// Il metodo permette l'effettivo movimento della visuale dato dai valori di MouseX e MouseY
    /// </summary>
    private void movimentoEffettivoMouse()
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -rangeVisuale, rangeVisuale);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        modelloPlayer.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// Il metodo aggiorna i valori MouseX e MouseY in base alla tipologia di input utilizzato
    /// </summary>
    private void controlliInputVisuale()
    {
        if (controlloStick.Player.MovimentoCamera.IsPressed())
        {
            movimentoStick = controlloStick.Player.MovimentoCamera.ReadValue<Vector2>();
            mouseX = movimentoStick.x * sensibilitaStick * Time.deltaTime;
            mouseY = movimentoStick.y * sensibilitaStick * Time.deltaTime;
        }
        else
        {
            mouseX = controlloStick.Player.MouseX.ReadValue<float>() * sensibilitaMouse * Time.deltaTime;
            mouseY = controlloStick.Player.MouseY.ReadValue<float>() * sensibilitaMouse * Time.deltaTime;

        }
    }

    /// <summary>
    /// Aggiorna il valore de fov
    /// </summary>
    public void aggiornamentoFovInGame()
    {
        cameraGioco.fieldOfView = PlayerSettings.caricaImpostazioniFov();
        posizioneCameraIniziale.localPosition = new Vector3(
            posizioneCameraIniziale.localPosition.x, 
            posizioneCameraIniziale.localPosition.y, 
            calcoloPosizioneCameraFovAsseZ(PlayerSettings.caricaImpostazioniFov())
        );
        cameraGioco.transform.position = posizioneCameraIniziale.transform.position;
    }

    /// <summary>
    /// Metodo che calcola la posizione della camera in base al fov.
    /// </summary>
    /// <param name="valoreFov">Valore del fov</param>
    /// <returns>Valore posizione della camera</returns>
    private float calcoloPosizioneCameraFovAsseZ(float valoreFov)
    {   
        return (posizioneZcamera + ((valoreFov - 60)/40) * (posizioneCameraFovMassimo - posizioneZcamera));
    }

    /// <summary>
    /// Blocca il movimento della visuale
    /// </summary>
    public void bloccaVisuale()
    {
        this.puoCambiareVisuale = false;
    }

    /// <summary>
    /// Attiva il movimento della visuale del giocatore
    /// </summary>
    public void attivaMovimento()
    {
        this.puoCambiareVisuale = true;
    }

    /// <summary>
    /// Sblocca o blocca la visuale del giocatore.
    /// </summary>
    public void lockUnlockVisuale()
    {
        this.puoCambiareVisuale = !puoCambiareVisuale;
    }
}
