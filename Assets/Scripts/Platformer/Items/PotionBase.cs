using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionBase : MonoBehaviour
{
    protected Player player;
    protected PlayerMovement playermovement;
    [SerializeField] protected int RotatorX, RotatorY, RotatorZ;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
            playermovement = collision.gameObject.GetComponent<PlayerMovement>();
            PotionEffect();
            Destroy(this.gameObject);
        }
    }

    protected void Update()
    {
        rotator(RotatorX,RotatorY,RotatorZ);
    }
    protected void rotator(int x, int y, int z)
    {
        transform.Rotate(new Vector3(x,y,z) * Time.deltaTime);
    }

    protected abstract void PotionEffect();
}
