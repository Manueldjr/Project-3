using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombThrowing : MonoBehaviour
{
    public GameObject bomb;
    GameObject newbomb;
    public float throwForce;
    bool activeBomb;
    bool isHolding;

    [SerializeField] Transform bombSpawnPoint;

    private void Awake()
    {
        activeBomb = true;
        //isHolding = false;
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.T) && activeBomb == true)
        {
            bombSpawning();
        }

        if(Input.GetKeyDown(KeyCode.Y) && activeBomb == false)
        {
            detonateBomb();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            throwBomb();
        }
    }

    void bombSpawning()
    {
        newbomb = Instantiate(bomb, bombSpawnPoint.position, bombSpawnPoint.rotation);
        newbomb.transform.SetParent(bombSpawnPoint);
        activeBomb = false;

    }

    void detonateBomb()
    {
        Destroy(newbomb);
        activeBomb = true;
    }

    void throwBomb()
    {
        newbomb.transform.SetParent(null);
    }
}
