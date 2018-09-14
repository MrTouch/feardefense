using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class magic : MonoBehaviour {

    public GameObject powerballPrefab;

    public bool powerballIsLoading = true;

	// Use this for initialization
	void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(GetComponent<VRTK_ControllerEvents>().triggerClicked);

        GameObject PowerBall = Instantiate(powerballPrefab, other.transform.position, other.transform.rotation);
        powerballIsLoading = true;
        StartCoroutine(loadPowerBall(PowerBall));

        Debug.Log("magic");

    }

    private void OnTriggerExit(Collider other)
    {
        powerballIsLoading = false;
        Debug.Log("release magic");

    }

    private IEnumerator loadPowerBall(GameObject PowerBall)
    {

        while (powerballIsLoading == true)
        {
            PowerBall.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            yield return new WaitForSeconds(0.05f);
        }

    }
}
