using UnityEngine;
public class Explosive : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 0.5f;
    [SerializeField] private float _explosionRadius = 5;
    [SerializeField] private float _explosionForce = 500;
    [SerializeField] private float _upwardsModifier = 1000;
    //[SerializeField] private GameObject _particles;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= _triggerForce)
        {
            var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);
            foreach (var obj in surroundingObjects)
            {
                try
                {
                    var rb = obj.gameObject.GetComponent<Rigidbody>();

                    if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Agent")
                    {
                        Debug.Log(collision.gameObject.ToString());
                        rb.AddForceAtPosition(collision.relativeVelocity * _explosionForce, collision.GetContact(0).point);
                        rb.AddExplosionForce(_explosionForce * 0.04f, collision.GetContact(0).point, _explosionRadius, _upwardsModifier, ForceMode.Acceleration);
                    }
                }
                catch { }
            }



            //Instantiate(_particles, transform.position, Quaternion.identity);
            //
            //Destroy(gameObject);
        }
    }
}