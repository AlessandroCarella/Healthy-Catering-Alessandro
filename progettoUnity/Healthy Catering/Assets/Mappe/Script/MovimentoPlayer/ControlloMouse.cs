using UnityEngine;

/// <summary>
/// Classe per la gestione della camera del gioco<para>
/// <strong>Da aggiungere a:</strong><br></br>
/// Camera principale del gioco.
/// </para>
/// </summary>
public class ControlloMouse : MonoBehaviour
{
    private Transform modelloPlayer;
    private Transform posizioneCameraIniziale;
    private float posizioneCameraFovMassimo = 0.51f;
    private Camera cameraGioco;
    private float sensibilitaMouse = 250f;              //250 valore mediano
    private float rangeVisuale = 90f;                   //Range visuale spostamento camera negli assi

    private float xRotation = 0f;
    private float mouseX;
    private float mouseY;
    bool puoCambiareVisuale;
    private float posizioneZcamera;


    // Start is called before the first frame update
    void Start()
    {
        modelloPlayer = this.transform.parent.transform;
        posizioneCameraIniziale = modelloPlayer.gameObject.GetComponentsInChildren<Transform>()[1];
        posizioneZcamera = posizioneCameraIniziale.transform.position.z;
        if (PlayerSettings.caricaPrimoAvvioSettaggiSensibilita() == 0)
        {
            PlayerSettings.salvaPrimoAvvioSettaggiSensibilita();
            PlayerSettings.salvaImpostazioniSensibilita(250f);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.puoCambiareVisuale = true;
        cameraGioco = GetComponent<Camera>();
        aggiornamentoFovInGame();
    }

    // Update is called once per frame
    void Update()
    {
        sensibilitaMouse = PlayerSettings.caricaImpostazioniSensibilita();
        if (puoCambiareVisuale)
        {
            mouseX = Input.GetAxis("Mouse X") * sensibilitaMouse * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * sensibilitaMouse * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -rangeVisuale, rangeVisuale);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            modelloPlayer.Rotate(Vector3.up * mouseX);
        }
        if(!Interactor.pannelloAperto)
        {
            aggiornamentoFovInGame();
        }
    }


    /// <summary>
    /// Aggiorna il valore de fov
    /// </summary>
    public void aggiornamentoFovInGame()
    {
        cameraGioco.fieldOfView = PlayerSettings.caricaImpostazioniFov();
        posizioneCameraIniziale.localPosition = new Vector3(posizioneCameraIniziale.localPosition.x, posizioneCameraIniziale.localPosition.y, calcoloPosizioneCameraFovAsseZ(PlayerSettings.caricaImpostazioniFov()));
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
