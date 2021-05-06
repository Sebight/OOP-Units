using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{

    public IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBomb());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
