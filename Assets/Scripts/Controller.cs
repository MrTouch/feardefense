using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private SteamVR_TrackedController controller;
    private SteamVR_Controller.Device device;
    private Rigidbody rb;
    private bool firstHaptic;

    // Use this for initialization
    void Start () {
        controller = this.GetComponent<SteamVR_TrackedController>();
        device = SteamVR_Controller.Input((int)controller.controllerIndex);
        firstHaptic = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Tower")) {
            rb = other.GetComponent<Rigidbody>();
            if (controller.triggerPressed)
            {
                triggerHaptic();
                other.transform.SetParent(this.transform);
                rb.isKinematic = true;
                Debug.Log("touched");
            }
            else if(!controller.triggerPressed)
            {
                other.transform.parent = null;
                rb.isKinematic = false;
                firstHaptic = false;
            }
        }
    }

    private void triggerHaptic()
    {
        if(!firstHaptic)
        {
            device.TriggerHapticPulse(3000);
            firstHaptic = true;
        }
    }
}
