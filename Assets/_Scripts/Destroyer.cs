using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Triggered");
        Destroy(col.gameObject);
    }
}
