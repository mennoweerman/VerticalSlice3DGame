using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTrain : MonoBehaviour
{
    [Header("Array of GameObjects and Transforms")]
    public GameObject[] RandomTrains;
    public Transform[] RandomTransform;

    [Header("The back of the train")]
    public GameObject BackOfTrain;
    Collider backOfTheTrain;

    [Header("The public Ints :D")]
    public int DeathCount = 0;

    [Header("Floats in coroutines")]
    private IEnumerator coroutine;

    // Start is called before the first frame update
    private void Start()
    {
        coroutine = RandomTrains1(2f);
        BackOfTrain.tag = "Back";
    }

    // Update is called once per frame
    private void Update()
    {
        _ = StartCoroutine(coroutine);
    }

    public IEnumerator RandomTrains1(float waitTime)
    {
        while (true)
        {
            GameObject NewTrains = RandomTrains[Random.Range(0, RandomTransform.Length)];
            Transform Pingas = RandomTransform[Random.Range(0, RandomTransform.Length)];
            Quaternion spawnRotation = Quaternion.identity;
            GameObject DestroyTrain = Instantiate(NewTrains, Pingas.transform.position, spawnRotation) as GameObject;
            OnCollisionEnter(backOfTheTrain);
            yield return new WaitForSeconds(waitTime);
            if(DeathCount == 1)
            {
                Destroy(DestroyTrain);
            }
        }
    }


    public void OnCollisionEnter(Collider collision)
    {
        if (BackOfTrain.CompareTag("UnSpawn"))
        {
            DeathCount += 1;
        }
    }



}
