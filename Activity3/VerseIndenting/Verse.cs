using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerseIndenting
{
    // Data class to hold the label and text of a verse
    class Verse
    {
        public string Label { get; set; }
        public string Text { get; set; }

        public Verse(string label, string text) 
        {
            Label = label;
            Text = text;
        }
    }
}
