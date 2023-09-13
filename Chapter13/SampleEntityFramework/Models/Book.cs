using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework.Models {
    public class Book {
        public int Id { get; set; } //主キー
        public string Title { get; set; } //本のタイトル
        public int PublishedYear { get; set; } //出版年
        public virtual Author Author { get; set; } //著者
    }
}
