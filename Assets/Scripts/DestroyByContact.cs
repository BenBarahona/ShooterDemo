using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;

    public int scoreValue;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find GameController script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, transform.position, transform.rotation);
                gameController.GameOver();
            }

            gameController.addScore(scoreValue);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
