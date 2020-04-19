using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text startKilledEnemis;
    public static Text killedEnemis;
    public static int killedEnemisNumber;
    void Awake()
    {
        killedEnemis = startKilledEnemis;
    }


    public static void AddKilledEnemy()
    {
        killedEnemisNumber++;
        killedEnemis.text = killedEnemisNumber.ToString();
    }
}
