using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    public MenuController menuController;
    FirstPersonController fpController;
    bool menuUp = false;
    // Start is called before the first frame update
    void Start()
    {
        fpController = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Inventory"))
        {
            menuUp = !menuUp;
            fpController.enabled = !menuUp;
            menuController.show(menuUp);
            if (menuUp) {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }
    }
    public void JournalItemGain(JournalItem journalItem)
    {
        menuController.GainJournalItem(journalItem);
    }
}
