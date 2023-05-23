using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Vector2 velocity;
    Vector2 rawInput;

    public bool estatico = false;

    void FixedUpdate()
    {
        if(estatico == false)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        velocity.x = rawInput.x * speed * Time.deltaTime;
        velocity.y = rawInput.y * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
