using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistration.Models;

namespace StudentRegistration.Services
{
    public class ValidationChecker
    {
        public bool HasValueInObject(Object objData)
        {
            if (objData != null)
            {
                return true;
            }

            return false;
        }

        public bool HasObjectInArray<T>(ICollection<T> dataList)
        {
            if (dataList.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}