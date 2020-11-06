using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject bouncePrefab;
    public float minX = -5f;
    public float maxX = 5f;
    public int addY = 5; //this is to place them right outside the camera



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1, 10) == 1)
            {
                Destroy(collision.gameObject);

                Instantiate(
                    bouncePrefab,
                    new Vector2(Random.Range(minX, maxX), player.transform.position.y + (addY + Random.Range(0.5f, 1f))),
                    Quaternion.identity);
            }
            else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(minX, maxX), player.transform.position.y + (addY + Random.Range(0.5f, 1f)));
            }


        } else if (collision.gameObject.name.StartsWith("Spring"))
        {
            if (Random.Range(1, 10) == 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(minX, maxX), player.transform.position.y + (addY + Random.Range(0.5f, 1f)));
            }
            else
            {
                Destroy(collision.gameObject);

                Instantiate(
                    platformPrefab,
                    new Vector2(Random.Range(minX, maxX), player.transform.position.y + (addY + Random.Range(0.5f, 1f))),
                    Quaternion.identity);
            }
        }
    } 

   
}



