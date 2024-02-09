using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Gui;
using FlatRedBall.Math;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using Microsoft.Xna.Framework;

namespace RockBlaster.Screens
{
    public partial class GameScreen
    {

        void CustomInitialize()
        {
            this.TextInstance.Text = "0";
        }

        void CustomActivity(bool firstTimeCalled)
        {
            RemovalActivity();
            EndGameActivity();
        }
        void RemovalActivity()
        {
            // reverse loop since we're going to Destroy
            for (int i = BulletList.Count - 1; i > -1; i--)
            {
                float absoluteX = Math.Abs(BulletList[i].X);
                float absoluteY = Math.Abs(BulletList[i].Y);

                const float removeBeyond = 600;
                if (absoluteX > removeBeyond || absoluteY > removeBeyond)
                {
                    BulletList[i].Destroy();
                }
            }

            for (int i = RockList.Count - 1; i > -1; i--)
            {
                float absoluteX = Math.Abs(RockList[i].X);
                float absoluteY = Math.Abs(RockList[i].Y);

                const float removeBeyond = 600;
                if (absoluteX > removeBeyond || absoluteY > removeBeyond)
                {
                    RockList[i].Destroy();
                }
            }
        }

        void EndGameActivity()
        {
            // If the list has 0 ships, then all have been killed
            if (GameOverAnnouncement.Visible == false & this.PlayerList.Count == 0)
            {
                GameOverAnnouncement.Visible = true;
            }
        }

        void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

    }
}
