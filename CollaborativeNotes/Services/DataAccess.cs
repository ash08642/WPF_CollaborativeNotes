using CollaborativeNotes.Helpers;
using CollaborativeNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CollaborativeNotes.Services
{
    public class DataAccess : IDataAccess
    {
        public Theme myTheme { get; set; }
        public DataAccess()
        {
            MessageBox.Show("Constructor of DataAccess Called");

            MyColors myColors = new MyColors();

            SolidColorBrush[] colours = new SolidColorBrush[Theme.themesSize];
            colours[(int)Theme.ColoursIndices.IconActiveForeground] = new SolidColorBrush(MyColors.tinacious_pink);
            colours[(int)Theme.ColoursIndices.IconInactiveForeground] = new SolidColorBrush(MyColors.tinacious_lightPink);
            colours[(int)Theme.ColoursIndices.DashboardIconBackground] = new SolidColorBrush(MyColors.tinacious_secondaryBackground);
            colours[(int)Theme.ColoursIndices.Border] = new SolidColorBrush(MyColors.tinacious_pink);
            colours[(int)Theme.ColoursIndices.PrimaryBackground] = new SolidColorBrush(MyColors.tinacious_primaryBackground);
            colours[(int)Theme.ColoursIndices.SecondaryBackground] = new SolidColorBrush(MyColors.tinacious_secondaryBackground);
            colours[(int)Theme.ColoursIndices.TertiaryBackground] = new SolidColorBrush(MyColors.tinacious_pink);
            colours[(int)Theme.ColoursIndices.ForthBackground] = new SolidColorBrush(MyColors.tinacious_tertiaryBackground);
            colours[(int)Theme.ColoursIndices.PrimaryFont] = new SolidColorBrush(MyColors.fullBlack);
            colours[(int)Theme.ColoursIndices.SecondaryFont] = new SolidColorBrush(MyColors.tinacious_pink);
            colours[(int)Theme.ColoursIndices.TertiaryFont] = new SolidColorBrush(MyColors.tinacious_pink);
            colours[(int)Theme.ColoursIndices.FileTree] = new SolidColorBrush(MyColors.fullWhite);
            colours[(int)Theme.ColoursIndices.CloseIcon] = new SolidColorBrush(MyColors.fullWhite);
            colours[(int)Theme.ColoursIndices.MaxMinIcon] = new SolidColorBrush(MyColors.fullWhite);
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
