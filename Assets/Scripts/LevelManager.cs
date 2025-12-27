using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject player;


    private void Start()
    {
        if (PlayerMovement.Instance != null)
        {
            PlayerMovement.Instance.transform.position = spawnPoint.transform.position;
            StartCoroutine(FalseJustTeleported());
        }
        else
        {
            Instantiate(player);
        }
    }
    IEnumerator FalseJustTeleported(){
        yield return new WaitForSeconds(1);
        PlayerMovement.Instance.justTeleported = false;
    }
}
