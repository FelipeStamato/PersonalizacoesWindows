using System;
using Teste.Servicos;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoimagem = @"C:\Users\User\Desktop\diferen-as-resolu-es-1-.jpg";
            WallpaperAppServico.PlanoDeFundo(caminhoimagem);
            WallpaperAppServico.TelaDeBloqueio(caminhoimagem);
        }
    }
}
