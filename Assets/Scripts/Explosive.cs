using UnityEngine;
public class Explosive : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 0.5f;
    [SerializeField] private float _explosionRadius = 5;
    [SerializeField] private float _explosionForce = 500;
    [SerializeField] private float _upwardsModifier = 1000;
    [SerializeField] private float _bounceForce = 1000;
    //[SerializeField] private GameObject _particles;

    public void SetTriggerForce(float tf)
    {
        _triggerForce= tf;
    }
    public void SetExplosionRadius(float er)
    {
        _explosionRadius= er;   
    }
    public void SetExplosionForce(float ef)
    {
        _explosionForce= ef;
    }
    public void setUpwardsModifier(float um)
    {
        _upwardsModifier= um; 
    }
    public void setBounceForce(float bf)
    {
        _bounceForce= bf;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= _triggerForce)
        {
            var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);
            if (this.gameObject.layer == 11)
            {
                var rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.AddForceAtPosition(collision.impulse * _bounceForce, collision.GetContact(0).point);
                //rb.AddExplosionForce(_explosionForce * 0.04f, collision.GetContact(0).point, _explosionRadius, _upwardsModifier, ForceMode.Acceleration);
            }
            else
            {
                foreach (var obj in surroundingObjects)
                {
                    try
                    {
                        var rb = obj.gameObject.GetComponent<Rigidbody>();


                        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Agent"))
                        {
                            //Debug.Log(collision.gameObject.ToString());
                            rb.AddForceAtPosition(collision.relativeVelocity * _explosionForce, collision.GetContact(0).point);
                            rb.AddExplosionForce(_explosionForce * 0.04f, collision.GetContact(0).point, _explosionRadius, _upwardsModifier, ForceMode.Acceleration);
                        }

                    }
                    catch { }
                }
            }



            //Instantiate(_particles, transform.position, Quaternion.identity);
            //
            //Destroy(gameObject);
        }
    }
}