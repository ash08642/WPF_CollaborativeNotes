using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaborativeNotes.Helpers
{
    public class MyColors
    {
        public static Color fullBlack = new Color();
        public static Color fullWhite = new Color();

        public static Color tinacious_pink = new Color();
        public static Color tinacious_lightPink = new Color();
        public static Color tinacious_primaryBackground = new Color();
        public static Color tinacious_secondaryBackground = new Color();
        public static Color tinacious_tertiaryBackground = new Color();

        public MyColors() {
            fullBlack.A = 255;
            fullBlack.R = 0;
            fullBlack.G = 0;
            fullBlack.B = 0;

            fullWhite.A = 255;
            fullWhite.R = 255;
            fullWhite.G = 255;
            fullWhite.B = 255;

            tinacious_pink.A = 255;
            tinacious_pink.R = 255;
            tinacious_pink.G = 51;
            tinacious_pink.B = 153;

            tinacious_lightPink.A = 102;
            tinacious_lightPink.R = 255;
            tinacious_lightPink.G = 51;
            tinacious_lightPink.B = 153;

            tinacious_primaryBackground.A = 255;
            tinacious_primaryBackground.R = 248;
            tinacious_primaryBackground.G = 248;
            tinacious_primaryBackground.B = 255;

            tinacious_secondaryBackground.A = 102;
            tinacious_secondaryBackground.R = 219;
            tinacious_secondaryBackground.G = 218;
            tinacious_secondaryBackground.B = 255;

            tinacious_tertiaryBackground.A = 255;
            tinacious_tertiaryBackground.R = 68;
            tinacious_tertiaryBackground.G = 66;
            tinacious_tertiaryBackground.B = 94;
        }
    }
}
