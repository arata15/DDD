using DDD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Helpers
{
    public static class Guard
    {
        public static void IsNull(object o,string message)
        {
            if(o == null)
            {
                throw new InputException(message);
            }
        }

        public static float IsFloat(string text,string message)
        {
            float floatValue;
            if (!float.TryParse(text, out floatValue))
            {
                throw new InputException("温度の入力に誤りがあります");
            }

            return floatValue;
        }
    }
}
