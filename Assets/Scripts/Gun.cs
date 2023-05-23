using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class Gun : MonoBehaviour
{
    float offset = -90;
    GameObject player;
    MainCharacter character;
    private Transform OutBullet;
    public GameObject Bullet;
    private Inventory _inventory;

    void Start()
    {
        player = GameObject.Find("MainCharacter");
        character = player.GetComponent<MainCharacter>();
        OutBullet = transform.GetChild(0).GetComponent<Transform>();
        _inventory = GameObject.Find("Bag").GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update()
    {
        if (character.DistToEnemy < 625 && character.Enemy != null)
        {
            Vector3 tmp = character.Enemy.transform.position - character.transform.position;
            float rot = Mathf.Atan2(tmp.x, tmp.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, -(rot + offset));
        }
        else if (character.DistToEnemy == 625) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void Fire()
    {
        if (_inventory.GetAmmo())
            Instantiate(Bullet, OutBullet.position, transform.rotation);
    }
}
