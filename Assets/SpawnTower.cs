using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SpawnTower : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += Handle_ObjectUnsnappedFromDropZone;
    }

    void Handle_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        e.snappedObject.GetComponent<Rigidbody>().useGravity = true;
    }

	
	// Update is called once per frame
	void Update () {
		
	}


}
