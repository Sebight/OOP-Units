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


    public void RegisterOnArrive(ArrivedDelegate callback)
    {
        //arrivedDelegate = callback;

    }

    public override void Action(RaycastHit hit)
    {
        Unit unitComponent = hit.transform.gameObject.GetComponent<Unit>();
        if (unitComponent != null)
        {
            if (!coroutineStarted)
            {
                base.Action(hit);
                //StartCoroutine(Shoot(unitComponent));

                //RegisterOnArrive(() => StartCoroutine(Shoot(unitComponent)));
                arrivedAction = () => StartCoroutine(Shoot(unitComponent));
                

                //TODO: create dynamic on arrive system
                //RegisterOnArrive(Shoot);
                //Move()

                // delegate /w event

                // Action / Func

                /*
                  System.Action<Vector3, Vector3> met;

                  met = ShowLine;

                  met(Vector3.zero, Vector3.one);
                  */
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
        Debug.Log("Play sound!");
    }
}
