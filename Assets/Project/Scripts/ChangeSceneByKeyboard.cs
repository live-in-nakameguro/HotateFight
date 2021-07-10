using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneByKeyboard : MonoBehaviour
{
	public string keyDownCommand;
	public string sceneName;

	private bool firstPush = false;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(keyDownCommand))
		{
			if (!firstPush)
            {
				Debug.Log("keyDownCommand:" + keyDownCommand);
				Debug.Log("sceneName:" + sceneName);
				SceneManager.LoadScene(sceneName);// シーンをロードする
			}
		}

	}
}
