using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSystem : MonoBehaviour
{
    //Gun Stats
    public int damage;
    public float spread, timeBetweenShooting, reloadTime, timeBetweenShoots;
    public float shootForce, upwardForce;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft, bulletsShot;

    //bools
    public bool shooting, readyToShoot, reloading;
    private bool allowInvoke;

    //Reference
    public Camera cam;
    public Transform attackPoint;

    //Graphics
    public GameObject bullet;

    //Text
    public Text bulletsText;
    public Text reloadingText;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        allowInvoke = true;
    }
    private void Update()
    {
        MyInput();
        bulletsText.text = bulletsLeft + " / " + magazineSize;
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

        //Shake Camera


        bulletsLeft--;
        bulletsShot--;

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
        reloadingText.gameObject.SetActive(true);
        reloading = true;
        Invoke("ReloadFinish", reloadTime);
    }
    private void ReloadFinish()
    {
        reloadingText.gameObject.SetActive(false);
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
