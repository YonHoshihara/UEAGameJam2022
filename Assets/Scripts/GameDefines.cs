using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefines
{
    public static string m_PlayerTag = "Player";
    public static string m_ItemControllerTag = "ItemController";
    public static string m_TimerControler = "TimerController";
    public static string m_FoodTag = "Food";
    public static string m_TimeTextTag = "TimeText";
    public static string m_ScoreTextTag = "ScoreText";
    public static string m_WinScreenTag = "WinScreen";
    public static string m_LoseScreenTag = "GameOverScreen";
    public static string m_CurrentScenePlayerPref = "CurrentScene";
    public const int m_GroundLayer = 6;
    public const int m_LandLayer = 7;
    
    public static KeyCode m_JumpButton = KeyCode.Space;

    public enum PlayerDirection
    {
        LEFT,RIGHT
    }
    
    public enum Sounds
    {
        BoxCrash, EatFood, Jump, MonsterDie, PressButton, Spring, Walk, Water, Lose, Win
    }
}
