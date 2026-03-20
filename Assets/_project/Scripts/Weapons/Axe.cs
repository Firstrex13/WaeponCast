using UnityEngine;

public class Axe :Weapon
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime, 0, 0);
    }
}
