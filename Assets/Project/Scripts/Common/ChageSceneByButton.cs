using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChageSceneByButton : MonoBehaviour
{
	[SerializeField] string sceneName;

	private bool firstPush = false;
	public void ChangeSecenButtonMethod()
	{
		if (!firstPush)
		{
			firstPush = true;
			SceneManager.LoadScene(sceneName);// シーンをロードする
		}
	}
}