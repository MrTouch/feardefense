using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 1f;
    public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = target.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            DoBulletHit();
        }
        else
        {
            //move towards node 
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotaton = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotaton, Time.deltaTime * 5);
        }
    }

    void DoBulletHit()
    {
        Destroy(gameObject);
    }
}
