using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Result.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
