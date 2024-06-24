using System;
using Teste.Servicos;

namespace Teste {
    public class Program
    {
        static void Main(string[] args)
        {
            string caminhoImagem = @"C:\Users\User\Desktop\branco.png";
            WallpaperAppServico.PlanoDeFundo(caminhoImagem);
        }
    }
}

// C:\Users\User\Desktop\branco.png
// C:\Users\User\Desktop\preto.png