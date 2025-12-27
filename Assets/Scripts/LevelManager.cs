using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public Transform spawnPoint; // Baþýna [SerializeField] ekledik
    [SerializeField] public GameObject karakter;

    void Start()
    {
        if (PlayerMovement.Instance == null) { Instantiate(karakter); }

        if (LevelTeleporter.cameFromTransition && PlayerMovement.Instance != null)
        {
            Debug.Log("AAAAAAAAAAAAAA");
            if (karakter) karakter.SetActive(false);
            PlayerMovement.Instance.transform.position = spawnPoint.position;
            LevelTeleporter.cameFromTransition = false;
        }
    }
}
