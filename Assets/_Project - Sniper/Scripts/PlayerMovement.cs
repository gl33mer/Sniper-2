using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    public float power = 500f;
    private float powerInput;

    private Vector3 controlPosition;
    private Vector3 thrustForward;
    private Rigidbody craftRigidBody;          // Reference to the player's rigidbody.
    private Vector3 hitpoint = new Vector3(0, 0, 0);

    public Sprite crosshair;
    private GameObject crosshairObject;
    private SpriteRenderer crosshairSprite;

    void Awake()
    {
        craftRigidBody = GetComponent<Rigidbody>();
        Crosshair();
    }

    void FixedUpdate()
    {
        powerInput = Input.GetAxis("Vertical");
        hitpoint = MouseCast();
        Vector3 v = hitpoint - transform.position;
        crosshairObject.transform.position = transform.position + Vector3.ClampMagnitude(v.normalized, 3);
        ApplyThrustToTarget(powerInput, hitpoint);
    }

    private Vector3 MouseCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mouseTarget = hit.point;
        mouseTarget.y = 0;
        return mouseTarget;
    }

    void ApplyThrustToTarget(float p, Vector3 _target)
    {
        thrustForward = _target - transform.position;
        thrustForward = (thrustForward.normalized * power * Time.deltaTime) * p;
        craftRigidBody.AddForce(thrustForward);
    }

    private void Crosshair()
    {
        crosshairObject = new GameObject("Crosshair");
        //crosshairObject.transform.SetParent(transform);
        crosshairObject.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        crosshairSprite = crosshairObject.AddComponent<SpriteRenderer>();
        crosshairSprite.size = new Vector2(8, 8);
        crosshairSprite.sprite = crosshair;
    }

}