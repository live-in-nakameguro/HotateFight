using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneByKeyboard : MonoBehaviour
{
	public string keyDownCommand;
	public string sceneName;

	private bool firstPush = false;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(keyDownCommand))
		{
			if (!firstPush)
			{
				firstPush = true;
				Debug.Log("keyDownCommand:" + keyDownCommand);
				Debug.Log("sceneName:" + sceneName);
				SceneManager.LoadScene(sceneName);// シーンをロードする
			}
		}

	}
}
