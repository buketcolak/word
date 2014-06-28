using NUnit.Framework;

using WordSaver.Business;
using WordSaver.Business.Data;

namespace WordSaver.Tests
{
    [TestFixture]
    public class DomainDesignTests
    {
        [Test]
        public void visitor_should_save_a_word()
        {
            var repository = new Repository<Word>();

            var service = new WordService(repository);
            const string word = "Kelime";
            var isSaved = service.Save(word);

            Assert.IsTrue(isSaved);
        }
    }
}
