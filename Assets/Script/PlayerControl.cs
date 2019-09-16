using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    Rigidbody rdb;
    Camera cam;
    public int speedFactor = 40;
    public float firedDelay = 0.1f;
    public float delayBeforeNextFire = 0;
    public GameObject bulletPrefab;
    // Use this for initialization
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float imputAxisX = Input.GetAxis("Horizontal");
        float imputAxisY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(imputAxisX, 0, imputAxisY);
        rdb.MovePosition(rdb.position + movement * speedFactor * Time.deltaTime);
        ProssesFire();
        OrientalPlayer();
    }
    private void ProssesFire()
    {
        delayBeforeNextFire -= Time.deltaTime;
        if (Input.GetAxis("Fire1") != 0)
        {
            if (delayBeforeNextFire <= 0)
            {
                shootBullet();
                delayBeforeNextFire = firedDelay;
            }
        }
    }
    private void shootBullet()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, transform.position + (transform.forward * 2), transform.rotation);
    }
    private Vector3 findPositionOfMouse()
    {
        Vector3 result = new Vector3();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            result.x = hit.point.x;
            result.y = hit.point.y;
            result.z = hit.point.z;
        }
        return result;
    }
    private void OrientalPlayer()
    {
        Vector3 result =  findPositionOfMouse();
        result.y = rdb.position.y;
        Vector3 relativePos = result - transform.position;
        Quaternion quaternionRotation = Quaternion.LookRotation(relativePos,Vector3.up);
        rdb.MoveRotation(quaternionRotation);
    }
}
