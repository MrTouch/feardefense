using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaveButton : MonoBehaviour {


    public GameObject EnemySpawner;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DelayButton());
        EnemySpawner.GetComponent<EnemySpawner>().nextWave();
    }

    private IEnumerator DelayButton()
    {
        float yValue = transform.position.y;
        while(yValue > 0.575f)
        {
            yValue -= 0.005f;
            transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.3f);

        while(yValue < 0.6)
        {
            yValue += 0.005f;
            transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
            yield return new WaitForSeconds(0.04f);
        }

    }
}
