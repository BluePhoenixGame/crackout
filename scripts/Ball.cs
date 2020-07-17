using Godot;
using System;

public class Ball : KinematicBody2D
{
    /// <summary> Internal variable for calculating when the ball is under the screen. </summary>
    private int screenHeight = (int)ProjectSettings.GetSetting("display/window/size/height");
    /// <summary> Internal variable for continuing movement </summary>
    private Vector2 velocity = new Vector2();

    /// <summary> The chosen speed at which the ball should move </summary>
    [Export]
    public int Speed;

    public override void _PhysicsProcess(float delta)
    {
        var collisionInfo = MoveAndCollide(velocity * delta);
        if (collisionInfo != null)
        {
            if (collisionInfo.Collider is IBrick brick)
            {
                brick.Hit(this);
            }
            
            // Bounce ball, will keep moving if not executed
            Velocity = Velocity.Bounce(collisionInfo.Normal);
        }
    }
}
