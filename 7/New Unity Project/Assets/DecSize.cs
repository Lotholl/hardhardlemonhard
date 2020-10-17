using System.Collections;
using UnityEngine;

public class DecSize : IncSize
{
    public void Decrease()
    {
        scale = scale - 0.1f;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
}