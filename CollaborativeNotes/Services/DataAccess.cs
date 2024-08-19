using CollaborativeNotes.Helpers;
using CollaborativeNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CollaborativeNotes.Services
{
    public class DataAccess : IDataAccess
    {
        public Theme myTheme { get; set; }
        public DataAccess()
        {
            Console.WriteLine("Constructor of DataAccess Called");

            MyColors myColors = new MyColors();

            SolidColorBrush[] colours = new SolidColorBrush[Theme.themesSize];
            colours[(int)Theme.ColoursIndices.IconC] = new SolidColorBrush(MyColors.tinacious_pink);
            colours[(int)Theme.ColoursIndices.FadedIconC] = new SolidColorBrush(MyColors.tinacious_lightPink);
            colours[(int)Theme.ColoursIndices.PrimaryBgC] = new SolidColorBrush(MyColors.tinacious_primaryBackground);
            colours[(int)Theme.ColoursIndices.SecondaryBgC] = new SolidColorBrush(MyColors.tinacious_secondaryBackground);
            colours[(int)Theme.ColoursIndices.TertiaryBgC] = new SolidColorBrush(MyColors.tinacious_pink);
            colours[(int)Theme.ColoursIndices.ForthBgC] = new SolidColorBrush(MyColors.tinacious_tertiaryBackground);
            colours[(int)Theme.ColoursIndices.PrimaryFontC] = new SolidColorBrush(MyColors.fullBlack);
            colours[(int)Theme.ColoursIndices.SecondaryFontC] = new SolidColorBrush(MyColors.fullWhite);
            myTheme = new Theme(colours);
        }

        public Theme ColorTheme()
        {
            throw new NotImplementedException();
        }

        public string GetFileName()
        {
            return "File name";
        }
    }
}
