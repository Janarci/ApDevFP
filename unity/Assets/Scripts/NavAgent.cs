using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{//put a circle around player and stop agent when near it
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    void Start()
    {

        agent = this.GetComponent<NavMeshAgent>();
        destination();
    }
    private void destination()
    {
        Vector3 TargetVec = target.transform.position;
        agent.SetDestination(TargetVec);
    }
}
