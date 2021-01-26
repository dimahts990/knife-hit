using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    [SerializeField] float speed;
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }
}
