using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    // 점프
    [SerializeField]
    private float jumpForce = 300f;

    private bool isJump = false;

    // 총알
    [SerializeField]
    private GameObject bulletPos = null;

    [SerializeField]
    private GameObject bulletObj = null;


    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        if (Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float playerSpeed = h * moveSpeed * Time.deltaTime;
        Vector3 vector3 = new Vector3();
        vector3.x = playerSpeed;
        transform.Translate(vector3);

        if (h < 0)
        {
            GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h == 0)
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void PlayerJump()
    {
        // 점프 상태가 아닐때만 점프 가능
        if(isJump == false)
        {
            GetComponent<Animator>().SetBool("Walk", false);
            GetComponent<Animator>().SetBool("Jump", true);

            // 
            Vector2 vector2 = new Vector2(0, jumpForce);
            GetComponent<Rigidbody2D>().AddForce(vector2);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌체의 콜라이더가 플렛폼 태그라면
        if(collision.collider.tag == "Platform")
        {
            GetComponent<Animator>().SetBool("Jump", false);
            isJump = false;
        }
    }

    private void Fire()
    {
        GetComponent<AudioSource>().Play();
        float direction = transform.localScale.x;
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);
        Instantiate(bulletObj, bulletPos.transform.position, quaternion).GetComponent<Bullet>().InstantiateBullet(direction);
    }
}