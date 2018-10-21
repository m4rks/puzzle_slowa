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
                new Satz {Idnum = 1, Belohnung = "asdf", Bild = "asdf", SatzMitSemikolon = "asdf;zxcv;cvbn;zzzz"},
                new Satz {Idnum = 2, Belohnung = "asdf", Bild = "asdf", SatzMitSemikolon = "asdf;asdf;asdf"},

            };


        }

        public Satz Get(int id)
        {
            return satze.SingleOrDefault(s => s.Idnum == id);
        }

    }
}
