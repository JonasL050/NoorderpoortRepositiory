using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    public Text ShootingPower;
    [SerializeField]
    Transform barrelRotator;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject bulletToFire;

    public float movementSpeed;
    public float rotateSpeed;
    public float shootingForce;
    public int PlayerNumber;
    bool isAanDeBeurt = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isAanDeBeurt == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isAanDeBeurt == true)
            {
                Invoke("WisselBeurt", 0.1f);
            }
            if (PlayerNumber == 1)
            {
                barrelRotator.RotateAround(Vector3.forward, Input.GetAxisRaw("Vertical") * rotateSpeed * Time.deltaTime);
            }
            if (PlayerNumber == 2)
            {
                barrelRotator.RotateAround(Vector3.forward, Input.GetAxisRaw("Vertical") * rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * shootingForce, ForceMode2D.Impulse);

                if (PlayerNumber == 1)
                {
                    b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * 10 * rotateSpeed);
                }
                if (PlayerNumber == 2)
                {
                    b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * 10 * rotateSpeed);
                }


            }
            if (PlayerNumber == 1) { }

            if (Input.GetKeyDown(KeyCode.E))
            {
                IncreasePower();

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DecreasePower();

            }

            ShootingPower.text = shootingForce.ToString();

            transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime);
        }

    }

    public void IncreasePower()
    {
        shootingForce++;
    }

    public void DecreasePower()
    {
        shootingForce--;
    }

    void WisselBeurt()
    {
        GameObject.Find("TurnManager").GetComponent<TurnManager>().WisselBeurt();
    }

    public void ZetActief(bool b)
    {
        if (b == true)
        {
            isAanDeBeurt = true;
        }
        else
        {
            isAanDeBeurt = false;
        }
    }
}