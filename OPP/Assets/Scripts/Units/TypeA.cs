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
            coroutineStarted = true;
            //StartCoroutine(DropBomb());
            arrivedDelegate = () => DropBomb();
        }
    }

    void DropBomb()
    {
        base.Move(originalPos);
        GameObject bomb = Instantiate(bombPrefab);
        bomb.transform.position = gameObject.transform.position;
        bomb.GetComponent<BombHandler>().enabled = true;
        sentDelegate = false;
        arrivedDelegate = () => AllowNextMove();
    }

    void AllowNextMove()
    {
        Debug.Log("ALLOW");
        coroutineStarted = false;
        arrivedDelegate = null;
    }

    /*public IEnumerator DropBombOld()
    {
        //coroutineStarted = true;
        
        //arrivedDelegate = () => ;
        //coroutineStarted = false;
    }*/
}
