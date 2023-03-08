using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; } = true;
        public object Result { get; set; } = null;
        public string ErrorMessage { get; set; } =null;
    }
}