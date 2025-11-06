using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;
    
    private Vector3 moveDirection;
    
    public CharacterController charController;
    void Start()
    {
        
    }
    
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDirection = moveDirection * moveSpeed;
        
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        
        moveDirection.y += Physics.gravity.y * Time.deltaTime;
        
        //transform.position = transform.position + (moveDirection * Time.deltaTime * moveSpeed);

        charController.Move(moveDirection * Time.deltaTime);
    }
}
