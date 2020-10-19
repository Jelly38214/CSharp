using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanzhouBeefNoodles.Models
{
    public class MockFeedbackRepository : IFeedbackRepository
    {
        private List<Feedback> _feedbacks;
        public MockFeedbackRepository()
        {
            if (_feedbacks == null)
            {
                InitializeFeedback();
            }
        }

        private void InitializeFeedback()

        {
            _feedbacks = new List<Feedback> {
                new Feedback {Id = 1, Name="Jelly1", Email="Jelly1@hotmail.com", CreateDateUTC=new DateTime()},
                new Feedback {Id = 2, Name="Jelly2", Email="Jelly2@hotmail.com", CreateDateUTC=new DateTime()},
                new Feedback {Id = 3, Name="Jelly3", Email="Jelly3@hotmail.com", CreateDateUTC=new DateTime()},
                new Feedback {Id = 4, Name="Jelly4", Email="Jelly4@hotmail.com", CreateDateUTC=new DateTime()}
            };
        }

        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            return _feedbacks;
        }
    }
}
