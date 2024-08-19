using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CollaborativeNotes.Models
{
    public class Theme
    {
        public enum ColoursIndices
        {
            IconC,
            FadedIconC,
            PrimaryBgC,
            SecondaryBgC,
            TertiaryBgC,
            ForthBgC,
            PrimaryFontC,
            SecondaryFontC,
            TertiaryFontC
        }

        public static int themesSize = 9;

        public IList<SolidColorBrush> myColors {  get; set; }

        public Theme(SolidColorBrush[] colors) 
        {
            Console.WriteLine("Constructor of Theme Called");
            myColors = new ObservableCollection<SolidColorBrush>(new SolidColorBrush[themesSize]);
            for (int i = 0; i < colors.Length; i++)
            {
                myColors[i] = colors[i];
            }
        }
    }
}
