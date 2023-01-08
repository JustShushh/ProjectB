using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Patrol patrol;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame

    private void OnTriggerEnter (Collider other)
    {
        if (patrol.animator.GetBool("AttackPlayer") && !patrol.animator.GetBool("Die"))
        {
            other.gameObject.SendMessageUpwards("TakeHit");
        }
      
    }
}
