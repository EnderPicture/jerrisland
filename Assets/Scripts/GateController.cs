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
    public GateButton button5;
    public GateButton button6;
    public GatePowerInput powerInput;
    public GatePowerSource powerSource;
    public string masterPasscode;
    string passcode;
    bool passcodeCorrect = false;

    bool doorOpen = false;
    bool lastDoorOpen = false;

    public Animator gate;


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //sounds

    public GameObject openSound;



    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    // Start is called before the first frame update
    void Start()
    {
        button1.setGateID(gateID);
        button1.setButtonID(1);
        button1.gateController = this;

        button2.setGateID(gateID);
        button2.setButtonID(2);
        button2.gateController = this;

        button3.setGateID(gateID);
        button3.setButtonID(3);
        button3.gateController = this;

        button4.setGateID(gateID);
        button4.setButtonID(4);
        button4.gateController = this;

        button5.setGateID(gateID);
        button5.setButtonID(5);
        button5.gateController = this;

        button6.setGateID(gateID);
        button6.setButtonID(6);
        button6.gateController = this;

        powerInput.setGateID(gateID);
        powerSource.setGateID(gateID);
    }

    // Update is called once per frame
    void Update()
    {
        doorOpen = powerInput.isPowered() && passcodeCorrect;
        gate.SetBool("DoorOpen", doorOpen);

        if (!lastDoorOpen && doorOpen)
        {
            Instantiate(openSound);
        }

        lastDoorOpen = doorOpen;
    }
    public void buttonPressed(int id)
    {
        passcode += id + "";
        Debug.Log(passcode);
        if (passcode == masterPasscode)
        {
            passcodeCorrect = true;
        }
        if (!passcodeCorrect && passcode.Length >= masterPasscode.Length)
        {
            passcode = "";
            StartCoroutine(waitToReset());
        }
    }
    // https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
    IEnumerator waitToReset()
    {
        yield return new WaitForSeconds(1);
        button1.reset();
        button2.reset();
        button3.reset();
        button4.reset();
        button5.reset();
        button6.reset();
    }
}
