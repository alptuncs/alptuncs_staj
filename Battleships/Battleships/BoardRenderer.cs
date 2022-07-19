﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class BoardRenderer
    {
        private int _height;
        private int _width;
        private string _boardGraphicString;
        IConsole console;

        public string[][] BoardSurface;
        public string BoardGraphicString => _boardGraphicString;


        public BoardRenderer(int height, int width)
        {
            this._height = height;
            this._width = width;
            InitializeBoardSurface();
        }

        public string InitializeBoardGraphicString()
        {
            _boardGraphicString = "";

            for (int i = 0; i < BoardSurface.Length; i++)
            {
                for (int j = 0; j < BoardSurface[i].Length; j++)
                {
                    _boardGraphicString += BoardSurface[i][j] + (j < BoardSurface[i].Length - 1 ? " " : "");
                }
                _boardGraphicString += i < BoardSurface.Length - 1 ? "\n" : "";
            }
            return _boardGraphicString;
        }


        private void InitializeBoardSurface()
        {
            BoardSurface = new string[_height][];

            for (int i = 0; i < BoardSurface.Length; i++)
            {
                BoardSurface[i] = Enumerable.Repeat("[ ]", _width).ToArray();
            }


        }

        public string Render(BoardManager boardManager)
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (boardManager.HasShip(i, j))
                    {
                        BoardSurface[i][j] = $"[{boardManager.Board[i][j].shipType}]";
                    }
                    if (boardManager.IsHit(i, j))
                    {
                        BoardSurface[i][j] = "[*]";
                    }
                }



            }

            return InitializeBoardGraphicString();
        }
    }
}
