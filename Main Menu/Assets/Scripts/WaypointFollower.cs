using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    
    private int currentWaypointIndex = 0;
    public bool isMoving = true;
    private float timeUntilMove = 0;
    

    

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        if (isMoving == true)
        {
           transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
        else
        {
            timeUntilMove = timeUntilMove - Time.deltaTime;
            if (timeUntilMove <= 0)
                isMoving = true;
        }
    }

    public void WaitRandom(float min, float max)
    {
        isMoving = false;
        timeUntilMove = Random.Range(min, max); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered..");
        if (other.CompareTag("Waypoints") == true)
        {
            Debug.Log("entered a waypoint..");
            WaitRandom(3, 10);
            Debug.Log(timeUntilMove);
        }

    }

}
