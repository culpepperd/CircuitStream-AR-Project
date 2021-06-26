using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] FixedJoystick fxJoystick;
    [SerializeField] float movementSpeed = 1.5f;
    [SerializeField] float shootForce = 200;
    [SerializeField] GameObject prefabBullet;

    private Transform player;

    private void OnEnable()
    {
        player = Player.instance.transform;
    }

    private void Update()
    {
        Vector2 joystick = new Vector2(fxJoystick.Horizontal, fxJoystick.Vertical);

        Vector3 playerForward = player.forward * joystick.y * Time.deltaTime * movementSpeed;
        
        Vector3 playerRight = player.right * joystick.x * Time.deltaTime * movementSpeed;

        player.position += playerForward + playerRight;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(prefabBullet, player.position + player.forward * 0.5f + player.up * 0.5f, player.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shootForce);
        Destroy(bullet, 5);
    }
}
