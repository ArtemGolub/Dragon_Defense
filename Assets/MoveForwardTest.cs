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

        if (Input.GetKeyDown(KeyCode.E) && parabolicMovement.IsMoving())
        {
            parabolicMovement.StopMovement();
            transform.SetParent(null);
            dropTest();
        }
        
        if (parabolicMovement.IsMoving())
        {
            parabolicMovement.UpdateMovement();
        }
    }


    void dropTest()
    {
        RaycastHit hit;
        Vector3 groundPosition = Vector3.zero;
        Vector3 raycastStartPosition = transform.position + Vector3.up * 0.1f;
            
        if (Physics.Raycast(raycastStartPosition, Vector3.down, out hit))
        {
            groundPosition = hit.point;
        }
            
        transform.position = groundPosition;
    }
}
