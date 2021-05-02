using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Gravity
{
    public class Gravity : MonoBehaviour
    {
        [SerializeField] private float _gravityMultiplier = 1.0f;
        private float _acceleration = 9.8f;
        private Rigidbody _rigidBody;
        private bool _isGravityActive = true;

        // Start is called before the first frame update
        void Start()
        {
            _rigidBody = gameObject.GetComponent<Rigidbody>();

            if (_rigidBody == null)

            {
                Debug.Log("No RigidBody Attached to GameObject");
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // Apply gravity if object isn't on ground and gravity is enabled
            if (_isGravityActive)
            {
                float accel = (_acceleration * Time.fixedDeltaTime * _gravityMultiplier) * -1;
                _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, _rigidBody.velocity.y + accel, _rigidBody.velocity.z);
            }
        }
    }
}