using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    public float driftForce;
    [SerializeField]
    public float speedForce;
    [SerializeField]
    public float turningForce;
    [SerializeField]
    public float maxSpeed;

    float accelerationForce = 0;
    float steeringForce = 0;

    float rotationAngle = 0;

    public float velocityVsUp = 0;

    Rigidbody2D carRB;

    void Awake()
    {
        carRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        ApplyEngineForce();

        KillOrthagonalVelocity();

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        velocityVsUp = Vector2.Dot(transform.up, carRB.velocity);

        if (velocityVsUp > maxSpeed && accelerationForce > 0)
        {
            return;
        }

        if (velocityVsUp < 0 && velocityVsUp > -maxSpeed * 0.5f && accelerationForce > 0)

            if (carRB.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationForce > 0)
            {
                return;
            }
        if (accelerationForce == 0)
        {
            carRB.drag = Mathf.Lerp(carRB.drag, 2.0f, Time.fixedDeltaTime * 2);
        }
        else
        {
            carRB.drag = 0;
        }

        Vector2 engineForceVector = transform.up * accelerationForce * speedForce;

        carRB.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowedTurning = (carRB.velocity.magnitude / 8);
        minSpeedBeforeAllowedTurning = Mathf.Clamp01(minSpeedBeforeAllowedTurning);

        rotationAngle -= steeringForce * turningForce * minSpeedBeforeAllowedTurning;

        carRB.MoveRotation(rotationAngle);
    }
    void KillOrthagonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRB.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRB.velocity, transform.right);

        carRB.velocity = forwardVelocity + rightVelocity * driftForce;
    }
    public void SetInput(Vector2 inputVector)
    {
        steeringForce = inputVector.x;
        accelerationForce = inputVector.y;
    }
}