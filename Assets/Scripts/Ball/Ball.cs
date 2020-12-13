using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 restartingVelocity;
    public Vector3 restartingPositon;
    public int restartingCamera = 0;
    public GameObject LevelCamera;
    public GameObject trailCollider;
    bool isTailed;
    LevelCamera lvlCam;
    float _speedBall, time;
    Rigidbody _rigidBody;
    public Vector3 _velocity;
    bool inCollision;
    ParticleSystem _particles;
    bool collidingLeft, collidingRight, collidingUp, collidingDown, bounceOnTrailDoor, god, reduceSize;
    List<GameObject> trailColliders;

    public GameObject[] _wheels;

    void Start()
    {
        trailColliders = new List<GameObject>();
        lvlCam = LevelCamera.GetComponent<LevelCamera>();
        inCollision = false;
        _speedBall = 12f;
        _rigidBody = GetComponent<Rigidbody>();
        _velocity = new Vector3(1f, 1f, 0f).normalized * _speedBall;
        _rigidBody.velocity = _velocity;
        _particles = GetComponent<ParticleSystem>();
        reduceSize = god = isTailed = collidingLeft = collidingRight = collidingDown = collidingUp = false;
        bounceOnTrailDoor = true;
        time = 0f;
    }

    void Update()
    {
        if (reduceSize)
        {
            time += Time.deltaTime;
            if (transform.localScale.x > 0f && time >= 0.05f)
            {
                float reduce = 1f / 22f;
                transform.localScale -= new Vector3(reduce, reduce, reduce);
                if (transform.localScale.x < 0f) transform.localScale = new Vector3(0f, 0f, 0f);
                time = 0f;
            }
            else if (transform.localScale.x <= 0f)
            {
                Invoke("resetPosition", 0.4f);
            }
        }
        else
        {
            if (!inCollision && Input.GetKeyDown(KeyCode.Space))
            {
                _velocity = new Vector3(_velocity.x, -_velocity.y, _velocity.z);
                _rigidBody.velocity = _velocity;
                if (!isTailed)
                    _particles.Play();
                GameSounds.Instance.playBallChangeDirection();
                Invoke("StopParticles", 0.1f);
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (gameObject.layer == 0)
                {
                    god = true;
                    gameObject.layer = 10;
                    for (int i = 0; i < gameObject.transform.childCount; ++i)
                    {
                        gameObject.transform.GetChild(i).gameObject.layer = 10;
                    }
                }
                else
                {
                    god = false;
                    gameObject.layer = 0;
                    for (int i = 0; i < gameObject.transform.childCount; ++i)
                    {
                        gameObject.transform.GetChild(i).gameObject.layer = 0;
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isTailed)
        {
            instantiateTrailCollider();
        }
        if (collidingRight)
        {
            _velocity = new Vector3(-System.Math.Abs(_velocity.x), _velocity.y, _velocity.z).normalized;
        } else if (collidingLeft)
        {
            _velocity = new Vector3(System.Math.Abs(_velocity.x), _velocity.y, _velocity.z).normalized;
        } else if (collidingUp)
        {
            _velocity = new Vector3(_velocity.x, -System.Math.Abs(_velocity.y), _velocity.z).normalized;
        } else if (collidingDown)
        {
            _velocity = new Vector3(_velocity.x, System.Math.Abs(_velocity.y), _velocity.z).normalized;
        }
        _rigidBody.velocity = _velocity.normalized * _speedBall;
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Death") && !god)
        {
            deathBall();
            inCollision = false;
        }
        else
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
        for(int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].GetComponent<WheelSpike>().changeDirection();
        }
    }

    public void setCollisionLeft(bool a)
    {
        collidingLeft = a;
    }

    public void setCollisionRight(bool a)
    {
        collidingRight = a;
    }

    public void setCollisionUp(bool a)
    {
        collidingUp = a;
    }

    public void setCollisionDown(bool a)
    {
        collidingDown = a;
    }

    void instantiateTrailCollider()
    {
        Vector3 newPosition = transform.position - _velocity.normalized * 1.1f;
        trailColliders.Add(Instantiate(trailCollider, newPosition, Quaternion.identity));
    }
    public void addTail()
    {
        isTailed = true;
        GetComponent<TrailRenderer>().enabled = true;
    }
    public void destroyTrail()
    {
        isTailed = false;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().Clear();
        for (int i = 0; i < trailColliders.Count; ++i)
        {
            Destroy(trailColliders[i]);
        }
        while (trailColliders.Count > 0)
        {
            trailColliders.RemoveAt(0);
        }
    }

    public bool itIsTailed()
    {
        return isTailed;
    }

    public bool isGod()
    {
        return god;
    }

    private void deathBall()
    {
        destroyTrail();
        GameSounds.Instance.playDeathSound();
        _velocity = new Vector3(0f, 0f, 0f);

        reduceSize = true; 
    }
    private void resetPosition()
    {
        reduceSize = false;
        _rigidBody.transform.localScale = new Vector3(1f, 1f, 1f);
        _rigidBody.transform.position = restartingPositon;
        _velocity = restartingVelocity.normalized;
        lvlCam.setActualCamera(restartingCamera);
    }
}
