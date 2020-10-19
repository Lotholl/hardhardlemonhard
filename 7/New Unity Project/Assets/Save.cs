using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : EgyptT
{
    public void OnSave()
    { // функция сохранения
        StreamWriter sw = new StreamWriter(@"savedata.txt"); // создаём файл
        if (meshRenderer.material.GetTexture("_MainTex") == Bricks) sw.WriteLine("Bricks texture"); // записываем в файл строку
        else if (meshRenderer.material.GetTexture("_MainTex") == Egypt) sw.WriteLine("Egypt texture"); // записываем в файл строку
        sw.WriteLine(scale);
        sw.Close(); // закрываем файл
    }
}
