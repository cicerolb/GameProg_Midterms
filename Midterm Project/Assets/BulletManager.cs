using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Rigidbody rigidBody;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        var player = GameObject.FindGameObjectWithTag("Player");
        var currentColor = player.GetComponent<ColorManager>().currentColor;

        

        meshRenderer.material.color = currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") && collision.GetComponent<MeshRenderer>().material.color.Equals(meshRenderer.material.color))
        {
            Destroy(collision.gameObject);

        }



        
    }

}
