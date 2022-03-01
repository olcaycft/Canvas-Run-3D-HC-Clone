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
        /*var rot = transform.rotation;
        rot.y = Random.Range(0, 180);
        transform.rotation = rot;*/
        rigidBody.isKinematic = false;
        rigidBody.useGravity = true;
        rigidBody.angularDrag = 0.01f;
    }

    private void AddImpulseForce()
    {
        ChangeRigidBody();
        transform.rotation = Quaternion.Euler(Random.Range(-90, 90), Random.Range(0, -90),0f);
        //transform.eulerAngles = new Vector3(Random.Range(-90, 90), Random.Range(0, -90));
        rigidBody.AddForce (Vector3.forward*Random.Range(5,10),ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChangeUnitParent"))
        {
            transform.SetParent(null);
        }
    }
}
