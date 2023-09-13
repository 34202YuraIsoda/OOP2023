using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework.Models {
    public class Book {
        public int Id { get; set; } //主キー
        [Required]
        public string Title { get; set; } //本のタイトル
        public int PublishedYear { get; set; } //発行年
        public virtual Author Author { get; set; } //著者
    }
}
