using System;
using System.Collections.Generic;
using System.Linq;

namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public class Fleet
    {
        private readonly List<string> inputs;
        private readonly List<LawnMower> lawnMowers = new List<LawnMower>();

        public Fleet(string input)
        {
            inputs = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();

            Lawn = Lawn.CreateWith(inputs[0]);

            inputs.RemoveAt(0);

            if (inputs.Count%2 != 0)
            {
                throw new ArgumentException("The inputs for lawn mowers must be the initial position followed by movement commands");
            }
        }

        public Lawn Lawn { private set; get; }

        public string Output => string.Join(Environment.NewLine, lawnMowers.Select(mower => mower.Output));

        public void MowLawn()
        {
            for (var lawnMowerInput = 0; lawnMowerInput < inputs.Count; lawnMowerInput += 2)
            {
                var lawnMower = LawnMower.CreateAt(inputs[lawnMowerInput]);
                lawnMower.ExecuteMoves(inputs[lawnMowerInput+1]);

                lawnMowers.Add(lawnMower);
            }    
        }
    }
}