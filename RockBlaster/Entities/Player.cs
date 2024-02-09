using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;
using System.Reflection;

namespace RockBlaster.Entities
{
    public partial class Player
    {
        public I1DInput TurningInput { get; set; }
        public IPressableInput ShootingInput { get; set; }

        int health;

        private void CustomInitialize()
        {
            if (InputManager.Xbox360GamePads[0].IsConnected)
            {
                TurningInput = InputManager.Xbox360GamePads[0].LeftStick.Horizontal;

                ShootingInput = InputManager.Xbox360GamePads[0].GetButton(
                    Xbox360GamePad.Button.RightTrigger);
            }
            else
            {
                TurningInput = InputManager.Keyboard.Get1DInput(
                    Microsoft.Xna.Framework.Input.Keys.A,
                    Microsoft.Xna.Framework.Input.Keys.D);

                ShootingInput = InputManager.Mouse.GetButton(Mouse.MouseButtons.LeftButton);
            }

            var hudParent = gumAttachmentWrappers[0];
            hudParent.ParentRotationChangesRotation = false;

            Health = StartingHealth;
        }

        private void CustomActivity()
        {
            this.RotationZVelocity = -TurningInput.Value * this.TurningSpeed;
            this.Velocity = this.RotationMatrix.Up * this.MovementSpeed;

            if (ShootingInput.WasJustPressed)
            {
                Bullet firstBullet = Factories.BulletFactory.CreateNew();
                firstBullet.Position = this.Position;
                firstBullet.Position += this.RotationMatrix.Up * 12;
                // This is the bullet on the right side when the ship is facing up.
                // Adding along the Right vector will move it to the right relative to the ship
                firstBullet.Position += this.RotationMatrix.Right * 6;
                firstBullet.RotationZ = this.RotationZ;
                firstBullet.Velocity = this.RotationMatrix.Up * firstBullet.MovementSpeed;

                Bullet secondBullet = Factories.BulletFactory.CreateNew();
                secondBullet.Position = this.Position;
                secondBullet.Position += this.RotationMatrix.Up * 12;
                // This bullet is moved along the Right vector, but in the nevative
                // direction, making it the bullet on the left.
                secondBullet.Position -= this.RotationMatrix.Right * 6;
                secondBullet.RotationZ = this.RotationZ;
                secondBullet.Velocity = this.RotationMatrix.Up * secondBullet.MovementSpeed;
            }
        }

        public int Health
        {
            get 
            { 
                return health; 
            }

            set
            {
                health = value;

                HealthBarRuntimeInstance.PercentFull = Health * 100 / (float)StartingHealth;

                if (health <= 0)
                {
                    Destroy();
                }
            }
        }

        private void CustomDestroy()
        {

        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }
}
