using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector2 normPos;

    private void Awake()
    {
        normPos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }

    public void HIT()
    {
        StartCoroutine(Hit());
    }

    private IEnumerator Hit()
    {
        Vector2 newPos = new Vector2(normPos.x, normPos.y + 0.1f);
        for(float i = 0; i <= 1; i += 0.1f)
        {
            transform.position = Vector2.Lerp(normPos, newPos, i);
            yield return new WaitForSeconds(0.01f);
        }
        for(float i = 1; i >= 0; i -= 0.1f)
        {
            transform.position = Vector2.Lerp(normPos, newPos, i);
            yield return new WaitForSeconds(0.01f);

        }
    }
}
