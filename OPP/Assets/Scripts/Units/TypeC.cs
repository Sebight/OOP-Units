using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeC : Unit
{
    private bool coroutineStarted = false;

    public override void Action(RaycastHit hit)
    {
        Unit unitComponent = hit.transform.gameObject.GetComponent<Unit>();
        if (unitComponent != null)
        {
            if (!coroutineStarted)
            {
                base.Action(hit);
                //Shooting logic
                StartCoroutine(Shoot(unitComponent));
            }
        }
    }

    public IEnumerator Shoot(Unit otherUnit)
    {
        if (!coroutineStarted)
        {
            coroutineStarted = true;
            while (!(Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)) yield return null;
            yield return new WaitForSeconds(0.5f);
            //Shoot the ray
            //Ray ray = new Ray(agent.gameObject.transform.position, otherUnit.gameObject.transform.position);
            //Debug.DrawRay(agent.gameObject.transform.position, agent.gameObject.transform.forward, Color.red, 1.0f);
            Debug.Log("Shoot!");
            otherUnit.gameObject.SetActive(false);
            coroutineStarted = false;
        }
    }

    public override void OnSelect()
    {
        base.OnSelect();
        Debug.Log("Play sound!");
    }
}
