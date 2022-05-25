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
    public bool isAttacking;

    NavMeshAgent agent;
    
    int waypointIndex;
    Transform targetWp;
    EnemyAttack eAttack;



    public void Start()
    {
        canAtk = false;

        isAttacking = false;

        targetWp = Waypoints.points[0];
        
        agent = GetComponent<NavMeshAgent>();
        eAttack = GetComponent<EnemyAttack>();

        UpdatePath();
    }

    void Update()
    {
        if (canAtk == false && atkCountdown > 0 && isAttacking == true)
        {
            atkCountdown -= Time.deltaTime;
            
        }
        if(atkCountdown <= 0) {
            isAttacking = false;
        }
        if(canAtk == true && Vector3.Distance(transform.position, targetWp.position) <= 3f && isAttacking == false)
        {
            AtkTheCastle();
        }
        

        if (Vector3.Distance(transform.position, targetWp.position) <= 3f && canAtk == false && isAttacking == false)
        {
            canAtk = true;
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
        }
    }

    void UpdatePath()
    {
        targetWp.position = Waypoints.points[waypointIndex].transform.position;
        agent.SetDestination(targetWp.position);
    }

    void AtkTheCastle()
    {
        eAttack.Attack();
        canAtk = false;
        isAttacking = true;
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
