using System;
using System.Security.Cryptography;
using Game.Scripts.Managers;
using Game.Scripts.MiniGame;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitRigidBody : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private Rigidbody rigidBody => _rigidbody ??= GetComponent<Rigidbody>(); // =>_rigidbody ?? (_rigidbody=GetComponent<Rigidbody>()); 

    private void OnEnable()
    {
         //rigidBody = _rigidbody ??= GetComponent<Rigidbody>();
        PlinkoMiniGame.ChangeUnitRigidBodyObserver += ChangeRigidBodyAsActive;
        GameStateController.ImpulseMiniGameStartObserver += AddImpulseForce;
    }

    private void OnDestroy()
    {
        PlinkoMiniGame.ChangeUnitRigidBodyObserver -= ChangeRigidBodyAsActive;
        GameStateController.ImpulseMiniGameStartObserver -= AddImpulseForce;
    }


    private void ChangeRigidBodyAsActive()
    {
        rigidBody.isKinematic = false;
        rigidBody.useGravity = true;
        rigidBody.angularDrag = 0.01f;
        /*if (GetComponent<Rigidbody>() == null)
        {
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.drag = 0.05F;
            rigidBody.angularDrag = 0f;
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;
            rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }
        else
        {
            var rigidBody = _rigidbody;
            rigidBody.drag = 0.05F;
            rigidBody.angularDrag = 0f;
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;
            rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }*/
        
    }


    private void AddImpulseForce()
    {
        ChangeRigidBodyAsActive();
        transform.rotation = Quaternion.Euler(Random.Range(-90, 90), Random.Range(0, -90), 0f);
        //transform.eulerAngles = new Vector3(Random.Range(-90, 90), Random.Range(0, -90));
        //rigidBody.AddForce(Vector3.forward * Random.Range(5, 10), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChangeUnitParent"))
        {
            transform.SetParent(null);
        }
    }
}