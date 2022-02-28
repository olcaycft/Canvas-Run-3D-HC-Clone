using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitRigidBody : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Rigidbody rigidBody =>_rigidbody ??= GetComponent<Rigidbody>();


    private float maxTorque = 1f;
    
    private void OnEnable()
    {
        Finish.FinishGameObserver += SetRigidBodyAndImpulse;
    }

    private void OnDestroy()
    {
        Finish.FinishGameObserver -= SetRigidBodyAndImpulse;
    }


    private void SetRigidBodyAndImpulse()
    {
        var rot = transform.rotation;
        rot.y = Random.Range(0, 180);
        transform.rotation = rot;
        rigidBody.isKinematic = false;
        rigidBody.useGravity = true;
        rigidBody.angularDrag = 0.05f;
        rigidBody.AddForce (Vector3.forward*Random.Range(10,30),ForceMode.Impulse);
        //rigidBody.AddRelativeForce(Vector3.forward*Random.Range(20,30),ForceMode.Impulse);
        //rigidBody.AddRelativeTorque(Vector3.forward,ForceMode.VelocityChange);
        
    }
}
