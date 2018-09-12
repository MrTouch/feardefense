using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class ConnectTower : MonoBehaviour {

    public GameObject snapDropZonePrefab;

    // Use this for initialization
    void Start () {
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += Handle_ObjectSnappedToDropZone; 
    }

    void Handle_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        Transform tower = gameObject.transform.parent;


        e.snappedObject.transform.localScale = new Vector3(1f, 1f, 1f);
        //e.snappedObject.transform.localScale = tower.transform.localScale;
        //e.snappedObject.transform.parent = tower.transform;
        Debug.Log(tower.transform.localScale);
        Debug.Log(e.snappedObject.transform.localScale);
        //Destroy(e.snappedObject.GetComponent<Rigidbody>());
        e.snappedObject.GetComponent<Collider>().enabled = false;

        GameObject newDropZone = Instantiate(snapDropZonePrefab, tower , false);
        newDropZone.transform.localPosition.Set(newDropZone.transform.localPosition.x, newDropZone.transform.localPosition.y + 2, newDropZone.transform.localPosition.z);
        newDropZone.transform.parent = tower.transform;
        Debug.Log("Snaped");
    }


	
	// Update is called once per frame
	void Update () {
		
	} 



}
