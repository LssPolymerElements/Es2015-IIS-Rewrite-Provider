using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ES5File()
        {
            //Arrange
            var input = "FILE,|Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; Touch; rv:11.0) like Gecko,|a=123&b=1222,|/images/test.html";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es5/images/test.html?a=123&b=1222", result);
        }

        [TestMethod]
        public void ES5Index()
        {
            //Arrange
            var input = "INDEX,|Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; Touch; rv:11.0) like Gecko,|a=123&b=1222,|/search";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string>{ { "Delimiter", ",|"}}, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es5/?a=123&b=1222", result);
        }

        [TestMethod]
        public void ES6File()
        {
            //Arrange
            var input = "FILE,|Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36,|,|/images/leavitt_group_logo.png";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es6/images/leavitt_group_logo.png", result);
        }

        [TestMethod]
        public void ES6Index()
        {
            //Arrange
            var input = "INDEX,|Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36,|,|/search/asss";
            var provider = new Polymer2RewriteProvider5.Polymer2RewriteProvider4();
            provider.Initialize(new Dictionary<string, string> { { "Delimiter", ",|" } }, null);

            //Act
            var result = provider.Rewrite(input);

            //Assert
            Assert.AreEqual("es6/", result);
        }
    }
}
