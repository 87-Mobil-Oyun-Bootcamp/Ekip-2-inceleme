using UnityEngine;

public class WoodLog : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            var wood = Resources.Load<ResourcesSO>("Resource/Wood");
            wood.amount++;
        }
    }
}
