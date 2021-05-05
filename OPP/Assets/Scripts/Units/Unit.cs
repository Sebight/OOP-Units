﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    public virtual void Move(Vector3 position)
    {
        agent.SetDestination(position);
    }
}