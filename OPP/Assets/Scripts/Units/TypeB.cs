using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TypeB : Unit
{

    private void Start()
    {

    }
    

    public override void Action(RaycastHit hit)
    {
        gameManager.GetNearestUnit(gameObject).gameObject.SetActive(false);
    }
}
