using System;
using System.Net;

using Microsoft.Xna.Framework;

using PokeD.Core.Wrappers;

using PokeD.SCON.Windows.WrapperInstances;

namespace PokeD.SCON.Windows
{
    public static class Program
    {
        static Game Game { get; set; }

        static Program()
        {
            FileSystemWrapper.Instance = new FileSystemWrapperInstance();
            NetworkTCPClientWrapper.Instance = new NetworkTCPClientWrapperInstance();
            NetworkTCPServerWrapper.Instance = new NetworkTCPServerWrapperInstance();
            InputWrapper.Instance = new InputWrapperInstance();
            ThreadWrapper.Instance = new ThreadWrapperInstance();
        }

        [STAThread]
        public static void Main(params string[] args)
        {
            if (Type.GetType("Mono.Runtime") != null) // -- Running on Mono
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            Action<Rectangle> onResize = null;
            using (Game = new EmptyKeysUI(ref onResize))
            {
                Game.Window.AllowUserResizing = true;
                Game.Window.ClientSizeChanged += (sender, eventArgs) => onResize(Game.Window.ClientBounds);

                Game.Run();
            }
        }
    }
}
