using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateButton : MonoBehaviour
{
    int gateID = 0;
    int buttonID = 0;
    public Transform gateRoot;
    bool buttonDown = false;
    public GateController gateController;
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
    public void setButtonID(int id)
    {
        buttonID = id;
    }
    public void pressDown()
    {
        if (!buttonDown)
        {
            gateRoot.transform.DOLocalMove(new Vector3(-.5f, 0, 0), .2f).SetEase(Ease.InOutQuint);
            gateController.buttonPressed(buttonID);
        }
    }
    public void reset()
    {
        buttonDown = false;
        gateRoot.transform.DOLocalMove(new Vector3(0, 0, 0), .2f).SetEase(Ease.InOutQuint);
    }
}
