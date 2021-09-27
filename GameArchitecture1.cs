using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace Other2 {
    public static class Buffer {
        public static void Write(char chr) {
            throw new NotImplementedException();
        }
        public static void WriteStr(string chr) {
            throw new NotImplementedException();
        }
    }
}

namespace Dumb2 {
    public static class Program {
        public static void Main() {

            #region Control 1
            // Definition control 1:
            string[] charMenu1Options = new string[] { "Начать", "Игру" };
            int charMenu1SelectedOptionOndex = 1;
            Point charMenu1ConsoleLocation = Point.Empty;
            Point charMenu1OtherBufferLocation = new Point(5, 5);

            // Prerendering
            charMenu1Options[charMenu1SelectedOptionOndex] = "*" + charMenu1Options[charMenu1SelectedOptionOndex];

            RenderInConsole(charMenu1Options, charMenu1ConsoleLocation);
            RenderInOtherBuffer(charMenu1Options, charMenu1OtherBufferLocation);
            #endregion

            #region Control 2
            // Definition control 2:
            char[,] charMenu2Options = new char[,] { { '0', '1' }, { '2', '2' } };
            // Point, потому что двумерный.
            Point charMenu2SelectedOptionIndex = Point.Empty;

            Point charMenu2ConsoleLocation = new Point(5, 5);
            Point charMenu2OtherBufferLocation = new Point(10, 10);

            // Prerendering
            charMenu2Options[charMenu2SelectedOptionIndex.X, charMenu2SelectedOptionIndex.Y] = '*';

            RenderInConsole(charMenu2Options, charMenu2ConsoleLocation);
            RenderInOtherBuffer(charMenu2Options, charMenu2OtherBufferLocation);

            // Render control on other buffer:

            #endregion

            #region Control 3
            // Definition control 3:
            string[] charList1Strings = new string[] { "1", "2", "3" };
            List<int> charList1SelectedOptionIndexes = new List<int>() { 0, 1 };
            Point charList1ConsoleLocation = new Point(10, 10);
            Point charList1OtherBufferLocation = new Point(20, 20);

            // Prerendering
            foreach (var optionIndex in charList1SelectedOptionIndexes) {
                charList1Strings[optionIndex] = "*" + charList1Strings[optionIndex];
            }

            RenderInConsole(charList1Strings, charList1ConsoleLocation);
            RenderInOtherBuffer(charList1Strings, charList1OtherBufferLocation);
            #endregion

            #region Control 4
            // Definition control 4:
            char[,] charList2Options = new char[,] { { '3', '4' }, { '5', '6' } };
            List<Point> charList2SelectedOptionIndexes = new List<Point>() { new Point(0, 0), new Point(0, 1) };
            Point charList2ConsoleLocation = Point.Empty;
            Point charList2OtherBufferLocation = new Point(5, 5);

            // Prerendering:
            foreach (var optionIntex in charList2SelectedOptionIndexes) {
                charList2Options[optionIntex.X, optionIntex.Y] = charList2Options[optionIntex.X, optionIntex.Y];
            }

            RenderInConsole(charList2Options, charList2ConsoleLocation);
            RenderInOtherBuffer(charList2Options, charList2OtherBufferLocation);
            #endregion

        }

        public static void RenderInConsole(string[] control, Point location) {
            for (int i = 0; i < control.Length; i++) {
                Console.SetCursorPosition(location.X, location.Y + i);
                Console.Write(control[i]);
            }
        }
        public static void RenderInOtherBuffer(string[] control, Point location) {
            foreach (var str in control) {
                foreach (var chr in str) {
                    Other1.Buffer.Write(chr);
                }
            }
        }
        public static void RenderInConsole(char[,] control, Point location) {
            for (int r = 0; r < control.GetUpperBound(0); r++) {
                for (int c = 0; c < control.GetUpperBound(1); c++) {
                    Console.Write(control[r, c]);
                }
            }
        }
        public static void RenderInOtherBuffer(char[,] control, Point location) {
            foreach (var chr in control) {
                Other1.Buffer.Write(chr);
            }
        }

    }
}


