using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /// <summary>
    /// None of these methods actually move the character, they just return
    /// a vector with the given velocity or acceleration the 
    /// </summary>
    public static Vector2 positionVector;
    public static Vector2 velocityVector;
    public static Vector2 accelVector;
    
    /// <summary>
    /// Doesn't actually move the character left, only returns a vector.
    /// </summary>
    /// <param name="magnitude">Magnitude of the vector</param>
    /// <returns>Vector in the -X direction with with a magnitude taken
    /// from the paramater</returns>
    public Vector2 MoveLeft(float magnitude)
    {
        return new Vector2(-magnitude, 0);
    }
    /// <summary>
    /// Doesn't actually move the character right, only returns a vector.
    /// </summary>
    /// <param name="magnitude">Magnitude of the vector</param>
    /// <returns>Vector in the +X direction with with a magnitude taken
    /// from the paramater</returns>
    public Vector2 MoveRight(float magnitude)
    {
        return new Vector2(magnitude, 0);
    }
    /// <summary>
    /// Doesn't actually stop movement, only returns a zero sum vector.
    /// </summary>
    /// <returns>A zero sum vector to replace the velocity in the X direction</returns>
    public Vector2 StopMove()
    {
        return new Vector2(0, 0);
    }
    /// <summary>
    /// Doesn't make the player jump, only returns a vector that can be used to do so.
    /// </summary>
    /// <param name="magnitude">Force of the jump</param>
    /// <returns>The vector in the positive Y direction</returns>
    public Vector2 Jump(float magnitude)
    {
        return new Vector2(0, magnitude);
    }
    /// <summary>
    /// determines if gravity should be applied given if the player is on
    /// the ground or not. 
    /// If so, returns a zero sum vector to represent no gravity.
    /// If not on the ground, returns a vector in the -Y direction with a magnitude of gravity force applied.
    /// </summary>
    /// <param name="onGround">If the player is on the ground or not.</param>
    /// <param name="gravity">How much gravity force is applied.</param>
    /// <returns>The vector determined by if the player is on the ground or in the air.</returns>
    public Vector2 Gravity(bool onGround, float gravity)
    {
        if (onGround)
        {
            return new Vector2(0, 0);
        }
        else
        {
            return new Vector2(0, -gravity);
        }
    }
}
