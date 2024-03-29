﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scr_LifeSystem_Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _SprRender = null;
    [SerializeField] private GameObject _Avatar = null;

    public int _health = 5;
    public bool _haveTakeDamage = false;
    public float _invulnerabilityCooldown = 0.3f;

    private void Update()
    {
        IsLiving(_health);
    }

    private void IsLiving(int health)
    {
        if (health <= 0)
        {
            Destroy(_Avatar);
        }
    }
    
    public void TakingDamange(int damage)
    {
        if (!_haveTakeDamage)
        {
            _health -= damage;
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