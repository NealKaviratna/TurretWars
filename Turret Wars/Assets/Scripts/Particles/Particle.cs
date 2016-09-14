using UnityEngine;
using System.Collections;
using System;

public class Particle : Poolable {

    private new ParticleSystem particleSystem;

    public override bool InUse
    {
        get { return this.particleSystem.isPlaying; }
    }

    public override uint ObjectId
    {
        get { return 0; }
    }

    public Poolable Create(Transform transform)
    {
        return Create(transform: transform);
    }

    public override Poolable Create(Player creator, uint objectId, Vector3 transform)
    {
        throw new NotImplementedException();
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }

    public override void Recall()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Awake () {
        this.particleSystem = this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
