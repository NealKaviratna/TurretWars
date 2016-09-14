using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Will exist on clients
public class ParticleFactory : MonoBehaviour
{

    #region Object Pool declarations
    private ObjectPool<Particle> FireParticlePool;
    #endregion

    public Poolable CreateParticle(ParticleType partType, Vector3 position)
    {
        // Debug.Log("Creating: " + creepNo);
        switch (partType)
        {
            case ParticleType.Fire:
                var part = FireParticlePool.Create(null, 0, position);
                return part;
            default:
                Debug.Log("Problem creating particle in factory.");
                return null;
        }
    }

    // Use this for initialization
    void Start()
    {
        var DummyGameObject = Instantiate(Resources.Load("dgo")) as GameObject;
        #region Object Pool instantiation
        FireParticlePool = new ObjectPool<Particle>(DummyGameObject);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
