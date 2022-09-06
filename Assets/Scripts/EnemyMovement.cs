using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    
    int waypointIndex;
    public Transform targetWp;
    public Transform playerPos;

    public Transform currentWaypoints;

    bool chasingPlayer = false;
    
    public void Start()
    {

        targetWp = Waypoints.points[0];

        playerPos = GameManager.instance.playerGO.transform;
        
        agent = GetComponent<NavMeshAgent>();

        UpdatePath();
    }

    private void Update()
    {
        if (chasingPlayer)
        {
            agent.SetDestination(targetWp.position);
        }
    }

    void UpdatePath()
    {
        targetWp.position = Waypoints.points[waypointIndex].transform.position;
        agent.SetDestination(targetWp.position);
    }

    public void AttackPlayer()
    {
        Debug.Log("AttackPlayer!");
        targetWp = playerPos;
        agent.SetDestination(targetWp.position);
        chasingPlayer = true;
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

    //public void EndPath()
    //{ 
        // PlayerStats.Lives--;
        //WaveSpawner.EnemiesAlive--;
        //Destroy(gameObject);
    //}

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
