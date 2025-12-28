using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform teleportPoint;
    [SerializeField] GameObject player;

    private void Start()
    {
        if (PlayerMovement.Instance != null)
        {
            PlayerMovement.Instance.transform.position = teleportPoint.transform.position;
        }
        else
        {
            Instantiate(player);
        }
    }
    
}
