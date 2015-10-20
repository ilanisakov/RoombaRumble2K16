using UnityEngine;

/// <summary>
/// Creating instance of particles from code with no effort
/// </summary>
public class effectsHelper : MonoBehaviour
{

    public static effectsHelper Instance;

    public ParticleSystem fireEffect;
    public ParticleSystem boostEffect;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    /// <summary>
    /// Create an explosion at the given location
    /// </summary>
    /// <param name="position"></param>
    public void Explosion(Vector3 position, Quaternion rotation)
    {
       
        instantiate(fireEffect, position, rotation);
    }

    public void Boost(Vector3 position, Quaternion rotation)
    {
        instantiate(boostEffect, position,rotation);
    }

    /// <summary>
    /// Instantiate a Particle system from prefab
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position, Quaternion rotation)
    {
        position.z += 1;

        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          rotation
        ) as ParticleSystem;

        
        // Make sure it will be destroyed
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        
        return newParticleSystem;
    }
}
