using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    [SerializeField] Sprite[] skinKnife;
    [SerializeField] GameObject knifePrefub;
    public float speed=1;
    private Vector2 genPos=new Vector2(0,-3.5f);
    public int activeSkinKnife;
    private bool hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hit)
        {
            hit = true;
            Instantiate(knifePrefub, genPos, Quaternion.Euler(0, 0, -135));

        }
        if (hit)
        {
            transform.position += new Vector3(0, speed,0)*Time.deltaTime;
        }
    }
    
}
