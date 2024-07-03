using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Teste.Handlers;

namespace Teste.Servicos
{
    public static class WallpaperAppServico
    {

        public static void PlanoDeFundo(string caminhoimagem)
        {
            new PlanoDeFundoHandler(caminhoimagem).Executa();
        }


        public static void TelaDeBloqueio(string caminhoimagem)
        {
            new TelaDeBloqueioHandler(caminhoimagem).Executa();
        }
    }
}
