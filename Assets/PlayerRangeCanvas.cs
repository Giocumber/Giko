using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeCanvas : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;
    }
}
