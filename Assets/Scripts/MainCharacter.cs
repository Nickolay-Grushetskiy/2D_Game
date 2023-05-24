using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public float speed;
    public Transform Enemy;
    public float DistToEnemy;

    public Joystick joystick;
    public CapsuleCollider2D Collider;
    public Rigidbody2D RigidBody;
    public SpriteRenderer SpriteRenderer;
    public CircleCollider2D CircleCollider;
    public GameObject Gun;
    public Inventory _inventory;
    private Animator _animator;
    HealthBar _healthBar;

    void Start()
    {
        Collider = GetComponent<CapsuleCollider2D>();
        RigidBody = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        CircleCollider = GetComponent<CircleCollider2D>();
        _inventory = GameObject.Find("Bag").GetComponent<Inventory>();
        _healthBar = gameObject.GetComponentInChildren<HealthBar>();
        _healthBar.UpdateHealthBar(health, maxHealth);
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 tmpVector = new Vector2(joystick.Horizontal, joystick.Vertical);
        tmpVector = tmpVector.normalized * speed;
        tmpVector = RigidBody.position + tmpVector * Time.fixedDeltaTime;
        tmpVector.x = Mathf.Clamp(tmpVector.x, -500, 3000);
        tmpVector.y = Mathf.Clamp(tmpVector.y, -200, 200);
        RigidBody.MovePosition(tmpVector);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            _animator.SetBool("Move", true);
        else
            _animator.SetBool("Move", false);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Enemy")
        {
            otherCollider.GetComponent<Enemy>().toMove = true;
            otherCollider.GetComponent<Enemy>().animator.SetBool("ToMove", true);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        switch (otherCollider.gameObject.tag)
        {
            case "Enemy":
                {
                    var vectorEnemy = otherCollider.transform.position - transform.position;
                    var distance = vectorEnemy.magnitude;
                    if (distance < DistToEnemy)
                    {
                        DistToEnemy = distance;
                        Enemy = otherCollider.gameObject.transform;
                    }
                }
                break;
        }

    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        DistToEnemy = 625;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 1)
            Destroy(gameObject);
        _healthBar.UpdateHealthBar(health, maxHealth);
    }

}
