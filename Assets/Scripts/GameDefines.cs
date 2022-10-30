using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefines
{
    public static string m_PlayerTag = "Player";
    public static int m_GroundLayer = 6;
    public static KeyCode m_JumpButton = KeyCode.Space;

    public enum PlayerDirection
    {
        LEFT,RIGHT
    }
}
