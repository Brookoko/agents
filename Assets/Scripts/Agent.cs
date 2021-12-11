using System.Collections.Generic;
using System.Linq;
using Scenes.Behaviours;
using Scenes.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Victor.Agents;

public class Agent : MonoBehaviour
{
    [SerializeField]
    private float mass = 1;

    [SerializeField]
    private AgentBehaviour[] behaviours;

    public IEnumerable<Vector2> TargetsPositions { get; set; }

    [FormerlySerializedAs("VelocityLimit")] [SerializeField]
    public float velocityLimit;

    [FormerlySerializedAs("SteeringForceLimit")] [SerializeField]
    private float steeringForceLimit;

    [FormerlySerializedAs("AngularSpeed")] [SerializeField]
    private float angularSpeed;

    [FormerlySerializedAs("Friction")] [SerializeField]
    private float friction;

    [FormerlySerializedAs("Epsilon")] [SerializeField]
    private float epsilon;

    public Vector2 Velocity => velocity;
    private Vector2 velocity;
    private Vector2 acceleration;
    private bool isEnabled;
    private Rigidbody rb;
    private EntityProvider entityProvider;

    public void Construct(EntityProvider entityProvider)
    {
        this.entityProvider = entityProvider;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyForce(Vector2 force)
    {
        force /= mass;
        acceleration += force;
    }

    private void FixedUpdate()
    {
        ApplySteeringForce();
        ApplyFriction();
        ApplyForces();
        Debug.DrawRay(transform.position + Vector3.up * 2, velocity.ToXZVector3(), Color.yellow);
    }

    private void ApplySteeringForce()
    {
        // if (!isEnabled) return;
        var activeBehaviours = behaviours.Where(b => b.isActive).ToArray();
        if (!activeBehaviours.Any()) return;

        var steering = Vector2.zero;

        foreach (var behaviour in activeBehaviours)
        {
            behaviour.targets = entityProvider.entities;
            var desiredVelocity = behaviour.GetDesiredVelocity(this) * behaviour.weight;
            steering += desiredVelocity - velocity;
        }

        ApplyForce(Vector2.ClampMagnitude(steering - velocity, steeringForceLimit));
    }

    private void ApplyFriction()
    {
        var force = friction * velocityLimit * -velocity.normalized;
        ApplyForce(force);
    }

    private void ApplyForces()
    {
        velocity += acceleration * Time.deltaTime;

        var magnitude = Mathf.Clamp(velocity.magnitude, 0, velocityLimit);
        var direction = GetDirection();
        velocity = direction * magnitude;

        //animation.UpdateSpeed(magnitude / (VelocityLimit * 0.3f));

        var velocity3D = velocity.ToXZVector3();


        if (velocity.sqrMagnitude < epsilon * epsilon)
        {
            velocity = Vector2.zero;
            return;
        }


        var deltaPosition = transform.position + velocity3D * Time.deltaTime;
        rb.MovePosition(deltaPosition);
        transform.rotation = Quaternion.LookRotation(velocity3D);


        acceleration = Vector2.zero;
    }

    private Vector2 GetDirection()
    {
        var forward = transform.forward;
        var velocityNormalized = velocity.normalized.ToXZVector3();

        return Vector3.Lerp(forward, velocityNormalized, angularSpeed / 10).ToXZVector2().normalized;
    }
}