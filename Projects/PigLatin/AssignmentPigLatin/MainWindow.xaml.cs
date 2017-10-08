/**
 * Main Window class for PigLatin
 * 3/25/14
 * @author Camille Rasmussen
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssignmentPigLatin
{
    public partial class MainWindow : Window
    {
        string originalSentence;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void translateButton_Click(object sender, RoutedEventArgs e)
        {
            originalSentence = OriginalTb.Text;
            string pattern = @"\w+";
            MatchEvaluator evaluator = new MatchEvaluator(PigLatin);
            PigLatinTb.Text = Regex.Replace(originalSentence, pattern, evaluator);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            OriginalTb.Text = "";
            PigLatinTb.Text = "";
        }

        private string PigLatin(Match match)
        {
            String word = match.Value;
            if ("aeiouAEIOU".IndexOf(word[0]) >= 0)
                return VowelAtBeginning(word);
            else
                for (int i = 1; i < word.Length; i++)
                {
                    if ("aeiouyAEIOUY".IndexOf(word[i]) >= 0)
                    {
                        return VowelInMiddle(word, i);
                    }
                }
           return NoVowels(word);
        }

        private String NoVowels(String word)
        {
            return word + "ay";
        }

        private String VowelInMiddle(String word, int indexOfVowel)
        {
            if (Char.IsUpper(word[0]))
            {
                char[] letters = word.ToCharArray();
                letters[0] = Char.ToLower(letters[0]);
                letters[indexOfVowel] = Char.ToUpper(word[indexOfVowel]);
                word = new String(letters);
            }
            String ending = word.Substring(0, indexOfVowel);
            word = word.Remove(0, indexOfVowel);
            word = word + ending + "ay";
            return word;
        }

        private String VowelAtBeginning(String word)
        {
            return word + "way";
        }
    }
}
