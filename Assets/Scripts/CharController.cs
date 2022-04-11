using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharController : MonoBehaviour
{
    private NavMeshAgent _agent;
    
    [SerializeField]
    private GameObject groupTargets;

    private Transform[] _targets;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _targets = groupTargets.GetComponentsInChildren<Transform>();
        int choice = Random.Range(0, _targets.Length);
        _agent.destination = _targets[choice].transform.position;
    }

    void Update()
    {
        if (TargetReached()) { GetNewTarget(); };
    }

    private void GetNewTarget()
    {
        int choice = Random.Range(0, _targets.Length);
        _agent.destination = _targets[choice].transform.position;
    }

    private bool TargetReached()
    {
        return _agent.remainingDistance <= _agent.stoppingDistance ? true : false;
    }
}
