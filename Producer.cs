using UnityEngine;

public class Producer : MonoBehaviour
{
    public GameObject grothPrefab;
    public float popUpForce = 10f;
    public float delayBetweenPopUps = 1f;

    //[HideInInspector] // Hide the counter from the inspector
    public int counter = 0; // Counter for every grothPrefab instantiated

    private float timeSinceLastPopUp = 0f;

    private void FixedUpdate()
    {
        timeSinceLastPopUp += Time.deltaTime;

        if (timeSinceLastPopUp >= delayBetweenPopUps)
        {
            Pop();
            timeSinceLastPopUp = 0f;
        }
    }

    private void Pop()
    {
        // Instantiate the prefab object at the same position as this game object
        GameObject instantiatedObject = Instantiate(grothPrefab, transform.position, Quaternion.identity);

        // Apply a force to the rigidbody of the instantiated object to shoot it up in the air
        Rigidbody rigidbody = instantiatedObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.AddForce(Vector3.up * popUpForce, ForceMode.Impulse);
        }

        // Increment the counter
        counter++;
    }
}