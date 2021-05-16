using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    /*[SerializeField]*/ public NavMeshAgent agent;
    public Outline outline;

    public bool sentDelegate = false;

    public delegate void ArrivedDelegate();
    public ArrivedDelegate arrivedDelegate;

    public UnityEvent arrivedEvent;
    public System.Action arrivedAction;

    public GameManager gameManager;

    public virtual void Move(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public virtual void Action(RaycastHit hit)
    {
        Move(hit.point);
    }

    public virtual void OnSelect()
    {
        Outline();
    }

    public virtual void OnDeselect()
    {
        HideOutline();
    }

    public void Outline()
    {
        outline.enabled = true;
    }

    public void HideOutline()
    {
        outline.enabled = false;
    }


    public void Update()
    {
        bool distanceSmaller = (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance);
        if (distanceSmaller /*&& !sentDelegate*/)
        {
            if (arrivedDelegate != null)
            {
                arrivedDelegate?.Invoke();
                sentDelegate = true;
            }
            if (arrivedAction != null)
            {
                arrivedAction();
            }
        }
    }
}