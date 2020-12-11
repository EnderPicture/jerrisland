using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    public MenuController menuController;
    public Canvas instructions;
    public float gravityGunRange;
    public Transform gravityGunHoldingSpot;
    public Transform playerCamera;
    Transform ggHolding;
    FirstPersonController fpController;
    bool menuUp = false;
    bool instructionsUp = true;
    // Start is called before the first frame update
    void Start()
    {
        fpController = GetComponent<FirstPersonController>();
        instructionsToggleShow(true);
    }

    // Update is called once per frame
    void Update()
    {
        inventoryToggle();
        instructionsToggle();
        if (Input.GetButtonDown("Fire1") && !menuUp && !instructionsUp)
        {
            GravityGun();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Press();
        }
        if (ggHolding != null)
        {
            ggHolding.GetComponent<Rigidbody>().AddForce(10 * (gravityGunHoldingSpot.position - ggHolding.position));
        }
    }

    // tests for instruction keypresses
    void instructionsToggle()
    {
        if (Input.GetButtonDown("Instructions") && !menuUp)
        {
            instructionsToggleShow(!instructionsUp);
        }
    }

    // actually shows and hides instructions
    void instructionsToggleShow(bool show)
    {
        instructionsUp = show;
        fpController.enabled = !instructionsUp;
        instructions.enabled = instructionsUp;
        if (instructionsUp)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    void inventoryToggle()
    {
        if (Input.GetButtonDown("Inventory") && !instructionsUp)
        {
            menuUp = !menuUp;
            fpController.enabled = !menuUp;
            menuController.show(menuUp);
            if (menuUp)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
    // gravity gun controller
    // click to grab click to stop
    void GravityGun()
    {

        if (ggHolding == null && !menuUp)
        {
            int layerMask = ~(1 << LayerMask.NameToLayer("Player"));
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, gravityGunRange, layerMask))
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "Holdable")
                {
                    ggHolding = hit.transform;


                    Vector3 spotPos = gravityGunHoldingSpot.localPosition;
                    spotPos.z = transform.InverseTransformPoint(ggHolding.position).z;
                    gravityGunHoldingSpot.localPosition = spotPos;

                    // ggHolding.parent = gravityGunHoldingSpot;
                    Rigidbody rb = ggHolding.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    rb.drag = 5;
                    rb.angularDrag = 5;
                }
            }
        }
        else
        {
            // ggHolding.parent = null;
            Rigidbody rb = ggHolding.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.drag = 0;
            rb.angularDrag = 0.05f;
            ggHolding = null;
        }
    }
    public void JournalItemGain(JournalItem journalItem)
    {
        menuController.GainJournalItem(journalItem);
    }
    void Press()
    {
        int layerMask = ~(1 << LayerMask.NameToLayer("Player"));
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, gravityGunRange, layerMask))
        {
            if (hit.transform.tag == "GateButton")
            {
                GateButton button = hit.transform.parent.GetComponent<GateButton>();
                button.pressDown();
            }
        }
    }
}
