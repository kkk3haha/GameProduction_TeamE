using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project_X_s
{
    class PlayerInput
    {
        public static bool StartButton(PlayerIndex playerNum)
        {

            if (InputManager.IsButtonDown(playerNum, Buttons.Start))
            { return true; }
            else
            { return false; }
        }

        public static bool Determine(PlayerIndex playerNum)
        {
            if (InputManager.IsJustButtonDown(playerNum, Buttons.B))
            { return true; }
            else
            { return false; }
        }

        public static bool Cancel(PlayerIndex playerNum)
        {
            if (InputManager.IsJustButtonDown(playerNum, Buttons.A))
            { return true; }
            else
            { return false; }
        }

        public static bool PadUp(PlayerIndex playerNum)
        {
            if (InputManager.IsJustButtonDown(playerNum, Buttons.DPadUp))
            { return true; }
            else
            { return false; }
        }

        public static bool PadDown(PlayerIndex playerNum)
        {
            if (InputManager.IsJustButtonDown(playerNum, Buttons.DPadDown))
            { return true; }
            else
            { return false; }
        }

        public static bool PadLeft(PlayerIndex playerNum)
        {
            if (InputManager.IsJustButtonDown(playerNum, Buttons.DPadLeft))
            { return true; }
            else
            { return false; }
        }

        public static bool PadRight(PlayerIndex playerNum)
        {
            if (InputManager.IsJustButtonDown(playerNum, Buttons.DPadRight))
            { return true; }
            else
            { return false; }
        }

        public static Vector2 LeftStick(PlayerIndex playerNum)
        {
            Vector2 vec;
            vec = InputManager.GetThumbSticksLeft(playerNum);
            return vec;

        }

        public static bool AttackButton(PlayerIndex playerNum)
        {

            if (InputManager.IsJustButtonDown(playerNum, Buttons.X))
            { return true; }
            else
            { return false; }
        }

        public static int AttackButtonChage(PlayerIndex playerNum)
        {
            int PushTime = 0;
            if (InputManager.IsButtonDown(playerNum, Buttons.X))
            {
                PushTime++;
                return PushTime;
            }
            else
            { return PushTime; }
        }

        public static bool ExtraAttackButton(PlayerIndex playerNum)
        {
            if (InputManager.IsJustButtonDown(playerNum, Buttons.Y))
            { return true; }
            else
            { return false; }
        }

        public static bool LeftButton(PlayerIndex playerNum)
        {
            if (InputManager.IsJustButtonDown(playerNum, Buttons.LeftShoulder))
            { return true; }
            else
            { return false; }
        }

        public static bool RightButton(PlayerIndex playerNum)
        {
            if (InputManager.IsJustButtonDown(playerNum, Buttons.RightShoulder))
            { return true; }
            else
            { return false; }
        }

    }
}
