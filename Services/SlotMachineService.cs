using System;
using System.Collections.Generic;
using Slot.Models;

namespace Slot.Services
{
    public class SlotMachineService
    {
        private static string Banana = "BANAN";
        private static string Apple = "APPLE";
        private static string Plum = "PLUM";

        public static string FirstDraw()
        {
            var random = new Random();
            string[] data = {Apple, Apple, Apple, Apple, Apple, Banana, Banana, Banana, Plum, Plum};
            return data[random.Next(0, data.Length)];
            
        }
        
        public static string SecondDraw()
        {
            var random = new Random();
            string[] data = {Apple, Apple, Plum, Banana, Banana, Banana, Banana, Banana, Plum, Plum};
            return data[random.Next(0, data.Length)];
        }
        
        public static string ThirdDraw()
        {
            var random = new Random();
            string[] data = {Apple, Apple, Apple, Banana, Banana, Plum, Plum, Plum, Plum, Plum};
            return data[random.Next(0, data.Length)];
        }

        public static bool ValidateResult(Result result)
        {
            var values = new HashSet<string>
            {
                result.FirstResult, 
                result.SecondResult,
                result.ThirdResult
            };

            return values.Count < 3;
        }
    }
}