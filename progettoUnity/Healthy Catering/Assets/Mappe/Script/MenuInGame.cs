using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    [Header("Menu Opzioni")]
    public KeyCode tastoMenu;

    private bool giocoInPausa = false;
    [SerializeField] public GameObject menuPausa;




    // Start is called before the first frame update
    void Start()
    {
        giocoInPausa = false;
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkTastoMenu();
    }

    private void checkTastoMenu()
    {
        if(Input.GetKeyDown(tastoMenu))
        {
            if (!Interactor.pannelloAperto)
            {
                if (giocoInPausa)
                {
                    resumeGame();
                    disabilitaCursore();
                }
                else
                {
                    pauseGame();
                    abilitaCursore();
                }
            }
        }
    }


    void resumeGame()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f; //sblocca il tempo
        giocoInPausa = false;
    }


    void pauseGame()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f; //blocca il tempo
        giocoInPausa = true;
    }

        private void abilitaCursore()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void disabilitaCursore()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
