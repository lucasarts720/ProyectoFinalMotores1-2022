using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int dmg;
    [SerializeField] protected int RotatorX, RotatorY, RotatorZ;

    protected void Update()
    {
        rotator(RotatorX, RotatorY, RotatorZ);
    }
    protected void rotator(int x, int y, int z)
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player s_player = collision.gameObject.GetComponent<Player>();
            s_player.GetDMG(dmg);
        }
    }
}
