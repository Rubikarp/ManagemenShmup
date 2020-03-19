using System.Collections;
using UnityEngine;

public class Scr_Enemy2_Behavior : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Rigidbody2D _rbg;
    [SerializeField] private Transform _player;

    [Header("Statistique")]
    [Range(0, 360)] public float _angleCorrection = 0f;
    public float _moveSpeed = 12f;
    public float _dashSpeed = 20f;
    public float _dashInitRange = 15f;
    public float _dashTimePrep = 0.3f;
    public float _dashDuration = 0.3f;
    public float _dashCooldown = 0.3f;

    [Header("Info")]
    [SerializeField] private Vector2 _playerDir;
    [SerializeField] private float _playerDist;
    [SerializeField] private bool _readyToDash = true;
    [SerializeField] private bool _isDashing = false;

    private void Start()
    {
        _rbg = this.gameObject.GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        _playerDir = _player.position - transform.position;
        _playerDist = Vector2.Distance(transform.position, _player.transform.position);

        if (_playerDist < _dashInitRange)
        {
            if (_readyToDash)
            {
                StartCoroutine(Dash(_dashSpeed, _dashTimePrep, _dashDuration, _dashCooldown));
            }
        }
        else
        {
            _rbg.position += Vector2.down * _moveSpeed * Time.deltaTime;
        }
    }

    private IEnumerator Dash(float dashSpeed, float dashTimePrep, float dashDuration, float dashCooldown)
    {
        Vector2 dashDirection = Vector2.zero;

        _readyToDash = false;
        _isDashing = true;

        while (0 < dashTimePrep) // boucle durant la durée du dash
        {
            dashTimePrep -= Time.deltaTime;
            dashDirection = _player.position - transform.position;

            FaceTarget(dashDirection, _angleCorrection);

            // Retour à la prochaine frame
            yield return new WaitForEndOfFrame();
        }

        while (0 < dashDuration) // boucle durant la durée du dash
        {
            dashDuration -= Time.deltaTime;

            _rbg.position += dashDirection.normalized * dashSpeed * Time.deltaTime;

            // Retour à la prochaine frame
            yield return new WaitForEndOfFrame();
        }

        _isDashing = false;

        yield return new WaitForSeconds(dashCooldown);

        _readyToDash = true;
    }

    private void FaceTarget(Vector2 targetDirection, float _angleCorrection)
    {
        //calcul l'angle pour faire face au joueur
        float rotZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg + _angleCorrection;
        //oriente l'object pour faire face au joueur
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(_rbg.position, _playerDir.normalized * _dashInitRange, Color.blue);
    }
}