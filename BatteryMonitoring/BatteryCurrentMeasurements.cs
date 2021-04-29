using System.Collections.Generic;
using System.Linq;
namespace BatteryMonitoring
{
    public class BatteryCurrentMeasurements
    {
        public bool IsReadingsListEmpty(List<int> readingList)
        {
            if (readingList == null || readingList.Count == 0)
                return true;
            return false;
        }
        public Dictionary<string, int> GetEvaluatedReadingRangesFromGivenList(List<int> readingsList)
        {
            Dictionary<string, int> readingsWithRanges = new Dictionary<string, int>();
            if (!IsReadingsListEmpty(readingsList))
                readingsWithRanges = EvaluateReadingRanges(readingsList);
            return readingsWithRanges;
        }
        private Dictionary<string, int> EvaluateReadingRanges(List<int> readingList)
        {
            Dictionary<string, int> readingsWithRanges = new Dictionary<string, int>();
            readingList.Sort();
            int firstReading = readingList[0];
            int lastReading = readingList[0];
            int currentReading = readingList[0];
            int counter = 1;
            for (int i = 1; i < readingList.Count(); i++)
            {
                if (currentReading == readingList[i] || currentReading + 1 == readingList[i])
                {
                    currentReading = lastReading = readingList[i];
                    counter++;
                }
                else
                {
                    readingsWithRanges.Add(firstReading + "-" + lastReading, counter);
                    currentReading = lastReading = firstReading = readingList[i];
                    counter = 1;
                }
            }
            readingsWithRanges.Add(firstReading + "-" + lastReading, counter);
            return readingsWithRanges;
        }
    }
}
