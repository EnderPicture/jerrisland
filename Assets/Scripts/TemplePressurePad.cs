using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplePressurePad : MonoBehaviour
{
    bool down = false;
    int attachedId = 0;

    public GameObject poweredSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        TemplePowerPack power = other.gameObject.GetComponent<TemplePowerPack>();
        if (power != null) {
            down = true;
            attachedId = power.GetInstanceID();
            Instantiate(poweredSound);
        }
    }
    private void OnTriggerExit(Collider other) {
        TemplePowerPack power = other.gameObject.GetComponent<TemplePowerPack>();
        if (power != null && power.GetInstanceID() == attachedId) {
            attachedId = 0;
            down = false;
        }
    }
    public bool getStatus() {
        return down;
    }
}
