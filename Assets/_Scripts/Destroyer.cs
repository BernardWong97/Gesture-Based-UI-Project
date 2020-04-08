using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Destroyer class uses collision detection to destroy food that collides with it.
 */
public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}
