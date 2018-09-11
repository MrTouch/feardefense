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
        if (other.gameObject.CompareTag("Tower") && controller.triggerPressed)
        {
            this.transform.SetParent(other.transform);
            Debug.Log("touched");
        }

    }
}
