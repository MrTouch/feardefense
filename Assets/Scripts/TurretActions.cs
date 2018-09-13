using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class TurretActions : MonoBehaviour {

    AudioSource audioSource;
    // Use this for initialization
    void Start ()
    {
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += Handle_ObjectSnappedToDropZone;
        GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += Handle_ObjectUnsnappedFromDropZone;
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Handle_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {

        e.snappedObject.GetComponent<Tower>().setTurretOnPlayfield();
        audioSource.Play();

    }
    void Handle_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("unsnapped");
        e.snappedObject.GetComponent<Tower>().removeTurretFromPlayfield();
    }
}
