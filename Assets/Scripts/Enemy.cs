using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    public int speed;
    public int attackDamage;
    public float distAttackInSqr;
    public bool toMove = false;
    public float radiusAttack;

    public Rigidbody2D RigidBody;
    public Collider2D Collider;
    public GameObject Player;
    private HealthBar _healthBar;
    public ItemsList _itemsList;
    public DropItemList _dropItemList;
    public Animator animator;
    public Transform AttackPoint;
    

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
        _healthBar = GetComponentInChildren<HealthBar>();
        _healthBar.UpdateHealthBar(_health, _maxHealth);
        _itemsList = GameObject.Find("Map").GetComponent<ItemsList>();
        _dropItemList = GetComponent<DropItemList>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Player != null)
        {
            var tmp = Player.transform.position - transform.position;
            if (toMove && tmp.sqrMagnitude > distAttackInSqr)
            {
                Move();
                animator.SetBool("ToMove", true);
            }
            if (tmp.sqrMagnitude < distAttackInSqr)
            {
                animator.SetBool("ToMove", false);
                animator.SetTrigger("Attack");
            }
        }
        else
            animator.SetBool("ToMove", false);
    }

    void Attack()
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(AttackPoint.position, radiusAttack);
        foreach (Collider2D col in players)
        {
            if (col != null && col.gameObject.tag == "Player")
            {
                col.transform.GetComponent<MainCharacter>().TakeDamage(attackDamage);
                break;
            }
        }
    }

    public void Check()
    {
        if(Player != null)
        {
            toMove = true;
        }
    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _healthBar.UpdateHealthBar(_health, _maxHealth);
        if (_health < 1)
        {
            foreach(var item in _dropItemList.dropItemList)
            {
                if (item.chance >= Random.Range(1, 100))
                {
                    Object obj;
                    GameObject prefab = _itemsList.prefabs[_itemsList.items[item.name]];
                    obj = Instantiate(prefab, new Vector3(transform.position.x + Random.Range(-30, 30), transform.position.y + Random.Range(-30, 30)), Quaternion.identity);
                    obj.GetComponent<Item>().count = Random.Range(item.minAmount, item.maxAmount);
                }
            }
            Destroy(gameObject);
        }
    }


    abstract public void AddDropItems();
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(AttackPoint.position, radiusAttack);
    }
}
