using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private SteamVR_TrackedController controller;

	// Use this for initialization
	void Start () {
        controller = this.GetComponent<SteamVR_TrackedController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider other)
    {

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (other.gameObject.CompareTag("Tower") && controller.triggerPressed)
        {
            other.transform.SetParent(this.transform);
            rb.isKinematic = true;
            Debug.Log("touched");
        }
        else if(!controller.triggerPressed)
        {
            other.transform.parent = null;
            rb.isKinematic = false;
        }

    }
}
