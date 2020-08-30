
using System;

namespace DDD.Domain.Entities
{
    public sealed class WeatherEntity
    {
        //完全コンストラクタパターン
        public WeatherEntity(int areaId,
                            DateTime dataDate,
                            int condition,
                            float temperaturee)
        {
            AreaID = areaId;
            DataDate = dataDate;
            Condition = condition;
            Temperature = temperaturee;
        }

        public int AreaID { get;  }
        public DateTime DataDate { get; }
        public int Condition { get; }
        public float Temperature { get; }

        public bool IsOK()
        {
            if (DataDate < DateTime.Now.AddMonths(-1))
            {
                if(Temperature < 10)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
