using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Shooting : MonoBehaviour
{
    public int capacity;
    public int magSize;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Vector2 mousePos;
    public float reloadTime;
    private float reloadTimer;
    public bool reloaded;
    public bool isShooting;
    public Text Magazine;
    public Rigidbody2D rb;
    public GameObject AK_103;
    public GameObject M249;
    public GameObject Intervention;
    public GameObject AUG;
    public GameObject MK14;
    public GameObject Scorpion;
    public GameObject UMP;
    public GameObject[] arsenal;
    public GameObject InHand;
    public float recoilUp;
    public float spreadDown;
    public float spreadUp;
    public float speed = 20f;
    public float totalRecoil;
    public float fireRate;
    public bool recoilRecovering;
    public GameObject OnHand;
    public float recoveryTimer;
    public CinemachineVirtualCamera vcam;
    public bool isZoom;
    public GameObject crosshair;

    void Start()
    {
        arsenal = new GameObject[] { AK_103, M249, Intervention, AUG, MK14, Scorpion, UMP };
        OnHand = InHand;
        capacity = InHand.GetComponent<WeaponStats>().magCapacity;
        reloadTime = InHand.GetComponent<WeaponStats>().reloadSpeed;
        spreadUp = InHand.GetComponent<WeaponStats>().SpreadUp;
        spreadDown = InHand.GetComponent<WeaponStats>().SpreadDown;
        fireRate = InHand.GetComponent<WeaponStats>().timeBetweenShots;
        reloadTimer = reloadTime;
        crosshair.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && reloadTimer == reloadTime)
        {
            InvokeRepeating("Shoot", 0.01f, fireRate);
            isShooting = true;
            recoilRecovering = false;
            recoveryTimer = 1.5f;
        }
        if (Input.GetMouseButtonUp(0) || magSize <= 0)
        {
            CancelInvoke();
            isShooting = false;
            recoilRecovering = true;
        }
        if (Input.GetKeyDown("r") && !isShooting)
        {
            reloaded = true;
        }
        if(reloadTimer <= 0)
        {
            magSize = capacity;
            reloaded = false;
            reloadTimer = reloadTime;
        }
        if (reloaded)
        {
            if (reloadTimer > 0) reloadTimer -= Time.deltaTime;
        }
        Magazine.text = magSize.ToString();
        for (int i = 0; i < arsenal.Length; i++)
        {
            if (!GameObject.ReferenceEquals(InHand, arsenal[i]))
            {
                arsenal[i].SetActive(false);
            }
        }
        InHand.SetActive(true);
        if (totalRecoil > 0 && recoilRecovering)
        {
            recoveryTimer -= Time.deltaTime;
        }

        if(recoveryTimer <= 0)
        {
            totalRecoil = 0;
            recoveryTimer = 1f;
        }

        if (Input.GetMouseButtonDown(1))
        {
            isZoom = true;
            fireRate = 1;
            spreadUp = InHand.GetComponent<WeaponStats>().adsAccuracyUp;
            spreadDown = InHand.GetComponent<WeaponStats>().adsAccuracyDown;
            Cursor.visible = false;
            crosshair.SetActive(true);
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
            {
                vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = InHand.GetComponent<WeaponStats>().adsdistance;
            }
            else
            {
                vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = InHand.GetComponent<WeaponStats>().adsdistance * -1;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
            crosshair.SetActive(false);
            fireRate = InHand.GetComponent<WeaponStats>().timeBetweenShots;
            spreadUp = InHand.GetComponent<WeaponStats>().SpreadUp;
            spreadDown = InHand.GetComponent<WeaponStats>().SpreadDown;
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = 0;
        }

        if(vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x != 0)
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
            {
                vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = InHand.GetComponent<WeaponStats>().adsdistance;
            }
            else
            {
                vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = InHand.GetComponent<WeaponStats>().adsdistance * -1;
            }
        }

        if (OnHand != InHand)
        {
            capacity = InHand.GetComponent<WeaponStats>().magCapacity;
            reloadTime = InHand.GetComponent<WeaponStats>().reloadSpeed;
            spreadUp = InHand.GetComponent<WeaponStats>().SpreadUp;
            spreadDown = InHand.GetComponent<WeaponStats>().SpreadDown;
            fireRate = InHand.GetComponent<WeaponStats>().timeBetweenShots;
            GetComponent<PlayerMovement>().runSpeed = 40 * InHand.GetComponent<WeaponStats>().walkSpeed;
            reloadTimer = reloadTime;
            magSize = capacity;
            OnHand = InHand;
        }
    }

    void Shoot()
    {
        totalRecoil += recoilUp;
        var bulletClone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        magSize--;
    }
}
