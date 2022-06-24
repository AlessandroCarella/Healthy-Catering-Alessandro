using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private GameObject modelloCliente3D;

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
                    Debug.Log("Ciao");
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
                SetMaterialTransparent();
                iTween.FadeTo(modelloCliente, 0, 1);
                StartCoroutine(attendi(2f));
            }
        }
    }


    IEnumerator attendi(float attesa)
    {
        yield return new WaitForSecondsRealtime(attesa);
        Destroy(modelloCliente);
    }



    private void SetMaterialTransparent()

    {

        foreach (Material m in modelloCliente3D.GetComponent<Renderer>().materials)

        {

            m.SetFloat("_Mode", 2);

            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);

            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

            m.SetInt("_ZWrite", 0);

            m.DisableKeyword("_ALPHATEST_ON");

            m.EnableKeyword("_ALPHABLEND_ON");

            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

            m.renderQueue = 3000;

        }

    }



    private void SetMaterialOpaque()

    {

        foreach (Material m in modelloCliente3D.GetComponent<Renderer>().materials)

        {

            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);

            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);

            m.SetInt("_ZWrite", 1);

            m.DisableKeyword("_ALPHATEST_ON");

            m.DisableKeyword("_ALPHABLEND_ON");

            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

            m.renderQueue = -1;

        }

    }

    private void disattivaModello()
    {
        modelloCliente.SetActive(false);
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


