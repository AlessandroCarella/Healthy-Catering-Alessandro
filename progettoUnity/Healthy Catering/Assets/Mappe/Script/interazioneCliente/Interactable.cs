using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;   //variabile per trigger dell'evento
    public int IDCliente;
    private Animator controllerAnimazione;
    [SerializeField] private ParticleSystem effettoPositivo;
    [SerializeField] private ParticleSystem effettoNegativo;
    [SerializeField] private GameObject modelloCliente;

    //Controller della mappa percorribile degli NPC
    NavMeshAgent agent;
    //Waypoint percorso degli NPC
    public Transform[] waypoints;
    //Indice per la gestione dei waypoint raggiunti
    int waypointIndex;
    //Vettore per calcolare la distanza tra il waypoint ed NPC
    Vector3 target;

    public bool raggiuntoBancone = false;
    public bool servito = false;

    void Start()
    {
        controllerAnimazione = GetComponentInChildren<Animator>();
        effettoPositivo.Stop();
        effettoNegativo.Stop();
        //modelloCliente.SetActive(false);

        //Inizializza il controller
        agent = GetComponent<NavMeshAgent>();
        animazioneCamminata();
        //refresh delle impostazioni
        updateDestinazione();
    }

    // Update is called once per frame
    void Update()
    {
        //Controllo della distanza minima per considerare il waypoint raggiunto, in caso positivo si
        if (Vector3.Distance(transform.position, target) < 1)
        {
            if(waypoints.Length -2 == waypointIndex)
            {
                raggiuntoBancone = true;
                animazioneIdle();
                if (servito == true)
                {
                    if (controllerAnimazione.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !controllerAnimazione.IsInTransition(0))
                    {
                        Debug.Log("Dentro");
                        iterazioneIndex();
                        updateDestinazione();
                        raggiuntoBancone = false;
                        animazioneCamminata();
                    }
                }
            } else
            {
                modelloCliente.SetActive(false);
            }
            if (waypoints.Length == waypointIndex)
            {
                
            }
        }
    }

    public void animazioneContenta()
    {
        controllerAnimazione.SetBool("servito", true);
        controllerAnimazione.SetBool("affinitaPatologiePiatto", true);
        controllerAnimazione.SetBool("affinitaDietaPiatto", true);
        effettoPositivo.Play();
        servito = true;
    }

    public void animazioneScontenta()
    {
        controllerAnimazione.SetBool("servito", true);
        controllerAnimazione.SetBool("affinitaPatologiePiatto", false);
        controllerAnimazione.SetBool("affinitaDietaPiatto", false);
        effettoNegativo.Play();
        servito = true;
    }

    public void animazioneIdle()
    {
        controllerAnimazione.SetBool("servito", false);
        controllerAnimazione.SetBool("affinitaPatologiePiatto", false);
        controllerAnimazione.SetBool("affinitaDietaPiatto", false);
        controllerAnimazione.SetBool("finito", false);
    }

    public void animazioneCamminata()
    {
        controllerAnimazione.SetBool("finito", true);
    }

    /// <summary>
    /// Imposta la destinazione del WayPoint Successiva
    /// </summary>
    private void updateDestinazione()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    /// <summary>
    /// Reset dell'indice dei waypoint da raggiungere.<br></br>
    /// Permette di far camminare all'infinito gli NPC una volta che hanno raggiunto tutti i waypoint facendoli ri-percorre tutti i waypoint
    /// </summary>
    private void iterazioneIndex()
    {
        waypointIndex++;
        /*  Se si vuole far percorrere il percorso all'infinito, eliminare il commento
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
        */
    }
}


