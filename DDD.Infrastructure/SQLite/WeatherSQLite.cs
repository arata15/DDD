﻿using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public class WeatherSQLite : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            string sql = @"
            select DataDate,
                   Condition,
                   Tempereture
            from Weather
            where AreaId = @AreaId
            order by DataDate desc
            LIMIT 1
            ";

            return SQLiteHelper.QuerySingle(
                sql,
                new List<SQLiteParameter>
                {
                    new SQLiteParameter("@AreaId",areaId)
                }.ToArray(),
                reader =>
                {
                    return new WeatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Tempereture"]));
                },
                null);
        }
        public IReadOnlyList<WeatherEntity> GetData()
        {
            string sql = @"
            select A.AreaId,
            ifnull(B.AreaName,'') as AreaName,
            A.DataDate,
            A.Condition,
            A.Tempereture
            from Weather A
            left outer join Areas B
            on A.AreaId = B.AreaId
            ";

            return SQLiteHelper.Query(sql,
                reader =>
                {
                    return new WeatherEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToString(reader["AreaName"]),
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Tempereture"])); ;
                });
        }

        public void Save(WeatherEntity weather)
        {
            string insert = @"
            insert into Weather
            (AreaId,DataDate,Condition,Tempereture)
            values
            (@AreaId,@DataDate,@Condition,@Tempereture)
            ";

            string update = @"
            update Weather
            set Condition = @Condition,
                Tempereture = @Tempereture
            where AreaId = @AreaId
            and DataDate = @DataDate
            ";

            var args = new List<SQLiteParameter>
            {
                new SQLiteParameter("@AreaId",weather.AreaID.Value),
                new SQLiteParameter("@DataDate",weather.DataDate),
                new SQLiteParameter("@Condition",weather.Condition.Value),
                new SQLiteParameter("@Tempereture",weather.Temperature.Value)
            };

            SQLiteHelper.Execute(insert, update, args.ToArray());
        }
    }
}
