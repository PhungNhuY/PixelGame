using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] private GameObject[] waypoints;
    int currentWaypointIndex = 0;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += new Vector3(moveSpeed, 0, 0);
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f){
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length){
                currentWaypointIndex = 0;
            }
        }
        if(transform.position.x - waypoints[currentWaypointIndex].transform.position.x < 0f){
            sprite.flipX = true;
        }else{
            sprite.flipX = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * moveSpeed);
    }
}
