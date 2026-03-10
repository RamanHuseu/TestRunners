namespace EHU.NUnit.Tests
{
    public static class TestData
    {
       
        public static IEnumerable<TestCaseData> SearchQueries()
        {
            yield return new TestCaseData("study programs")
                .SetName("Search_StudyPrograms");
            yield return new TestCaseData("admission")
                .SetName("Search_Admission");
            yield return new TestCaseData("research")
                .SetName("Search_Research");
        }

       
        public static IEnumerable<TestCaseData> NavigationLinks()
        {
            yield return new TestCaseData("About", "/about/", "About")
                .SetName("Nav_About");
            yield return new TestCaseData("Admissions", "/admissions/", "Admissions")
                .SetName("Nav_Admissions");
        }
    }
}