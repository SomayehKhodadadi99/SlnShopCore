using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOGeneral
{
    public class BaseDto<T>
    {

        public BaseDto(T _Data, bool _IsSuccess, List<string> _Message)
        {
            this.Data = _Data;
            this.IsSuccess = _IsSuccess;    
            this.Message = _Message;
        }
        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public List<string> Message { get; set; }

    }


    public class BaseDto
    {

        public BaseDto( bool _IsSuccess, List<string> _Message)
        {
            this.IsSuccess = _IsSuccess;
            this.Message = _Message;
        }
      
        public bool IsSuccess { get; set; }

        public List<string> Message { get; set; }

    }
}
