using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public GameObject canvas;
	private Counter counterScript;
	public void Awake()
	{
		counterScript = canvas.GetComponent<Counter>();
	}
	
	public void ShowHello(Button btn)
	{
		// SceneManager.LoadScene("Greeting");
		Debug.Log("Привет!");
		OnClick(btn);
	}
	
	public void ShowStats(Button btn)
	{
		Debug.Log("Статистика");
		OnClick(btn);
		canvas.transform.Find("StatMenu").gameObject.SetActive(true);
		counterScript.GetPresses();
		canvas.transform.Find("MainMenu").gameObject.SetActive(false);
	}

	// public void ReturnToMenu()
	// {
	// 	SceneManager.LoadScene("Menu");
	// }
	
	public void Quit(Button btn)
	{
		Debug.Log("Выход");
		Application.Quit();
		OnClick(btn);
	}

	public void OnClick(Button btn)
	{
		counterScript.AddClick(btn.name);
	}
}
