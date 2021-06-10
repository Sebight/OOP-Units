using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] Unit[] allUnits;
    [SerializeField] Transform[] waypoints;

    public List<Unit> AllUnits = new List<Unit>();


    void Start()
    {
        var spots = waypoints.OrderBy(x => Guid.NewGuid());
        
        foreach (var s in spots)
        {
            SpawnUnit(s.position);
        }
    }

    void SpawnUnit(Vector3 position)
    {
        var unit = allUnits[Random.Range(0, allUnits.Length)];
        var instance = Instantiate(unit);
        instance.transform.position = position;


        instance.gameManager = this;

        AllUnits.Add(instance);
    }

    public Unit GetNearestUnit(GameObject from)
    {
        List<Unit> unitsList = AllUnits;
        int returnIndex = 1;
        Unit[] sortedUnits = unitsList.ToArray();
        sortedUnits = sortedUnits.OrderBy((x) => (x.gameObject.transform.position - from.transform.position).sqrMagnitude).ToArray();
        for (int i = 1; i < sortedUnits.Length; i++)
        {
            if (sortedUnits[i].gameObject.activeInHierarchy)
            {
                returnIndex = i;
                break;
            }
        }
        return sortedUnits[returnIndex];
    }
}
