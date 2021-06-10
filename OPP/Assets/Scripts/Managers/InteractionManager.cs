using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] ActionsManager actionsManager;

    delegate void InteractionHandler();
    Dictionary<Type, InteractionHandler> interactions = new Dictionary<Type, InteractionHandler>();

    void Awake()
    {
        interactions.Add(typeof(TypeA), GoTo);
        interactions.Add(typeof(TypeB), GoTo);
        interactions.Add(typeof(TypeC), GoTo);
    }

    void Update()
    {
        var unit = actionsManager.SelectedUnit;
        if (unit == null)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(interactions.TryGetValue(unit.GetType(), out InteractionHandler handler))
            {
                handler();
            }
        }
    }


    void GoTo()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            actionsManager.SelectedUnit.Action(hit);
        }
    }
}
