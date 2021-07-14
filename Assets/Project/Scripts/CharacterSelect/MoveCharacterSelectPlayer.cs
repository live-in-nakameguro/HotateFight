using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;

public class MoveCharacterSelectPlayer : MonoBehaviour
{
    //GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
    [SerializeField] int gamepadNumber = 0;

	//　アイコンが1秒間に何ピクセル移動するか
	[SerializeField]
	private float iconSpeed = Screen.width;
	//　アイコンのサイズ取得で使用
	private RectTransform rect;
	//　アイコンが画面内に収まる為のオフセット値
	private Vector2 offset;

	void Start()
	{
		rect = GetComponent<RectTransform>();
		//　オフセット値をアイコンのサイズの半分で設定
		//offset = new Vector2(rect.sizeDelta.x / 2.0f, rect.sizeDelta.y / 2.0f);
		//Debug.Log(offset);
	}

	void Update()
	{
		//　移動キーを押していなければ何もしない
		if (Mathf.Approximately(Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI)), 0f) && Mathf.Approximately(Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)), 0f))
		{
			return;
		}
		//　移動先を計算
		//	Time.deltaTimeは単に 直前のフレームと今のフレーム間で経過した時間[秒] を返すプロパティ
		var pos = rect.anchoredPosition + new Vector2(Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI)) * iconSpeed, 
			Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)) * iconSpeed * -1) * Time.deltaTime;

		//　アイコンが画面外に出ないようにする
		pos.x = Mathf.Clamp(pos.x, 0.0f, Screen.width);
		pos.y = Mathf.Clamp(pos.y, 0.0f, Screen.height);
		Debug.Log("Screen.width:" + Screen.width + " Screen.height" + Screen.height);
		//　アイコン位置を設定
		rect.anchoredPosition = pos;
	}

	//地面に接触したときにはonGroundをtrue、injumpingをfalseにする
	//ただし地面にGroundタグをつける必要がある
	//OnCollisionEnterは物体同士がぶつかった時に呼ばれる
	void OnCollisionEnter(Collision col)
    {

    }

    string SetGamepadNumber(string gamepadKey)
    {
        string gamepadNumberStr = "";
        if (gamepadNumber != 0)
        {
            gamepadNumberStr = $" {gamepadNumber}";
        }
        //Debug.Log(string.Format(gamepadKey, gamepadNumberStr));
        return string.Format(gamepadKey, gamepadNumberStr);
    }
}
