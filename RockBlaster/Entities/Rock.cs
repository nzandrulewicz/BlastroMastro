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

namespace RockBlaster.Entities
{
    public partial class Rock
    {
        public void TakeHit()
        {
            if (this.CurrentRockSizeState == RockSize.Size4)
            {
                BreakIntoPieces(RockSize.Size3);
            }
            else if (this.CurrentRockSizeState == RockSize.Size3)
            {
                BreakIntoPieces(RockSize.Size2);
            }
            else if (this.CurrentRockSizeState == RockSize.Size2)
            {
                BreakIntoPieces(RockSize.Size1);
            }
            // don't break into pieces if at size 1
            this.Destroy();
        }

        void BreakIntoPieces(RockSize newRockState)
        {
            for (int i = 0; i < NumberOfRocksToBreakInto; i++)
            {
                Rock newRock = Factories.RockFactory.CreateNew();
                newRock.Position = this.Position;

                newRock.Position.X += -1 + 2 * (float)(FlatRedBallServices.Random.NextDouble());
                newRock.Position.Y += -1 + 2 * (float)(FlatRedBallServices.Random.NextDouble());

                float randomAngle = (float)(FlatRedBallServices.Random.NextDouble() * System.Math.PI * 2);

                float speed = 0 + (float)(FlatRedBallServices.Random.NextDouble() * RandomSpeedOnBreak);
                newRock.Velocity = FlatRedBall.Math.MathFunctions.AngleToVector(randomAngle) * speed;
                newRock.CurrentRockSizeState = newRockState;
            }
        }

        private void CustomInitialize()
        {


        }

        private void CustomActivity()
        {


        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }
}
