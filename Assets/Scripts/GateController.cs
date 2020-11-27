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
    public GatePowerSource powerSource;
    public string masterPasscode;
    string passcode;
    bool passcodeCorrect = false;

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

        powerInput.setGateID(gateID);
        powerSource.setGateID(gateID);
    }

    // Update is called once per frame
    void Update()
    {
        if (powerInput.isPowered() && passcodeCorrect)
        {
            gate.SetBool("DoorOpen", true);
            
        }
        else
        {
            gate.SetBool("DoorOpen", false);
        }
    }
    public void buttonPressed(int id)
    {
        passcode += id + "";
        if (passcode == masterPasscode)
        {
            passcodeCorrect = true;
            Instantiate(openSound);
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
    }
}
