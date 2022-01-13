using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTrain : MonoBehaviour
{

    [Header("Array of GameObjects and Transforms")]
    public GameObject[] RandomTrains;
    public Transform[] RandomTransform;

    [Header("Train Noises")]
    public AudioSource TrainNoice;
    public AudioSource GoneTrain;

    [Header("Collider")]
    public Collider Train;

    [Header("The public Ints & bools")]
    public int DeathCount = 0;

    [Header("Floats in coroutines")]
    private IEnumerator coroutine;

    // Start is called before the first frame update
    private void Start()
    {
        coroutine = RandomTrains1();
        InvokeRepeating("Update", 20, 20);
    }

    // Update is called once per frame
    public void Update()
    {
        //Make gameobject, transform and a quaternion, so you can use it for a random spawner
        GameObject NewTrains = RandomTrains[Random.Range(0, RandomTrains.Length)];
        Transform Pingas = RandomTransform[Random.Range(0, RandomTransform.Length)];
        Quaternion spawnRotation = Quaternion.identity;

        //After you made the gameObject, transform and Quaternion, instantiate it with a GameObject so you can later destroy the instantiated gameobject if it goes behind the player
        GameObject DestroyTrain = Instantiate(NewTrains, Pingas.transform.position, spawnRotation) as GameObject;
        TrainNoice.Play();
        DestroyTrain.transform.Rotate(0, -90, 0);
        
        //Start the Coroutine to get the timing right for spawning the trains (Still an issue dammit)
        _ = StartCoroutine(coroutine);

        OnCollisionEnter(Train);
        if (DeathCount == 1)
        {
            //Destroy Train if the train is behind the player...
            GoneTrain.Play();
            Destroy(DestroyTrain);
        }
    }

    public IEnumerator RandomTrains1()
    {
        while (true)
        {
            //Wait for 20 seconds....it should be fucking simple :(
            yield return new WaitForSeconds(20f);
        }
    }

    public void OnCollisionEnter(Collider collision)
    {
        if (Train.CompareTag("UnSpawn"))
        {
            DeathCount += 1;
        }
    }

}
