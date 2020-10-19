using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanzhouBeefNoodles.Models
{
    public class MockNoodleRepository : INoodleRepository
    {

        private List<Noodle> _noodles;


        // 和类名称一样的函数是其构造函数
        public MockNoodleRepository()
        {
            if (_noodles == null)
            {
                InitializeNoodle();
            }
        }

        private void InitializeNoodle()
        {
            _noodles = new List<Noodle> {
                new Noodle {Id = 1, Name ="毛细", Price=12, ShortDescription ="毛细简介", LongDescription="毛细详情", ImageUrl=""},
                new Noodle {Id = 2, Name ="细", Price=10, ShortDescription ="细简介", LongDescription="细详情", ImageUrl=""},
                new Noodle {Id = 3, Name ="三细", Price=11, ShortDescription ="三细简介", LongDescription="三细详情", ImageUrl=""},
                new Noodle {Id = 4, Name ="二细", Price=10, ShortDescription ="二细简介", LongDescription="二细详情", ImageUrl=""},
                new Noodle {Id = 5, Name ="二柱子", Price=11, ShortDescription ="二柱子简介", LongDescription="二柱子详情", ImageUrl=""},
                new Noodle {Id = 6, Name ="韭叶子", Price=12, ShortDescription ="韭叶子简介", LongDescription="韭叶子详情", ImageUrl=""},
                new Noodle {Id = 7, Name ="薄宽", Price=11, ShortDescription ="薄宽简介", LongDescription="薄宽详情", ImageUrl=""},
                new Noodle {Id = 8, Name ="大宽", Price=10, ShortDescription ="大宽简介", LongDescription="大宽详情", ImageUrl=""},
                new Noodle {Id = 9, Name ="荞麦棱子", Price=15, ShortDescription ="荞麦棱子简介", LongDescription="荞麦棱子详情", ImageUrl=""},
                new Noodle {Id = 10, Name ="一窝丝", Price=15, ShortDescription ="一窝丝简介", LongDescription="一窝丝详情", ImageUrl=""},
            };
        }

        public IEnumerable<Noodle> GetAllNoodles()
        {
            return _noodles;
        }

        public Noodle GetNoodleById(int id)
        {
            // 找到第一个和id一样的Noodle，找不到则返回null
            return _noodles.FirstOrDefault(n => n.Id == id);
            throw new NotImplementedException();
        }
    }
}