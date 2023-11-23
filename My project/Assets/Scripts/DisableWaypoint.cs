using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWaypoint : MonoBehaviour
{
    public GameObject Objekti1;

    // Start is called before the first frame update
    void Start()
    {
        Objekti1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
