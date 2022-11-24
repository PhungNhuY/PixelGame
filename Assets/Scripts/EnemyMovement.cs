using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] private GameObject[] waypoints;
    int currentWaypointIndex = 0;
    private SpriteRenderer sprite;
    private float jumpForce = 10f;
    private Animator anim;
    private float timer = 0;
    private float fallSpeed = -0.02f;
    private float fallPlus = -0.001f;

    private bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            if (transform.position.x - waypoints[currentWaypointIndex].transform.position.x < 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * moveSpeed);
        }else{
            transform.position += new Vector3(0, fallSpeed, 0);
            transform.Rotate(0, 0, Time.deltaTime * -120);
            timer += Time.deltaTime;
            fallSpeed += fallPlus;
            if(timer>1){
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetBool("death", true);
            gameObject.tag = "Untagged";
            isDeath = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
        }
    }
}
