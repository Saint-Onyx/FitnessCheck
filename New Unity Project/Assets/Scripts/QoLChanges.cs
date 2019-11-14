using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QoLChanges : MonoBehaviour
{
    public MeshRenderer dumbbellLeft;
    public MeshRenderer dumbbellRight;
    public Animator animator;

    /// <summary>
    /// Enables dumbbell renderer
    /// </summary>
    public void enableDumbbell()
    {
        if (dumbbellLeft && dumbbellRight)
        {
            dumbbellLeft.enabled = true;
            dumbbellRight.enabled = true;
        }
    }

    /// <summary>
    /// Disables dumbbell renderer
    /// </summary>
    public void disableDumbbell()
    {
        if (dumbbellLeft && dumbbellRight)
        {
            dumbbellLeft.enabled = false;
            dumbbellRight.enabled = false;
        }
    }

    /// <summary>
    /// Allow the user to change animation states with the UI buttons.
    /// </summary>
    /// <param name="id"></param>
    public void changeAnimation(int id)
    {
        switch (id)
        {
            case 1:
                animator.SetTrigger("DBC");
                break;
            case 2:
                animator.SetTrigger("SDP");
                break;
            case 3:
                animator.SetTrigger("OLS");
                break;
            case 4:
                animator.SetTrigger("DBR");
                break;
            default:
                break;
        }
    }
}
