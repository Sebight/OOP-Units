using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TypeB : Unit
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    public Unit GetNearestUnit()
    {
        List<Unit> unitsList = gameManager.AllUnits;
        Unit[] sortedUnits = new Unit[unitsList.Count];
        int returnIndex = 1;
        //SortedDictionary<Unit, float> distances = new SortedDictionary<Unit, float>();
        sortedUnits = unitsList.ToArray();
        sortedUnits = sortedUnits.OrderBy((x) => (x.gameObject.transform.position - gameObject.transform.position).sqrMagnitude).ToArray();
        for(int i = 1; i < sortedUnits.Length; i++)
        {
            if (sortedUnits[i].gameObject.activeInHierarchy)
            {
                returnIndex = i;
                break;
            }
        }
        return sortedUnits[returnIndex];
    }

    public override void Action(RaycastHit hit)
    {
        GetNearestUnit().gameObject.SetActive(false);
    }
}
