using UnityEngine;
using System.Collections.Generic;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> enemiesToActivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            foreach (var enemy in enemiesToActivate)
            {
                if (enemy != null)
                    enemy.GetComponent<EnemyMovement>().enabled = true;
            }
        }
    }
}

