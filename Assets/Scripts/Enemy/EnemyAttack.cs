using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Patrol patrol;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
       playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); 
    }

    // Update is called once per frame

    private void OnTriggerStay(Collider other)
    {
        if (patrol.GetComponent<Animator>().GetBool("AttackPlayer") == true)
        {
            Debug.Log(other.gameObject);
            if (other.CompareTag("Player"))
            {
                playerController.TakeHit();   
            }
        }
    }
}
