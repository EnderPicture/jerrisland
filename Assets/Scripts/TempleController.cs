using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleController : MonoBehaviour
{
    public TemplePressurePad p1;
    public TemplePressurePad p2;
    public TemplePressurePad p3;

    public GameObject final;

   

    bool powered = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        powered = p1.getStatus() && p2.getStatus() && p3.getStatus();
        final.SetActive(powered);
        
    }
    bool getPowered()
    {
        return powered;
      
    }
}
