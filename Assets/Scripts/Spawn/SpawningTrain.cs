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

    [Header("Floats")]
    [SerializeField] private float LifeTime = 5f;

    [Header("Floats in coroutines")]
    private IEnumerator coroutine;

    private void Awake() => Invoke("TrainSpawn", LifeTime);

    // Start is called before the first frame update
    private void Start()
    {
        coroutine = RandomTrains1();
        TrainsSpawn();
        if (RandomTrains == null)
        {
            RandomTrains = GameObject.FindGameObjectsWithTag("Front");
        }

        foreach (GameObject Train in RandomTrains)
        {
            RandomTrains1();
            StartCoroutine(RandomTrains1());
            this.Wait(3f, TrainsSpawn);
        }
    }

    // Update is called once per frame
    public void Update()
    {
       
    }

    public void TrainsSpawn()
    {
        //Make gameobject, transform and a quaternion, so you can use it for a random spawner
        GameObject NewTrains = RandomTrains[Random.Range(0, RandomTrains.Length)];
        Transform Pingas = RandomTransform[Random.Range(0, RandomTransform.Length)];
        Quaternion spawnRotation = Quaternion.identity;

        //After you made the gameObject, transform and Quaternion, instantiate it with a GameObject so you can later destroy the instantiated gameobject if it goes behind the player
        GameObject DestroyTrain = Instantiate(NewTrains, Pingas.transform.position, spawnRotation) as GameObject;
        TrainNoice.Play();
        DestroyTrain.transform.Rotate(0, 90, 0);
       
        //Start the Coroutine to get the timing right for spawning the trains (Still an issue dammit)
        
        
    }

    public IEnumerator RandomTrains1()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            Update();
        }
    }

   

}
