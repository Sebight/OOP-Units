using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeC : Unit
{
    public override void Action(RaycastHit hit)
    {
        Unit unitComponent = hit.transform.gameObject.GetComponent<Unit>();
        if (unitComponent != null)
        {
            base.Action(hit);
            Debug.Log("Type C moving to Unit");
            //Shooting logic
        }
    }

    public override void OnSelect()
    {
        base.OnSelect();
        Debug.Log("Play sound!");
    }
}
