using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuController : MonoBehaviour
{
    List<Transform> inventorySlots = new List<Transform>();
    List<JournalItem> journalItems  = new List<JournalItem>();
    public Transform inventory;
    // Start is called before the first frame update
    void Start()
    {
        // get all the slots from the inventory
        for (int c = 0; c < inventory.childCount; c++)
        {
            Transform child = inventory.GetChild(c);
            for (int j = 0; j < child.childCount; j++)
            {
                Transform slot = child.GetChild(j);
                inventorySlots.Add(slot);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void UpdateMenu()
    {
        foreach (JournalItem item in journalItems)
        {
            if (item != null)
            {
                Transform slot = inventorySlots[item.index];
                TextMeshProUGUI text = slot.GetChild(0).GetComponent<TextMeshProUGUI>();
                text.text = item.itemName;
            }
        }
    }
    public void GainJournalItem(JournalItem item)
    {
        journalItems.Add(item);
        UpdateMenu();
    }
}
