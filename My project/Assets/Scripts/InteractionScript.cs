using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Piano")
        {
            Debug.Log(collision.gameObject.name);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Piano")
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
