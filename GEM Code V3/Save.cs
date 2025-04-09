using System;
using System.Collections.Generic;
using System.IO;

namespace GEM_Code_V3
{
    public class Save
    {
        public static void SaveStint(List<Entrant> EntryList, CommonData CD, string Session, string RoundName, bool T)
        {
            string FilePath = Path.Combine(CD.GetSavePath(), Session + ".csv");

            string SaveString = "";

            List<int> Positions = new List<int>();

            for (int P = 0; P < CD.GetClassCount(); P++)
            {
                Positions.Add(0);
            }

            string CP = "";
            int Rows = CD.GetRows();

            for (int E = 0; E < EntryList.Count; E++)
            {
                if (EntryList[E].GetOVR() == 1)
                {
                    CP = "DNF";
                }

                else if (EntryList[E].GetInGarage() && Session != "Race Results")
                {
                    CP = "GAR";

                    int CI = EntryList[E].GetClassIndex();
                    Positions[CI]++;
                }

                else if (EntryList[E].GetOVR() == 100 && EntryList[E].GetInGarage())
                {
                    CP = "NC";
                }

                else
                {
                    int CI = EntryList[E].GetClassIndex();

                    Positions[CI]++;
                    CP = "P" + Positions[CI];
                }

                SaveString += EntryList[E].GetClass() + "," + CP + "," + EntryList[E].GetCarAsWriteString() + ",," + Convert.ToString(EntryList[E].GetInGarage()) + ",," + Convert.ToString(EntryList[E].GetStintsInGarage()) + "," + Convert.ToString(EntryList[E].GetTotalStintsInGarage()) + ",," + Convert.ToString(EntryList[E].GetTotalStops());

                if (E != EntryList.Count - 1)
                {
                    SaveString += Environment.NewLine;
                }

                if ((E + 1) % Rows == 0)
                {
                    SaveString += Environment.NewLine;
                }
            }

            WriteFile(FilePath, SaveString);
        }

        public static void WriteFile(string FilePath, string SaveString)
        {
            try
            {
                File.WriteAllText(FilePath, SaveString);
            }

            catch
            {
                CalendarEditor.UseMessageBox("Please Close File '" + FilePath + "'.", "File Open Error");
                WriteFile(FilePath, SaveString);
            }
        }
    }
}
