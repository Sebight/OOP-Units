using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    /*[SerializeField]*/ public NavMeshAgent agent;

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
        gameObject.GetComponent<Outline>().enabled = true;
    }

    public void HideOutline()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }
}