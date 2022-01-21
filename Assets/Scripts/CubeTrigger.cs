using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    public string triggeredPlayer;

    private void OnTriggerEnter(Collider other)
    {
        triggeredPlayer = other.name;
    }
}
