using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    float spawnCD = 0.9f;
    float spawnCDRemaining = 20;

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
        bool didSpawn = false;
        spawnCDRemaining -= Time.deltaTime;
        if(spawnCDRemaining < 0 )
        {
            spawnCDRemaining = spawnCD;

            foreach(WaveComponent wc in waveCamps)
            {
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
                // wave must be complete;
                //instantiate next wave
                if (transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    //inactivate Wave and make harder for next round.
                    transform.parent.GetChild(1).gameObject.SetActive(false);
                    //Destroy(gameObject);
                    //transform.parent.GetChild(0).gameObject.SetActive(false);
                }

            }
        }

    }

    public void nextWave()
    {
        if (transform.parent.childCount > 1)
        {
            transform.parent.GetChild(1).gameObject.SetActive(true);
        }
    }
}
