using System.Collections.Generic;

namespace GEM_Code_V3
{
    public class HyperPole
    {
        List<Entrant> Entrants = new List<Entrant>();

        public void AddCar(Entrant E)
        {
            Entrants.Add(E);
        }

        public Entrant GetEntrant(int I)
        {
            return Entrants[I];
        }

        public int GetLength()
        {
            return Entrants.Count;
        }

        public void Sort()
        {
            for (int i = 0; i < Entrants.Count - 1; i++)
            {
                bool Swap = false;

                for (int j = 0; j < Entrants.Count - i - 1; j++)
                {
                    if (Entrants[j].GetOVR() < Entrants[j + 1].GetOVR())
                    {
                        Swap = true;

                        (Entrants[j], Entrants[j + 1]) = (Entrants[j + 1], Entrants[j]);
                    }

                    else if (Entrants[j].GetOVR() == Entrants[j + 1].GetOVR())
                    {
                        if (Entrants[j].GetOVR() == 1)
                        {
                            continue;
                        }

                        else if (Entrants[j].GetLastStint() < Entrants[j + 1].GetLastStint())
                        {
                            Swap = true;

                            (Entrants[j], Entrants[j + 1]) = (Entrants[j + 1], Entrants[j]);
                        }
                    }
                }

                if (!Swap)
                {
                    break;
                }
            }
        }
    }
}
