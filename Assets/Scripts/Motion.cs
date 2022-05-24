using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Motion : MonoBehaviour
    {
        public float speed;
        public float sprintModifier;
        

        public float jumpForce;
        public float jumpCooldown;
        public float airMultiplier;
        bool readyToJump;

        public Camera normalCam;
        public Transform groundDetector;
        public LayerMask ground;

        private Rigidbody rig;

        [Header("Keybinds")]
        public KeyCode jumpKey = KeyCode.Space;

        public float groundDistance = 0.4f;
        private float baseFOV = 60;
        private float sprintFOVModifier = 1.5f;
        bool isGrouded;


        private void Start()
        {
            isGrouded = true;
            baseFOV = normalCam.fieldOfView;
            Camera.main.enabled = false; //Turn off main camera
            rig = GetComponent<Rigidbody>(); //Get component RigiBody (for Moving Player)
        }

        private void Update()
        {
            //Input Axis
            float horiMove = Input.GetAxisRaw("Horizontal");
            float vertMove = Input.GetAxisRaw("Vertical");

            //Controls
            bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            bool jump = Input.GetKeyDown(KeyCode.Space);

            bool isGrouded = Physics.Raycast(groundDetector.position, Vector3.down,0.1f, ground);
            //isGrouded = Physics.CheckSphere(groundDetector.position, groundDistance, ground);
            bool isJumping = jump && isGrouded;
            bool isSprinting = sprint && vertMove > 0 && !isJumping  && isGrouded;//

            //Jumping
            if (isJumping)
            {
                rig.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //Input Axis
            float horiMove = Input.GetAxisRaw("Horizontal");  
            float vertMove = Input.GetAxisRaw("Vertical");

            //Controls
            bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            bool jump = Input.GetKeyDown(KeyCode.Space);


            //States
            bool isGrouded = Physics.Raycast(groundDetector.position, Vector3.down,0.1f, ground);
            //isGrouded = Physics.CheckSphere(groundDetector.position, groundDistance, ground);
            bool isJumping = jump && isGrouded;
            bool isSprinting = sprint && vertMove > 0 &&  isGrouded;//!isJumping &&

            

            //Movement
            Vector3 direction = new Vector3(horiMove, 0f, vertMove);
            direction.Normalize();

            float adjustedSpeed = speed; 
            if (isSprinting) 
                adjustedSpeed *= sprintModifier;

            Vector3 targetVelocity = transform.TransformDirection(direction) * adjustedSpeed * Time.deltaTime;
            targetVelocity.y = rig.velocity.y;
            rig.velocity = targetVelocity;

            //Field of view
            if (isSprinting) 
            {
                normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView,baseFOV * sprintFOVModifier,Time.deltaTime * 8f);
            }
            else
            {
                normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f);
            }
        }

        /*private void Jump()
        {
            rig.velocity = new Vector3(rig.velocity.x, 0f, rig.velocity.z);

            rig.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        private void ResetJump()
        {
            readyToJump = true;
        }*/
    }