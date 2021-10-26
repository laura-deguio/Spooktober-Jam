using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class CandyController : MonoBehaviour
{
    private NavMeshAgent agent;

    private GameObject player;

    private GameObject destination;

    public float smellSense = 20;

    private GameObject[] destinations;

    private bool isSeeking;

    public Animator anim;

    public float wanderSpeed = 1.5f;
    public float chaseSpeed = 4f;
    public float rampageSpeed = 6f;

    public Transform playerTransform;

    public float detectAngle = 90;
    public float changeDestinationDistance = 2f;


    private Vector3 lastPlayerSpottedPosition;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameManager.instanceManager.GameOver();
        }

        if(collider.gameObject.tag == "Staff")
        {
            Death();
        }
    }

    private void SetNextDestination()
    {
        int index = Random.Range(0, destinations.Length);
        destination = destinations[index];
        agent.destination = destination.transform.position;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().speed = wanderSpeed;
        GetComponent<NavMeshAgent>().speed = chaseSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
        destinations = GameObject.FindGameObjectsWithTag("Destination");
        SetNextDestination();
        agent.speed = wanderSpeed;
        anim = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        var pos = transform.position;
        var playerPos = player.transform.position;
        var distanceToTarget = Vector3.Distance(pos, playerPos);
        var distanceToDestination = Vector3.Distance(pos, destination.transform.position);
        var distanceToSupposedTarget = Vector3.Distance(pos, lastPlayerSpottedPosition);
        var playerDirection = playerPos - pos;
        var angle = Vector3.Angle(playerDirection, transform.forward);

        var hasHit = Physics.Raycast(pos, playerDirection, out var hit);

        if (hasHit)
        Debug.Log(hit.collider.gameObject);

        if (distanceToTarget < smellSense && angle < (detectAngle / 2) && hasHit && hit.collider.gameObject.CompareTag("Player"))
        {
            agent.destination = playerPos;
            lastPlayerSpottedPosition = playerPos;
            isSeeking = true;

            agent.speed = chaseSpeed;
            anim.SetBool("isSeeking", false);
            anim.SetBool("isRunning", true);
        }
        else
        {
            isSeeking = false;

            agent.speed = wanderSpeed;
            anim.SetBool("isSeeking", true);
            anim.SetBool("isRunning", false);

            if (distanceToDestination < changeDestinationDistance && !isSeeking)
            {
                SetNextDestination();
            }

        }

        if (distanceToTarget < 6)
        {
            agent.speed = rampageSpeed;
            anim.SetBool("isSeeking", false);
            anim.SetBool("isRunning", false);

        }
    }
 
    public void Death()
    {
        Destroy(this, 0.5f);
    }

    private void OnDrawGizmos()
    {
        if (isSeeking)
        {
            Handles.color = new Color(1f, 0f, 0f, 0.1f);
            Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
        }
        else
        {
            Handles.color = new Color(0f, 1f, 0f, 0.1f);
            Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
        }

        var pos = transform.position;
        Handles.DrawSolidDisc(pos, Vector3.up, smellSense);
        Gizmos.DrawSphere(pos, smellSense);
        Handles.DrawSolidArc(pos, Vector3.up, transform.forward, detectAngle / 2, smellSense);
        Handles.DrawSolidArc(pos, Vector3.up, transform.forward, -detectAngle / 2, smellSense);

        if (player == null) return;
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
    
}