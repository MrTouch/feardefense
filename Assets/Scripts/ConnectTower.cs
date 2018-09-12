using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class ConnectTower : MonoBehaviour {



    // Use this for initialization
    void Start () {
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += Handle_ObjectSnappedToDropZone; 
    }

    void Handle_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        //this.gameObject.AddComponent<FixedJoint>();
        Transform tower = gameObject.transform.parent;
        Debug.Log(tower.transform.localScale);
        e.snappedObject.transform.localScale = new Vector3(1f, 1f, 1f);
        Debug.Log(e.snappedObject.transform.localScale);
        //Destroy(e.snappedObject.GetComponent<Rigidbody>());
        e.snappedObject.GetComponent<Collider>().enabled = true;
        //this.gameObject.transform.localScale.Scale(new Vector3(0.3f , 0.3f, 0.3f));
        Debug.Log("added Fixed Joint");
    }


	
	// Update is called once per frame
	void Update () {
		
	} 



}
