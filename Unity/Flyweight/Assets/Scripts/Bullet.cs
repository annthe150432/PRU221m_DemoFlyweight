using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    public BulletFlyweight BulletFlyweight { get; }
    public float Speed { get; set; }
    public Bullet(BulletFlyweight flyweight)
    {
        BulletFlyweight = flyweight;
    }
}
