using UnityEngine;
using System.Collections.Generic;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> enemiesToActivate;
    Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            col.enabled = false;
            foreach (var enemy in enemiesToActivate)
            {
                if (enemy != null)
                    enemy.GetComponent<EnemyMovement>().enabled = true;
                    enemy.GetComponent<Animator>().enabled = true;
            }
        }
    }
}

