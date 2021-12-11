using System.Collections.Generic;
using Scenes.Behaviours;
using Scenes.Scripts;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField]
    private float mass = 1;

    [SerializeField]
    [Range(1, 30)]
    private float velocityLimit = 3;

    [SerializeField]
    [Range(1, 30)]
    private float steeringForceLimit = 5;

    [SerializeField]
    [Range(1, 15)]
    private float angularSpeed = 8;

    [SerializeField]
    [Range(0, 0.7f)]
    private float friction;

    [SerializeField]
    private LayerMask layer;

    [SerializeField]
    private AgentType type;

    [SerializeField]
    private AgentBehaviour[] behaviours;

    public float VelocityLimit => velocityLimit;
    public Vector3 Velocity => velocity;
    public AgentType Type => type;

    private const float Epsilon = 0.5f;
    private Vector3 velocity;
    private Vector3 acceleration;
    private bool isEnabled;
    private Rigidbody rb;
    private RaycastHit[] hits = new RaycastHit[1];

    public List<Agent> Agents;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        foreach (var behaviour in behaviours)
        {
            behaviour.Targets = Agents;
        }
    }

    public void ApplyForce(Vector3 force)
    {
        force /= mass;
        acceleration += force;
    }

    private void FixedUpdate()
    {
        ApplySteeringForce();
        ApplyFriction();
        ApplyForces();
    }

    private void ApplySteeringForce()
    {
        // if (!isEnabled) return;
        var steering = Vector3.zero;
        foreach (var behaviour in behaviours)
        {
            var desiredVelocity = behaviour.GetDesiredVelocity(this) * behaviour.Weight;
            steering += desiredVelocity - velocity;
        }

        ApplyForce(Vector3.ClampMagnitude(steering - velocity, steeringForceLimit));
    }

    private void ApplyFriction()
    {
        var force = friction * VelocityLimit * -velocity.normalized;
        ApplyForce(force);
    }

    private void ApplyForces()
    {
        velocity += acceleration * Time.deltaTime;

        var magnitude = Mathf.Clamp(velocity.magnitude, 0, velocityLimit);
        var direction = GetDirection();
        velocity = direction * magnitude;
        velocity = AlignVelocityWithGround(velocity);

        if (velocity.sqrMagnitude < Epsilon * Epsilon)
        {
            velocity = Vector3.zero;
            return;
        }

        rb.MovePosition(transform.position + velocity * Time.deltaTime);
        acceleration = Vector3.zero;
        transform.rotation = Quaternion.LookRotation(velocity);
    }

    private Vector3 GetDirection()
    {
        var forward = transform.forward;
        var velocityNormalized = velocity.normalized;
        return Vector3.Lerp(forward, velocityNormalized, angularSpeed * Time.deltaTime).normalized;
    }

    private Vector3 AlignVelocityWithGround(Vector3 velocity)
    {
        var count = Physics.RaycastNonAlloc(transform.position, Vector3.down, hits, 10f, layer);
        if (count == 0) return velocity;
        var normal = hits[0].normal;
        var sin = Vector3.Dot(normal, velocity) / (velocity.magnitude * normal.magnitude);
        var angle = Mathf.Asin(Mathf.Clamp(sin, -1, 1));
        var right = Vector3.Cross(normal, velocity);
        return Quaternion.AngleAxis(angle, right) * velocity;
    }

    // public void ApplyModifier(BehaviourModifier modifier)
    // {
    //     foreach (var behaviour in behaviours)
    //     {
    //         modifier.ModifyBehaviour(behaviour);
    //     }
    // }

    public void Enable()
    {
        isEnabled = true;
    }

    public void Disable()
    {
        isEnabled = false;
    }
}