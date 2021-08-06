using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;
using Gamepad.CharacterSelect;

namespace CharacterSelect.Player
{
	public class MoveCharacterSelectPlayer : MonoBehaviour
	{
		//GamepadNumberの指定(0を選択した場合、すべてのゲームパッドで操作可能になる。)
		public int gamepadNumber = 0;

		//　アイコンが1秒間に何ピクセル移動するか
		[SerializeField]
		private float iconSpeed = 500;
		//　アイコンのサイズ取得で使用
		private RectTransform rect;

		void Start()
		{
			//ゲームプレイ人数に満たない場合、オブジェクトを非表示にする。
			CharacterSelectUtil.checkPlayersNumAndHidden(gamepadNumber, gameObject);

			rect = GetComponent<RectTransform>();
		}

		void Update()
		{
			//　移動キーを押していなければ何もしない
			if (Mathf.Approximately(Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI)), 0f) && Mathf.Approximately(Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)), 0f))
			{
				return;
			}
			//　移動先を計算
			//	Time.deltaTimeは単に直前のフレームと今のフレーム間で経過した時間[秒] を返すプロパティ
			var pos = rect.anchoredPosition + new Vector2(Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI)) * iconSpeed,
				Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)) * iconSpeed * -1) * Time.deltaTime;

			//　アイコンが画面外に出ないようにする
			pos.x = Mathf.Clamp(pos.x, 0.0f, 1920.0f);
			pos.y = Mathf.Clamp(pos.y, 0.0f, 1080.0f);
			Debug.Log("Screen.width:" + Screen.width + " Screen.height" + Screen.height);
			//　アイコン位置を設定
			rect.anchoredPosition = pos;
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
}
