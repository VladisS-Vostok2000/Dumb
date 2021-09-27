using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace Other1 {
    public static class Buffer {
        public static void Write(char chr) {
            throw new NotImplementedException();
        }
        public static void WriteStr(string chr) {
            throw new NotImplementedException();
        }
    }
}

namespace Dumb1 {
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

            // Render control on Console:
            for (int i = 0; i < charMenu1Options.Length; i++) {
                Console.SetCursorPosition(charMenu1ConsoleLocation.X, charMenu1ConsoleLocation.Y + i);
                Console.Write(charMenu1Options[i]);
            }

            // Render control on other buffer:
            foreach (var str in charMenu1Options) {
                foreach (var chr in str) {
                    Other1.Buffer.Write(chr);
                }
            }
            #endregion

            #region Control 2
            // Definition control 2:
            char[,] charMenu2Options = new char[,] { { '0', '1' }, { '2', '2' } };
            // Point, потому что двумерный.
            Point charMenu2SelectedOpionOndex = Point.Empty;

            Point charMenu2ConsoleLocation = new Point(5, 5);
            Point charMenu2OtherBufferLocation = new Point(10, 10);

            // Prerendering
            charMenu2Options[charMenu2SelectedOpionOndex.X, charMenu2SelectedOpionOndex.Y] = '*';

            // Render control on Console:
            for (int r = 0; r < charMenu2Options.GetUpperBound(0); r++) {
                for (int c = 0; c < charMenu2Options.GetUpperBound(1); c++) {
                    Console.Write(charMenu2Options[r, c]);
                }
            }

            // Render control on other buffer:
            foreach (var chr in charMenu2Options) {
                Other1.Buffer.Write(chr);
            }
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

            // Visualizing control in Console:
            for (int i = 0; i < charList1Strings.Length; i++) {
                Console.SetCursorPosition(charList1ConsoleLocation.X, charList1ConsoleLocation.Y + i);
                Console.Write(charList1Strings[i]);
            }

            // Visualizing control in other buffer:
            foreach (var str in charList1Strings) {
                foreach (var chr in str) {
                    Other1.Buffer.Write(chr);
                }
            }
            #endregion

            #region Control 4
            // Definition control 4:
            char[,] charList2Options = new char[,] { { '3', '4' }, { '5', '6' } };
            List<Point> charList2SelectedOpionIndexes = new List<Point>() { new Point(0, 0), new Point(0, 1) };
            Point charList2ConsoleLocation = Point.Empty;
            Point charList2OtherBufferLocation = new Point(5, 5);

            // Prerendering:
            foreach (var optionIntex in charList2SelectedOpionIndexes) {
                charList2Options[optionIntex.X, optionIntex.Y] = charList2Options[optionIntex.X, optionIntex.Y];
            }

            // Render control on console:
            for (int r = 0; r < charList2Options.GetUpperBound(0); r++) {
                for (int c = 0; c < charList2Options.GetUpperBound(1); c++) {
                    Console.Write(charList2Options[r, c]);
                }
            }

            // Render control on other buffer:
            foreach (var chr in charList2Options) {
                Other1.Buffer.Write(chr);
            }
            #endregion

        }
    }
}


