using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArtifactController : MonoBehaviour
{

    public Transform Levitater;
    public PlayerController controller;

    // Rotation Vars
    [SerializeField]
    float rotationSpeed;
    float rotateVal;

    //Levitate Vars
    Vector3 startPos;
    float flipThreshold;
    [SerializeField]
    float distance;
    [SerializeField]
    float smoothing;
    bool ShouldFlip;

    //Color Vars
    public Color NewColor;
    public float colorSmooth;
    bool AreWeChanging;


    Color ArtifactColor
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
    

    // Start is called before the first frame update
    void Start()
    {

        rotateVal = 0f;
        ShouldFlip = false;
        AreWeChanging = false;
        startPos = Levitater.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.gamePaused == true) return;
        LevitateArtifact();
        RotateArtifact();
        
    }

    void LevitateArtifact()
    {
        var flipVal = Mathf.Clamp(flipThreshold, 0, 1);
        //Debug.Log("FlipThreshold Var: " + flipThreshold);
        if (ShouldFlip == true)
        {
            flipThreshold -= Time.deltaTime * smoothing;
        }
        else if (ShouldFlip == false)
        {
            flipThreshold += Time.deltaTime * smoothing;
        }
        if (flipVal == 1.0f)
        {
            ShouldFlip = true;
        }
        else if (flipVal == 0.0f)
        {
            ShouldFlip = false;
        }
        Levitater.position = Vector3.Lerp(new Vector3(Levitater.position.x, Levitater.position.y - distance, Levitater.position.z),
            new Vector3(Levitater.position.x, Levitater.position.y + distance, Levitater.position.z), flipVal);

    }

    void RotateArtifact()
    {
        rotateVal += rotationSpeed;
        transform.rotation = Quaternion.Euler(rotateVal, 0, rotateVal);
    }


    public void ChangeArtifact(Color color)
    {
        if (AreWeChanging != true)
        {
            StartCoroutine(ChangeToColor(color));
        }
    }

    IEnumerator ChangeToColor(Color newColor)
    {
        AreWeChanging = true;
        while(ArtifactColor != newColor)
        {
            Debug.Log("Changing Color...");
            ArtifactColor = Color.Lerp(ArtifactColor, newColor, Time.deltaTime * colorSmooth);
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", newColor);
            yield return null;
        }
        DynamicGI.UpdateEnvironment();
        AreWeChanging = false;
    }


}
