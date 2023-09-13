using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SampleEntityFramework.Models {
    public class Author {
        public int Id { get; set; } //主キー
        [MaxLength(30)]
        [Required]
        public string Name { get; set; } //著者名
        public DateTime Birthday { get; set; } //誕生日
        public string Gender { get; set; } //性別
        public virtual ICollection<Book> Books { get; set; } //本
    }
}
