using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float bulletTtl = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletTtl -= Time.deltaTime;
        if (bulletTtl <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Tank1"))
        {
            GameObject.Find("Canvas").GetComponent<Score>().AddP2Score();
        }
        GetComponent<SpriteRenderer>().enabled = false;
        if (collision.transform.CompareTag("Tank2"))
        {
            GameObject.Find("Canvas").GetComponent<Score>().AddP1Score();
        }
        Destroy (gameObject);
    }
}
