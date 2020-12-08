using System;
using System.Collections.Generic;

namespace day2
{
    public class PasswordPolicy
    {
        public int Min { get; }
        public int Max { get; }
        public string RequiredCharacter { get; }
        public string Password { get; }

        public PasswordPolicy(int min, int max, string requiredCharacter, string password)
        {
            this.Min = min;
            this.Max = max;
            this.RequiredCharacter = requiredCharacter;
            this.Password = password;
        }

        public bool GetPart1Answer()
        {
            int count = Password.Split(RequiredCharacter).Length - 1;
            return count >= Min && count <= Max;
        }

        public bool GetPart2Answer()
        {
            return Password[Min -1] == RequiredCharacter[0] ^  Password[Max -1] == RequiredCharacter[0];                           
        }
    }
}