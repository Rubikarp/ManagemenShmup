using UnityEngine;

public class Scr_Enemy3_BulletScript : MonoBehaviour
{
    [Header("movement")]
    public Vector3 _direction = Vector3.down;
    public float _bulletSpeed = 5f;

    [Header("Dégât")]
    public int _bulletDamage = 1;

    void Update()
    {
        transform.position += _direction * _bulletSpeed * Time.deltaTime;
        _direction = _direction.normalized;
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Scr_LifeSystem_Player lifesyst = collision.gameObject.GetComponent<Scr_LifeSystem_Player>();

            if (!lifesyst._haveTakeDamage)
            {
                lifesyst.TakingDamange(_bulletDamage);
            }

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(this.transform.position, _direction.normalized, Color.yellow);
    }
}
