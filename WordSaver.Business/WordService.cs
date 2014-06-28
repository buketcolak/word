using System;
using WordSaver.Business.Data;

namespace WordSaver.Business
{
    public class WordService : IWordService
    {
        private readonly IRepository<Word> _wordRepository;

        public WordService(IRepository<Word> wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public bool Save(string word)
        {
            var entity = new Word
            {
                Name = word,
                CreatedAt = DateTime.Now
            };

            _wordRepository.Create(entity);

            return _wordRepository.SaveChanges();
        }
    }
}