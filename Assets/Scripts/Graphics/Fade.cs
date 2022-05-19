using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public GameObject fadeTarget;
    public float fadeSpeed;
    private Material material;

    private void Start()
    {
        material = fadeTarget.GetComponent<Material>();
    }
    private void Update()
    {
        
    }
}
