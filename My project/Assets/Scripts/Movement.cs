using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    public float olenmuuttuja = 300f;
    private Rigidbody rb;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInputti = Input.GetAxis("Horizontal");
        float verticalInputti = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontalInputti, 0f, verticalInputti).normalized * olenmuuttuja * Time.deltaTime);
    }
}
