using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingE : MonoBehaviour
{
    private void Start()
    {
        // Aluksi piilotetaan FloatingE
        SetFloatingEVisibility(false);
    }

    public void SetFloatingEVisibility(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }
}
