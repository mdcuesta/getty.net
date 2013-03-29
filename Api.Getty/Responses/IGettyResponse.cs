using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Getty.Responses
{
    interface IGettyResponse
    {
        ResponseHeader ResponseHeader { get; set; }
    }
}
