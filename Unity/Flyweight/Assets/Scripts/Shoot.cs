using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab1;
    [SerializeField]
    GameObject bulletPrefab2;
    Vector3 gunPosition;
    Timer timer;
    List<Bullet> Bullets;
    const float RotateDegreesPerSecond = 90;
    void Start()
    {
        gunPosition = gameObject.transform.position;
        Bullets = new List<Bullet>();
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 0.05f;
        timer.Run();
    }
    void Update()
    {
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), rotationAmount);
        if (!timer.Running)
        {
            CreateBulletObject();
            timer.Run();
        }
    }
    void CreateBulletObject()
    {
        int rand = Random.Range(1, 3);
        GameObject bulletGO;
        if (rand == 1)
            bulletGO = Instantiate<GameObject>(bulletPrefab1);
        else
            bulletGO = Instantiate<GameObject>(bulletPrefab2);
        bulletGO.transform.position = gunPosition;
        string name = bulletGO.tag;
        Bullet bullet = BulletFactory.Instance.CreateBullet(name);
        Bullets.Add(bullet);

        Rigidbody2D bulletRB2D = bulletGO.GetComponent<Rigidbody2D>();
        bulletRB2D.AddForce(getVector2DByDegree(-transform.eulerAngles.z) * bullet.Speed, ForceMode2D.Impulse);
    }
    Vector2 getVector2DByDegree(float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        float sinD = Mathf.Sin(radian);
        float cosD = Mathf.Cos(radian);
        float x = sinD;
        float y = cosD;
        return new Vector2(x, y);
    }
}
