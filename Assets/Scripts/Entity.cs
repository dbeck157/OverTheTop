using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{

    public int health = 100;

    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    void Death()
    {
        Destroy(gameObject, 0.2f);
    }
}
