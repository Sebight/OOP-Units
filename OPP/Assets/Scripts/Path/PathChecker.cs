using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathChecker : MonoBehaviour
{
    // Start is called before the first frame update

    public event System.Action arrivedAction;
    public NavMeshAgent agent;

    public bool sentDelegate = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
