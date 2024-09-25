using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomGun : MonoBehaviour {
    [SerializeField] private float radius = 5.0f;
    [SerializeField] private float force = 3000.0f;
    [SerializeField] private GameObject effectsPrefab;
    [SerializeField] private float effectDisplayTime = 3.0f;	// The explosion prefab
	public Camera cam;              // Reference to the Player camera

	void Update ()
	{
		// If the player presses fire
		if (Input.GetButtonDown("Fire1"))
			Shoot();
	}

	void Shoot ()
	{
		RaycastHit _hitInfo;
		// If we hit something
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hitInfo))
		{
			if (effectsPrefab != null) {
                GameObject effect = Instantiate(effectsPrefab, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
                Destroy(effect, effectDisplayTime);
            }

            Collider[] colliders = Physics.OverlapSphere(_hitInfo.point, radius);

            foreach (Collider collider in colliders) {
                Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

                if (rigidbody != null) {
                    rigidbody.AddExplosionForce(force, _hitInfo.point, radius);
                }
            }
		}
	}
}