using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    float _charge;

    public float chargeMax;
    public float chargeRate;

    public KeyCode fireButton;

    public Transform spawn;
    public GameObject arrowObject;
    public GameObject arrowObjWhileHolding;

    public GameObject bompArrowObject;
    public GameObject bompArrowObjWhileHolding;

    public Transform orientRef;
    public Transform arrowLookAtPos25;
    public Transform arrowLookAtPos50;
    public Transform arrowLookAtPos75;

    [HideInInspector]
    public PauseMenu ps;

    public bool isTimeStopped;
    public bool isUsingBomp;

    public Animator animator;
    public Camera fpsCam;
    

    void Start()
    {

        ps = FindObjectOfType<PauseMenu>();

        Animator animator = gameObject.GetComponent<Animator>();

        isUsingBomp = false;

    }

    void Update()
    {
        if (isTimeStopped)
        {
            return;
        }

        if (GameManager.instance.money < 100)
        {
            isUsingBomp = false;
        } 

        if (Input.GetKeyDown(KeyCode.Mouse1) && isUsingBomp == true)
        {
            isUsingBomp = false;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && isUsingBomp == false && GameManager.instance.money >= 100)
        {
            isUsingBomp = true;
        }

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        RaycastHit hit;

        Vector3 targetPoint;

        if(Physics.Raycast(ray,out hit)){
            targetPoint = hit.point;

        }
        else{
            targetPoint = ray.GetPoint(75);
        }

        Vector3 direction = targetPoint - spawn.position;

        switch (isUsingBomp)
        {
            case true:

                if(GameManager.instance.money >= 100)
                {
                    //BompArrow();

                    

                    if (Input.GetKey(fireButton) && _charge < chargeMax)
                    {

                        animator.Play("BowHolding");

                        _charge += Time.deltaTime * chargeRate;

                        bompArrowObjWhileHolding.SetActive(true);
                    }

                    if(Input.GetKeyUp(fireButton))
                    {

                        animator.Play("BowRelease");
                        bompArrowObjWhileHolding.SetActive(false);
                        GameObject arrow = Instantiate(bompArrowObject, spawn.position, Quaternion.identity);
                        arrow.transform.forward = direction.normalized;
                        arrow.GetComponent<Rigidbody>().AddForce(direction.normalized * _charge, ForceMode.Impulse);
                        _charge = 0;

                    }
                }
                break;

            case false:

                //DefaultArrow();

                if (Input.GetKey(fireButton) && _charge < chargeMax)
                {

                    animator.Play("BowHolding");

                    _charge += Time.deltaTime * chargeRate;

                    arrowObjWhileHolding.SetActive(true);
                }

                if(Input.GetKeyUp(fireButton))
                {

                    animator.Play("BowRelease");
                    arrowObjWhileHolding.SetActive(false);
                    GameObject arrow = Instantiate(arrowObject, spawn.position, Quaternion.identity);
                    arrow.transform.forward = direction.normalized;
                    arrow.GetComponent<Rigidbody>().AddForce(direction.normalized * _charge, ForceMode.Impulse);
                    _charge = 0;

                }

                

                
                

                break;
        }          
    }
  
    // public void DefaultArrow()
    // {
    //     if (Input.GetKey(fireButton) && _charge < chargeMax)
    //     {
    //         animator.Play("BowHolding");
    //         _charge += Time.deltaTime * chargeRate;
    //         arrowObjWhileHolding.SetActive(true);

    //     }

    //     if (Input.GetKeyUp(fireButton))
    //     {
    //         animator.Play("BowRelease");

    //         arrowObjWhileHolding.SetActive(false);
    //         GameObject arrow = Instantiate(arrowObject, spawn.position, Quaternion.identity);
    //         Debug.Log(_charge.ToString());

    //         if (_charge <= 20)
    //         {

    //             arrow.transform.LookAt(arrowLookAtPos25);
    //             arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);
    //             _charge = 0;
    //             // Destroy(arrow,2f);

    //             Debug.Log("20%");



    //         }
    //         else if (_charge > 20 && _charge <= 40)
    //         {

    //             arrow.transform.LookAt(arrowLookAtPos50);
    //             arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);

    //             _charge = 0;
    //             // Destroy(arrow,2f);

    //             Debug.Log("50%");
    //         }
    //         else if (_charge > 40 && _charge <= 80)
    //         {
    //             arrow.transform.LookAt(arrowLookAtPos75);
    //             arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);

    //             _charge = 0;
    //             // Destroy(arrow,2f);

    //         }
    //         else if (_charge > 80)
    //         {
    //             arrow.transform.LookAt(orientRef);
    //             arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);
    //             //arrow.transform.Rotate(-_charge * 15 * Time.deltaTime, 0f, 0f, Space.Self);
    //             _charge = 0;
    //             // Destroy(arrow,2f);

    //         }
    //     }
    // }

    // public void BompArrow()
    // {
    //     if (Input.GetKey(fireButton) && _charge < chargeMax)
    //     {
    //         animator.Play("BowHolding");
    //         _charge += Time.deltaTime * chargeRate;
    //         bompArrowObjWhileHolding.SetActive(true);

    //     }

    //     if (Input.GetKeyUp(fireButton))
    //     {
    //         PlayerStats.Money -= 100;

    //         animator.Play("BowRelease");

    //         bompArrowObjWhileHolding.SetActive(false);


    //         GameObject arrow = Instantiate(bompArrowObject, spawn.position, Quaternion.identity);
    //         Debug.Log(_charge.ToString());

    //         if (_charge <= 20)
    //         {

    //             arrow.transform.LookAt(arrowLookAtPos25);
    //             arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);
    //             _charge = 0;
    //             Destroy(arrow,2f);

    //             Debug.Log("20%");



    //         }
    //         else if (_charge > 20 && _charge <= 40)
    //         {

    //             arrow.transform.LookAt(arrowLookAtPos50);
    //             arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);

    //             _charge = 0;
    //             Destroy(arrow,2f);

    //             Debug.Log("50%");
    //         }
    //         else if (_charge > 40 && _charge <= 80)
    //         {
    //             arrow.transform.LookAt(arrowLookAtPos75);
    //             arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);

    //             _charge = 0;
    //             Destroy(arrow,2f);

    //         }
    //         else if (_charge > 80)
    //         {
    //             arrow.transform.LookAt(orientRef);
    //             arrow.GetComponent<Rigidbody>().AddForce(spawn.forward * _charge, ForceMode.Impulse);
    //             //arrow.transform.Rotate(-_charge * 15 * Time.deltaTime, 0f, 0f, Space.Self);
    //             _charge = 0;
    //             Destroy(arrow,2f);

    //         }
    //     }
    // }
}
