using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{

    [Header("Movement of the Train")]
    public float SpeedTrain = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * SpeedTrain;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UnSpawn"))
        {
            //this will destroy the train behind the player
            Destroy(gameObject);
        }
    }
}
