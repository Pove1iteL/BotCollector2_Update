using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Resource : MonoBehaviour
{
    public bool IsCollected { get; private set; }

    public void Collect()
    {
        IsCollected = true;
    }
}