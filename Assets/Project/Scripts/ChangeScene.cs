using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public string keyDownCommand;
	public string sceneName;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(keyDownCommand)) // enterが押された場合
		{
			Debug.Log("keyDownCommand:"+ keyDownCommand);
			Debug.Log("sceneName:" + sceneName);
			SceneManager.LoadScene(sceneName);// シーンをロードする
		}

	}
}
