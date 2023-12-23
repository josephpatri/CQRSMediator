using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int Number { get; set; }
        public int Size { get; set; }

        public PagedResponse(T data, int pNumber, int pSize) 
        { 
            Number = pNumber;
            Size = pSize;
            this.Data = data;
            this.Message = null;
            this.Succeded = true;
            this.Errors = null;
        }
    }
}
