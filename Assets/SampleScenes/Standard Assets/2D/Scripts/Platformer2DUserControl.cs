using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        
        private bool m_Jump;
        private bool m_Action;
        public Rigidbody2D rb2D;
        private float floatHeight = 10f;
        private float liftForce = 5f;
        private float damping = 0;


        void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            rb2D = GetComponent<Rigidbody2D>();
            
        }


        private void Update()
        {

          

            if (Input.GetKeyDown("return")){
                Debug.Log("space hit!");

                int layerMask = 1 << 10;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up,10,layerMask);

                Vector3 up = transform.TransformDirection(Vector3.up) * 10;
                Debug.DrawRay(transform.position, up, Color.green);

                if (hit.collider != null) {
                    Debug.Log("HIT");
                    float distance = Mathf.Abs(hit.point.y - transform.position.y);
                    float heightError = floatHeight - distance;
                    float force = liftForce * heightError - rb2D.velocity.y * damping;
                    hit.rigidbody.AddForce(Vector3.up * force);
        }



            }
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                //m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(1, false, m_Jump);
            m_Jump = false;
        }
    }
}
