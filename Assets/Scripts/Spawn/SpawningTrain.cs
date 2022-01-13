using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTrain : MonoBehaviour
{

    [Header("Array of GameObjects and Transforms")]
    public GameObject[] RandomTrains;
    public Transform[] RandomTransform;

    [Header("Collider")]
    public Collider Train;

    [Header("The public Ints & bools")]
    public int DeathCount = 0;

    [Header("Floats in coroutines")]
    private IEnumerator coroutine;

    // Start is called before the first frame update
    private void Start()
    {
        coroutine = RandomTrains1(15f);
        InvokeRepeating("Update", 20, 20);
    }

    // Update is called once per frame
    public void Update()
    {
        GameObject NewTrains = RandomTrains[Random.Range(0, RandomTrains.Length)];
        Transform Pingas = RandomTransform[Random.Range(0, RandomTransform.Length)];
        Quaternion spawnRotation = Quaternion.identity;

        GameObject DestroyTrain = Instantiate(NewTrains, Pingas.transform.position, spawnRotation) as GameObject;
        DestroyTrain.transform.Rotate(0, -90, 0);
        
        _ = StartCoroutine(coroutine);
        OnCollisionEnter();

        if (DeathCount == 1)
        {
           Destroy(DestroyTrain);
        }

    }

    public IEnumerator RandomTrains1(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void OnCollisionEnter()
    {
        if (Train.tag == "UnSpawn")
        {
            DeathCount += 1;
        }
    }

}
