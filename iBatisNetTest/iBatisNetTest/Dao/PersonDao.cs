﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iBatisNetTest.Domain;
using IBatisNet.DataMapper;

namespace iBatisNetTest.Dao
{
    public class PersonDao
    {
        public IList<Person> GetList()
        {
            ISqlMapper mapper = Mapper.Instance();
            IList<Person> ListPerson = mapper.QueryForList<Person>("Ibatis.SelectAllPerson", null);  //这个"SelectAllPerson"就是xml映射文件的Id
            return ListPerson;
        }

        public void AddPerson(Person person)
        {
            ISqlMapper mapper = Mapper.Instance();
            mapper.Insert("Ibatis.InsertPerson", person);
            //return i;
        }
    }
}