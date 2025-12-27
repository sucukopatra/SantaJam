using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public Transform spawnPoint; // Baþýna [SerializeField] ekledik

    void Start()
    {
        if (LevelTeleporter.cameFromTransition && PlayerMovement.Instance != null)
        {
            PlayerMovement.Instance.transform.position = spawnPoint.position;
            LevelTeleporter.cameFromTransition = false;
        }
    }
}
