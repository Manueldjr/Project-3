using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bombThrowing : MonoBehaviour
{
    public Transform cam;

    public GameObject bomb;
    GameObject newbomb;
    public float throwForce = 100f;
    public float throwUpForce = 2f;
    bool activeBomb;

    public float cooldownTime;
    bool isCooldown = false;

    [SerializeField] Transform bombSpawnPoint;

    [SerializeField]Animator animator;

    bombExplosion explosion;


    private void Awake()
    {
        activeBomb = true;
        isCooldown = false;

        explosion = bomb.GetComponent<bombExplosion>();
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.T) && activeBomb == true && isCooldown == false)
        {
            bombSpawning();
        }

        if(Input.GetKeyDown(KeyCode.Y) && activeBomb == false )
        {
            isCooldown = true;
            detonateBomb();
            StartCoroutine(CoolDown());
        }

        if (Input.GetKeyDown(KeyCode.R) && activeBomb == false)
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
        explosion.StartExplosion();

        Destroy(newbomb);
        activeBomb = true;
       
    }

    void throwBomb()
    {


        animator.SetTrigger("isThrowing");
       

        Rigidbody b_rb = newbomb.GetComponent<Rigidbody>();
        b_rb.constraints = RigidbodyConstraints.None;
        b_rb.useGravity = true;
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpForce;
        b_rb.AddForce(forceToAdd, ForceMode.Impulse);

        newbomb.transform.SetParent(null);

    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
