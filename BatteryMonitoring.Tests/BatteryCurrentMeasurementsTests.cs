using Xunit;
using System.Collections.Generic;
namespace BatteryMonitoring.Tests
{
    public class BatteryCurrentMeasurementsTests
    {
        BatteryCurrentMeasurements currentMonitoring = new BatteryCurrentMeasurements();
        [Fact]
        public void GivenEmptyList_WhenListIsEmpty_TrueIsReturned()
        {
            List<int> emptyReadingsList = new List<int>();
            bool actualResult = currentMonitoring.IsReadingsListEmpty(emptyReadingsList);
            Assert.True(actualResult);
        }
        [Fact]
        public void GivenReadingsList_WhenListHaveValues_FalseIsReturned()
        {
            List<int> readingsListWithValues = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            bool actualResult = currentMonitoring.IsReadingsListEmpty(readingsListWithValues);
            Assert.False(actualResult);
        }
        [Fact]
        public void GivenReadingsList_WhenListDoesntHaveEnoughValues_FalseIsReturned()
        {
            List<int> readingsList = new List<int>() { 3 };
            bool actualResult = currentMonitoring.AreValuesEnoughToMeasure(readingsList);
            Assert.False(actualResult);
        }
        [Fact]
        public void GivenReadingsList_WhenListHasEnoughValues_TrueIsReturned()
        {
            List<int> readingsList = new List<int>() { 3, 3 };
            bool actualResult = currentMonitoring.AreValuesEnoughToMeasure(readingsList);
            Assert.True(actualResult);
        }
        [Fact]
        public void GivenReadingsList_WhenListHasCurrentRanges_CompareActualAndExpectedMatches()
        {
            Dictionary<string, int> expectedRangeList = new Dictionary<string, int>();
            expectedRangeList.Add("3-5", 4);
            expectedRangeList.Add("10-12", 3);
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            Dictionary<string, int> actualRangeList = currentMonitoring.GetReadingRangesFromGivenList(currentReadingsList);
            Assert.Equal(actualRangeList, expectedRangeList);
        }
        [Fact]
        public void GivenReadingsList_WhenListHasCurrentRanges_CompareActualAndExpectedMisMatch()
        {
            Dictionary<string, int> expectedRangeList = new Dictionary<string, int>();
            expectedRangeList.Add("3-5", 4);
            expectedRangeList.Add("10-12", 5);
            List<int> currentReadingsList = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            Dictionary<string, int> actualRangeList = currentMonitoring.GetReadingRangesFromGivenList(currentReadingsList);
            Assert.NotEqual(actualRangeList, expectedRangeList);
        }
        [Fact]
        public void GivenReadingList_WhenListIsEmpty_FalseIsReturned()
        {
            List<int> emptyReadingsList = new List<int>();
            Dictionary<string, int> actualRangeList = currentMonitoring.GetReadingRangesFromGivenList(emptyReadingsList);
            Assert.False(actualRangeList.Count > 0);
        }
    }
}