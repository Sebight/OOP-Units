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

    public List<Unit> AllUnits { get; set; } = new List<Unit>();

    void Start()
    {
        var spots = waypoints.OrderBy(x => Guid.NewGuid());
        foreach(var s in spots)
        {
            SpawnUnit(s.position);
        }
    }

    void SpawnUnit(Vector3 position)
    {
        var unit = allUnits[Random.Range(0, allUnits.Length)];
        var instance = Instantiate(unit);
        instance.transform.position = position;

        AllUnits.Add(instance);
    }
}
