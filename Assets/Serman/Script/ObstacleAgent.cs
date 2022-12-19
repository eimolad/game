using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(NavMeshObstacle))]
public class ObstacleAgent : MonoBehaviour
{
    [SerializeField]
    private float CarvingTime = 0.5f;
    [SerializeField]
    private float CarvingMoveThreshold = 0.1f;

    private NavMeshAgent Agent;
    private NavMeshObstacle Obstacle;
    AI_Correct_Graund AI_Correct;

    private float LastMoveTime;
    private Vector3 LastPosition;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Obstacle = GetComponent<NavMeshObstacle>();
        AI_Correct = GetComponent<AI_Correct_Graund>();

        Obstacle.enabled = false;
        AI_Correct.enabled = true;
        Obstacle.carveOnlyStationary = false;
        Obstacle.carving = true;

        LastPosition = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(LastPosition, transform.position) > CarvingMoveThreshold)
        {
            LastMoveTime = Time.time;
            LastPosition = transform.position;
        }
        if (LastMoveTime + CarvingTime < Time.time && gameObject.GetComponent<Bot_Trol>().Agreses)
        {
            Agent.enabled = false;
            Obstacle.enabled = true;
            AI_Correct.enabled = false;
        }
    }

    public void SetDestination(Vector3 Position)
    {
        Obstacle.enabled = false;
        AI_Correct.enabled = true;

        LastMoveTime = Time.time;
        LastPosition = transform.position;

        StartCoroutine(MoveAgent(Position));
    }

    private IEnumerator MoveAgent(Vector3 Position)
    {
        yield return null;
        Agent.enabled = true;
        Agent.SetDestination(Position);
    }
}