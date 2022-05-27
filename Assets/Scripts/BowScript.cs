using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    public enum ArrowType { Ice, Fire, Normal };
    float _charge;

    public float chargeMax;
    public float chargeRate;

    public KeyCode fireButton;

    public Transform spawn;
    public GameObject iceArrowObject;
    public GameObject iceArrowObjWhileHolding;

    public GameObject fireArrowObject;
    public GameObject fireArrowObjWhileHolding;
    public GameObject normalArrowObject;
    public GameObject normalArrowObjWhileHolding;

    private ArrowType currentArrowType;


    //[HideInInspector]
    //public PauseMenu ps;

    public bool isTimeStopped;
    public bool isUsingBomp;
    public bool isShopOpen;

    public Animator animator;
    public Camera fpsCam;

    public void Start()
    {
        currentArrowType = ArrowType.Normal;

        

        Animator animator = gameObject.GetComponent<Animator>();

        isUsingBomp = false;

    }

    public void Update()
    {
        if (GameManager.instance.isGameOver || isTimeStopped)
        {
            return;
        }

        //isTimeStopped = ps.isShopOpen;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (currentArrowType == ArrowType.Normal)
            {
                if (GameManager.instance.IceQuantity > 0)
                {
                    currentArrowType = ArrowType.Ice;
                }
                else if (GameManager.instance.FireQuantity > 0)
                {
                    currentArrowType = ArrowType.Fire;
                }
            }

            else if (currentArrowType == ArrowType.Ice && GameManager.instance.FireQuantity > 0)
            {
                currentArrowType = ArrowType.Fire;
            }
            else
            {
                currentArrowType = ArrowType.Normal;
            }
        }


        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;

        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 direction = targetPoint - spawn.position;

        switch (currentArrowType)
        {
            case ArrowType.Fire:

                if (Input.GetKey(fireButton) && _charge < chargeMax)
                {

                    animator.Play("BowHolding");

                    _charge += Time.deltaTime * chargeRate;

                    fireArrowObjWhileHolding.SetActive(true);
                }

                if (Input.GetKeyUp(fireButton))
                {
                    // Debug.Log("Fire");
                    GameManager.instance.DecsFireArrow();
                    CheckQuantity();
                    animator.Play("BowRelease");
                    fireArrowObjWhileHolding.SetActive(false);
                    GameObject arrow = Instantiate(fireArrowObject, spawn.position, Quaternion.identity);
                    arrow.transform.forward = direction.normalized;
                    arrow.GetComponent<Rigidbody>().AddForce(direction.normalized * _charge, ForceMode.Impulse);
                    _charge = 0;
                    Destroy(arrow, 2f);

                }

                break;

            case ArrowType.Ice:
                {
                    if (Input.GetKey(fireButton) && _charge < chargeMax)
                    {

                        animator.Play("BowHolding");

                        _charge += Time.deltaTime * chargeRate;

                        iceArrowObjWhileHolding.SetActive(true);
                    }

                    if (Input.GetKeyUp(fireButton))
                    {

                        // Debug.Log("Ice arrow");
                        GameManager.instance.DecsIceArrow();
                        CheckQuantity();
                        animator.Play("BowRelease");
                        iceArrowObjWhileHolding.SetActive(false);
                        GameObject arrow = Instantiate(iceArrowObject, spawn.position, Quaternion.identity);
                        arrow.transform.forward = direction.normalized;
                        arrow.GetComponent<Rigidbody>().AddForce(direction.normalized * _charge, ForceMode.Impulse);
                        _charge = 0;

                        Destroy(arrow, 2f);
                    }

                    break;
                }
            case ArrowType.Normal:
                {
                    if (Input.GetKey(fireButton) && _charge < chargeMax)
                    {

                        animator.Play("BowHolding");

                        _charge += Time.deltaTime * chargeRate;

                        normalArrowObjWhileHolding.SetActive(true);
                    }

                    if (Input.GetKeyUp(fireButton))
                    {
                        // Debug.Log("Normal");

                        animator.Play("BowRelease");
                        normalArrowObjWhileHolding.SetActive(false);
                        GameObject arrow = Instantiate(normalArrowObject, spawn.position, Quaternion.identity);
                        arrow.transform.forward = direction.normalized;
                        arrow.GetComponent<Rigidbody>().AddForce(direction.normalized * _charge, ForceMode.Impulse);
                        _charge = 0;
                        // Debug.Log(arrow);

                        Destroy(arrow, 2f);
                    }

                    break;
                }

        }
    }
    public void CheckQuantity()
    {
        if (GameManager.instance.IceQuantity <= 0 && GameManager.instance.FireQuantity <= 0)
        {
            currentArrowType = ArrowType.Normal;
        }
        if (GameManager.instance.IceQuantity <= 0 && GameManager.instance.FireQuantity > 0)
        {
            currentArrowType = ArrowType.Fire;
        }
        if (GameManager.instance.IceQuantity > 0 && GameManager.instance.FireQuantity <= 0)
        {
            currentArrowType = ArrowType.Ice;
        }
    }

   
}
