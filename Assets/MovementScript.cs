using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovementScript : MonoBehaviour
{

    public XRNode inputNode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputNode);
        Vector2 inputAxis;
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        this.transform.Translate(inputAxis.x, 0, inputAxis.y);
        Debug.Log(inputAxis);
    }
}
