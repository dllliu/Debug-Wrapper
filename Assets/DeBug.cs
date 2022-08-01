using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBug : MonoBehaviour
{
    /*
    private bool debugInfo = false;
    private int wheelIndex = 0;
    private int pedalIndex = 1;

    private bool FWheel;

    private bool MasterSteeringWheel = false;
    */
    
    // Start is called before the first frame update
    void Start()
    {
        DirectInputWrapper.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The amount of devices found: " + DirectInputWrapper.DevicesCount());
        for (int i = 0; i < DirectInputWrapper.DevicesCount(); i++)
        {
            Debug.Log("The current " + i + " device is: " + DirectInputWrapper.GetProductName(i));
        }
    }
}
