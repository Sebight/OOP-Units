using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeA : Unit
{
    private bool coroutineStarted = false;
    public Vector3 originalPos;
    public GameObject bombPrefab;

    private void Start()
    {
        originalPos = gameObject.transform.position;
    }

    public override void Action(RaycastHit hit)
    {
        if (!coroutineStarted)
        {
            base.Action(hit);
            StartCoroutine(DropBomb());
        }
    }

    public IEnumerator DropBomb()
    {
        coroutineStarted = true;
        while (!(Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)) yield return null;
        base.Move(originalPos);
        GameObject bomb = Instantiate(bombPrefab);
        bomb.transform.position = gameObject.transform.position;
        StartCoroutine(DestoryBomb(bomb));
        while (!(Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)) yield return null;
        coroutineStarted = false;
    }

    public IEnumerator DestoryBomb(GameObject bomb)
    {
        yield return new WaitForSeconds(5);
        Destroy(bomb);
    }
}
