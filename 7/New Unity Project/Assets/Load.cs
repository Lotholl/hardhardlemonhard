using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Load : Save
{
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

        public void OnLoadF() // функция чтения
    {
        StreamReader sr = new StreamReader(@"savedata.txt"); // открываем файл
        string textu = sr.ReadLine(); // читаем строку
        if (textu.Equals("Egypt texture"))
        {
            meshRenderer.material.SetTexture("_MainTex", Egypt);
        }
        if (textu.Equals("Bricks texture"))
        {
            meshRenderer.material.SetTexture("_MainTex", Bricks);
        }

        scale = float.Parse(sr.ReadLine());

        gameObject.transform.localScale = new Vector3(scale, scale, scale);


        sr.Close(); // закрываем файл
    }
}
