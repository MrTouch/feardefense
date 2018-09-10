    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerModul : MonoBehaviour {

    public SteamVR_TrackedController right;
    public SteamVR_TrackedController left;

    private bool isTriggered;

	// Use this for initialization
	void Start () {
        isTriggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("GameController")){
            this.transform.SetParent(other.transform);
            Debug.Log("touched");
        }

    }
    }
