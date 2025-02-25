using System;
using UnityEngine;

public class BulletRing : Tile
{
    [Header("Bullet Ring Settings")]
    [SerializeField] private GameObject m_bulletPrefb;
    [SerializeField] private int m_bulletAmount;
    [SerializeField] private float m_ringRadius;
    [SerializeField] private float m_radiusOffset;
    [SerializeField] private float m_radiusNoiseScale = 2f;
    [SerializeField] [Range(-90,90)] private float m_initRotAngleOffset;
    [SerializeField] private float m_rotAngleChangeRate = .1f;
    [SerializeField] private float m_bulletForce;
    [SerializeField] private float m_spawnRate = 0.2f;
    [SerializeField] private float m_spawnTrackerIncre = 0.1f;
    
    private bool m_firing = false;
    private float m_timer = 0;
    private float m_spawnTracker = 0;
    private float m_rotAngleTracker = 0;

    private void Update()
    {
        //if (!m_firing) return;
        m_timer++;
        if (m_timer >= m_spawnRate)
        {
            SpawnBullet();
            m_timer = 0;
        }
    }

    private void SpawnBullet()
    {
        m_spawnTracker += m_spawnTrackerIncre;
        m_rotAngleTracker += m_rotAngleChangeRate;
        
        float _ringRadius = m_ringRadius + (2 * Mathf.PerlinNoise1D(m_spawnTracker) - 1) * m_radiusNoiseScale;
        
        float _rotAngle = 360f / m_bulletAmount;
        float _initRotAngle = m_initRotAngleOffset + m_rotAngleTracker;

        for (int i = 0; i < m_bulletAmount; i++)
        {
            Vector3 _localSpawnPos = new Vector3(0, _ringRadius + m_radiusOffset*i, 0);
            _localSpawnPos = Quaternion.Euler(0, 0, _rotAngle * i + _initRotAngle) * _localSpawnPos;
            GameObject _bullet = Instantiate(m_bulletPrefb, transform);
            _bullet.transform.localPosition = _localSpawnPos;
            _bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.Normalize(_localSpawnPos)*m_bulletForce, ForceMode2D.Impulse);
        }
    }
}
