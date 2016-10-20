using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SoundPlayer : MonoBehaviour
{
    public List<AudioSource> audio2d;
    public List<AudioSource> audio3d;

    private float timeSinceLastSound = 0.0f;
    private float soundBuffer = 0.07f;

    void Awake()
    {
       foreach(Transform child in GameObject.Find("2DAudio").transform)
        {
            audio2d.Add(child.gameObject.GetComponent<AudioSource>());
        }
        foreach (Transform child in GameObject.Find("3DAudio").transform)
        {
            audio3d.Add(child.gameObject.GetComponent<AudioSource>());
        }
    }

    void Update() { timeSinceLastSound += Time.deltaTime; }

    public void ShotHitHandler(object sender, EventArgs e)
    {
        BulletBehaviour bullet = sender as BulletBehaviour;
        play3DSound(bullet.HitSFX, bullet.transform.position);
    }

    public void ShotFiredHandler(object sender, EventArgs e)
    {
        play2DSound((sender as Weapon).ShotSFX);
    }

    private void play2DSound(AudioClip sound)
    {
        if (sound == null || timeSinceLastSound < soundBuffer) return;
        foreach (AudioSource source in audio2d)
        {
            if (!source.isPlaying)
            {
                source.PlayOneShot(sound);
                timeSinceLastSound = 0.0f;
                break;
            }
        }
    }

    private void play3DSound(AudioClip sound, Vector3 position)
    {
        if (sound == null || timeSinceLastSound < soundBuffer) return;
        foreach (AudioSource source in audio3d)
        {
            if (!source.isPlaying)
            {
                source.transform.position = position;
                source.PlayOneShot(sound);
                timeSinceLastSound = 0.0f;
                break;
            }
        }
    }
}
