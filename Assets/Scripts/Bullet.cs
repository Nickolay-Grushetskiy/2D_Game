using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float distanceFly;
    public float speed;
    public LayerMask mask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, speed * Time.deltaTime, mask);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
                hit.collider.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if(distanceFly<=0)
            Destroy(gameObject);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        distanceFly -= speed * Time.deltaTime;
        
    }
}
