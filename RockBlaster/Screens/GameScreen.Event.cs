using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using RockBlaster.Entities;
using RockBlaster.Screens;
namespace RockBlaster.Screens
{
    public partial class GameScreen
    {
        void OnBulletVsRockCollided (Entities.Bullet bullet, Entities.Rock rock) 
        {
            bullet.Destroy();
            rock.TakeHit();

            DataTypes.GlobalData.PlayerData.Score += rock.PointValue;
            this.TextInstance.Text = DataTypes.GlobalData.PlayerData.Score.ToString();
        }
        void OnPlayerVsRockCollided (Entities.Player player, Entities.Rock rock) 
        {
            player.Health--;
            rock.TakeHit();
        }
    }
}
