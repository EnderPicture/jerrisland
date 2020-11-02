using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalItem : MonoBehaviour
{
    public string itemName;

    public int index;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            pc.JournalItemGain(this);
            DieSequence();
        }
    }
    void DieSequence()
    {
        Destroy(gameObject);
    }
}
