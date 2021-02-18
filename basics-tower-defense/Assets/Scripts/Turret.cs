using UnityEngine;

public class Turret : MonoBehaviour
{

    //reference for target
    private Transform target;

    [Header("Attributes")]
    //turrent attack range
    public float range = 15f;

    //turnSpeed
    public float turnSpeed = 10f;

    public float fireRate = 1f;
    //time between each fire
    private float fireCountown = 0f;

    //tag for enemy
    private string enemyTag = "Enemy";

    [Header("Unity Setup fields")]
    
    //bullet config params

    //bullet prefab
    public GameObject bulletPrefab;

    //part to rotate
    public Transform partToRotate;

    //firepoint for bullet
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    private void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookDirection = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookDirection, Time.deltaTime * turnSpeed) .eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        //firing
        if(fireCountown <= 0)
        {
            Shoot();
            fireCountown = 1f / fireRate;
        }

        fireCountown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        //make sure that the bullet instance is not empty
        if(bullet != null)
        {
            bullet.Seek(target);
        }
        
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            //get the distance between the current enemy and turret
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //check if we have a nearest enemy, if true, then set the nearest enemy as target.
       
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        //if the nearest enemy move out of range, set target to null.
        else
        {
            target = null;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
