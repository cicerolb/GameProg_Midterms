using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform pointB;
    public float moveSpeed;
    public float rangeValue;
    public float rotSpeed;
 

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var currentColor = player.GetComponent<ColorManager>().color;

        var meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.material.color = currentColor[Random.Range(0, currentColor.Count)];
        pointB = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pointB.position, moveSpeed * Time.deltaTime);

        float dist = Vector3.Distance(transform.position, pointB.position);

        if (dist <= rangeValue)
        {
            Debug.Log("Point B has been detected");
        }
        LookRotation();
    }


    void LookRotation()
    {
        Vector3 relativePos = pointB.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
    }
}
