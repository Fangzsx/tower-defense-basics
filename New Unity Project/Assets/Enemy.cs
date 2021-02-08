using UnityEngine;

public class Enemy : MonoBehaviour
{
    //speed of the movement
    public float speed = 10f;

    //target object
    private Transform target;
    private int wavepointIndex = 0;


    private void Start()
    {
        //set the target to the first waypoint
        target = Waypoint.points[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);


        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoint.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }
}
