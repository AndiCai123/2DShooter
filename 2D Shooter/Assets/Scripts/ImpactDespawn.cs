using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactDespawn : MonoBehaviour
{

    public float despawnTime;
    // Start is called before the first frame update
    void Start()
    {
        despawnTime = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (despawnTime > 0) despawnTime -= Time.deltaTime;
        if(despawnTime <= 0)
        {
            DestroyObject(gameObject);
        }
    }
}
