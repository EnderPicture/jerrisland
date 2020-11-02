using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalItemTrigger : MonoBehaviour
{
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
            JournalItem journalItem = transform.parent.GetComponent<JournalItem>();
            pc.JournalItemGain(journalItem);
            DieSequence();
        }
    }
    void DieSequence()
    {
        Destroy(gameObject);
    }
}
