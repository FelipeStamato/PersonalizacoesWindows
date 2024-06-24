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



    }
}
        



// Comando dentro de uma classe de handler para evitar armazenamento da magma
// Dar uma olhada app serviço

