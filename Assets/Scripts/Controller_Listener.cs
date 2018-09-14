using System.Collections;
using System.Collections.Generic;
using VRTK; 
using UnityEngine;

public class Controller_Listener : MonoBehaviour {

    public GameObject PowerBallPrefab;
    private GameObject powerball;
    private bool powerballIsLoading;
	// Use this for initialization
	void Start () {
        GetComponent<VRTK_InteractGrab>().GrabButtonPressed += Controller_Listener_GrabButtonPressed;
        GetComponent<VRTK_InteractGrab>().GrabButtonReleased += Controller_Listener_GrabButtonReleased;
    }

    private void Controller_Listener_GrabButtonReleased(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("grip unclicked");
        powerballIsLoading = false;
        shootPowerBall(powerball, e);
    }

    private void Controller_Listener_GrabButtonPressed(object sender, ControllerInteractionEventArgs e)
    {

        Debug.Log("grip clicked");
        powerball = Instantiate(PowerBallPrefab, e.controllerReference.model.transform.position, e.controllerReference.model.transform.rotation);
        powerballIsLoading = true;
        StartCoroutine(loadPowerBall(powerball));
    }

   


    // Update is called once per frame
    void Update () {
	}

    private IEnumerator loadPowerBall(GameObject PowerBall)
    {
       
        while (powerballIsLoading == true)
        {
            PowerBall.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
            yield return new WaitForSeconds(0.05f);
        }

    }

    private void shootPowerBall(GameObject PowerBall, ControllerInteractionEventArgs e)
    {
        //shoot powerball
        Debug.Log("shoot");
    }

}
