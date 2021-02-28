using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UseArtifact : MonoBehaviour
{

    public ArtifactController Artifact;

 

    public void OnUseArtifact1(InputValue button)
    {
        Debug.Log("pressed: 1");
        Artifact.ChangeArtifact(Color.red);
    } 
    public void OnUseArtifact2(InputValue button)
    {
        Debug.Log("pressed: 2");
        Artifact.ChangeArtifact(Color.blue);
    }
    public void OnUseArtifact3(InputValue button)
    {
        Debug.Log("pressed: 3");
        Artifact.ChangeArtifact(Color.green);
    }

    public void OnUseArtifact4(InputValue button)
    {
        Debug.Log("pressed: 4");
        Artifact.ChangeArtifact(Color.cyan);
    }
    public void OnUseArtifact5(InputValue button)
    {
        Debug.Log("pressed: 5");
        Artifact.ChangeArtifact(Color.magenta);
    }  
    public void OnUseArtifact6(InputValue button)
    {
        Debug.Log("pressed: 6");
        Artifact.ChangeArtifact(new Color(1,1,0,1));
    }

    public void OnUseArtifact7(InputValue button)
    {
        var orange = 125f / 255f; 
        Debug.Log("pressed: 7");
        Artifact.ChangeArtifact(new Color(1, orange, 0, 1));
    }

    public void OnUseArtifact8(InputValue button)
    {
        Debug.Log("pressed: 8");
        Artifact.ChangeArtifact(Color.white);
    }



}
