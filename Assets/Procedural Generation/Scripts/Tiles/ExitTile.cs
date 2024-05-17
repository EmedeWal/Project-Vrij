using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTile : Tile
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("End Screen");
        }
    }
}
