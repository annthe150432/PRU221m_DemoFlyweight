using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory
{
    public List<BulletFlyweight> Flyweights { get; set; }
    private static BulletFactory _instance;
    private static readonly object padlock = new object();
    public static BulletFactory Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new BulletFactory();
                }
            }
            return _instance;
        }
    }

    private BulletFactory()
    {
        Flyweights = new List<BulletFlyweight>();
    }

    public Bullet CreateBullet(string name)
    {
        BulletFlyweight bulletFlyweight = GetBulletFlyweight(name);
        Bullet bullet = new Bullet(bulletFlyweight); 
        bullet.Speed = 5f;
        return bullet;
    }

    private BulletFlyweight GetBulletFlyweight(string name)
    {
        BulletFlyweight bulletFlyweight = Flyweights.Find(bf => bf.Name == name);
        if (bulletFlyweight == null)
        {
            if (name == "lazer")
            {
                bulletFlyweight = new BulletFlyweight(name, new Color(123, 212, 0));
            }
            else if (name == "bounce")
            {
                bulletFlyweight = new BulletFlyweight(name, new Color(123, 12, 0));
            }
            else
            {
                bulletFlyweight = new BulletFlyweight(name, new Color(4, 212, 0));
            }
            Flyweights.Add(bulletFlyweight);
        }
        return bulletFlyweight;
    }
}
