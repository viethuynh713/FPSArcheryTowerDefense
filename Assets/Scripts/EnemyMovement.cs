using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    
    int waypointIndex;
    Vector3 target;
    Transform targetWp;
    EnemyAttack eAttack;



    public void Start()
    {
        targetWp = Waypoints.points[0];
        target = Waypoints.points[0].transform.position;
        agent = GetComponent<NavMeshAgent>();
        eAttack = GetComponent<EnemyAttack>();

        UpdatePath();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetWp.position) < 1)
        {
            IncreaseWaypoint();
            UpdatePath();
        }
    }

    void UpdatePath()
    {
        targetWp.position = Waypoints.points[waypointIndex].transform.position;
        agent.SetDestination(target);
    }

    void IncreaseWaypoint()
    {
        waypointIndex++;

        if(waypointIndex == Waypoints.points.Length)
        {
            waypointIndex = 0;
            //Put the enemy attack code here
            eAttack.Attack();

        }
    }


    // private Transform target;
    // private int wavepointIndex = 0;

    // private Enemy enemy;

    // [HideInInspector]
    // public PlayerStats ps;

    // public void Start()
    // {
    //     enemy = GetComponent<Enemy>();

    //     target = Waypoints.points[0];

    //     ps = FindObjectOfType<PlayerStats>();
    // }

    // public void Update()
    // {
    //     Vector3 dir = target.position - transform.position;

    //     transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

    //     if (Vector3.Distance(transform.position, target.position) <= 0.4f)
    //     {
    //         GetNextWaypoint();
    //     }

        
    // }

    public void EndPath()
    { 
        // PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    // public void GetNextWaypoint()
    // {
    //     if (wavepointIndex >= Waypoints.points.Length - 1)
    //     { 
    //         EndPath();
    //         return;
    //     }

    //     wavepointIndex++;
        
    //     target = Waypoints.points[wavepointIndex];
    // }

    // public void EndPath()
    // { 
    //     PlayerStats.Lives--;
    //     WaveSpawner.EnemiesAlive--;
    //     Destroy(gameObject);

}
