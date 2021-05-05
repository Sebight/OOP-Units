using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeA : Unit
{
    public override void Action(RaycastHit hit)
    {
        base.Action(hit);
        StartCoroutine(DropBomb());
    }

    public IEnumerator DropBomb()
    {
        while (!(Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)) yield return null;
        Debug.Log("arrived!");
    }
}
