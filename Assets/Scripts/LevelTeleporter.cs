using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTeleporter : MonoBehaviour
{
    [SerializeField] private string targetSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player") && !PlayerMovement.Instance.justTeleported)
        {
            PlayerMovement.Instance.justTeleported = true;
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
