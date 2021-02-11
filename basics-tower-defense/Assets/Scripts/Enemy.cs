using UnityEngine;

public class Enemy : MonoBehaviour
{

    //enemy speed
    public float speed = 10f;

    //movement target
    private Transform target;

    //starting index of wave
    private int wavepointIndex = 0;

    //in start method, set the target = the first element in the static array inside Waypoint.cs

    private void Start()
    {
        target = Waypoint.points[0];
    }

    private void Update()
    {
        //get the direction
        Vector3 directionOfMovement = target.position - transform.position;
        transform.Translate(directionOfMovement.normalized * speed * Time.deltaTime, Space.World);
    
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GoToNextWaypoint();

        }
    }

    private void GoToNextWaypoint()
    {
        if(wavepointIndex >= Waypoint.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

}
