using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    Transform turretTransform;

    float range = 1f;

    public GameObject bulletPrefab;

    public float damage = 1f;

    public float fireCooldown = 0.8f;
    float fireCooldownLeft = 0;


	// Use this for initialization
	void Start () {
        turretTransform = transform.Find("Turret");

    }
	
	// Update is called once per frame
	void Update () {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach(Enemy e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if(nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
                Debug.Log("enemy found");
                Debug.Log(e);
            }

            if(nearestEnemy == null)
            {
                Debug.Log("noenemies?");
            }

            Vector3 dir = nearestEnemy.transform.position - this.transform.position;
            Quaternion lookRot = Quaternion.LookRotation(dir);

            //rotate Tower to enemy direction
            //turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

            fireCooldownLeft -= Time.deltaTime;
            Debug.Log("firecooldownleft: " + fireCooldownLeft);
            if (fireCooldownLeft <= 0 && dir.magnitude <= range)
            {
                fireCooldownLeft = fireCooldown;
                ShootAt(nearestEnemy);
            }
        }
	}
    void ShootAt(Enemy e)
    {
        Debug.Log("shoot");
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        Bullet b = bulletGo.GetComponent<Bullet>();
        b.target = e.transform;
    }
}
