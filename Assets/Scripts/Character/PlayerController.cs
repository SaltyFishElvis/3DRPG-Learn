using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        SwitchAnimation();
    }

    private void Start()
    {
        MouseManager.Instance.OnMouseClick += MoveToTarget;
    }

    public void MoveToTarget(Vector3 target)
    {
        agent.destination = target;
    }

    private void SwitchAnimation()
    {
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
}
