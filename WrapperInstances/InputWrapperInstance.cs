﻿using System;

using Aragas.Core.Wrappers;

namespace PokeD.SCON.Desktop.WrapperInstances
{
    public class InputWrapperInstance : IInputWrapper
    {
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public InputWrapperInstance() { }

        public void ShowKeyboard() { }

        public void HideKeyboard() { }

        public void ConsoleWrite(string message)
        {
            //ConsoleManager.WriteLine(message);
        }

        public void LogWriteLine(DateTime time, string message)
        {
            //LogManager.WriteLine(message);
        }
    }
}
