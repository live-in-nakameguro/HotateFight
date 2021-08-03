using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;
using UnityEngine.SceneManagement;
using GameScenes.SettingAndResultBattle;


public class MoveRandomStageSelectPlayer : MonoBehaviour
{
	//GamepadNumber�̎w��(0��I�������ꍇ�A���ׂẴQ�[���p�b�h�ő���\�ɂȂ�B)
	public int gamepadNumber = 0;

	//�@�A�C�R����1�b�Ԃɉ��s�N�Z���ړ����邩
	[SerializeField]
	private float iconSpeed = 500;
	//�@�A�C�R���̃T�C�Y�擾�Ŏg�p
	private RectTransform rect;

	private Collider2D collision2d;

	private bool isOnStageImage = false;


	void Start()
	{
		rect = GetComponent<RectTransform>();
	}

	void Update()
	{
		MoveRestrictions();
		SwitchStage();
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "CharacterSelect")
		{
			isOnStageImage = true;
			collision2d = col;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "CharacterSelect")
		{
			isOnStageImage = false;
			collision2d = null;
		}
	}

	private void SwitchStage()
	{
		if (!isOnStageImage) return;

		if (Input.GetKeyDown(SetGamepadNumber(GamepadButtonConfig.BUTTON_A)))
		{
			//�����Ń����_���ŏo�Ă���X�e�[�W��ON/OFF�����߂�
			Debug.Log(string.Format("Switch Stage"));
			var randomStageSelect = collision2d.gameObject.GetComponent<RandomStageSelect>();
			bool randomStageBool = RandomStageSetting.RandomStageSettingDic[randomStageSelect.stageName];
			RandomStageSetting.RandomStageSettingDic[randomStageSelect.stageName] = !randomStageBool;
		}

	}

	void MoveRestrictions()
	{
		//�@�ړ��L�[�������Ă��Ȃ���Ή������Ȃ�
		if (Mathf.Approximately(Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI)), 0f) && Mathf.Approximately(Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)), 0f))
		{
			return;
		}
		//�@�ړ�����v�Z
		//	Time.deltaTime�͒P�ɒ��O�̃t���[���ƍ��̃t���[���ԂŌo�߂�������[�b] ��Ԃ��v���p�e�B
		var pos = rect.anchoredPosition + new Vector2(Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_HORI)) * iconSpeed,
			Input.GetAxis(SetGamepadNumber(GamepadButtonConfig.LEFT_STICK_VER)) * iconSpeed * -1) * Time.deltaTime;

		//�@�A�C�R������ʊO�ɏo�Ȃ��悤�ɂ���
		pos.x = Mathf.Clamp(pos.x, 0.0f, 1920.0f);
		pos.y = Mathf.Clamp(pos.y, 0.0f, 1080.0f);
		Debug.Log("Screen.width:" + Screen.width + " Screen.height" + Screen.height);
		//�@�A�C�R���ʒu��ݒ�
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

