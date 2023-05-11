using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSystem : MonoBehaviour
{
    [Header("Gun Stats")]
    public int damage;
    [SerializeField] private float spread, timeBetweenShooting, reloadTime, timeBetweenShoots;
    [SerializeField] private float shootForce, upwardForce;
    [SerializeField] private int magazineSize, bulletsPerTap;
    [SerializeField] private bool allowButtonHold;
    [SerializeField] public int bulletsLeft, bulletsShot;
    
    private bool shooting, readyToShoot, reloading;
    private bool allowInvoke;

    [Header("Reference")]
    public Camera cam;
    public Transform attackPoint;

    //Graphics
    public GameObject bullet;

    //Controllers
    [SerializeField]private UIController uic;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        allowInvoke = true;
    }
    private void Start()
    {
        uic = FindObjectOfType<UIController>();
        uic.UpdateBullets(bulletsLeft, magazineSize);
    }
    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        //Reload
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        if(readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }
        //Shoot
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Find the exact hit position
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //Ray going in the middle of the screen
        RaycastHit hit;

        //Checks if ray hits something
        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75); //Just a point far away
        }

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add force to the bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(cam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot--;
        uic.UpdateBullets(bulletsLeft, magazineSize);

        if (allowInvoke)
        {
            Invoke("ResetShoot", timeBetweenShooting);
            allowInvoke = false;
        }

        if(bulletsShot>0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShoots);
        }
    }
    private void ResetShoot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    private void Reload()
    {
        uic.ReloadText(true);
        reloading = true;
        Invoke("ReloadFinish", reloadTime);
    }
    private void ReloadFinish()
    {
        uic.ReloadText(false);
        bulletsLeft = magazineSize;
        uic.UpdateBullets(bulletsLeft, magazineSize);
        reloading = false;
    }
}
