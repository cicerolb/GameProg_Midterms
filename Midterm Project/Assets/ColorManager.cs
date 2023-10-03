using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public List<Color> color;
    public MeshRenderer meshRenderer;
    public float delayTime;

    public Color currentColor;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeColor()
    {
        for (int i = 0; i < color.Count; i++)
        {
            currentColor = color[Random.Range(0, color.Count)];
            meshRenderer.material.color = currentColor; 
        }
    }
    private void OnMouseDown()
    {
        ChangeColor();
    }
}
