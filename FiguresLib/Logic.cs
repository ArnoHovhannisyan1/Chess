using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Logic : IDisposable
    {
        private Process stockfishProcess;

        public Logic()
        {
            InitializeStockfish();
        }

        private void InitializeStockfish()
        {
            // Replace this path with the correct path to your Stockfish executable
            string stockfishPath = @"C:\Users\arnoh\OneDrive\Desktop\ChessProject\stockfish\stockfish-windows-x86-64-avx2.exe";

            stockfishProcess = new Process
            {
                StartInfo =
            {
                FileName = stockfishPath,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
            };

            stockfishProcess.Start();
        }

        public string GetBestMove(string fen)
        {
            // Send the "position fen <fen>" command to Stockfish
            stockfishProcess.StandardInput.WriteLine($"position fen {fen}");

            // Send the "go depth 1" command to get a quick move recommendation
            stockfishProcess.StandardInput.WriteLine("go depth 1");

            // Wait for Stockfish to compute the best move
            string bestMove = string.Empty;
            while (true)
            {
                string output = stockfishProcess.StandardOutput.ReadLine();
                if (output.StartsWith("bestmove"))
                {
                    bestMove = output.Split(' ')[1];
                    break;
                }
            }

            return bestMove;
        }

        public void Dispose()
        {
            // Close the Stockfish process when done
            stockfishProcess.StandardInput.WriteLine("quit");
            stockfishProcess.WaitForExit();
            stockfishProcess.Close();
        }
    }

}

