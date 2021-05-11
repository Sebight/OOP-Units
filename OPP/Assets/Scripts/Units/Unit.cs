using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    /*[SerializeField]*/ public NavMeshAgent agent;
    public Outline outline;

    public bool sentDelegate = false;
    public event System.Action<Unit> arrivedAction;

    public delegate void ArrivedDelegate();
    public ArrivedDelegate arrivedDelegate;

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
        if (distanceSmaller && !sentDelegate)
        {
            if (arrivedDelegate != null)
            {
                Debug.Log("SOMETHING I SSUBCRISD");
                arrivedDelegate?.Invoke();
                sentDelegate = true;
            }
        }
    }
}