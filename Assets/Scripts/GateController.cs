using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public int gateID;
    public GateButton button1;
    public GateButton button2;
    public GateButton button3;
    public GateButton button4;
    public GatePowerInput powerInput;
    
    // Start is called before the first frame update
    void Start()
    {
        button1.setGateID(gateID);
        button2.setGateID(gateID);
        button3.setGateID(gateID);
        button4.setGateID(gateID);
        powerInput.setGateID(gateID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
