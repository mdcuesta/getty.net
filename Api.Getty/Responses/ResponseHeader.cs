﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Getty.Exceptions;

namespace Api.Getty.Responses
{
    class ResponseHeader
    {
        public string Status { get; set; }

        public List<StatusEntry> StatusList { get; set; }

        public string CoordinationId { get; set; }

        public ResponseErrorException ToResponseErrorException()
        {
            return new ResponseErrorException 
            { 
                Status = Status,
                CoordinationId = CoordinationId,
                StatusList = StatusList
            };
        }
    }
}
