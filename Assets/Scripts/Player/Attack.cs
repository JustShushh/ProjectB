using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Patrol patrol;
    [SerializeField] private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            patrol = enemy.GetComponent<Patrol>();
        }
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Patrol>().dead = true;
                other.GetComponent<Animator>().SetBool("Die", true);
            }
        }
    }
}
