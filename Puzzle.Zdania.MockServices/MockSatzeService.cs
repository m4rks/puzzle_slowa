using System;
using System.Collections.Generic;
using System.Linq;
using Puzzle.Zdania.Model;
using Puzzle.Zdania.IServices;

namespace Puzzle.Zdania.MockServices
{
    public class MockSatzeService : ISatzeService
    {

        private IList<Satz> satze;

        public MockSatzeService()
        {
            satze = new List<Satz>
            {
                new Satz {Idnum = 1, Belohnung = "Co robi Gabryś?", Bild = "gabrys-architekt.jpg", SatzMitSemikolon = "Pokazuje swoj dom;Liczy na kalkulatorze;Pisze;Biega"},
                new Satz {Idnum = 2, Belohnung = "Co robi mis?", Bild = "mis ksiezyc spi.jpg", SatzMitSemikolon = "śpi;śpiewa;pływa"},
                new Satz {Idnum = 3, Belohnung = "Co robi mis?", Bild = "mis ksiezyc spi.jpg", SatzMitSemikolon = "śpi;śpiewa;pływa"},
                new Satz {Idnum = 4, Belohnung = "Co robi mis?", Bild = "mis ksiezyc spi.jpg", SatzMitSemikolon = "śpi;śpiewa;pływa"},

            };


        }

        public Satz Get(int id)
        {
            return satze.SingleOrDefault(s => s.Idnum == id);
        }

    }
}
