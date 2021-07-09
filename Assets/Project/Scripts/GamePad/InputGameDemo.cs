using System.Collections.Generic;
using UnityEngine;
public class InputGameDemo : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("button0");
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("button1");
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("button2");
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("button3");
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("button4");
        }
        if (Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("button5");
        }
        if (Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("button6");
        }
        if (Input.GetKeyDown("joystick button 7"))
        {
            Debug.Log("button7");
        }
        if (Input.GetKeyDown("joystick button 8"))
        {
            Debug.Log("button8");
        }
        if (Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("button9");
        }
        if (Input.GetKeyDown("joystick button 10"))
        {
            Debug.Log("button10");
        }
        if (Input.GetKeyDown("joystick button 11"))
        {
            Debug.Log("button11");
        }
        if (Input.GetKeyDown("joystick button 12"))
        {
            Debug.Log("button12");
        }
        if (Input.GetKeyDown("joystick button 13"))
        {
            Debug.Log("button8");
        }
        if (Input.GetKeyDown("joystick button 13"))
        {
            Debug.Log("button13");
        }
        if (Input.GetKeyDown("joystick button 14"))
        {
            Debug.Log("button14");
        }
        if (Input.GetKeyDown("joystick button 15"))
        {
            Debug.Log("button15");
        }

        float hori = Input.GetAxis("LeftHorizontal");
        float vert = Input.GetAxis("LeftVertical");
        if ((hori != 0) || (vert != 0))
        {
            Debug.Log("left stick:" + hori + "," + vert);
        }

        float hori2 = Input.GetAxis("RightHorizontal");
        float vert2 = Input.GetAxis("RightVertical");
        if ((hori2 != 0) || (vert2 != 0))
        {
            Debug.Log("right stick2:" + hori2 + "," + vert2);
        }

        float hori3 = Input.GetAxis("DpadHorizontal");
        float vert3 = Input.GetAxis("DpadVertical");
        if ((hori3 != 0) || (vert3 != 0))
        {
            Debug.Log("dpad:" + hori3 + "," + vert3);
        }
    }
}
