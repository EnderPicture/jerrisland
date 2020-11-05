using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePowerInput : MonoBehaviour
{
    int gateID = 0;
    bool gatePowered = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void setGateID(int id)
    {
        gateID = id;
    }
    private void OnTriggerEnter(Collider other)
    {
        GatePowerSource gatePowerSource = other.GetComponent<GatePowerSource>();
        if (gatePowerSource != null && gatePowerSource.getGateId() == gateID)
        {
            gatePowered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        GatePowerSource gatePowerSource = other.GetComponent<GatePowerSource>();
        if (gatePowerSource != null && gatePowerSource.getGateId() == gateID)
        {
            gatePowered = false;
        }
    }
    public bool isPowered()
    {
        return gatePowered;
    }
}
