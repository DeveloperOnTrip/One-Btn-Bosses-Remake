using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerPoint;
    [Tooltip("Rotate Speed")] public float r_Speed = 75;

    void Update()
    {
        transform.RotateAround(playerPoint.position, Vector3.forward, r_Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            r_Speed = r_Speed * -1;
        }
    }
}
