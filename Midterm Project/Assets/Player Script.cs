using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
public class vector3 : MonoBehaviour
{

    public Transform pointB;
    public float rangeValue;
    public Quaternion currentRotation;
    public float rotSpeed;
    public Transform targetA;
    float timeCount = 0.0f;
    public float bulletSpawnTime;
    //prefab projectile
    public GameObject bulletPreFab;

    

    //bullet Spawn here
    public Transform bulletSpawnPoint;

    //speed of bullet
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    // Update is called once per frame
    void Update()
    {


        var targets = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var target in targets)
        {
            float dist = Vector3.Distance(transform.position, target.transform.position);

            if (dist <= rangeValue)
            {
                transform.LookAt(target.transform.position);
            }

          
        }

        




        //QuaternionRotateTowards();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Bullet = Instantiate(bulletPreFab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody rb = Bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * bulletSpeed;
        }


    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            GameObject Bullet = Instantiate(bulletPreFab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody rb = Bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * bulletSpeed;
            yield return new WaitForSeconds(bulletSpawnTime);
        }
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeValue);
    }

    //void QuaternionRotateTowards()
    //{
    //    var step = rotSpeed * Time.time;
    //    transform.rotation =
    //        Quaternion.RotateTowards(transform.rotation, targetA.rotation, step);


    //}

    void LookRotation()
    {
        Vector3 relativePos = targetA.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
    }

    


   


}