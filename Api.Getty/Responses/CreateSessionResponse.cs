using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Getty.Responses
{
    class CreateSessionResponse : IGettyResponse
    {
        public ResponseHeader ResponseHeader { get; set; }

        public CreateSessionResult CreateSessionResult { get; set; }
    }
}
