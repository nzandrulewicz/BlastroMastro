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

using RockBlaster.Entities;


namespace RockBlaster.Screens
{
    public partial class StartMenu
    {
        void CustomInitialize()
        {
            Forms.PlayButton.Click += HandleButtonClick;
        }

        private void HandleButtonClick(object sender, EventArgs e)
        {
            this.MoveToScreen(typeof(Level1).FullName);
        }

        void CustomActivity(bool firstTimeCalled)
        {


        }

        void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

    }
}
