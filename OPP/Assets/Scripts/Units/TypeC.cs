using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeC : Unit
{
    private bool coroutineStarted = false;
    public LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public override void Action(RaycastHit hit)
    {
        Unit unitComponent = hit.transform.gameObject.GetComponent<Unit>();
        if (unitComponent != null)
        {
            if (!coroutineStarted)
            {
                base.Action(hit);
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
            lineRenderer.SetPosition(0, gameObject.transform.position + new Vector3(0, 1, 0));
            lineRenderer.SetPosition(1, otherUnit.gameObject.transform.position + new Vector3(0, 1, 0));
            lineRenderer.enabled = true;
            Debug.Log("Shoot!");
            otherUnit.gameObject.SetActive(false);
            yield return new WaitForSeconds(1);
            lineRenderer.enabled = false;
            coroutineStarted = false;
        }
    }

    public override void OnSelect()
    {
        base.OnSelect();
        Debug.Log("Play sound!");
    }
}
