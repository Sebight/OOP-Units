using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameManager gameManager;

    public Unit SelectedUnit { get; private set; }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            SelectUnitAtCurosr();
        }
    }

    void SelectUnitAtCurosr()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Unit unitComponent = hit.transform.gameObject.GetComponent<Unit>();
            if (unitComponent != null)
            {
                if (SelectedUnit != null) SelectedUnit.OnDeselect();
                SelectedUnit = unitComponent;
                SelectedUnit.OnSelect();
            }
        }
    }
}
