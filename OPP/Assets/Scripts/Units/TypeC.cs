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

                arrivedAction = () => StartCoroutine(Shoot(unitComponent));
                
            }
        }
    }

    IEnumerator Shoot(Unit otherUnit)
    {
        yield return new WaitForSeconds(1);
        lineRenderer.SetPosition(0, gameObject.transform.position + new Vector3(0, 1, 0));
        lineRenderer.SetPosition(1, otherUnit.gameObject.transform.position + new Vector3(0, 1, 0));
        lineRenderer.enabled = true;
        otherUnit.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        lineRenderer.enabled = false;
        //sentDelegate = false;
        arrivedAction = null;
    }

    public override void OnSelect()
    {
        base.OnSelect();
        //...
    }
}
