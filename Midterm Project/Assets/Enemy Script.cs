using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;
    public float rangeValue;
    public float rotSpeed;
    public Rigidbody rigidBody;
    public GameObject player;
    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var currentColor = player.GetComponent<ColorManager>().color;

        meshRenderer.material.color = currentColor[Random.Range(0, currentColor.Count)];

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        float dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist <= rangeValue)
        {
            Debug.Log("Point B has been detected");
        }
        LookRotation();
    }


    void LookRotation()
    {
        Vector3 relativePos = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
    }
}
