using System;
using Game.Scripts.MiniGame;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitRigidBody : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Rigidbody rigidBody =>_rigidbody ??= GetComponent<Rigidbody>();
    
    
    private void OnEnable()
    {
        //Finish.FinishGameObserver += SetRigidBodyAndImpulse;
        PlinkoMiniGame.ChangeUnitRigidBodyObserver += ChangeRigidBody;
        MiniGameController.ImpulseMiniGameObserver += AddImpulseForce;
    }

    private void OnDestroy()
    {
        //Finish.FinishGameObserver -= SetRigidBodyAndImpulse;
        PlinkoMiniGame.ChangeUnitRigidBodyObserver -= ChangeRigidBody;
        MiniGameController.ImpulseMiniGameObserver -= AddImpulseForce;
    }


    private void ChangeRigidBody()
    {
        var rot = transform.rotation;
        rot.y = Random.Range(0, 180);
        transform.rotation = rot;
        rigidBody.isKinematic = false;
        rigidBody.useGravity = true;
        rigidBody.angularDrag = 0.05f;
    }

    private void AddImpulseForce()
    {
        ChangeRigidBody();
        rigidBody.AddForce (Vector3.forward*Random.Range(10,30),ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChangeUnitParent"))
        {
            transform.SetParent(null);
        }
    }
}
