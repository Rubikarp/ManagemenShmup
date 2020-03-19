using UnityEngine;
using System.Collections;

public class Scr_LifeSystem_Ennemis : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer _SprRender = null;
    [SerializeField] private GameObject _Avatar = null;
    [SerializeField] private Data_GameData _data = null;

    [Header("Vie")]
    public int _health = 5;
    public int _scoreForKill = 100;
    public int _scoreForDamage = 20;

    [Header("Invulnérabilité")]
    public float _invulnerabilityCooldown = 0.3f;
    public bool _haveTakeDamage = false;

    private void Update()
    {
        IsLiving(_health);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Scr_LifeSystem_Player lifesyst = collision.gameObject.GetComponent<Scr_LifeSystem_Player>();

            if (!lifesyst._haveTakeDamage)
            {
                lifesyst.TakingDamange(10);
            }

            _data._score += _scoreForKill;

            Destroy(gameObject);
        }
    }

    private void IsLiving(int health)
    {
        if (health <= 0)
        {
            _data._score += _scoreForKill;

            Destroy(_Avatar);
        }
    }

    public void TakingDamange(int damage)
    {
        if (!_haveTakeDamage)
        {
            _health -= damage;
            _data._score += _scoreForDamage;

            _haveTakeDamage = true;

            StartCoroutine(DammageInvulnerability(_invulnerabilityCooldown));
        }
    }

    private IEnumerator DammageInvulnerability(float Cooldown)
    {
        if (_haveTakeDamage)
        {
            _SprRender.color = Color.red;

            yield return new WaitForSeconds(Cooldown);

            _SprRender.color = Color.white;
            _haveTakeDamage = false;
        }
    }
}