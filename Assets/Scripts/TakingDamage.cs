using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TakingDamage : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [PunRPC]
    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
    }
}
