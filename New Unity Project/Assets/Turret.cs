using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    /*steps
        1. specify turret range
        2. reference to the game obj target
        3. draw range of turret
        4. update the nearest target
     */
    

    //config params
    //range of turret attack
    public float range = 15f;

    //reference for the target
    public Transform target;

    //tag for enemy(change in prefab)
    public string enemyTag = "Enemy";

    //part to rotate
    public Transform partToRotate;


    // Start is called before the first frame update
    void Start()
    {
        //invoke this method numerous times per sec
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);


        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }


        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }


        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        //convert to eulerAngle
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        //draw a wired-sphere in the current obj
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
