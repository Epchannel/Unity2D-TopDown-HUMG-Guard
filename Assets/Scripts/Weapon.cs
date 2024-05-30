using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePos;
    public GameObject muzzle;
    // public GameObject fireEffect;
    
    public float TimeBtwFire = 0.2f; //Thời gian viên đạn bắn ra
    public float bulletForce; //Lực của viên đạn khi rời khỏi súng

    private float timeBtwFire;


    void Update()
    {
        RotateGun();
        timeBtwFire -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timeBtwFire < 0)
        {
            FireBullet();
        }
    }

    //Quay súng theo hướng chuột
    void RotateGun()
    {
        //Chuyển tọa độ con chuột pixel sang workpoint
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Lấy vector từ nhân vật sang con chuột: Lấy vt con chuột - vt cái súng
        Vector2 lookDir = mousePos - transform.position;

        //Góc hệ radian bằng công thức Atan2
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) 
            transform.localScale = new Vector3(1, -1, 0);
        else
            transform.localScale = new Vector3(1, 1, 0);
    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);

        //Effect
        Instantiate(muzzle, firePos.position, transform.rotation, transform);
        // Instantiate(fireEffect, firePos.position, transform.rotation, transform);

        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>(); //Viên đạn bay
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse); //Thêm lực đạn, vector lực = , chế độ lực Impulse là thêm lực 1 lần khi bắn ra
    }

}
