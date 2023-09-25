using UnityEngine;

public class MoveForwardTest : MonoBehaviour
{
    private ParabolaMovement parabolicMovement;
    public Transform endPoint;
    void Start()
    {
        parabolicMovement = new ParabolaMovement(transform, endPoint.position, 4.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !parabolicMovement.IsMoving())
        {
            parabolicMovement.StartMovement();
        }
        if (parabolicMovement.IsMoving())
        {
            parabolicMovement.UpdateMovement();
        }
    }
}
