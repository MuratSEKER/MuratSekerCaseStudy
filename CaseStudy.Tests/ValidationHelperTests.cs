using MuratSekerCaseStudy.Helpers;
using Xunit;

namespace CaseStudy.Tests
{
    public class ValidationHelperTests
    {
        [Fact]
        public void IsUrlValid()
        {
            string url1 = "http://abc.com";
            string url2 = "https://murat.com";
            string url3 = "http://mur�♥.co";
            string url4 = "//abc.com";

            bool res1 = ValidationHelper.IsUrlValid(url1);
            bool res2 = ValidationHelper.IsUrlValid(url2);
            bool res3 = ValidationHelper.IsUrlValid(url3);
            bool res4 = ValidationHelper.IsUrlValid(url4);

            Assert.True(res1);
            Assert.True(res2);
            Assert.True(res3);
            Assert.False(res4);

        }

        [Fact]
        public void IsNameInUtfSet()
        {
            var name1 = "sdkdsflkdfsşsdf +-*/* ";
            var name2 = "://mur�♥.co";
            var name3 = "__-ŞĞÜökodfı";

            var res1 = ValidationHelper.IsNameInUtfSet(name1);
            var res2 = ValidationHelper.IsNameInUtfSet(name2);
            var res3 = ValidationHelper.IsNameInUtfSet(name3);

            Assert.True(res1);
            Assert.False(res2);
            Assert.True(res3);
        }
    }
}
