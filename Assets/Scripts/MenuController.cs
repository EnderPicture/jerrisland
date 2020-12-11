using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public List<Transform> inventorySlots = new List<Transform>();
    public List<JournalItem> journalItems = new List<JournalItem>();
    public Transform inventory;
    public Transform inventoryRoot;
    public TextMeshProUGUI selectedItemName;
    public Image pageRender;
    int viewingIndex = 0;
    JournalItem currentItem;
    public GameObject selectBG;


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //sounds

    public GameObject journalPickupSound;
    public GameObject interactSound;
    public GameObject menuOpenSound;


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        // get all the slots from the inventory
        int index = 0;
        for (int c = 0; c < inventory.childCount; c++)
        {
            Transform child = inventory.GetChild(c);
            for (int j = 0; j < child.childCount; j++)
            {
                Transform slot = child.GetChild(j);
                inventorySlots.Add(slot);
                slot.GetComponent<InvSlot>().controller = this;
                slot.GetComponent<InvSlot>().index = index;
                index++;
            }

        }
        updateSelect();
        updateMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void click(int index)
    {
        viewingIndex = index;
        updateSelect();
        //add click sound here
        Instantiate(interactSound);
    }
    public void show(bool show)
    {
        GetComponent<Canvas>().enabled = show;
        //open and close menu
        Instantiate(menuOpenSound);
    }
    void updateSelect()
    {

       

        currentItem = journalItems.Find(d => d.index == viewingIndex);
        if (currentItem == null)
        {
            selectedItemName.text = "missing";
            pageRender.sprite = null;
            pageRender.color = new Color(0, 0, 0, 0);

        }
        else
        {
            selectedItemName.text = currentItem.itemName;
            pageRender.sprite = currentItem.journalPage;
            pageRender.color = new Color(255, 255, 255, 255);


        }
        selectBG.transform.DOMove(inventorySlots[viewingIndex].transform.position, 0.2f).SetEase(Ease.InOutQuint);
    }
    public void increment(int delta)
    {
        viewingIndex += delta;
        viewingIndex = viewingIndex > inventorySlots.Count - 1 ? 0 : viewingIndex;
        viewingIndex = viewingIndex < 0 ? inventorySlots.Count - 1 : viewingIndex;
        updateSelect();

        //add click sound here
        Instantiate(interactSound);

    }
    void updateMenu()
    {
        foreach (JournalItem item in journalItems)
        {
            if (item != null)
            {
                Transform slot = inventorySlots[item.index];
                TextMeshProUGUI text = slot.GetChild(0).GetComponent<TextMeshProUGUI>();
                Image image = slot.GetComponent<Image>();
                image.sprite = item.icon;

                text.text = item.itemName;
            }
        }
    }
    public void GainJournalItem(JournalItem item)
    {
        journalItems.Add(item);
        Instantiate(journalPickupSound); //sound effect
        updateMenu();
        updateSelect();
    }
}
