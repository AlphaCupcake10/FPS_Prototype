using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float Range = 10,Damage = 100,HitForce = 1000f;
    public GameObject BulletImpact,BloodImpact;
    public LayerMask Mask;
    public float ShootDelay = .1f;
    float ShootTimer = 0;
    public ParticleSystem MuzzleFlash;
    void Update()
    {
        ShootTimer += Time.deltaTime;
        if(Input.GetButton("Fire1") && ShootTimer > ShootDelay)
        {
            Shoot();
            ShootTimer = 0;
        }
    }
    void Shoot()
    {
        MuzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,Range,Mask))
        {
            Debug.Log(hit.collider.name);
            GameObject impact = Instantiate(BulletImpact,hit.point + hit.normal * .005f,Quaternion.LookRotation(hit.normal));
            EnemyPart enemyPart = hit.collider.GetComponent<EnemyPart>();
            if(enemyPart != null)
            {
                Transform blood = Instantiate(BloodImpact,hit.point + hit.normal * .005f,Quaternion.LookRotation(hit.normal)).transform;
                blood.SetParent(hit.collider.transform);
                Destroy(impact);
                enemyPart.TakeDamage(Damage,-hit.normal * HitForce);
            }
        }
    }

}
