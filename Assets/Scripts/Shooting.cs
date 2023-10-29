
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text ammoCount;

    [Header("Ammo")]
    public int ammo;
    public int maxAmmo;
    public int storedAmmo;

    [Header("Shooting")]
    public Transform spawnPoint;
    public GameObject basicProjectile;
    public GameObject orientation;
    public float speed;
    public Camera cam;

    [Header("Input")]
    public KeyCode Shoot = KeyCode.Mouse0;
    public KeyCode Reload = KeyCode.R;

    private void Start()
    {
        ammo = maxAmmo;
    }

    private void Update()
    {
        if ((ammo <= 0) && storedAmmo >= maxAmmo)
        {
            ammo = maxAmmo;
            storedAmmo -= maxAmmo;
        }

        if (Input.GetKeyDown(Shoot))
        {
            ShootMethod();
        }
    }

    void ShootMethod()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(1000);

        GameObject instance = Instantiate(basicProjectile, spawnPoint.transform.position, orientation.transform.rotation);
        Debug.Log(instance.name);
       // var bullet = Instantiate(basicProjectile, targetPoint, orientation.transform.rotation);
        instance.GetComponent<Rigidbody>().velocity = (targetPoint - spawnPoint.transform.position).normalized * speed;
    }

}
