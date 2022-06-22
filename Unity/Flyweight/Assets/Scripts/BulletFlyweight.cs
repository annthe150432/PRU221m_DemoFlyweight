using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BulletFlyweight
{
    public string Name { get; }
    public Color BulletColor { get; }
    public BulletFlyweight(string name, Color color)
    {
        Name = name;
        BulletColor = color;
    }
    public override bool Equals(object obj)
    {
        if (obj is BulletFlyweight)
        {
            return ((BulletFlyweight)obj).Name == Name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, BulletColor);
    }
}

