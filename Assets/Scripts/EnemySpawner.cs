using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    float spawnCD = 0.9f;
    float spawnCDRemaining = 20;

    int waveCounter = 0;
    bool manualWave = false;

    [System.Serializable]
    public class WaveComponent
    {
        public GameObject enemyPrefab;
        public int num;

        //not show this value in inspector
        [System.NonSerialized]
        public int spawned = 0;
    }

    public WaveComponent[] waveCamps;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("anzahl waves: ");
        //Debug.Log(transform.parent.childCount);
        bool didSpawn = false;
        spawnCDRemaining -= Time.deltaTime;

        if(spawnCDRemaining < 0 || manualWave)
        {
            manualWave = false;
            spawnCDRemaining = spawnCD;

            foreach(WaveComponent wc in waveCamps)
            {
                Debug.Log("spawned: " + wc.spawned);
                if (wc.spawned < wc.num)
                {
                    wc.spawned++;
                    
                   Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation).transform.Rotate(0,90f,0);
                    //spawn
                    didSpawn = true;
                    break;
                }
            }
            if(didSpawn == false)
            {
                foreach(WaveComponent wc in waveCamps)
                {
                    wc.spawned = 0;
                }
                // wave must be complete;
                //instantiate next wave
                if (waveCounter < transform.parent.childCount -1)
                {
                    waveCounter++;
                    transform.parent.GetChild(waveCounter - 1).gameObject.SetActive(false);
                    Debug.Log("wave counter = " + waveCounter);
                    if (waveCounter < transform.parent.childCount)
                    {
                        transform.parent.GetChild(waveCounter).gameObject.SetActive(true);
                    }

                }
                else
                {
                    transform.parent.GetChild(waveCounter).gameObject.SetActive(false);
                    Debug.Log("reset waves");
                    //restart waves
                    waveCounter = 0;
                    transform.parent.GetChild(waveCounter).gameObject.SetActive(true);
                }

            }
        }

    }

    public void nextWave()
    {
        manualWave = true;
    }
}
