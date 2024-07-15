using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public float damage;
    public string punchNAME;
    public Fighter fighter;
    
     private void OnTriggerEnter(Collider other)
    {
        Fighter enemy = other.GetComponent<Fighter>();
        if(fighter.attacking)
        {
            if(enemy != null && enemy!=fighter)
            {
                enemy.takeDamage(damage);
            }
        }
    }
}
