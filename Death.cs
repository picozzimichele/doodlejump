using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.StartsWith("Doodler"))
        {
            Destroy(collision.gameObject);

            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
