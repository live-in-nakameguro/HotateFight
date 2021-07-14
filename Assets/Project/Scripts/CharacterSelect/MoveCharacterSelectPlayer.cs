using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamepad.Config;

namespace CharacterSelect.Player
{
	public class MoveCharacterSelectPlayer : MonoBehaviour
	{
		//GamepadNumber�̎w��(0��I�������ꍇ�A���ׂẴQ�[���p�b�h�ő���\�ɂȂ�B)
		public int gamepadNumber = 0;

		//�@�A�C�R����1�b�Ԃɉ��s�N�Z���ړ����邩
		[SerializeField]
		private float iconSpeed = 500;
		//�@�A�C�R���̃T�C�Y�擾�Ŏg�p
		private RectTransform rect;
		//�@�A�C�R������ʓ��Ɏ��܂�ׂ̃I�t�Z�b�g�l
		private Vector2 offset;

		void Start()
		{
			rect = GetComponent<RectTransform>();
			//�@�I�t�Z�b�g�l���A�C�R���̃T�C�Y�̔����Őݒ�
			//offset = new Vector2(rect.sizeDelta.x / 2.0f, rect.sizeDelta.y / 2.0f);
			//Debug.Log(offset);
		}

		void Update()
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

		//�n�ʂɐڐG�����Ƃ��ɂ�onGround��true�Ainjumping��false�ɂ���
		//�������n�ʂ�Ground�^�O������K�v������
		//OnCollisionEnter�͕��̓��m���Ԃ��������ɌĂ΂��
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
}
