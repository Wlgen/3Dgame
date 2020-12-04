using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 restartingVelocity;
    public Vector3 restartingPositon;
    public int restartingCamera = 0;
    public GameObject LevelCamera;
    LevelCamera lvlCam;
    float _speedBall;
    Rigidbody _rigidBody;
    public Vector3 _velocity;
    bool inCollision;
    ParticleSystem _particles;

    public GameObject[] _wheels;

    void Start()
    {
        lvlCam = LevelCamera.GetComponent<LevelCamera>();
        inCollision = false;
        _speedBall = 10f;
        _rigidBody = GetComponent<Rigidbody>();
        _velocity = new Vector3(1f, 1f, 0f).normalized * _speedBall;
        _rigidBody.velocity = _velocity;
        _particles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!inCollision && Input.GetKeyDown(KeyCode.Space))
        {
            _velocity = new Vector3(_velocity.x, -_velocity.y, _velocity.z);
            _rigidBody.velocity = _velocity;
            _particles.Play();
            Invoke("StopParticles", 0.1f);
        }
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = _velocity.normalized * _speedBall;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            _rigidBody.transform.position = restartingPositon;
            _velocity = restartingVelocity.normalized;
            lvlCam.setActualCamera(restartingCamera);
        }
        inCollision = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        inCollision = false;
    }

    public void setRestartingVelocity(Vector3 velocity) { _velocity = velocity; }
    private void StopParticles()
    {
        _particles.Stop();
    }

    public void changeDirectionWheel() {
        Debug.Log("Holii");
        for(int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].GetComponent<WheelSpike>().changeDirection();
        }
    }
}
