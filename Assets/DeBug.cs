using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBug : MonoBehaviour
{
    
    private bool debugInfo = false;
    private int wheelIndex = 0;
    private int pedalIndex = 1;
    private int masterIndex = 2;

    private bool FWheel;

    private bool MasterSteeringWheel = false;
    private float slaveSteering = 0;
    private float steerInput = 0f;
    
    
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
            Debug.Log("The current " + i + " device is: " + DirectInputWrapper.GetProductNameManaged(i));
        }
       
        DeviceState state;
        DeviceState slaveState;

           
        if (MasterSteeringWheel) {
            state = DirectInputWrapper.GetStateManaged (masterIndex);
            slaveState = DirectInputWrapper.GetStateManaged (wheelIndex);
            slaveSteering = slaveState.lX / 32768f;
        } else {
               
            state = DirectInputWrapper.GetStateManaged (wheelIndex);
        }

        steerInput = state.lX / 32768f;
//accelInput = state.rglSlider [0] / -32768f;
        Debug.Log(DirectInputWrapper.GetProductNameManaged(wheelIndex));

        Debug.Log("Device One: \tlRx: " + state.lRx + "\tlRy: " + state.lRy + "\tlRz: " + state.lRz + "\tlX: " + state.lX + "\tlY: " + state.lY + "\tlZ: " + state.lZ);
    }
}
