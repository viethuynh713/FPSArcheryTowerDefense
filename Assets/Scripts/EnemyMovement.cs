using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public float timeBetweenAtk = 1.5f;
    public float atkCountdown;
    public bool canAtk;

    NavMeshAgent agent;
    
    int waypointIndex;
    Vector3 target;
    Transform targetWp;
    EnemyAttack eAttack;



    public void Start()
    {
        canAtk = false;

        targetWp = Waypoints.points[0];
        
        agent = GetComponent<NavMeshAgent>();
        eAttack = GetComponent<EnemyAttack>();

        UpdatePath();
    }

    void Update()
    {
        if (canAtk = false && atkCountdown > 0)
        {
            atkCountdown -= Time.deltaTime;
            Debug.Log(atkCountdown.ToString());
        }
        if(atkCountdown <= 0)
        {
            canAtk = true;
        }
        if(canAtk = true)
        {
            AtkTheCastle();
        }
        

        if (Vector3.Distance(transform.position, targetWp.position) <= 2)
        {
            agent.isStopped = true;
            canAtk = true;
        }
    }

    void UpdatePath()
    {
        targetWp.position = Waypoints.points[waypointIndex].transform.position;
        agent.SetDestination(targetWp.position);
    }

    void AtkTheCastle()
    {
        Debug.Log("Atk");
        eAttack.Attack();
        canAtk = false;
        atkCountdown = timeBetweenAtk;
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
