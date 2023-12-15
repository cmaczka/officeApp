using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetChallenge.Dto
{
    public class RequestDto<T>
    {
        [Required]
        public T Data { get; set; }
    }
}
