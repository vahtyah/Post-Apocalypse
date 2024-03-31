using System;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    private float length;

    public void Setup(AudioClip clip, Vector3 position)
    {
        transform.position = position;
        source.clip = clip;
        length = clip.length;
        source.Play();
        Invoke(nameof(Destroy), length);
    }
    
    private void Destroy()
    {
        SFXSourcePool.Instance.Return(AudioType.SFX ,this);
    }
}
