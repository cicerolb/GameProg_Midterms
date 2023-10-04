using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public List<Color> color;
    public MeshRenderer meshRenderer;
    public int i = 0;

    public Color currentColor;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.material.color = color[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 4)
        {
            i = 0;
            currentColor = color[0];
            
        }
       meshRenderer.material.color = currentColor;
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
        i++;
        currentColor = color[i];
        meshRenderer.material.color = currentColor;

       
    }
}
