using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class Tower : MonoBehaviour {

    Transform turretTransform;

    float range = 0.5f;

    public GameObject bulletPrefab;

    public float damage = 1f;

    public float fireCooldown = 0.8f;
    float fireCooldownLeft = 0;

    public bool isPlacedOnPlayfield = false;

    private int countSpeedTowers;
    private int countRangeTowers;
    private int countDamageTowers;

    float initialDamage;
    float initialSpeed;
    float initialRange;

    public float affectDamagePerTower;
    public float affectFireCoolDownPerTower;
    public float affectRangePerTower;

    // Use this for initialization
    void Start () {
        turretTransform = transform.Find("Turret");
        initialDamage = damage;
        initialSpeed = fireCooldown;
        initialRange = range;
    }

	// Update is called once per frame
	void Update () {
        countSpeedTowers = 0;
        countRangeTowers = 0;
        countDamageTowers = 0;
        damage = initialDamage;
        range = initialRange;
        fireCooldown = initialSpeed;

        TowersSnapped(this.gameObject);

        damage += countDamageTowers * affectDamagePerTower;
        range += countRangeTowers * affectRangePerTower;
        fireCooldown -= countSpeedTowers * affectFireCoolDownPerTower;

        Debug.Log("Speed Tower: " + countSpeedTowers + " Speed: " + fireCooldown);
        Debug.Log("Range Tower: " + countRangeTowers + " Range: " + range);
        Debug.Log("Damage Tower: " + countDamageTowers + " Damage: " + damage);

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
                //Debug.Log(e);
            }

            if(nearestEnemy == null)
            {
               // Debug.Log("noenemies?");
            }

            Vector3 dir = nearestEnemy.transform.position - this.transform.position;
            Quaternion lookRot = Quaternion.LookRotation(dir);

            //rotate Tower to enemy direction
            //turretTransform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

            fireCooldownLeft -= Time.deltaTime;
            //Debug.Log("firecooldownleft: " + fireCooldownLeft);
            if (fireCooldownLeft <= 0 && dir.magnitude <= range && isPlacedOnPlayfield)
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

    public void setTurretOnPlayfield()
    {
        isPlacedOnPlayfield = true;
    }

    public void removeTurretFromPlayfield()
    {
        isPlacedOnPlayfield = false;
    }

    private void TowersSnapped(GameObject tower)
    {
        Transform snapdropzone = tower.transform.GetChild(0);

        foreach (Transform child in snapdropzone)
        {
            if (child.CompareTag("Speed Tower"))
            {
                Debug.Log("Found Speed Tower");
                countSpeedTowers += 1;
                TowersSnapped(child.gameObject);
            }
            else if (child.CompareTag("Range Tower"))
            {
                Debug.Log("Found Range Tower");
                countRangeTowers += 1;
                TowersSnapped(child.gameObject);
            }
            else if (child.CompareTag("Damage Tower"))
            {
                Debug.Log("Found Damage Tower");
                countDamageTowers += 1;
                TowersSnapped(child.gameObject);
            }
        }


    }
}
