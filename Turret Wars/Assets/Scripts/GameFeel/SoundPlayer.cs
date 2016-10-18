using UnityEngine;
using System.Collections;
using System;

public class SoundPlayer : MonoBehaviour
{

    public AudioSource[] audio2d;

    public AudioSource[] audio3d;

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
        if (sound == null) return;
        foreach (AudioSource source in audio2d)
        {
            if (!source.isPlaying)
            {
                source.PlayOneShot(sound);
                break;
            }
        }
    }

    private void play3DSound(AudioClip sound, Vector3 position)
    {
        if (sound == null) return;
        foreach (AudioSource source in audio3d)
        {
            if (!source.isPlaying)
            {
                source.transform.position = position;
                source.PlayOneShot(sound);
                break;
            }
        }
    }
}
