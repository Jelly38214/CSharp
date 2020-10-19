using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanzhouBeefNoodles.Models
{
    public interface IFeedbackRepository
    {

        // 返回类型为Feedback的列表
        IEnumerable<Feedback> GetAllFeedbacks();
    }
}