using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    [SerializeField] Sprite[] skinKnife;
    [SerializeField] GameObject knifePrefub,trigger;
    public float speed=1;
    private Vector2 genPos=new Vector2(0,-4.5f), 
                    startPos=new Vector2(0,-3.5f);
    public int activeSkinKnife;
    private bool hit;
    private int flip;

    private void Awake()
    {
        StartCoroutine(Gen());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hit)
        {
            hit = true;
            Instantiate(knifePrefub, genPos, Quaternion.identity);

        }
        if (hit)
        {
            transform.position += new Vector3(0, speed,0)*Time.deltaTime;
        }

        switch (flip)
        {
            case 1://right
                transform.Rotate = new Vector3(0, 0, Random.Range(5f, 50f));
                return;
            case 2://left
                transform.Rotate = new Vector3(0, 0, Random.Range(-50f, 5f));
                return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wood")
        {
            transform.SetParent(collision.transform);
            collision.GetComponent<wood>().HIT();
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            trigger.SetActive(true);
            Destroy(this);
        }
        else
        {
            if (collision.name == "left")
            {
                speed = 0;
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3500f, 100f), Random.Range(-100f, -1001f)));
                Destroy(gameObject.GetComponent<BoxCollider2D>());
                flip = 2;
                //Destroy(this);
            }else if (collision.name == "right")
            {
                speed = 0;
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(360f, 3600f), Random.Range(-100f, -1001f)));
                Destroy(gameObject.GetComponent<BoxCollider2D>());
                flip = 1;
                //Destroy(this);
            }
        }
        /*if (collision.tag == "wood")
        {
            transform.SetParent(collision.transform);
            collision.GetComponent<wood>().HIT();
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(this);
        }
        else if (collision.tag == "knife")
        {
            speed = 0;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-25, 26), -10f));
            Destroy(this);
        }*/
    }

    private IEnumerator Gen()
    {
        for (float i = 0; i <= 1; i += 0.1f)
        {
            transform.position = Vector2.Lerp(genPos, startPos, i);
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
