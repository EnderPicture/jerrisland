﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MenuController : MonoBehaviour
{
    public List<Transform> inventorySlots = new List<Transform>();
    List<JournalItem> journalItems = new List<JournalItem>();
    public Transform inventory;
    public Transform inventoryRoot;
    public TextMeshProUGUI selectedItemName;
    int viewingIndex = 0;
    JournalItem currentItem;
    public GameObject selectBG;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
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
        UpdateSelect();
        UpdateMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void show(bool show)
    {
        GetComponent<Canvas>().enabled = show;
    }
    void UpdateSelect()
    {
        currentItem = journalItems.Find(d => d.index == viewingIndex);

        if (currentItem == null)
        {
            selectedItemName.text = "not collected yet";
        }
        else
        {
            selectedItemName.text = currentItem.itemName;
        }
        selectBG.transform.DOMove(inventorySlots[viewingIndex].transform.position, 0.2f).SetEase(Ease.InOutQuint);
    }
    public void increment(int delta)
    {
        viewingIndex += delta;
        viewingIndex = viewingIndex > inventorySlots.Count - 1 ? 0 : viewingIndex;
        viewingIndex = viewingIndex < 0 ? inventorySlots.Count - 1 : viewingIndex;
        UpdateSelect();
    }
    void UpdateMenu()
    {
        foreach (JournalItem item in journalItems)
        {
            if (item != null)
            {
                Debug.Log(inventorySlots.Count);
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
