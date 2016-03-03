using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
    public Transform target;
    NavMeshAgent agent;

    // Use this for initialization
    new public void Start()
    {
        base.Start(); // Calling Entity Start

        Debug.Log("merp");
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    new public void Update()
    {
        base.Update(); // Calling Entity Update
        agent.destination = target.position;
    }

    public void SetSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }

    public void SetStopDistance(float distance)
    {
        agent.stoppingDistance = distance;
    }
}