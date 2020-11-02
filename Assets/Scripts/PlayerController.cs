using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MenuController menuController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void JournalItemGain(JournalItem journalItem)
    {
        menuController.GainJournalItem(journalItem);
    }
}
