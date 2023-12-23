using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parameters
{
    public class RequestParameters
    {
        public int Number { get; set; }
        public int Size { get; set; }

        public RequestParameters()
        {
            this.Number = 1;
            this.Size = 10;
        }

        public RequestParameters(int number, int size)
        {
            this.Number = number < 1 ? 1 : number;
            this.Size = size > 10 ? 10 : size;
        }
    }
}
