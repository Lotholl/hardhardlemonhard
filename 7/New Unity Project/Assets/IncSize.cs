using System.Collections;
using UnityEngine;

public class IncSize : MonoBehaviour
{
    public static float scale = 1.1f;

    public void Increase()
    {
        scale = scale + 0.1f;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
}
