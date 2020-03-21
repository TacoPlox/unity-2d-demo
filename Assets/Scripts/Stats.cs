using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health = 100f;
    public float damageOnHit = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit() {
        Debug.Log("OnHit");
        // health = health - damageOnHit;
        health -= damageOnHit;

        if (health <= 0f) {
            Die();
        }
    }

    private void Die() {
        Destroy(this.gameObject);
    }
}
