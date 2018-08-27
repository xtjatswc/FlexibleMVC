using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexibleMVC.IServer
{
    public interface IOperation
    {
        int Operate(int left, int right);
    }
}
