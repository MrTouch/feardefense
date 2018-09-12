using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject pathGo;

    Transform targetPathNode;
    int pathNodeIndex = 0;

    public float speed = 1f;
    public float health = 1f;
    public float score = 1f;
    public int MoneyValue = 1;

    // Use this for initialization
    void Start () {
        pathGo = GameObject.Find("Paths");
	}

    void getNextPathNode()
    {
        if (pathNodeIndex < pathGo.transform.childCount)
        {
            targetPathNode = pathGo.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else
        {
            reachedGoal();
            targetPathNode = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(targetPathNode == null)
        {
            getNextPathNode();
            if (targetPathNode == null)
            {
                //out of pathnodes
                reachedGoal();
                return;
            }
        }
        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            //we reached the node
            targetPathNode = null;
        }
        else
        {
            //move towards node 
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotaton = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotaton, Time.deltaTime * 5);
        }
	}
    void reachedGoal()
    {
        GameObject.FindObjectOfType<ScoreManager>().LoseLife();

        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject.FindObjectOfType<ScoreManager>().money += MoneyValue;
        Destroy(gameObject);
    }
}
