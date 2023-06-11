using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassProduceP2 : MonoBehaviour
{

    private IEnumerator _coroutineSpawn;
    [SerializeField] private int objectQuantity = 0;
    [SerializeField] private int maxObjectQuantity = 20;
    private float posX;
    private float posY;
    private bool isWaiting = false;


    public GameObject theCollectible2;


    // Start is called before the first frame update
    void Start()
    {

        _coroutineSpawn = CoroutineSpawn(); 
 
    }

    // Update is called once per frame
    void Update()
    {
        if (objectQuantity == 0)
        {
            Respawn();
        }
        else if (isWaiting == false & objectQuantity <= 10)
        {
            isWaiting = true;
            StartCoroutine(Waiter());
        }

    }



    public void DecreaseCollectibleCount()
    {
        objectQuantity -= 1;
    }

    public void Respawn()
    {
        //GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        //foreach (GameObject collectible in collectibles)
        //    if (collectible.transform.position.x > 0f)
        //    {
        //        objectQuantity--;
        //        GameObject.Destroy(collectible);
        //    }
        
        while (objectQuantity < maxObjectQuantity)
        {
            _coroutineSpawn.MoveNext();
        }
    }

    IEnumerator CoroutineSpawn()
    {
        while (true)
        {
            posX = Random.Range(+8.31f, +0.3f);
            posY = Random.Range(-4.41f, 4.41f);
            Instantiate(theCollectible2, new Vector3(posX, posY, 0f), Quaternion.identity);
            objectQuantity += 1;
            yield return null;
        }
    }

    IEnumerator Waiter()
    {
        float counter = 5;

        while (counter > 0)
        {
            //Increment Timer until counter >= waitTime
            counter -= Time.deltaTime;
            //Debug.Log("We have waited for: " + counter + " seconds");
            //Wait for a frame so that Unity doesn't freeze
            //Check if we want to quit this function
            
            yield return null;
        }
        Respawn();
        isWaiting = false;
    }
}

