using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    public GameObject followtarget;

    enum EPetState
    {
        STATE_IDLE,
        STATE_HUNT,
        STATE_POP,
    };

    EPetState _eCurrentState = EPetState.STATE_IDLE;
    EPetState _eNextState = EPetState.STATE_IDLE;

    public float kfHuntDistance = 7.0F;
    public float kfHuntForce = 3.0F;
    public float kfBuffer = 2.0F;
    public float kfPopDistance = 3.0F;
    public float kfPopDuration = 1.0F;
    public float kfPopForce = 3.0F;
    public float kfSpawnDistance = 16.0F;
    public float kfRespawnDistance = 3.0F;

    public AudioClip fxHuntSound;
    public AudioClip fxRoosterSound;

    public bool bNoise = false;


    float _fPopTime = 0.0F;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		
	}

    Vector3 _DirectionToTarget()
    {
        return (new Vector3(followtarget.transform.position.x, 0, followtarget.transform.position.z) -
                new Vector3(transform.position.x, 0, transform.position.z));
    }

    float _DistanceToTarget() 
    {
        return _DirectionToTarget().magnitude;
    }


    void _SetState(EPetState nextState)
    {
        _eNextState = nextState;
    }

    // Update is called once per frame
    void Update()
    {

        float fFollowDistance = _DistanceToTarget();

        if (_eNextState != _eCurrentState)
        {
            AudioSource audio = GetComponent<AudioSource>();
            if (bNoise && (audio != null))
            {
                switch (_eNextState)
                {

                    case EPetState.STATE_HUNT:
                        {
                            audio.clip = fxHuntSound;
                            audio.loop = true;
                            audio.Play();
                        }
                        break;
                    case EPetState.STATE_IDLE:
                        {
                            audio.clip = null;
                            audio.loop = false;
                            audio.Stop();
                        }
                        break;
                    case EPetState.STATE_POP:
                        {
                            audio.clip = fxRoosterSound;
                            audio.loop = false;
                        }
                        break;
                }
            }
            _eCurrentState = _eNextState;
        }


        if (fFollowDistance > kfSpawnDistance)
        {
            //respawn randomly closer to the player
            Vector3 v3SpawnPt = Quaternion.AngleAxis(Random.Range(-180.0F, 180.0F), new Vector3(0, 1, 0)) * new Vector3(0, 0, kfRespawnDistance);
            Debug.Log("RESPAWN! " + v3SpawnPt.ToString());
            transform.position = followtarget.transform.position + v3SpawnPt;
        }

        switch (_eCurrentState)
        {
            case EPetState.STATE_HUNT:

    

                //GetComponent<Rigidbody>().useGravity = true;
                //GetComponent<SphereCollider>().enabled = true;


                if (fFollowDistance < kfHuntDistance)
                {
                    _SetState(EPetState.STATE_IDLE);
                }
                else
                {
                    //push toward the object
                    Debug.Log("PUSH "+fFollowDistance);
                    GetComponent<Rigidbody>().AddForce(_DirectionToTarget().normalized * kfHuntForce);
                }


                break;
            case EPetState.STATE_IDLE:
                //GetComponent<Rigidbody>().useGravity = false;
                //GetComponent<SphereCollider>().enabled = false;
                if (fFollowDistance > kfHuntDistance + kfBuffer)
                {
                    _SetState(EPetState.STATE_HUNT);
                }
                else if (fFollowDistance < kfPopDistance)
                {
                    _SetState(EPetState.STATE_POP);
                }
                else
                {
                    transform.rotation = Quaternion.identity;
                    //face toward the player
                    transform.LookAt(followtarget.transform);
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                }
                break;
            case EPetState.STATE_POP:
                if (fFollowDistance >= kfPopDistance+kfBuffer)
                {
                    _fPopTime = 0.0F;
                    _SetState(EPetState.STATE_IDLE);
                }

                _fPopTime += Time.deltaTime;
                if (_fPopTime > kfPopDuration)
                {
                    _fPopTime = 0.0F;
                    Debug.Log("POP! " + fFollowDistance);
                    AudioSource audio = GetComponent<AudioSource>();
                    if (bNoise && (audio != null))
                    {
                        audio.Play();
                    }
                    GetComponent<Rigidbody>().AddForce(new Vector3(0,1,0) * kfPopForce, ForceMode.Impulse);
                }
                break;


        }
    }
}
