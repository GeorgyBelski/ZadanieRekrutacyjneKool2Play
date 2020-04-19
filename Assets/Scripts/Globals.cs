using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    public static float gravity = 9.8f;
    public static int groundLayer = 8;
    public static int groundMask = 1 << groundLayer;

    public static int playerLayer = 9;
    public static int playerMask = 1 << playerLayer;

    public static int enemyLayer = 10;
    public static int enemyMask = LayerMask.GetMask("Enemy");
}
