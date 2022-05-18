using System;
using System.Collections.Generic;
using System.Text;

namespace P324_Reflection_Exception
{
    class StudentAgeOutOfRangeException:Exception
    {
        //string _message;
        //public override string Message => _message;

        public StudentAgeOutOfRangeException(string message="18 yashdan ashagidir"):base(message)
        {
            //_message = message;
        }
    }
}
