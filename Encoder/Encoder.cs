using System.Collections.Generic;
using System.Linq;

namespace Encoder
{
    public class EncoderProcessor
    {
        List<char> encodedString = new List<char>();
        List<char> numberList = new List<char>();

        private void checkNumberList()
        {
            if (numberList.Count > 0)
            {
                if (numberList.Count > 1)
                {
                    numberList.Reverse();
                    encodedString.AddRange(numberList);
                }

                numberList.Clear();
            }
        }

        public string Encode(string message)
        {
            List<char> messageCharacterList = message.ToLower().Select(c => c).ToList();
            var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };

            foreach (char c in messageCharacterList)
            {
                // Checking for Alphabet 
                if (c >= 97 && c <= 122)
                {
                    checkNumberList();
                    var i = vowels.IndexOf(c);
                    if(c == 'y')
                    {
                        encodedString.Add(' ');
                    }
                    else
                    {
                        if (i < 0)
                        {
                            encodedString.Add((char)(c - 1));
                        }
                        else
                        {
                            encodedString.Add((char)(i + 49));
                        }
                    }
                }

                // Checking for Digits 
                else if (c >= 48 && c <= 57)
                {
                    numberList.Add(c);
                }

                // Otherwise Special Character 
                else
                {
                    checkNumberList();
                    if (c == 32)
                    {
                        encodedString.Add('y');
                    }
                    else
                    {
                        encodedString.Add(c);
                    }
                }
            }

            if (numberList.Count > 0)
            {
                checkNumberList();
            }

            return new string(encodedString.ToArray());
        }
    }
}