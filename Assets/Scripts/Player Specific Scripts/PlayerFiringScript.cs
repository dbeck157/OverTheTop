using UnityEngine;
using System.Collections;

public class PlayerFiringScript : MonoBehaviour {

    public Ray shootRay;
    public RaycastHit shootHit;
    public int shootableMask;
    public ParticleSystem gunParticles;
    public LineRenderer gunLine;
    public AudioSource gunAudio;
    public Light gunLight;

    public bool okToShoot = true;
    public float effectsDisplayTime = 0.2f;
    public float timer;
    public int damagePerShot = 50;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    void Update ()
    {
        timer += Time.deltaTime;

        if (Input.GetAxis("Fire1") > 0.1f && timer >= timeBetweenBullets || Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
	}

    public void Shoot()
    {
        timer = 0f;

        gunAudio.pitch = Random.Range(1f, 1.3f);
        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        gunLine.SetPosition(1, shootHit.point);
        gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {

            if (shootHit.collider.transform.tag == "Enemy")
            {
                Enemy enemyHealth = shootHit.collider.GetComponent<Enemy>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot);
                }
            }

            gunLine.SetPosition(1, shootHit.point);

        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }
}