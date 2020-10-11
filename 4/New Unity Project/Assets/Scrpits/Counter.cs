using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{

    //btnId - count
	private Dictionary<string, int> buttonPresses;
    
    //btnId - textFieldName
    private Dictionary<string, string> fieldToBtn;
    private TextMeshProUGUI text;
	void Awake()
	{
		buttonPresses = new Dictionary<string, int> ();	
        fieldToBtn = new Dictionary<string, string> ();		
	}

    public void AddClick(string btnName)
    {
        Debug.Log("Pressed: " + btnName);

        //if false current == 0
        buttonPresses.TryGetValue(btnName, out var cur);
        buttonPresses[btnName] = cur + 1;
    }

    public void GetPresses()
    {
        foreach (KeyValuePair<string, int> btnStat in buttonPresses)
        {
            UpdateLine(btnStat.Key, btnStat.Value);
        }
    }

    private void UpdateLine(string btnName, int count)
    {
        if (fieldToBtn.TryGetValue(btnName, out var textName))
        {
            Debug.Log(textName);
            text = GameObject.Find("Canvas/StatMenu/" + textName).GetComponent<TextMeshProUGUI>();
            text.SetText($"Кнопка {btnName}: {count}");
        } else {
            Debug.Log("New button found: " + btnName);
            fieldToBtn[btnName] = btnName + "Counter";
            UpdateLine(btnName, count);
        }
    }
}
