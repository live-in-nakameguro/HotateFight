using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common.PopUp
{
    public class PopUp : MonoBehaviour
    {
        public static void OpenOkPopUp(GameObject PopUpPanel, string PopUpTitle, string PopUpMessage)
        {
            PopUpPanel.SetActive(true);
            PopUpPanel.transform.GetChild(0).GetComponent<Text>().text = PopUpTitle;
            PopUpPanel.transform.GetChild(1).GetComponent<Text>().text = PopUpMessage;
        }

        public static void CloseOkPopUp(GameObject PopUpPanel)
        {
            PopUpPanel.SetActive(false);
        }
    }
}