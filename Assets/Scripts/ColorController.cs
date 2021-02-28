using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public Transform Cube;
    public GameObject Artifact;

    //Color BaseColor;
    [SerializeField]
    Vector3 Direction;
    Vector3 StartPosition;
    [SerializeField]
    float smooth;
    public float positionError;
    public float Delay;
    public bool ForceActive;
    public bool UseDefault = true;
    bool Repeat;
    bool IsRunning;

    Color ObjectColor
    {
        get
        {
            return gameObject.GetComponent<MeshRenderer>().material.color;
        }
        set
        {
            gameObject.GetComponent<MeshRenderer>().material.color = value;
        }
    }

    Light PuzzleGlow
    {
        get
        {
            return gameObject.GetComponentInChildren<Light>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Artifact = GameObject.FindGameObjectWithTag("Artifact"); 
        Direction = transform.position + Direction;
        StartPosition = transform.position;
        //ObjectColor = BaseColor;
    }

    // Update is called once per frame
    void Update()
    {
        Active();
    }


    void Active()
    {
        if(UseDefault)
        {
            // If The Artifact is the same Color as us. Active
            if (Artifact.GetComponent<MeshRenderer>().material.color == gameObject.GetComponent<MeshRenderer>().material.color || ForceActive)
            {
                if (IsRunning == false)
                {
                    if (Vector3.Distance(transform.position, StartPosition) < positionError)
                    {
                        StartCoroutine(MoveToTarget(Direction));
                    }
                }
            }
            else if (Vector3.Distance(transform.position, Direction) < positionError)
            {
                if (IsRunning == false)
                {
                    StartCoroutine(MoveToTarget(StartPosition));
                }
            }
        }
        else
        {
            // If The Artifact is the same Color as us. Active
            if (Artifact.GetComponent<MeshRenderer>().material.color == gameObject.GetComponent<MeshRenderer>().material.color || ForceActive)
            {
                if(IsRunning == false)
                {
                    if (Vector3.Distance(transform.position, StartPosition) < positionError)
                    {
                        StartCoroutine(MoveInDirection(Direction, Delay));
                    }
                    else if ( Vector3.Distance(transform.position, Direction) < positionError)
                    {
                        StartCoroutine(MoveInDirection(StartPosition, Delay));
                    }
                }
            }
        }
    }

    IEnumerator MoveToTarget(Vector3 target)
    {
        IsRunning = true;
        while (Vector3.Distance(transform.position, target) > positionError)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * smooth);
            yield return null; 
        }
        IsRunning = false;
    }

    IEnumerator MoveInDirection(Vector3 target, float time)
    {
        
        IsRunning = true;
        while (Vector3.Distance(transform.position, target) > positionError)
        {
            if(Artifact.GetComponent<MeshRenderer>().material.color != gameObject.GetComponent<MeshRenderer>().material.color)
            {
                yield return null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * smooth);
                yield return null;
            }
        }
        yield return new WaitForSeconds(time);
        IsRunning = false;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && gameObject.tag != "Untagged")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
            collision.collider.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
